using Library.Application;
using Library.Application.Common.Mappings;
using Library.Application.Interfaces;
using Library.Persistence;
using Library.WebAPI.Middleware;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Library.WebAPI
{
    public class Program
    {       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
            });


            //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //builder.Services.AddAutoMapper(typeof(ILibraryDbContext).Assembly);

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            //builder.Services.AddTransient<ExceptionHandlingMiddleware>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            //CreateDbIfNotExists(app);
            using (var scope = app.Services.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                // use dbInitializer
                DbInitializer.Initialize(dbInitializer);
            }
            app.UseExceptionHandlingMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(config => 
            { 
                config.RoutePrefix = String.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Library API");
            });

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            

            app.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LibraryDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }        
        }
    }
}