using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;
using System.Reflection;

namespace ProjectManagement.Persistence.Contexts
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOne(emp => emp.EmployeeContract)
                .WithOne(cont => cont.Employee);

            modelBuilder.Entity<Department>()
                .HasMany(dep => dep.Employees)
                .WithOne(emp => emp.Department)
                .HasForeignKey(emp => emp.DepartmentId);

            modelBuilder.Entity<Project>()
                .HasMany(proj => proj.Employees)
                .WithMany(emp => emp.Projects);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


    }
}
