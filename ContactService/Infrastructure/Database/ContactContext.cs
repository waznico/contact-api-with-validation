using System;
using ContactService.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Infrastructure.Database
{
    public class ContactContext : DbContext
    {
        public DbSet<ContactForm> ContactForms { get; set; }
        public string DbPath { get; private set; }

        public ContactContext(DbContextOptions options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}ContactForms.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
