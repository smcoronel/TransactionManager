using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransacManager.Core.Enumerations;
using TransacManager.Core.Models;
using TransacManager.Data.Implementation;
using TransacManager.Models;

namespace TransacManager.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index(string SearchType, string SearchString)
        {
            TransactionRepository transacRep = new TransactionRepository();
            List<Transaction> transactionList = transacRep.GetAll();
            List<TransactionViewModel> oTrasacViewList = MappingTransactionListtoViewList(transactionList);
            return View(oTrasacViewList);
        }

        [Authorize(Roles = "Administrator,Manager")]
        public ActionResult Search(string SearchType, string SearchString)
        {
            TransactionRepository transacRep = new TransactionRepository();
            List<Transaction> transactionList = new List<Transaction>();
            switch (int.Parse(SearchType))
            {
                //Search by IsFraud
                case 1:
                    transactionList = transacRep.GetFraudTransactions();
                    break;
                case 2:
                    transactionList = transacRep.GetByNameDest(SearchString);
                    break;
                case 3:
                    DateTime date = DateTime.ParseExact(SearchString, "MM/dd/yyyy", null);
                    transactionList = transacRep.GetByDate(date);
                    break;
            }

            List<TransactionViewModel> oTrasacViewList = MappingTransactionListtoViewList(transactionList);
            return View("Index", oTrasacViewList);
        }

        private List<TransactionViewModel> MappingTransactionListtoViewList(List<Transaction> transactionList)
        {
            List<TransactionViewModel> oTrasacViewList = new List<TransactionViewModel>();

            foreach (Transaction oTran in transactionList)
            {
                oTrasacViewList.Add(MappingTransactionToView(oTran));
            }
            return oTrasacViewList;
        }

        private TransactionViewModel MappingTransactionToView(Transaction transaction)
        {
            return new TransactionViewModel
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                OrigAccountId = transaction.OrigAccount.Id,
                OrigAccountNumber = transaction.OrigAccount.AccountNumber,
                NameOrig = transaction.OrigAccount.Customer.Name,
                DestAccountId = transaction.DestAccount != null ? transaction.DestAccount.Id : (int?)null,
                DestAccountNumber = transaction.DestAccount != null ? transaction.DestAccount.AccountNumber : string.Empty,
                NameDest = transaction.DestAccount != null ? transaction.OrigAccount.Customer.Name : string.Empty,
                TransactionDate = transaction.TransactionDate,
                TransactionTypeId = transaction.TransactionTypeId,
                IsFraud = transaction.IsFraud,
                OldBalanceOrig = transaction.OldBalanceOrig,
                NewBalanceOrig = transaction.NewBalanceOrig,
                OldBalanceDest = transaction.OldBalanceDest,
                NewBalanceDest = transaction.NewBalanceDest
            };
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        [Authorize(Roles = "Administrator,Assistant")]
        public ActionResult Create()
        {
            AccountRepository accountRep = new AccountRepository();

            ViewData["accounts"] = accountRep.GetAll();

            return View();
        }

        // POST: Transaction/Create
        [Authorize(Roles = "Administrator,Assistant")]
        [HttpPost]
        public ActionResult Create(TransactionViewModel transactionView)
        {
            try
            {
                //Mapping form data to transaction model
                Transaction transaction = MappingViewtoTransaction(transactionView);
                //Creating transaction in the database
                TransactionRepository transacRep = new TransactionRepository();
                transacRep.Create(transaction);

                return RedirectToAction("Index");
            }
            catch (Exception E)
            {
                return View();
            }
        }

        private Transaction MappingViewtoTransaction(TransactionViewModel transactionView)
        {
            Transaction transaction = new Transaction();
            transaction.TransactionTypeId = (int)Enum.Parse(typeof(TransactionType), transactionView.TransactionTypeName);
            transaction.OrigAccount = new Account {
                Id = transactionView.OrigAccountId
            };
            if (!string.IsNullOrEmpty(transactionView.DestAccountId.ToString()))
            {
                transaction.DestAccount = new Account
                {
                    Id = (int)transactionView.DestAccountId
                };
            }
            transaction.Amount = transactionView.Amount;
            transaction.OldBalanceOrig = transactionView.OldBalanceOrig;
            transaction.NewBalanceOrig = transactionView.NewBalanceOrig;
            transaction.OldBalanceDest = transactionView.OldBalanceDest;
            transaction.NewBalanceDest = transactionView.NewBalanceDest;
            transaction.IsFraud = transactionView.IsFraud;

            return transaction;
        }

        // GET: Transaction/Edit/5
        [Authorize(Roles = "Administrator,Superintendent")]
        public ActionResult Edit(int id)
        {
            TransactionRepository transacRep = new TransactionRepository();
            AccountRepository accountRep = new AccountRepository();
            ViewData["accounts"] = accountRep.GetAll();
            return View(MappingTransactionToView(transacRep.Get(id)));
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator,Superintendent")]
        public ActionResult Edit(int id, TransactionViewModel transaction)
        {
            try
            {
                //Updating transaction isfraud value
                TransactionRepository transacRep = new TransactionRepository();
                transacRep.SetIsFraud(transaction.Id, transaction.IsFraud);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
