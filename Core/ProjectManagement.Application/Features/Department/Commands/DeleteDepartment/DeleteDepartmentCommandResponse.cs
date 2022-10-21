namespace ProjectManagement.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandResponse
    {

        public int StatusCode { get; set; }
    }

    public class DeleteDepartmentCommandResponseMessage: DeleteDepartmentCommandResponse
    {
        public DeleteDepartmentCommandResponseMessage(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
    }
}
