using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Rocket.Models;
using System;
using System.Threading.Tasks;



namespace Rocket.Controllers {
    [Route ("api/users")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly MySql_appContext _context;
        public UsersController (MySql_appContext context) {
            _context = context;
        }

        // GET api/users
        [HttpGet ("{email}", Name = "email")]
        
        public ActionResult<Users> Get (string email) {
            var _result = _context.Users.Where(s => s.Email == email).FirstOrDefault();
            if (_result == null)  {
                return NotFound();
            }

            return _result;
        }
    }
}