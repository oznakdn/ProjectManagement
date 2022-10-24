﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagement.Persistence.Contexts;

#nullable disable

namespace ProjectManagement.Persistence.Migrations
{
    [DbContext(typeof(ProjectManagementDbContext))]
    partial class ProjectManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5a37fcc-ef2d-494c-8784-95bdb04195d9"),
                            Address = "Many desktop publishing packages and web page editors now use Lorem",
                            City = "Samsun",
                            CreatedDate = new DateTime(2022, 10, 24, 8, 23, 1, 54, DateTimeKind.Utc).AddTicks(4426),
                            EmailAddress = "ali.kaplan@mail.com",
                            IsActive = true,
                            IsDeleted = false,
                            PhoneNumber = "05999584578"
                        });
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("95ac8e7f-2d1d-4361-996c-a297ba3a803c"),
                            CreatedDate = new DateTime(2022, 10, 24, 8, 23, 1, 54, DateTimeKind.Utc).AddTicks(4833),
                            DepartmentName = "IT",
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("a2e896e8-ac0f-4b55-902e-38b8ec983c06"),
                            CreatedDate = new DateTime(2022, 10, 24, 8, 23, 1, 54, DateTimeKind.Utc).AddTicks(4836),
                            DepartmentName = "HR",
                            IsActive = true,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EmployeeBirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeLastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeePicture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5a37fcc-ef2d-494c-8784-95bdb04195d9"),
                            CreatedDate = new DateTime(2022, 10, 24, 8, 23, 1, 54, DateTimeKind.Utc).AddTicks(4964),
                            DepartmentId = new Guid("95ac8e7f-2d1d-4361-996c-a297ba3a803c"),
                            EmployeeBirthDate = new DateTime(1980, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeLastname = "Kaplan",
                            EmployeeName = "Ali",
                            EmployeePicture = "https://dm.henkel-dam.com/is/image/henkel/men_perfect_com_thumbnails_home_pack_400x400-wcms-international?scl=1&fmt=jpg",
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("447e5a4d-9bae-48a4-a229-2b210068cea2"),
                            CreatedDate = new DateTime(2022, 10, 24, 8, 23, 1, 54, DateTimeKind.Utc).AddTicks(4969),
                            DepartmentId = new Guid("a2e896e8-ac0f-4b55-902e-38b8ec983c06"),
                            EmployeeBirthDate = new DateTime(1985, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeLastname = "Aslan",
                            EmployeeName = "Sevda",
                            EmployeePicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQu5rOjQXpcVzkYiQ4bOlETYdskweUdNCK0mw&usqp=CAU",
                            IsActive = true,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProjectEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProjectStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11426e7f-ea32-4e01-90bf-7609d542a5c9"),
                            CreatedDate = new DateTime(2022, 10, 24, 8, 23, 1, 54, DateTimeKind.Utc).AddTicks(5133),
                            IsActive = true,
                            IsDeleted = false,
                            ProjectDetails = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            ProjectEndDate = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectStartDate = new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectTitle = "Crm software project"
                        });
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RefreshTokenExpireTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("ProjectManagement.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagement.Domain.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Contact", b =>
                {
                    b.HasOne("ProjectManagement.Domain.Entities.Employee", "Employee")
                        .WithOne("EmployeeContract")
                        .HasForeignKey("ProjectManagement.Domain.Entities.Contact", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Employee", b =>
                {
                    b.HasOne("ProjectManagement.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.User", b =>
                {
                    b.HasOne("ProjectManagement.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ProjectManagement.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeContract")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
