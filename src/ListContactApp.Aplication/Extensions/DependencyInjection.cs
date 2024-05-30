namespace ListContactApp.Aplication.Extensions
{
	public static class DependencyInjection
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
			});

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                   .AddFluentValidationAutoValidation()
                   .AddFluentValidationClientsideAdapters();
        }
	}
}
