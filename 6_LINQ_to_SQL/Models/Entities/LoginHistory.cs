using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using IteaLinqToSql.Models.Interfaces;

namespace IteaLinqToSql.Models.Entities
{
    public class LoginHistory : IIteaModel
    {
        [Key] public int Id { get; set; }
        public string IPAddress { get; set; }
        public DateTime LoginTime { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
    }
}
