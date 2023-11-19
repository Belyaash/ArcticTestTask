using Application;
using Application.Interfaces;
using Microsoft.Extensions.Options;
using Persistence;
using System.Reflection;

namespace Notes.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors(
                options =>
                {
                    options.AddPolicy("AllowAll", policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowAnyOrigin();
                    });
                }
            );
            

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<IApplicationDbContext>();
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

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
