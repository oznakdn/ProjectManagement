namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjects
{
    public class GetAllProjectsQueryResponse
    {
        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDetails { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }
    }
}
