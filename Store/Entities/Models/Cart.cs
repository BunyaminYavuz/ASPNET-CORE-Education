namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(line => line.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();
            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product)
        {
            Lines.RemoveAll(line => line.Product.ProductId.Equals(product.ProductId));
        }

        public decimal ComputeTotalValue()
        {
            var totalBalance = Lines.Sum(line => line.Quantity * line.Product.Price);
            return totalBalance;
        }

        public virtual void Clear()
        {
            Lines.Clear();
        }
    }
}