using Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(int id, string url, string faName, string enName, decimal price)
        {
            Id = id;
            Url = url;
            FaName = faName;
            EnName = enName;
            Price = price;
            //Seller = seller;
            //Images = images;
        }
        [Key]
        public int Id { get; private set; }
        public string Url { get; private set; }
        public string FaName { get; private set; }
        public string EnName { get; private set; }
        public decimal Price { get; private set; }
        //public Seller Seller { get; private set; }
        //public List<Image> Images { get; private set; }
        public ProductStatusType Status { get; private set; }

    }
    public class Seller
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        //...
    }
    public class Image
    {
        public int Id { get; private set; }
        public string Attachment { get; private set; }
    }
}
