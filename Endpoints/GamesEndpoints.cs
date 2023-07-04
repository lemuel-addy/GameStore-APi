using System;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Repositories;
//decouples the requests and application logic (endpoints) from the repository (management of data)
namespace GameStore.API.Endpoints
{
	public static class GamesEndpoints //class for extension methods
	{
     
        const string GetGameEndpointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
		{

            //creating route groups
            
            var group = routes.MapGroup("/games")
    .WithParameterValidation(); //activate endpoint filtering for validation

            //Getting
            
            group.MapGet("/", async (IGamesRepository repository) =>   //Injecting the Repository depency into the routes
            (await repository.GetAllAsync()).Select(game => game.AsDto())); //we are not returning entities but Dtos

            group.MapGet("/{id}", async (IGamesRepository repository, int id) => 
            {
                Game? game = await repository.GetAsync(id);
                return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
            })
            .WithName(GetGameEndpointName);

            //Adding
            group.MapPost("/", async (IGamesRepository repository, CreateGameDto gameDto) => //receives game Dto instead of Game entity
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUri = gameDto.ImageUri,
                    Price = gameDto.Price

                };
                await repository.CreateAsync(game);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

            //Updating
            //app.MapPut("/games/{id}", (int id, Game UpdatedGame) =>
            //{
            //    Game? existingGame = games.Find(game => game.Id == id);
            //    if (existingGame is null)
            //    {
            //        return Results.NotFound();
            //    }

            //    existingGame.Name = UpdatedGame.Name;
            //    existingGame.ReleaseDate = UpdatedGame.ReleaseDate;
            //    existingGame.Price = UpdatedGame.Price;
            //    existingGame.ImageUri = UpdatedGame.ImageUri;
            //    existingGame.Genre = UpdatedGame.Genre;
            //    return Results.NoContent();
            //});

            group.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = await repository.GetAsync(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                
                existingGame.Name = updatedGameDto.Name;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ImageUri = updatedGameDto.ImageUri;
                existingGame.Genre = updatedGameDto.Genre;

                await repository.UpdateAsync(existingGame);
                return Results.NoContent();

            });

            //Deleting
            //app.MapDelete("games/{id}", (int id) =>
            //{
            //    Game? existingGame = games.Find(game => game.Id == id);
            //    if (existingGame is not null)
            //    {
            //        games.Remove(existingGame);
            //        return Results.Ok("Deleted");
            //    }
            //    return Results.NotFound();
            //});
            group.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
            {
                Game? existingGame = await repository.GetAsync(id);
                if (existingGame is not null)
                {
                    await repository.DeleteAsync(id);
                    return Results.Ok("Deleted");
                }
                return Results.NotFound();
            });

            return group;
        }
	}
}


//async model for endpoints, repositories and entity framework core and InitializeDb in DataExtensions