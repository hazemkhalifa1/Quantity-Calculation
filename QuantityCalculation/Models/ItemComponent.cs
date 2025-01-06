namespace QuantityCalculation.Models
{
    public class ItemComponent
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}
