using Microsoft.EntityFrameworkCore;
using PizzaClub.Web.Data;
using PizzaClub.Web.Models.Main;

namespace PizzaClub.Web.Repositories;

public class MakePizzaRepository:IMakePizzaRepository
{
    private readonly PizzaDbContext _pizzaDbContext;

    public MakePizzaRepository(PizzaDbContext pizzaDbContext)
    {
        _pizzaDbContext = pizzaDbContext;
    }
    
    public async Task<IEnumerable<MakePizza>> GetAllAsync(string userID)
    {
        return await (_pizzaDbContext.MakePizzas.Where(x => x.UserID == userID)).ToListAsync();
    }

    public async Task<MakePizza> AddAsync(MakePizza makePizza)
    {
        await _pizzaDbContext.AddAsync(makePizza);
        await _pizzaDbContext.SaveChangesAsync();

        return makePizza;
    }

    public async Task<MakePizza> UpdateAsync(MakePizza makePizza)
    {
        var existingMakePizzaInDb = await _pizzaDbContext.MakePizzas.FirstOrDefaultAsync(x => x.Id == makePizza.Id);

        if (existingMakePizzaInDb != null)
        {
            // 10 Total Base And Meat
            existingMakePizzaInDb.PizzaName = makePizza.PizzaName;
            existingMakePizzaInDb.FinalPrice = makePizza.FinalPrice;
            existingMakePizzaInDb.Bacon = makePizza.Bacon;
            existingMakePizzaInDb.ButterChicken = makePizza.ButterChicken;
            existingMakePizzaInDb.GrilledChicken = makePizza.GrilledChicken;
            existingMakePizzaInDb.GroundBeef = makePizza.GroundBeef;
            existingMakePizzaInDb.ItalianHam = makePizza.ItalianHam;
            existingMakePizzaInDb.Pepperoni = makePizza.Pepperoni;
            existingMakePizzaInDb.Salami = makePizza.Salami;
            existingMakePizzaInDb.Sausage = makePizza.Sausage;
            
            // Veg
            existingMakePizzaInDb.Broccoli = makePizza.Broccoli;
            existingMakePizzaInDb.RedPeppers = makePizza.RedPeppers;
            existingMakePizzaInDb.Mushrooms = makePizza.Mushrooms;
            existingMakePizzaInDb.GreenOlives = makePizza.GreenOlives;
            existingMakePizzaInDb.GreenPeppers = makePizza.GreenPeppers;
            existingMakePizzaInDb.RedOnions = makePizza.RedOnions;
            existingMakePizzaInDb.Pineapple = makePizza.Pineapple;
            existingMakePizzaInDb.Spinach = makePizza.Spinach;
            
            // cheese
            existingMakePizzaInDb.ExtraCheese = makePizza.ExtraCheese;
            existingMakePizzaInDb.FetaCheese = makePizza.FetaCheese;
            existingMakePizzaInDb.GoatCheese = makePizza.GoatCheese;
        }

        await _pizzaDbContext.SaveChangesAsync();
        return existingMakePizzaInDb;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingMakePizzaInDb = await _pizzaDbContext.MakePizzas.FindAsync(id);

        if (existingMakePizzaInDb != null)
        {
            _pizzaDbContext.MakePizzas.Remove(existingMakePizzaInDb);
            await _pizzaDbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<MakePizza> GetAsync(Guid id)
    {
        return await _pizzaDbContext.MakePizzas.FirstOrDefaultAsync(x => x.Id == id);
    }
}