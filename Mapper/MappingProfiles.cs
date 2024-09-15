using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<WorkersViewModel, Workers>().ReverseMap();
            CreateMap<DepartmentsViewModel, Department>().ReverseMap();
        }
    }
}
