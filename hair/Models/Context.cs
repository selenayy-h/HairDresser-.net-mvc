


using hair.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Hairdresser.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-ACDH94DG\\SQLEXPRESS01;database=Hair;integrated security=true;TrustServerCertificate=True;");
        }


        public DbSet<Personel> Personels { get; set; }

        public DbSet<Islem> Islems { get; set; }


        public DbSet<Randevu> Randevus { get; set; }

    }
}
