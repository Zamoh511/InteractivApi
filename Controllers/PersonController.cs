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
    public class PersonController : ApiController
    {
        StoredProcConfig _procLogic = new StoredProcConfig();
        // GET: api/Person
        public IEnumerable<string> Get()
        {

            List<dynamic> list = _procLogic.LoadList("PersonMasterProc");
            return (IEnumerable<string>)list;
        }

        // GET: api/Person/5
        public string Get(Person person)
        {
            _procLogic.ExecuteStoredProcedure("PersonMasterProc", person);
            return "value";
        }

        // POST: api/Person
        [HttpPost]
        [Route("api/Person/Post")]
        public void Post([FromBody]Person person)
        {
            _procLogic.ExecuteStoredProcedure("PersonMasterProc", person);
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value,Person person)
        {
            
            _procLogic.ExecuteStoredProcedure("PersonMasterProc", person);
        }

        // DELETE: api/Person/5
        public void Delete(Person person)
        {
            _procLogic.ExecuteStoredProcedure("PersonMasterProc", person);
        }
    }
}
