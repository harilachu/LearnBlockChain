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
                new Location()
                {
                    Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                    Location_Name = "R&D"
                },
                new Location()
                {
                    Location_Id = new Guid("696A03E9-AE8D-46A5-918F-2E4C19CECFD3"),
                    Location_Name = "LAB"
                }
            );
            modelBuilder.Entity<Manufacture>().HasData(
                new Manufacture()
                {
                    Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                    Manufacture_Name = "RAININ"
                },
                new Manufacture()
                {
                    Manufacture_Id = new Guid("33E11F97-1705-466F-8F9D-9773D33AED8F"),
                    Manufacture_Name = "METTLER TOLEDO"
                }
            );
            modelBuilder.Entity<PippetteUser>().HasData(
                new PippetteUser() 
                { 
                    Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"), 
                    Pippette_User_Name = "Alex"    
                },
                new PippetteUser()
                {
                    Pippette_User_Id = new Guid("293D98BB-420B-4416-B5F0-7F6647E4548F"),
                    Pippette_User_Name = "Joe"
                }
            );
            modelBuilder.Entity<Pippette>().HasData(
                new Pippette()
                {
                    Pippette_Id = Guid.NewGuid(),
                    Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"),
                    Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                    Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                    ModelName = "P2020",
                    SerialNumber = "P2020-FEB",
                    UsageFrequency = 10
                },
                new Pippette()
                {
                    Pippette_Id = Guid.NewGuid(),
                    Pippette_User_Id = new Guid("293D98BB-420B-4416-B5F0-7F6647E4548F"),
                    Manufacture_Id = new Guid("33E11F97-1705-466F-8F9D-9773D33AED8F"),
                    Location_Id = new Guid("696A03E9-AE8D-46A5-918F-2E4C19CECFD3"),
                    ModelName = "L2020",
                    SerialNumber = "L2020-MAR",
                    UsageFrequency = 20
                },
                new Pippette()
                {
                    Pippette_Id = Guid.NewGuid(),
                    Pippette_User_Id = new Guid("ae30e17e-0a0e-4b9c-a6dc-7e442a6caecc"),
                    Manufacture_Id = new Guid("ca3bdc52-7a1a-4e72-b915-d35eca13666e"),
                    Location_Id = new Guid("696A03E9-AE8D-46A5-918F-2E4C19CECFD3"),
                    ModelName = "P2019",
                    SerialNumber = "P2019-MAR",
                    UsageFrequency = 510
                },
                new Pippette()
                {
                    Pippette_Id = Guid.NewGuid(),
                    Pippette_User_Id = new Guid("293D98BB-420B-4416-B5F0-7F6647E4548F"),
                    Manufacture_Id = new Guid("33E11F97-1705-466F-8F9D-9773D33AED8F"),
                    Location_Id = new Guid("ea9967dc-fd31-4add-97c2-e499d92079bb"),
                    ModelName = "L2019",
                    SerialNumber = "L2019-FEB",
                    UsageFrequency = 320
                }
            );
        }
    }
}
