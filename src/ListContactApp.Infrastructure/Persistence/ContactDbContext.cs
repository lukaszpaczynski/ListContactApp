namespace ListContactApp.Infrastructure.Persistence
{
	public class ContactDbContext : IdentityDbContext
	{
        public DbSet<Contact> Contacts { get; set; }

        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Contact>()
				.HasIndex(c => c.Email)
				.IsUnique();
		}
	}
}
