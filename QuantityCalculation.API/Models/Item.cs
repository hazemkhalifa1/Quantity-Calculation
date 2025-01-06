namespace QuantityCalculation.API.Models
{
    public class Item
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public List<ItemComponent> Components { get; set; }
    }
}
