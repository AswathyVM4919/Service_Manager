using Service_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service_Manager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServiceAsstController : ApiController
    {
        private MachineTestEntities _dbContext = new MachineTestEntities();
        public IHttpActionResult GetServiceAsstById(int id)
        {
            var service = _dbContext.gn_service_asst.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
        public IEnumerable<gn_service_asst> GetAllServiceAsst()
        {
            return _dbContext.gn_service_asst.ToList();
        }
        public IHttpActionResult SaveServiceAsst(gn_service_asst Service_Asst)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _dbContext.gn_service_asst.Add(Service_Asst);
                _dbContext.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpOptions]
        public IHttpActionResult Options()
        {
            return Ok();
        }
    }
}
