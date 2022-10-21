using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Persistence.DataSeed
{
    public class UserDataSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("0a69a0e7-e1c5-4554-b78d-50518dce0f49"),
                    EmployeeId = new Guid("447e5a4d-9bae-48a4-a229-2b210068cea2"),
                    Username = "sevda.aslan@mail.com",
                    Password = "aslnsvd123",
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
                );
        }
    }
}
