using System;
using GameStore.API.Dtos;
//to map the Dtos to the Game entity
namespace GameStore.API.Entities
{
	public static class EntityExtensions
	{
		public static GameDto AsDto(this Game game)
		{
			return new GameDto
				(
				game.Id,
				game.Name,
				game.Genre,
				game.Price,
				game.ReleaseDate,
				game.ImageUri
				);
		}
	}
}

