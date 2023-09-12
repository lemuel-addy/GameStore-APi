//using System.Text;
using GameStore.API.Data;
using GameStore.API.Endpoints;
//using GameStore.API.Options;
using GameStore.API.Repositories;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//register instance for dependency injection
builder.Services.AddScoped<IGamesRepository, EntityFrameworkGamesRepository>(); //Singleton Lifetime is throughout whole application independent of requests
var connString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddNpgsql<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
