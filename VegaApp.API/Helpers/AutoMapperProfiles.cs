using AutoMapper;
using VegaApp.API.Dtos;
using VegaApp.API.Models;

namespace VegaApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // AutoMapper is convention based.
            // Convention based means, if AutoMapper sees a Make.Name property and
            // it sees a MakeForListDto.Name property, then we don't need to add some
            // configuration as it is smart to know that those properties should map to 
            // each other.  
            CreateMap<Make, MakeForListDto>();
            CreateMap<Model, ModelForDetailDto>();

        }
    }
}