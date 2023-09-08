

namespace teset09062
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // add images
            builder.Services.AddControllersWithViews();
            var app = builder.Build();


            // Add SqlServer service, so the DbContext can use it
            
            // ??? this does not work?
            //builder.Services.AddDbContext<MotionDbContext>(options=>options.UseSqlServer(
            //        builder.Configuration.GetConnectionString("DefaultConnection")));
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}