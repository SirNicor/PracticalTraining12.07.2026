using EFRepository;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddInfrastructureServices(builder.Configuration);
    var app = builder.Build();      
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<PracticeDbContext>();
        dbContext.Database.Migrate(); 
    }
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
