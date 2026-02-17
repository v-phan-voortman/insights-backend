using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using insights_backend.Services;

namespace insights_backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var jsonPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
        if (string.IsNullOrWhiteSpace(jsonPath))
            throw new Exception("GOOGLE_APPLICATION_CREDENTIALS environment variable is not set.");

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile(jsonPath),
            ProjectId = builder.Configuration["Firebase:ProjectId"]
        });

        builder.Services.AddSingleton<PushNotificationService>();
        builder.Services.AddControllers()
                .AddJsonOptions(
                    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
            app.MapOpenApi();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}