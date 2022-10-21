using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Persistence.DataSeed
{
    public class ProjectDataSeed : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(

                new Project
                {
                    Id = new Guid("11426e7f-ea32-4e01-90bf-7609d542a5c9"),
                    ProjectTitle = "Crm software project",
                    ProjectDetails = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    ProjectStartDate = new DateTime(2021, 01, 05),
                    ProjectEndDate = new DateTime(2023, 01, 12),
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                }

                );
        }
    }
}
