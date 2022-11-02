namespace ProjectManagement.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQueryResponse
    {
        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDetails { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }
    }

    public class GetProjectByIdQueryResponseMessage: GetProjectByIdQueryResponse
    {
        public string ResponseMessage { get; set; }
    }
}
