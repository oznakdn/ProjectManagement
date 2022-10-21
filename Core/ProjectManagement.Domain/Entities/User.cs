using ProjectManagement.Domain.Enums;

namespace ProjectManagement.Domain.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Role = Role.Standard;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Guid? EmployeeId { get; set; } = null;
        public virtual Employee? Employee { get; set; }
    }
}
