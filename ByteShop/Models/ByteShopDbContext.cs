using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ByteShop.Models
{
    public class ByteShopDbContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
    }

    [Table("entity")]
    public class Entity
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Description", TypeName = "varchar")]
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [Column("Foo")]
        public string Foo { get; set; }
    }
}