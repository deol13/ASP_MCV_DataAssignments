using ASP_MCV_DataAssignments.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KnownLanguage>().HasKey(kl =>
            new
            {
                kl.PersonId,
                kl.LanguageId
            });

            modelBuilder.Entity<KnownLanguage>()
                .HasOne<Person>(kl => kl.Person)
                .WithMany(p => p.KnownLanguageList)
                .HasForeignKey(kl => kl.PersonId);

            modelBuilder.Entity<KnownLanguage>()
                .HasOne<Language>(kl => kl.Language)
                .WithMany(l => l.KnownLanguageList)
                .HasForeignKey(kl => kl.LanguageId);
        }

        public DbSet<Person> People { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Language> Languages { get; set; }
    }
}
