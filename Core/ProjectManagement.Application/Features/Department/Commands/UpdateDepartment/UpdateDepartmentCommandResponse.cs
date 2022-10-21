namespace ProjectManagement.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandResponse
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }
    }

    public class UpdateDepartmentCommandResponseMessage: UpdateDepartmentCommandResponse
    {
        public UpdateDepartmentCommandResponseMessage(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
