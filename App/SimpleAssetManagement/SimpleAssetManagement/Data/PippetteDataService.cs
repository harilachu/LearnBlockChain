using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace SimpleAssetManagement.Data
{
    public class PippetteDataService
    {
        public PippetteDataService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            DBContext = applicationDbContext;
            Mapper = mapper;
        }

        public ApplicationDbContext DBContext { get; }
        public IMapper Mapper { get; }

        public async Task<List<PippetteDataDto>> GetPippettesAsync()
        {
            var pippetteDataJoin = from p in DBContext.Pippettes
                                              join m in DBContext.Manufactures
                                              on p.Manufacture_Id equals m.Manufacture_Id
                                              join l in DBContext.Locations
                                              on p.Location_Id equals l.Location_Id
                                              join u in DBContext.PippetteUsers
                                              on p.Pippette_User_Id equals u.Pippette_User_Id
                                              orderby p.SerialNumber
                                              select new PippetteDataDto()
                                              {
                                                  ModelName = p.ModelName,
                                                  SerialNumber = p.SerialNumber,
                                                  UsageFrequency = p.UsageFrequency,
                                                  Location_Name = l.Location_Name,
                                                  Manufacture_Name = m.Manufacture_Name,
                                                  Pippette_User_Name = u.Pippette_User_Name
                                              };

            return await pippetteDataJoin.ToListAsync();
        }

        public async Task<List<LocationDto>> GetLocationsAsync()
        {
            var locations = from l in DBContext.Locations
                            orderby l.Location_Name
                            select new LocationDto()
                            {
                                Location_Name = l.Location_Name
                            };

            return await locations.ToListAsync();
        }

        public async Task<List<ManufactureDto>> GetManufacturesAsync()
        {
            var manufactures = from m in DBContext.Manufactures
                            orderby m.Manufacture_Name
                            select new ManufactureDto()
                            {
                                Manufacture_Name = m.Manufacture_Name
                            };

            return await manufactures.ToListAsync();
        }

        public async Task<List<PippetteUserDto>> GetUsersAsync()
        {
            var users = from u in DBContext.PippetteUsers
                               orderby u.Pippette_User_Name
                               select new PippetteUserDto()
                               {
                                   Pippette_User_Name = u.Pippette_User_Name
                               };

            return await users.ToListAsync();
        }

        public async Task AddPippetteAsync(PippetteDataDto pippetteDataDto)
        {
            var manufacture = await DBContext.Manufactures.Where(m => m.Manufacture_Name == pippetteDataDto.Manufacture_Name).FirstOrDefaultAsync();
            var location = await DBContext.Locations.Where(l => l.Location_Name == pippetteDataDto.Location_Name).FirstOrDefaultAsync();
            var user = await DBContext.PippetteUsers.Where(u => u.Pippette_User_Name == pippetteDataDto.Pippette_User_Name).FirstOrDefaultAsync();

            var pippette = new Pippette()
            {
                Pippette_Id = Guid.NewGuid(),
                Manufacture_Id = manufacture.Manufacture_Id,
                Location_Id = location.Location_Id,
                Pippette_User_Id = user.Pippette_User_Id,
                ModelName = pippetteDataDto.ModelName,
                SerialNumber = pippetteDataDto.SerialNumber,
                UsageFrequency = pippetteDataDto.UsageFrequency
            };

            await DBContext.Pippettes.AddAsync(pippette);
            await DBContext.SaveChangesAsync();
        }
    }
}
