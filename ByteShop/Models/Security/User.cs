using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ByteShop.Models.Security
{
    public class User
    {
        [Key]
        public int Id { get; set;}
        public string Email { get; set;}
        public string Password { get; set; }
        public string FirstName { get; set;}
        public DateTime Birthdate { get; set; }
        public DateTime CreationDate { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}