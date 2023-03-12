using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using NavalWar.Business.Game;
using NavalWar.Business.BateauServ;
using NavalWar.Business.ShotServ;
using NavalWar.DAL;
using NavalWar.DAL.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Cors 

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AutoCorsPolicy",
                      policy =>
                      {
                          policy.SetIsOriginAllowed(origin => true)
                          //.WithOrigins("http://localhost:3000", "https://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// login de la database
string[] logins = System.IO.File.ReadAllLines("data\\dataBaseAccess.txt");

// Nos builders DLA

builder.Services.AddDbContext<NavalContext>(options => options.UseSqlServer("Server=tcp:ballejos.database.windows.net,1433;Initial Catalog=NavalWatDataBase;Persist Security Info=False;User ID=" + logins[0] + ";Password=" + logins[1] + "/;Encrypt=True;", providerOptions => providerOptions.EnableRetryOnFailure()));
// Nos builders business
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IBateauService, BateauService>();
builder.Services.AddScoped<IPlayerDbRepository, PlayerDbRepository>();
builder.Services.AddScoped<ISessionDbRepository, SessionDbRepository>();
builder.Services.AddScoped<IShotService, ShotService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AutoCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
