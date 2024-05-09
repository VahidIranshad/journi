using Headphones.Application.Contracts;
using Headphones.Application.Exceptions;
using Headphones.Domain.Base;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Headphones.Persistence.Repositories
{
    public class GenericRepositoryForJson<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppSettings _appSettings;
        public GenericRepositoryForJson(IOptions<AppSettings> appSettings)
        {

            _appSettings = appSettings.Value;

        }
        public async Task<T> Add(T entity)
        {
            var list = await GetAll();
            int id = 1;
            if (list.Any())
            {
                id = list.Max(p => p.Id) + 1;
            }
            entity.Id = id;
            list.Add(entity);
            Rewrite(list);
            return entity;

        }

        public async Task Delete(int id)
        {
            var list = await GetAll();

            var old = list.Where(p => p.Id == id).FirstOrDefault();
            if (old == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }
            list.Remove(old);
            Rewrite(list);
        }

        public async Task<T> Get(int id)
        {
            var list = await GetAll();
            return list.Where(p => p.Id == id).First();
        }

        public async Task<IList<T>> GetAll()
        {
            var items = new List<T>();
            using (StreamReader r = new StreamReader(_appSettings.DataAddress))
            {
                string json = await r.ReadToEndAsync();
                if (json != null)
                {
                    items = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }
            return items;

        }

        public async Task Update(T entity)
        {
            var list = await GetAll();

            var old = list.Where(p => p.Id == entity.Id).FirstOrDefault();
            if (old == null)
            {
                throw new NotFoundException(typeof(T).Name, entity.Id);
            }
            var index = list.IndexOf(old) ;
            list.RemoveAt(index) ;
            list.Insert(index, entity);
            Rewrite(list);

        }
        private void Rewrite(IList<T> values)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(values, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_appSettings.DataAddress, output);
        }
    }
}
