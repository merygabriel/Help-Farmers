using FarmerApp.Data.DAO;
using FarmerApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmerApp.API.Utils
{
    public static class DbMigrator
    {
        const string ADMIN_USER_NAME = "Doghs Agro";

        public static async Task MigrateDbAndPopulate(WebApplication app, WebApplicationBuilder builder)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FarmerDbContext>();
                await context.Database.MigrateAsync();

                if (!(await context.Set<UserEntity>().AnyAsync(x => x.Name == ADMIN_USER_NAME)))
                {
                    var userSeed = new UserEntity
                    {
                        Name = ADMIN_USER_NAME,
                        Email = Environment.GetEnvironmentVariable("SEED_USERNAME", EnvironmentVariableTarget.Process) ?? builder.Configuration["SeedUsername"],
                        Password = Environment.GetEnvironmentVariable("SEED_PASS", EnvironmentVariableTarget.Process) ?? builder.Configuration["SeedPass"]
                    };

                    await context.AddAsync(userSeed);
                    await context.SaveChangesAsync();
                }

                if (!(await context.Set<InvestorEntity>().AnyAsync(x => x.Name == ADMIN_USER_NAME)))
                {
                    var userSeed = new InvestorEntity
                    {
                        Name = "Doghs Agro",
                        User = await context.Set<UserEntity>().FirstOrDefaultAsync(x => x.Name == ADMIN_USER_NAME)
                    };

                    await context.AddAsync(userSeed);
                }

                if (context.ChangeTracker.HasChanges())
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
