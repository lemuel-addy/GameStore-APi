using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Entities
{
	public class Game
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)] //The name cant be more than 50 char
		public required string Name { get; set; }
        [Required]
        [StringLength(20)]
        public required string Genre { get; set; }
		[Range(1,100)]
		public decimal Price { get; set; }
		public DateTime ReleaseDate { get; set; }
		[Url]//has to be a web url
		[StringLength(100)]
		public required string ImageUri { get; set; }

	}
}

//Endpoint filter nuget pkg needed for Validation (MinimalApis.Extensions)