using Microsoft.EntityFrameworkCore;
using DescartesDB.Models;
using DescartesDB.Data;

namespace DescartesDB
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
            //2. donner la connection
            string myConnectionString = builder.Configuration.GetConnectionString("DbConn");
            builder.Services.AddDbContext<RemaxDBContext>(options => { options.UseSqlServer(myConnectionString); });
            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}