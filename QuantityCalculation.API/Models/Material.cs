namespace QuantityCalculation.API.Models
{
    public class Material
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
