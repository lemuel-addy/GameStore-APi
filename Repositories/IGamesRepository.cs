using GameStore.API.Entities;

namespace GameStore.API.Repositories
{
    public interface IGamesRepository
    {
        Task CreateAsync(Game game);
        Task DeleteAsync(int id);
        Task<Game?> GetAsync(int id);
        Task<IEnumerable<Game>> GetAllAsync();
        Task UpdateAsync(Game updatedGame);
    }
}