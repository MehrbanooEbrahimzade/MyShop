using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum ProductStatusType
    {
        Available,
        Unavailable
    }
    public enum CartStatusType
    {
        Pending,
        Fulfilled,
        Sending,
        finished,
    }
}
