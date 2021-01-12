using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PhonebookWebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhonebookWebAPI.Data
{
    public class Context : DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        public DbSet<Phonebook> Phonebooks { get; set; }

        public Context()
            : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>()
                .Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Entry>()
                .Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Entry>()
                .Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired();

            //modelBuilder.Entity<Phonebook>()
            //    .HasMany(p => p.Entries)
            //    .WithRequired(p => p.Phonebook)
            //    .HasForeignKey(p => p.PhonebookId);

            modelBuilder.Entity<Entry>()
                .Property(e => e.PhonebookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}