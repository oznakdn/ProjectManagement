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
    public class ContactDataSeed : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Id = new Guid("f5a37fcc-ef2d-494c-8784-95bdb04195d9"),
                    Address = "Many desktop publishing packages and web page editors now use Lorem",
                    City = "Samsun",
                    EmailAddress = "ali.kaplan@mail.com",
                    PhoneNumber = "05999584578",
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
                );
        }
    }
}
