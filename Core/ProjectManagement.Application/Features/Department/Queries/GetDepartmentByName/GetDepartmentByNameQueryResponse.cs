namespace ProjectManagement.Application.Features.Department.Queries.GetDepartmentByName
{
    public class GetDepartmentByNameQueryResponse
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }

    }

    public class GetDepartmentByNameQueryResponseMessage: GetDepartmentByNameQueryResponse
    {
        public GetDepartmentByNameQueryResponseMessage(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
