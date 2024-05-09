using Headphones.Domain.Base;

namespace Headphones.Domain.Entity
{
    public class Headphone : BaseEntity
    {

        public Headphone(
            int id,
            string name, 
            string manufacturer, 
            string description, 
            string color, 
            double price, 
            string imageFileName, 
            string type, 
            bool wireless, 
            string batteryLife, 
            string noiseCancellationType, 
            string weight, 
            bool mic)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            Color = color;
            Price = price;
            ImageFileName = imageFileName;
            Type = type;
            Wireless = wireless;
            BatteryLife = batteryLife;
            NoiseCancellationType = noiseCancellationType;
            Weight = weight;
            Mic = mic;
        }
        /*Price*/
        public void UpdatePrice(double price)
        {
            this.Price = price;
        }

        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public string Description { get; private set; }
        public string Color { get; private set; }
        public double Price { get; private set; }
        public string ImageFileName { get; private set; }
        public string Type { get; private set; }
        public bool Wireless { get; private set; }
        public string BatteryLife { get; private set; }
        public string NoiseCancellationType { get; set; }
        public string Weight { get; private set; }
        public bool Mic { get; private set; }
    }
}
