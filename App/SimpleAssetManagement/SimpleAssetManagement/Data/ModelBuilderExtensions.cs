using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimpleAssetManagement.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                    Location_Name = "R&D"
                }
            );
            modelBuilder.Entity<Manufacture>().HasData(
                new Manufacture
                {
                    Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                    Manufacture_Name = "RAININ"
                }
            );
            modelBuilder.Entity<PippetteUser>().HasData(
                new PippetteUser 
                { 
                    Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"), 
                    Pippette_User_Name = "Alex"    
                }
            );
            modelBuilder.Entity<Pippette>().HasData(
                new Pippette
                {
                    Pippette_Id = Guid.NewGuid(),
                    Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"),
                    Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                    Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                    ModelName = "P2020",
                    SerialNumber = "P2020-FEB",
                    UsageFrequency = 10
                }
            );
        }
    }
}
