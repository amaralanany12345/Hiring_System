using AutoMapper;
using Hiring.dtos;
using Hiring.Models;

namespace Hiring.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Education, EducationDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.employeeId, opt => opt.MapFrom(src => src.employeeId))
                .ForMember(dest => dest.educationalInstitute, opt => opt.MapFrom(src => src.educationalInstitute))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.endDate, opt => opt.MapFrom(src => src.endDate))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description));

        }
    }
}
