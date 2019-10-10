using System.Collections.Generic;
using System.Linq;

using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IteaLinqToSql.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IService<User> service;

        public UserController(IService<User> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<User> Get()
        {
            return service
                .GetQuery()
                .Include(x => x.Logins)
                .Where(x => x.Id > 1)
                .ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<User> Post([FromBody] User value)
        {
            return service
                .GetAll()
                .Where(x => x.Email.Contains(value.Email) ||
                            x.Username.Contains(value.Username) ||
                            x.Id == value.Id)
                .ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
