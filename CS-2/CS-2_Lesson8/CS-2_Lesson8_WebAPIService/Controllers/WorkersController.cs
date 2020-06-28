using CS_2_Lesson8_WebAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CS_2_Lesson8_WebAPIService.Controllers
{
    public class WorkersController : ApiController
    {
        private DataWorkers data = new DataWorkers();
        [HttpGet]
        [Route("getlist")]
        public List<Workers> Get() => data.GetList();

        [Route("getlist/{id}")]
        public Workers GetWorker(int id) => data.GetWorkerById(id);

        #region __

        //test/22/e/2/st/10
        [Route("test/{s}/e/{e}/st/{st}")]
        public IEnumerable<int> GetWorkers(int s, int e, int st = 0)
        {
            return Enumerable.Range(s, e + st);
        }
        #endregion

        [Route("addworker")]
        public HttpResponseMessage Post([FromBody] Workers value)
        {
            if (data.AddWorker(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
