using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebServerTest.Models;

namespace WebServerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private AppDatabaseContext _db;
        public UserController(AppDatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _db.Users.Select(u => u.Name).ToArray();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _db.Users.Find(id).Name;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            User user = new User();

            user.Name = value;
            user.Age = 26;

            _db.Add(user);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            User user = _db.Users.Find(id);
            user.Name = value;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
