using InteractiveAssesment_API.Logic;
using InteractiveAssesment_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InteractiveAssesment_API.Controllers
{
    public class TransactController : ApiController
    {
        StoredProcConfig _procLogic = new StoredProcConfig();

        // GET: api/Transact
        public IEnumerable<dynamic> Get(Transactions transactions)
        {
           return _procLogic.LoadList("TransactionMasterProc");
        }


        // POST: api/Transact
        public void Post([FromBody] Transactions transactions)
        {
            _procLogic.ExecuteStoredProcedure("TransactionMasterProc", transactions);
        }

       

        // DELETE: api/Transact/5
        public void Delete([FromBody] Transactions transactions)
        {
            _procLogic.ExecuteStoredProcedure("TransactionMasterProc", transactions);
        }
    }
}
