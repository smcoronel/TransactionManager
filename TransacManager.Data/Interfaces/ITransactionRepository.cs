using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacManager.Core.Models;

namespace TransacManager.Data.Interfaces
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAll();
        List<Transaction> GetFraudTransactions();
        List<Transaction> GetByDate(DateTime transactionDate);
        List<Transaction> GetByNameDest(string nameDest);
        Transaction Get(int id);
        Transaction Create(Transaction newTransaction);
        void SetIsFraud(int id, bool isFraud);
    }
}
