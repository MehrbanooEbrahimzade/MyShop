using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Product
    {
        public Product(int id, string api, string faName, string enName, decimal price, Seller seller, List<Image> images)
        {
            Id = id;
            Api = api;
            FaName = faName;
            EnName = enName;
            Price = price;
            Seller = seller;
            Images = images;
        }
        public int Id { get; private set; }
        public string Api { get; private set; }
        public string FaName { get; private set; }
        public string EnName { get; private set; }
        public decimal Price { get; private set; }
        public Seller Seller { get; private set; }
        public List<Image> Images { get; private set; }
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
