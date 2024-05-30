namespace ListContactApp.Infrastructure.Extensions
{
	public static class DependencyInjection
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("ContactDbConnectionString")));

			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<ContactDbContext>();

			services.AddScoped<IContactRepository, ContactRepository>();
		}
	}
}
