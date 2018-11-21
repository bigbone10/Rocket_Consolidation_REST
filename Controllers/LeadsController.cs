using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket.Models;

namespace Rocket.Controllers {
    [Route ("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase {
        private readonly MySql_appContext _context;
        public LeadsController (MySql_appContext context) {
            _context = context;
        }

        // GET api/leads
        [HttpGet]
        public ActionResult<List<Leads>> GetAll () {
            var listl = _context.Leads.Include (le => le.Customers);

            if (listl == null) {
                return NotFound ("Not Found");
            }

            List<Leads> list_lead = new List<Leads> ();
            DateTime currentDate = DateTime.Now.AddDays (-30);
            foreach (var l in listl) {
                if (l.CreatedAt >= currentDate) {
                    if (l.Customers.ToList ().Count == 0) {
                        list_lead.Add (l);
                    }
                }
            }
            return list_lead;
        }
    }
}