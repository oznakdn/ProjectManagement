namespace ProjectManagement.Application.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandResponse
    {
        public UpdateEmployeeCommandResponse()
        {
            this.IsValid = true;
            this.ResponseMessages = new List<string>();
        }

        public bool IsValid { get; set; }
        public List<string> ResponseMessages { get; set; }
    }
}
