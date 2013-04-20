using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ByteShop.Models
{
    public class ByteShopDbContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
    }

    public class Entity
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}