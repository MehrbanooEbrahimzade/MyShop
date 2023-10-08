using Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Cart
    {
        public Cart(int userId)
        {
            UserId = userId;
            Status = CartStatusType.Pending;
            Items = new List<CartItem>();
        }
        public int Id { get; private set; }
        public List<CartItem> Items { get; private set; }
        public int UserId { get; private set; } //depends on our business
        public decimal TotalPrice { get; private set; }
        public CartStatusType Status { get; private set; }

        public void CalcTotalPrice()
        {
            decimal price = 0;
            Items.ForEach(x => price += x.TotalPrice);
            TotalPrice = price;
        }

        public void AddItem(CartItem cartItem)
        {
            var item = Items.Find(x => x.Id == cartItem.Id);
            if (item is not null)
            {
                item.AddItemCount();
            }
            else
            {
                Items.Add(cartItem);
            }
            CalcTotalPrice();
        }

        //and removeItem
    }
}
