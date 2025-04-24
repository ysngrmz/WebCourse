using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourse.Domain.Entities;


namespace WebCourse.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) :base(options)
        {
                
        }

        public DbSet<Villa> VillaDB { get; set; }

        public DbSet<VillaNumber> VillaNumberDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(

                new Villa
                {
                    Id = 1,
                    Name = "Deniz Manzaralı Lüks Villa",
                    Description = "Muhteşem deniz manzarasına sahip, geniş bahçeli ve özel havuzlu lüks villa.",
                    Price = 1500000.00,
                    Sqft = 3500,
                    Occupancy = 8,
                    ImageUrl = "https://example.com/villa1.jpg"
                },
                new Villa
                {
                    Id = 2,
                    Name = "Orman İçinde Sakin Villa",
                    Description = "Doğayla iç içe, huzurlu bir ortamda bulunan, orman manzaralı villa.",
                    Price = 950000.00,
                    Sqft = 2200,
                    Occupancy = 6,
                    ImageUrl = "https://example.com/villa2.jpg"
                },

                new Villa
                {
                    Id = 3,
                    Name = "Şehir Merkezine Yakın Modern Villa",
                    Description = "Şehir merkezine kolay ulaşım sağlayan, modern tasarımlı ve geniş teraslı villa.",
                    Price = 1200000.00,
                    Sqft = 2800,
                    Occupancy = 7,
                    ImageUrl = "https://example.com/villa3.jpg"
                }

             );

            modelBuilder.Entity<VillaNumber>().HasData(

                new VillaNumber {

                    Villa_Number = 101,
                    villaID = 1
                },

                new VillaNumber
                {

                    Villa_Number = 102,
                    villaID = 1
                },

                new VillaNumber
                {

                    Villa_Number = 103,
                    villaID = 1
                },

                new VillaNumber
                {

                    Villa_Number = 201,
                    villaID = 2
                },

                new VillaNumber
                {

                    Villa_Number = 202,
                    villaID = 2
                },

                new VillaNumber
                {

                    Villa_Number = 203,
                    villaID = 2
                },

                new VillaNumber
                {

                    Villa_Number = 301,
                    villaID = 3
                },

                new VillaNumber
                {

                    Villa_Number = 302,
                    villaID = 3
                },

                new VillaNumber
                {

                    Villa_Number = 303,
                    villaID = 3
                }

                );



        }
    }
}
