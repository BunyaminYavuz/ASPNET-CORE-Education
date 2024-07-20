namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = String.Empty;

        public ICollection<Product> Products { get; set; }  // Navigation properties collection
    }
}