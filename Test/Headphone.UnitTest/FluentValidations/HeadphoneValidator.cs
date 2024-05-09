using Headphones.Application.Dtos.HeadphonesDtos;
using Headphones.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Headphones.UnitTest.FluentValidations
{
    public class HeadphoneValidator
    {
        HeadphoneCrudDtoValidation _validator;
        public HeadphoneValidator()
        {
            _validator = new HeadphoneCrudDtoValidation();
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public async Task Applications_Validators_CreateData_ReturnsCorrectNumberOfErrors(HeadphoneCrudDto data, int numberExpectedErrors)
        {
            var validationResult = await _validator.ValidateAsync(data);
            Assert.Equal(numberExpectedErrors, validationResult.Errors.Count);
        }

        public static IEnumerable<object[]> GetData()
        {
            var allData = new List<object[]>
        {
            /*Error : With Error for Price, */
            new object[] {
                new  HeadphoneCrudDto()
            {
                Name = "name",
                Manufacturer = "manufacturer",
                Description = "description",
                Color = "color",
                Price = 0,
                ImageFileName = "imageFileName",
                Type = "type",
                Wireless = false,
                BatteryLife = "batteryLife",
                NoiseCancellationType = "noiseCancellationType",
                Weight = "weight",
                Mic = false
            }, 1},
            /*Error : without Error, */
                 new object[] {
                new  HeadphoneCrudDto()
            {
                Name = "name",
                Manufacturer = "manufacturer",
                Description = "description",
                Color = "color",
                Price = 1,
                ImageFileName = "imageFileName",
                Type = "type",
                Wireless = false,
                BatteryLife = "batteryLife",
                NoiseCancellationType = "noiseCancellationType",
                Weight = "weight",
                Mic = false
            }, 0},
        };

            return allData;
        }
    }
}
