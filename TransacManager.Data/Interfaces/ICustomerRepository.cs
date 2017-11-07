using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacManager.Core.Models;

namespace TransacManager.Data.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
    }
}
