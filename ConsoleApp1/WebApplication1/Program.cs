using EFRepository;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<PracticeDbContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("EFRepository")));
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
