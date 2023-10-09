using System;
namespace Domain.Models
{
    public class SellLog
    {
        public SellLog(int cartId, int userId)
        {
            CartId = cartId;
            UserId = userId;
            SubmitDate = DateTime.UtcNow;
        }
        public int Id{ get; private set; }
        public int CartId{ get; private set; }

        public int UserId{ get; private set; }
        public DateTime SubmitDate{ get; private set; }
    }
}
