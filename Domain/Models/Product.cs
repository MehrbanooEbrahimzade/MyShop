using Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Product
    {
        public Product(int id, string url, string faName, string enName, decimal price)
        {
            Id = id;
            Url = url;
            FaName = faName;
            EnName = enName;
            Price = price;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; private set; }
        public string Url { get; private set; }
        public string FaName { get; private set; }
        public string EnName { get; private set; }
        public decimal Price { get; private set; }
        public ProductStatusType Status { get; private set; }
        public  int CartId { get; private set; }
    }
}
