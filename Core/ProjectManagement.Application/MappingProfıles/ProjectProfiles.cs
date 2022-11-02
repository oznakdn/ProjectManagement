using AutoMapper;
using ProjectManagement.Application.Features.Project.Queries.GetAllProjects;
using ProjectManagement.Application.Features.Project.Queries.GetAllProjectsWith;
using ProjectManagement.Application.Features.Project.Queries.GetProjectById;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.MappingProfıles
{
    public class ProjectProfiles:Profile
    {
        public ProjectProfiles()
        {
            CreateMap<Project, GetAllProjectsQueryResponse>()
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()))
                .ForMember(dest=>dest.ProjectStartDate,opt=>opt.MapFrom(src=>src.ProjectStartDate.ToShortDateString()))
                .ForMember(dest=>dest.ProjectEndDate,opt=>opt.MapFrom(src=>src.ProjectEndDate.ToShortDateString()));

            CreateMap<Project, GetProjectByIdQueryResponseMessage>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
               .ForMember(dest => dest.ProjectStartDate, opt => opt.MapFrom(src => src.ProjectStartDate.ToShortDateString()))
               .ForMember(dest => dest.ProjectEndDate, opt => opt.MapFrom(src => src.ProjectEndDate.ToShortDateString()));

            //CreateMap<Project, GetAllProjectsWithQueryResponse>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            //    .ForMember(dest => dest.ProjectStartDate, opt => opt.MapFrom(src => src.ProjectStartDate.ToShortDateString()))
            //    .ForMember(dest => dest.ProjectEndDate, opt => opt.MapFrom(src => src.ProjectEndDate.ToShortDateString()))
            //    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employees.Select(x => x.Id.ToString())))
            //    .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => src.Employees.Select(x => x.EmployeeName +" "+ x.EmployeeLastname)));
        }
    }
}
