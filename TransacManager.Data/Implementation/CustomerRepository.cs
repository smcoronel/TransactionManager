using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacManager.Core.Models;
using TransacManager.Data.Interfaces;

namespace TransacManager.Data.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll()
        {
            List<Customer> list;
            using (var context = new Context())
            {
                list = context.Customers.ToList();
            }

            return list;
        }
    }
}
