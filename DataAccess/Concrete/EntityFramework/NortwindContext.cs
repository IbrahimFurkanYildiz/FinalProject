using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : DB tabloları ile proje classlarını bağlamak
    //Trusted_Connection=true : sql bağlantısı sağlanırken kullanıcı adı şifre isteme
    //Server=(localdb)\mssqllocaldb : c# içerisindeki sql server object explorer içerisindeki yolu yazdık.
    public class NortwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Projenin hangi DB ile bağlantı kuracağını belirtmek için kullanılır.
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Northwind;User Id=sa;Password=1234;"); // başına @ işareti koymak ters slaş işareti olduğunu anlaması için gereklidir. Normalde c# da ters slaş'ın anlamı vardır.
            
        }

        public DbSet<Product> Products { get; set; } //DB'deki verileri c# daki nesne ile eşleştirme işlemi yapmak için kullanılmaktadır.
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
