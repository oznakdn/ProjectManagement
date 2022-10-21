namespace ProjectManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryResponse
    {
        public string Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeePicture { get; set; }
        public string EmployeeBirthDate { get; set; }
    }

    public class GetEmployeeByIdQueryResponseMessage: GetEmployeeByIdQueryResponse
    {
        public string ResponseMessage { get; set; }
    }
}
