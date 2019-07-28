using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SlidEnglish.Shared.Word> Word { get; set; }
    }
}
