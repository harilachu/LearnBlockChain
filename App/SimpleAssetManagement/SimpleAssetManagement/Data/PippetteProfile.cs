using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SimpleAssetManagement.Data
{
    public class PippetteProfile : Profile
    {
        public PippetteProfile()
        {
            this.CreateMap<Pippette, PippetteDto>()
                .ForMember(pd=> pd.Location_Name, p=> p.Ignore())
                .ReverseMap()
                .ForMember(p => p.Pippette_Id, pd => pd.UseDestinationValue())
                .ForMember(p => p.Manufacture_Id, pd => pd.UseDestinationValue())
                .ForMember(p => p.Pippette_User_Id, pd => pd.UseDestinationValue())
                .ForMember(p => p.Location_Id, pd => pd.UseDestinationValue());

            this.CreateMap<Manufacture, ManufactureDto>()
                .ReverseMap()
                .ForMember(m => m.Manufacture_Id, md => md.UseDestinationValue());

            this.CreateMap<PippetteUser, PippetteUserDto>()
                .ReverseMap()
                .ForMember(p => p.Pippette_User_Id, pd => pd.UseDestinationValue());

            this.CreateMap<Location, LocationDto>()
                .ReverseMap()
                .ForMember(l => l.Location_Id, ld => ld.UseDestinationValue());

            this.CreateMap<AuditLog, AuditLogDto>()
                .ReverseMap()
                .ForMember(l => l.Log_Id, ld => ld.UseDestinationValue());
        }
    }
}
