using PizzaClub.Web.Models.Main;

namespace PizzaClub.Web.Repositories;

public interface IMakePizzaRepository
{
    Task<IEnumerable<MakePizza>> GetAllAsync(string userID);

    Task<MakePizza> AddAsync(MakePizza makePizza);
    
    Task<MakePizza> UpdateAsync(MakePizza makePizza);

    Task<bool> DeleteAsync(Guid id);

    Task<MakePizza> GetAsync(Guid id);
}