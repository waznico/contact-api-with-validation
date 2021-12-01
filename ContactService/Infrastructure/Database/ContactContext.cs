using ContactService.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Infrastructure.Database
{
    public class ContactContext : DbContext
    {
        public DbSet<ContactForm> ContactForms { get; set; }

        public ContactContext(DbContextOptions options) : base(options) { }
    }
}
