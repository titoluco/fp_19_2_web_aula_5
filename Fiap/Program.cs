using Fiap.Log;
using Fiap.Middlewares;
using Fiap.Services;
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
            //service.AddSingleton
            //service.AddScoped
            service.AddTransient<ILogCred, LogCred>();
            service.AddTransient<INoticiaService, NoticiaService>();

            service.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseLog();

            //app.UseMiddleware<MeuLogMiddleware>();


            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                    name: "padrao, default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );

                });

            // app.MapWhen(
            //     context => context.Request.Query.ContainsKey("parametro"),
            //     myapp =>
            //     {
            //         myapp.Run(async (context) =>
            //             { await context.Response.WriteAsync("admin");

            //             });
            //     });


            // app.Map("/admin", myapp =>
            // {
            //     myapp.Run(async (context) =>
            //     {
            //         await context.Response.WriteAsync("admin");
            //     });
            // });

            // app.Use(async (context, next) =>
            //{

            //    var teste = 123;
            //    await next.Invoke();
            //    var retorno = 123;
            //});

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("boa noite");
            // });




            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("boa noite Fiap !");

            //});
        }




    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuLogMiddleware>();
        }
    }
}


