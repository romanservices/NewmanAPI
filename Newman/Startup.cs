using Microsoft.EntityFrameworkCore;
using Newman.EntityModels;
using Newman.Helpers;
using Newman.Services;

namespace Newman
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {

        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Command line migrations
            services.AddDbContext<SqlLiteDbContext>();
        }
         
        public void Configure(IApplicationBuilder appBuilder)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddTransient<IAppService, AppService>();
            builder.Services.AddDbContext<SqlLiteDbContext>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            using (var scope =
                   appBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using var context = scope.ServiceProvider.GetService<SqlLiteDbContext>();
                context?.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
