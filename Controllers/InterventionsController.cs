using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Rocket.Models;
using System;

namespace Rocket.Controllers {

    [Route ("api/interventions")]
    [ApiController]
    public class InterventionsControllers : ControllerBase {
        private readonly domContext _context;

        public InterventionsControllers (domContext context) {
            _context = context;
        }

        // GET api/Interventions
        [HttpGet]
        public ActionResult<List<Interventions>> GetAll () {
            var list = _context.Interventions.ToList ();
            if (list == null) {
                return NotFound ("Not Found");
            }
            List<Interventions> list_pending = new List<Interventions> ();

            foreach (var i in list) {

                if (i.InterventionStatus == "Pending") {
                    list_pending.Add (i);
                }
            }
            return list_pending;
        }

        // PUT api/Interventions/InProgress
        [HttpPut ("InProgress/{id}", Name = "InterventionProgress")]
        public string UpdateIntervention (long id) {

            var intervention = _context.Interventions.Find (id);
            if (intervention == null) {
                
                return "Enter a valid intervention id.";
            }
            if (intervention.InterventionStatus != "Pending") {
                
                return "Can only update 'Pending' interventions.";
            } 
            else {
                intervention.InterventionStatus = "In Progress";
                intervention.InterventionStart = DateTime.Now;
                _context.Interventions.Update(intervention);
                _context.SaveChanges ();
                
                return "In Progress";
            }
        }

        // PUT api/Interventions/Completed
        [HttpPut ("Completed/{id}", Name = "InterventionComplete")]
        public string CompleteIntervention (long id) {

            var intervention = _context.Interventions.Find (id);
            if (intervention == null) {
                
                return "Enter a valid intervention id.";
            }
            if (intervention.InterventionStatus != "In Progress") {
                
                return "Can only complete 'In Progress' interventions.";
            } 
            else {
                intervention.InterventionStatus = "Completed";
                intervention.InterventionResult = "Completed";
                intervention.InterventionEnd = DateTime.Now;
                _context.Interventions.Update(intervention);
                _context.SaveChanges ();
                
                return "Completed";
            }
        }
    }
}