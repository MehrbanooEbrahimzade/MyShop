using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum ProductStatusType
    {
        OutOfStock,
        Marketable,
        //...
    }
    public enum CartStatusType
    {
        Pending,
        Paid,
        Fulfilled
    }
}
