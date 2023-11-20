using Application;
using Application.Interfaces;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence;
using System.Reflection;
using WebApi.MediatRHangfireBridge;

namespace Notes.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Adding mediatr and entityframework dependencyinjections
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Services.AddControllers();
            //Adding hangfire with postgres connection and with custom usage of mediatr
            builder.Services.AddHangfire(x =>
            {
                x.UsePostgreSqlStorage(builder.Configuration["DbConnection"]);
                x.UseMediatR(); 
            });
                
            builder.Services.AddHangfireServer();

            //Adding generation of xml documentation for swagger
            builder.Services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
            

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = "swagger";
                config.SwaggerEndpoint("v1/swagger.json", "API");
            });
            app.UseHangfireDashboard("/hangfire");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
