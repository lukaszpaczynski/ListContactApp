namespace ListContactApp.MVC.Extensions
{
	public static class DependencyInjection
	{
		public static void AddMvcServices(this IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact API", Version = "v1" });
				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});
		}

		public static void UseMvcServices(this WebApplication app)
		{
			if (!app.Environment.IsDevelopment())
			{
				app.UseHsts();
			}

			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("./v1/swagger.json", "Contact API");
			});

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseExceptionHandlerMiddleware();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Contact}/{action=Index}/{id?}");

			app.MapRazorPages();
		}
	}
}
