using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Rocket.Models;

namespace Rocket.Controllers {

    [Route ("api/interventions")]
    [ApiController]
    public class InterventionsControllers : ControllerBase {
        private readonly domContext _context;

        public InterventionsControllers (domContext context) {
            _context = context;
        }

        // GET api/Interventions/5
        [HttpGet ("{id}", Name = "GetInterventions")]
        public ActionResult GetById (string InterventionStatus, long id) {
            var item = _context.Interventions.Find (id);
            if (item == null) {
                return NotFound ("Not Found");
            }
            var json = new JObject ();
            json["status"] = item.InterventionStatus;
            return Content (json.ToString (), "application/json");
        }
    }
}