using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacManager.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Account OrigAccount { get; set; }
        public Account DestAccount { get; set; }
        public decimal Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsFraud { get; set; }
        public decimal OldBalanceOrig { get; set; }
        public decimal NewBalanceOrig { get; set; }
        public Nullable<decimal> OldBalanceDest { get; set; }
        public Nullable<decimal> NewBalanceDest { get; set; }

        public Transaction()
        {
        }
    }
}
