namespace Headphones.Application.Dtos.HeadphonesDtos
{
    public class HeadphoneDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public double Price { get; set; }
        public string? ImageFileName { get; set; }
        public string? Type { get; set; }
        public bool Wireless { get; set; }
        public string? BatteryLife { get; set; }
        public string? NoiseCancellationType { get; set; }
        public string? Weight { get; set; }
        public bool Mic { get; set; }
    }
}
