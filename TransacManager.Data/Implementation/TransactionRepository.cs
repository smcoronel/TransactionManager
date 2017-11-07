using System;
using System.Collections.Generic;
using System.Linq;
using TransacManager.Core.Models;
using System.Data.Entity;
using TransacManager.Data.Interfaces;

namespace TransacManager.Data.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        public List<Transaction> GetAll()
        {
            List<Transaction> list;
            using (var context = new Context())
            {
                list = context.Transactions
                                .Include(q => q.OrigAccount)
                                .Include(q => q.OrigAccount.Customer)
                                .Include(q => q.DestAccount)
                                .Include(q => q.DestAccount.Customer)
                                .ToList();
            }

            return list;
        }

        public List<Transaction> GetFraudTransactions()
        {
            List<Transaction> list;
            using (var context = new Context())
            {
                list = context.Transactions
                                .Include(q => q.OrigAccount)
                                .Include(q => q.OrigAccount.Customer)
                                .Include(q => q.DestAccount)
                                .Include(q => q.DestAccount.Customer)
                                .Where(q => q.IsFraud)
                                .ToList();
            }

            return list;
        }

        public List<Transaction> GetByDate(DateTime transactionDate)
        {
            List<Transaction> list;
            using (var context = new Context())
            {
                list = context.Transactions
                                .Include(q => q.OrigAccount)
                                .Include(q => q.OrigAccount.Customer)
                                .Include(q => q.DestAccount)
                                .Include(q => q.DestAccount.Customer)
                                .Where(q => DbFunctions.TruncateTime(q.TransactionDate) == transactionDate.Date)
                                .ToList();
            }

            return list;
        }

        public List<Transaction> GetByNameDest(string nameDest)
        {
            List<Transaction> list;
            using (var context = new Context())
            {
                list = context.Transactions
                                .Include(q => q.OrigAccount)
                                .Include(q => q.OrigAccount.Customer)
                                .Include(q => q.DestAccount)
                                .Include(q => q.DestAccount.Customer)
                                .Where(q => q.DestAccount.Customer.Name == nameDest)
                                .ToList();
            }

            return list;
        }

        public Transaction Get(int id)
        {
            Transaction result;
            using (var context = new Context())
            {
                result = context.Transactions
                                .Include(q => q.OrigAccount)
                                .Include(q => q.OrigAccount.Customer)
                                .Include(q => q.DestAccount)
                                .Include(q => q.DestAccount.Customer)
                                .Where(q => q.Id == id)
                                .FirstOrDefault();
            }

            return result;
        }

        public Transaction Create(Transaction newTransaction)
        {
            using (var context = new Context())
            {
                newTransaction.TransactionDate = DateTime.UtcNow;
                context.Accounts.Attach(newTransaction.OrigAccount);
                if(newTransaction.DestAccount != null)
                    context.Accounts.Attach(newTransaction.DestAccount);
                var result = context.Transactions.Add(newTransaction);
                context.SaveChanges();
            }

            return newTransaction;
        }

        public void SetIsFraud(int id, bool isFraud)
        {
            using (var context = new Context())
            {
                var transaction = context.Transactions.FirstOrDefault(c => c.Id == id);
                transaction.IsFraud = isFraud;
                context.SaveChanges();
            }
        }
    }
}
