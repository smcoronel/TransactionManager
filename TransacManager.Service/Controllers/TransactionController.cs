using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransacManager.Core.Models;
using TransacManager.Data.Implementation;

namespace TransacManager.Service.Controllers
{
    public class TransactionController : ApiController
    {
        // GET: api/Transaction/5
        public IHttpActionResult Get(int id)
        {
            TransactionRepository transacRep = new TransactionRepository();
            var transaction = transacRep.Get(id);
            return Ok(new { result = transaction });
        }

        // POST: api/Transaction
        public IHttpActionResult Post(Transaction transaction)
        {
            TransactionRepository transacRep = new TransactionRepository();
            transacRep.Create(transaction);
            return Ok(new { result = "OK" });
        }

    }
}
