using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;


namespace DataServ.Controllers
{
    public class JobsController : ApiController
    {

        [HttpGet]
        public IHttpActionResult searchjobs(string id)
        {
            DataTable dt = new DataTable();
            Dal dl = new Dal();
            dt = dl.GetJobs(id);
            string JSONString = dl.DataTableToJSONWithJSONNet(dt);
            return Ok(JSONString);
        }
      
    }
}
