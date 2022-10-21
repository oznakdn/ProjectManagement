using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.Domain.Entities
{
    public class Contact:BaseEntity
    {


        [Key,ForeignKey(nameof(Employee))]
        public override Guid Id { get; set; }
        public virtual Employee Employee { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
