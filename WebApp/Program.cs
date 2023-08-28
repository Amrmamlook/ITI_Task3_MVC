using WebApp.Repositry;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IUser, UserData>();
            builder.Services.AddSession();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
         name: "default",
        pattern: "{controller=User}/{action=Show}/{id?}");

            #region Custom MiddleWare

            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("1) MiddleWare1==Hello\n");
            //    await next.Invoke();
            //    await HttpContext.Response.WriteAsync("2) MiddleWare5==Hello\n");
            //});
            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("2) MiddleWare1==Hello\n");
            //    await next.Invoke();
            //    await HttpContext.Response.WriteAsync("3) MiddleWare4==Hello\n");
            //});
            //app.Run(async (HttpContext) =>
            //{
            //    await HttpContext.Response.WriteAsync("Terminate\n");
            //}); 
            #endregion
            app.Run();
        }
    }
}