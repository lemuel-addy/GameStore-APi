using System;
using GameStore.API.Entities;
//Stores the list of games with the functions you can run on them
namespace GameStore.API.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new(){
    new Game()
    {
        Id = 1,
        Name = "Street Fighter",
        Genre = "Action",
        Price = 1.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = "https://placehold.co/100"
    },

    new Game()
    {
        Id = 2,
        Name = "Street Fighter 2",
        Genre = "Action",
        Price = 1.99M,
        ReleaseDate = new DateTime(1991,2,1),
        ImageUri = "https://placehold.co/100"
    },

    new Game()
    {
        Id = 3,
        Name = "Final Fantasy",
        Genre = "Roleplaying",
        Price = 12.99M,
        ReleaseDate = new DateTime(2010,4,2),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 4,
        Name = "FIFA 2023",
        Genre = "Sports",
        Price = 10.99M,
        ReleaseDate = new DateTime(2010,2,1),
        ImageUri = "https://placehold.co/100"
    }
    };
        public async Task<IEnumerable<Game>> GetAllAsync()//IEnumerable RETURNS A LIST OF OBJECTS THAT CAN BE READ IN SEQUENTIAL
        {
            return await Task.FromResult(games);
        }

        public async Task<Game?> GetAsync(int id)
        {
            return await Task.FromResult(games.Find(game => game.Id == id));
        }

        public async Task CreateAsync(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;

            await Task.CompletedTask;

        }

        public async Task DeleteAsync(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);

            await Task.CompletedTask;

        }

    }
}

