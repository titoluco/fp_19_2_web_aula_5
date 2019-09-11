using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fiap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            //Console.WriteLine("Hello World!");
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Statup>()
                .Build();
        }
    }

    public class Statup
    {


        public void ConfigureServices(IServiceCollection service)
        {
            service.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                    name: "padrao, default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

                });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("boa noite Fiap !");

            //});
        }
    }
}
