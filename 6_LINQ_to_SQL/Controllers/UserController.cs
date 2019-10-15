using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        readonly IService<User> asyncservice;

        public UserController(IService<User> service)
        {
            this.service = service;
            this.asyncservice = service;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await asyncservice
                .GetQuery()
                .Include(x => x.Logins)
                .Where(x => x.Id > 1)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await asyncservice.FindByIdAsync(id);
        }

        [HttpPost("save")]
        public List<User> Post([FromBody] User value)
        {
            return asyncservice
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
