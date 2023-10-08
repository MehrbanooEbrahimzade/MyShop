namespace Domain.Models
{
    public class CartItem
    {
        public CartItem(Product product)
        {
            Product = product;
            Amount = 1;
            TotalPrice = product.Price;
        }
        public int Id { get; private set; }
        public Product Product { get; private set; }
        public int Amount { get; private set; }
        public decimal TotalPrice { get; private set; }

        public void AddItemCount()
        {
            Amount++;
            TotalPrice += Product.Price;
        }
        //and remove
    }
}
