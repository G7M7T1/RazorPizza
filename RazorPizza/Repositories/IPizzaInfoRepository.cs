using PizzaClub.Web.Models.Main;

namespace PizzaClub.Web.Repositories;

public interface IPizzaInfoRepository
{
    Task<IEnumerable<PizzaInfo>> GetAllAsync();

    // Find Where GetOneOrDefault
    Task<PizzaInfo> GetAsync(Guid id);
    
    // Find Url
    Task<PizzaInfo> GetAsync(string urlAddress);

    // Add Pizza
    Task<PizzaInfo> AddAsync(PizzaInfo pizza);

    // Update Pizza
    Task<PizzaInfo> UpdateAsync(PizzaInfo pizza);

    // Delete Pizza
    Task<bool> DeleteAsync(Guid id);
}