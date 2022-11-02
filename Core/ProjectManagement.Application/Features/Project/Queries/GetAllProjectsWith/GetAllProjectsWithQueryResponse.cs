namespace ProjectManagement.Application.Features.Project.Queries.GetAllProjectsWith
{
    public class GetAllProjectsWithQueryResponse
    {
        public string Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDetails { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }

        public IEnumerable <string> EmployeeId { get; set; }
        public IEnumerable<string> EmployeeFullName { get; set; }

    }
}
