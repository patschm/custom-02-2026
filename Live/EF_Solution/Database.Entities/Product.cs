
namespace Database.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<ProductGroup> ProductGroups { get; set; } = new HashSet<ProductGroup>();
}
