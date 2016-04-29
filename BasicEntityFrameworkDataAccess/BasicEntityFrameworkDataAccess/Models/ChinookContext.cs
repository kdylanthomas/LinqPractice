using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BasicEntityFrameworkDataAccess.Models
{
    public class ChinookContext: DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(c => c.ArtistId);


            modelBuilder.Entity<Genre>()
                .ToTable("Genre")
                .HasKey(c => c.GenreId);
        }


    }
}