using FarmerApp.API.Utils;
using FarmerApp.Core.Extensions;
using FarmerApp.Core.Utils;
using FarmerApp.Data.DAO;
using FarmerApp.Middlewares;
using Microsoft.EntityFrameworkCore;

#region Services

var builder = WebApplication.CreateBuilder(args);
var appSettings = new ApplicationSettings(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddCustomAuthentication(appSettings);
builder.Services.AddCustomServices();

builder.Services.AddDbContext<FarmerDbContext>(opts =>opts.UseSqlServer(appSettings.ConnectionString), ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

await DbMigrator.MigrateDbAndPopulate(app, builder);

#endregion

#region Pipeline

// Configure the HTTP request pipeline.
app.UseCors("MyPolicy");

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion
