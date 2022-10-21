using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Persistence.DataSeed
{
    public class EmployeeDataSeed : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("f5a37fcc-ef2d-494c-8784-95bdb04195d9"),
                    EmployeeName = "Ali",
                    EmployeeLastname = "Kaplan",
                    EmployeeBirthDate = new DateTime(1980, 03, 12),
                    EmployeePicture = "https://dm.henkel-dam.com/is/image/henkel/men_perfect_com_thumbnails_home_pack_400x400-wcms-international?scl=1&fmt=jpg",
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId= new Guid("95ac8e7f-2d1d-4361-996c-a297ba3a803c")
                },
                new Employee
                {
                    Id = new Guid("447e5a4d-9bae-48a4-a229-2b210068cea2"),
                    EmployeeName = "Sevda",
                    EmployeeLastname = "Aslan",
                    EmployeeBirthDate = new DateTime(1985, 05, 30),
                    EmployeePicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQu5rOjQXpcVzkYiQ4bOlETYdskweUdNCK0mw&usqp=CAU",
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    DepartmentId = new Guid("a2e896e8-ac0f-4b55-902e-38b8ec983c06")
                }

             );
        }
    }
}
