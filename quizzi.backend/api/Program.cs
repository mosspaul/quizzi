using core.Gateways;
using core.Gateways.Interfaces;
using core.Managers;
using core.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add Core layer -> make function later
builder.Services.AddHttpClient<IOpenTriviaGateway, OpenTriviaGateway>();
builder.Services.AddScoped<IOpenTriviaGateway, OpenTriviaGateway>();
builder.Services.AddScoped<ITriviaManager, TriviaManager>();

// Add Data layer -> make function later

// builder.Services.AddDbContext<MossFlashDbContext>(opt =>
//     opt.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Order matters — must be before UseAuthorization and MapControllers
app.UseRouting();
app.UseCors("AllowAngular");

// using (var scope = app.Services.CreateScope())
// {
//     var database = scope.ServiceProvider.GetRequiredService<MossFlashDbContext>();

//     for (int i = 0; i < 10; i++)
//     {
//         try
//         {
//             database.Database.Migrate();
//             break;
//         }
//         catch (Exception ex)
//         {
// 	    Console.WriteLine($"{ex.Message}");
//             Console.WriteLine("DB not ready yet...");
//             Thread.Sleep(5000);
//         }
//     }
// }

app.MapControllers();
app.Run();
