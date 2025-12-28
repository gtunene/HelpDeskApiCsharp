namespace HelpDesk.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TicketCategoryModel> TicketCategories { get; set; }
        public DbSet<TicketCommentModel> TicketComments { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<TicketPriorityModel> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasIndex(v => v.Email)
                .IsUnique();

            modelBuilder.Entity<TicketCategoryModel>()
                .HasIndex(v => v.Name)
                .IsUnique();

            modelBuilder.Entity<TicketModel>()
                .HasOne(v => v.Category)
                .WithMany()
                .HasForeignKey(v => v.CategoryId);

            modelBuilder.Entity<TicketCommentModel>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<TicketModel>()
                .HasOne(v => v.Priority)
                .WithMany()
                .HasForeignKey(v => v.PriorityId);

            modelBuilder.Entity<TicketModel>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId);
        }
    }
}