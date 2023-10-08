using System;
namespace Domain.Models
{
    public class SellLog
    {
        public SellLog(int productId, int userId)
        {
            ProductId = productId;
            UserId = userId;
            SubmitDate = DateTime.UtcNow;
        }
        public int Id{ get; private set; }
        public int cartId{ get; private set; }

        public int UserId{ get; private set; }
        public DateTime SubmitDate{ get; private set; }
    }
}
