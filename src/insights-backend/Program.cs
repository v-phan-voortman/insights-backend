
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.Net;

namespace insights_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Console.WriteLine(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));

            var jsonPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

            if (string.IsNullOrWhiteSpace(jsonPath))
            {
                throw new Exception("GOOGLE_APPLICATION_CREDENTIALS environment variable is not set.");
            }

            var credential = GoogleCredential.FromFile(jsonPath);

            FirebaseApp.Create(new AppOptions
            {
                Credential = credential,
                ProjectId = builder.Configuration["Firebase:ProjectId"]
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
