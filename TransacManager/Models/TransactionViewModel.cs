using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransacManager.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Origin Account")]
        public int OrigAccountId { get; set; }
        [Display(Name = "Origin Account")]
        public string OrigAccountNumber { get; set; }
        public string NameOrig { get; set; }
        [Display(Name = "Destination Account")]
        public Nullable<int> DestAccountId { get; set; }
        [Display(Name = "Destination Account")]
        public string DestAccountNumber { get; set; }
        public string NameDest { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Transaction Type")]
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name = "Old Balance Origin")]
        public decimal OldBalanceOrig { get; set; }
        [Display(Name = "New Balance Origin")]
        public decimal NewBalanceOrig { get; set; }
        [Display(Name = "Old Balance Destination")]
        public Nullable<decimal> OldBalanceDest { get; set; }
        [Display(Name = "New Balance Destination")]
        public Nullable<decimal> NewBalanceDest { get; set; }
        [Display(Name = "Is Fraud")]
        public bool IsFraud { get; set; }
    }
}