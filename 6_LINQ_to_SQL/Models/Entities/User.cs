using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IteaLinqToSql.Models.Interfaces;

namespace IteaLinqToSql.Models.Entities
{
    public class User : IIteaModel
    {
        [Key] public int Id { get; set; }
        public string Username { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<LoginHistory> Logins { get; set; }
    }
}
