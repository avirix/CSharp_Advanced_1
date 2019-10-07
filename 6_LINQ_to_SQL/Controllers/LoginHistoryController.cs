using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using IteaLinqToSql.Services;
using Microsoft.AspNetCore.Mvc;

namespace _6_LINQ_to_SQL.Controllers
{
    [Route("api/user/history")]
    [ApiController]
    public class LoginHistoryController : ControllerBase
    {
        readonly IService<LoginHistory> service;

        public LoginHistoryController(IService<LoginHistory> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<LoginHistory> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public LoginHistory Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost]
        public List<LoginHistory> Post([FromBody] LoginHistory value)
        {
            return service
                .GetAll()
                .Where(x => x.IPAddress.Contains(value.IPAddress) ||
                            x.User.Username.Contains(value.User.Username) ||
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