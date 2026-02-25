using Microsoft.Identity.Web;

namespace ACME.DataSvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration config = builder.Configuration;

            // Add services to the container.
            builder.Services.AddMicrosoftIdentityWebApiAuthentication(config);
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddCors(conf => {
                conf.AddPolicy("AllesMag", pol => { 
                    pol.AllowAnyHeader();
                    pol.AllowAnyMethod();
                    pol.AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllesMag");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
