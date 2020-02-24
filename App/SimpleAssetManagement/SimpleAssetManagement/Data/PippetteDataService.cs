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

        public async Task<List<PippetteDto>> GetPippettesAsync()
        {
            //var pippettes = await DBContext.Pippettes.ToListAsync();
            var pippetteLocationJoin = await DBContext.Pippettes.Join(DBContext.Locations, p => p.Location_Id, l => l.Pippette.Location_Id,
                (p, l) => new PippetteDto() {
                    ModelName = p.ModelName,
                    SerialNumber = p.SerialNumber,
                    UsageFrequency = p.UsageFrequency,
                    Location_Name = l.Location_Name
                }).ToListAsync();

            return pippetteLocationJoin.ToList();
        }

        public async Task<LocationDto> GetPippetteLocationAsync(string serialNumber)
        {
            var pippette = await DBContext.Pippettes.Where(p => p.SerialNumber == serialNumber).SingleOrDefaultAsync();
            var location = await DBContext.Locations.Where(l => l.Location_Id == pippette.Location_Id).SingleOrDefaultAsync();
            return Mapper.Map<LocationDto>(location);
        }
    }
}
