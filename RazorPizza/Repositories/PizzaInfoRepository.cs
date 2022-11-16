using Microsoft.EntityFrameworkCore;
using PizzaClub.Web.Data;
using PizzaClub.Web.Models.Main;

namespace PizzaClub.Web.Repositories;

public class PizzaInfoRepository:IPizzaInfoRepository
{
    private readonly PizzaDbContext _pizzaDbContext;
    
    public PizzaInfoRepository(PizzaDbContext pizzaDbContext)
    {
        _pizzaDbContext = pizzaDbContext;
    }
    
    public async Task<IEnumerable<PizzaInfo>> GetAllAsync()
    {
        return await _pizzaDbContext.PizzaInfos.ToListAsync();
    }

    public async Task<PizzaInfo> GetAsync(Guid id)
    {
        return await _pizzaDbContext.PizzaInfos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PizzaInfo> GetAsync(string urlAddress)
    {
        return await _pizzaDbContext.PizzaInfos.FirstOrDefaultAsync(x => x.UrlAddress == urlAddress);
    }

    public async Task<PizzaInfo> AddAsync(PizzaInfo pizzaInfo)
    {
        await _pizzaDbContext.AddAsync(pizzaInfo);
        await _pizzaDbContext.SaveChangesAsync();
        return pizzaInfo;
    }

    public async Task<PizzaInfo> UpdateAsync(PizzaInfo pizzaInfo)
    {
        var existingPizzaInDb = await _pizzaDbContext.PizzaInfos.FirstOrDefaultAsync(x => x.Id == pizzaInfo.Id);

        if (existingPizzaInDb != null)
        {
            existingPizzaInDb.Price = pizzaInfo.Price;
            existingPizzaInDb.Heading = pizzaInfo.Heading;
            existingPizzaInDb.PageTitle = pizzaInfo.PageTitle;
            existingPizzaInDb.Description = pizzaInfo.Description;
            existingPizzaInDb.ShortDescription = pizzaInfo.ShortDescription;
            existingPizzaInDb.ImageUrl = pizzaInfo.ImageUrl;
            existingPizzaInDb.UrlAddress = pizzaInfo.UrlAddress;
            existingPizzaInDb.Visible = pizzaInfo.Visible;
        }

        await _pizzaDbContext.SaveChangesAsync();
        return existingPizzaInDb;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingPizzaInDb = await _pizzaDbContext.PizzaInfos.FindAsync(id);

        if (existingPizzaInDb != null)
        {
            _pizzaDbContext.PizzaInfos.Remove(existingPizzaInDb);
            await _pizzaDbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}