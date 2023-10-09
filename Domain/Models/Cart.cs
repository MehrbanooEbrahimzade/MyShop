using System;
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
        }

        public int Id { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();
        public int UserId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public CartStatusType Status { get; private set; }

        public void ChangeStatus(CartStatusType status)
        {
            Status = status;
        }
        public void AddProduct(Product product)
        {
            var exist = Products.Any(x => x.Id == product.Id);
            if (exist)
                throw new Exception("The product already added to your cart!");

            Products.Add(product);

            TotalPrice += product.Price;
        }

        public void RemoveProduct(int productId)
        {
            var product = Products.SingleOrDefault(x => x.Id == productId);

            if (product is null)
                throw new NullReferenceException("The product not found in your cart!");

            Products.Remove(product);

            TotalPrice -= product.Price;
        }
    }
}