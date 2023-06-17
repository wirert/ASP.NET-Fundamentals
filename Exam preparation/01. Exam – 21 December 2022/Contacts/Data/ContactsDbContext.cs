using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static Contacts.Constants.DataConstants.User;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {  
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ApplicationUserContact> UsersContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserContact>()
                .HasKey(nameof(ApplicationUserContact.ApplicationUserId), nameof(ApplicationUserContact.ContactId));

            builder.Entity<ApplicationUser>()
                .Property(p => p.UserName)
                .HasColumnType($"nvarchar({MaxUserName})");

            builder.Entity<ApplicationUser>()
                .Property(p => p.Email)
                .HasColumnType($"nvarchar({MaxEmail})");

            builder
                .Entity<Contact>()
                .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });

            base.OnModelCreating(builder);
        }
    }
}