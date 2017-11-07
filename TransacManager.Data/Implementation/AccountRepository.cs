using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacManager.Core.Models;
using TransacManager.Data.Interfaces;
using System.Data.Entity;

namespace TransacManager.Data.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        public List<Account> GetAll()
        {
            List<Account> list;
            using (var context = new Context())
            {
                list = context.Accounts.Include(q => q.Customer).ToList();
            }

            return list;
        }
    }
}
