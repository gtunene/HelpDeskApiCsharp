using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasIndex(v => v.Email)
                .IsUnique();

            modelBuilder.Entity<TicketCategory>()
                .HasIndex(v => v.Name)
                .IsUnique();

            modelBuilder.Entity<Ticket>()
                .HasOne(v => v.Category)
                .WithMany()
                .HasForeignKey(v => v.CategoryId);

            modelBuilder.Entity<TicketComment>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(v => v.Priority)
                .WithMany()
                .HasForeignKey(v => v.PriorityId);

            modelBuilder.Entity<Ticket>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId);
        }
    }
}