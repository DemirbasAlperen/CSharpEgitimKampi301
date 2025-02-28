using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Context
{
    public class KampContext : DbContext
    {
        public DbSet<Category> Categories{ get; set; }  // Burada Category C# tarafında kullanacağımız sınıfımızın ismi, Categories ise Sql e yansıyacak olan tablo ismi. (C# a bana diyorki bunlar burda karışmaması için yalın halini C# tarafında çoğul halini Sql tarafında kullan)
        public DbSet<Product> Products { get; set; }   // Product tablosu
        public DbSet<Order> Orders { get; set; }     // Order tablosu
        public DbSet<Customer> Customers { get; set; }  // Customer tablosu
        public DbSet<Admin> Admins { get; set; }

    }
}
 