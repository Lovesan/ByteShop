using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByteShop.Models.Security
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum ByteShopRoles { admin = 1, user = 2 };
}