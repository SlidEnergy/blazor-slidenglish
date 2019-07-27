using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SlidEnglish.Server.Models;

namespace SlidEnglish.Server
{
    public partial class SlidEnglishContext : DbContext
    {
        public SlidEnglishContext()
        {
        }

        public SlidEnglishContext(DbContextOptions<SlidEnglishContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=slidenglish;Username=slidenglishuser;Password=slidenglish");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SlidEnglish.Server.Models.Word> Word { get; set; }
    }
}
