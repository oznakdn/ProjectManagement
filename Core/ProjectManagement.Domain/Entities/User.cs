using ProjectManagement.Domain.Enums;

namespace ProjectManagement.Domain.Entities
{
    public class User:BaseEntity
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
