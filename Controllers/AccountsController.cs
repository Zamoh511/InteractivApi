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
    public class AccountsController : ApiController
    {
        StoredProcConfig _procLogic = new StoredProcConfig();
        // GET: api/Account
        public IEnumerable<string> Get()
        {

            List<dynamic> list = _procLogic.LoadList("AccountMasterProc");
            return (IEnumerable<string>)list;
        }

        // GET: api/Account/5
        public string Get(Account Account)
        {
            _procLogic.ExecuteStoredProcedure("AccountMasterProc", Account);
            return "value";
        }

        // POST: api/Account
        public void Post([FromBody] Account Account)
        {
            _procLogic.ExecuteStoredProcedure("AccountMasterProc", Account);
        }

        // PUT: api/Account/5
        public void Put([FromBody] Account Account)
        {
            _procLogic.ExecuteStoredProcedure("AccountMasterProc", Account);
        }

        // DELETE: api/Account/5
        public void Delete(Account Account)
        {
            _procLogic.ExecuteStoredProcedure("AccountMasterProc", Account);
        }
    }
}
