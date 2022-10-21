using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Persistence.DataSeed
{
    public class DepartmentDataSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = new Guid("95ac8e7f-2d1d-4361-996c-a297ba3a803c"),
                    DepartmentName = "IT",
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Department
                {
                    Id = new Guid("a2e896e8-ac0f-4b55-902e-38b8ec983c06"),
                    DepartmentName = "HR",
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
                );
        }
    }
}
