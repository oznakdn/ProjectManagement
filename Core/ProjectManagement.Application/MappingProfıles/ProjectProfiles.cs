using AutoMapper;
using ProjectManagement.Application.Features.Project.Commands.AddProject;
using ProjectManagement.Application.Features.Project.Commands.UpdateProject;
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

            CreateMap<AddProjectCommandRequest, Project>();
            CreateMap<UpdateProjectCommandRequest, Project>();

        }
    }
}
