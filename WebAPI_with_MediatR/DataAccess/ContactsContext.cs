using Microsoft.EntityFrameworkCore;
using WebAPI_with_MediatR.Entities;

namespace WebAPI_with_MediatR.DataAccess
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "Tommy", LastName = "O'Hara" },
                new Contact { Id = 2, FirstName = "Maggie", LastName = "O'Hara" },
                new Contact { Id = 3, FirstName = "Betty", LastName = "O'Hara" }
                );
        }
    }
}