using Domain.IRepository;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class SellLogRepository: ISellLogRepository
    {
        private readonly DatabaseContext _context;

        public SellLogRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void CreateLog(SellLog sellLog)
        {
            _context.SellLogs.Add(sellLog);
        }
    }
}
