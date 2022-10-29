using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Models;

namespace RazorPizza.Pages;

public class Pizza : PageModel
{
    // ExtraCheese 5;
    // ExtraSauce 2;
    // Peperoni 3;
    // Mushroom 3;
    // Pineapple 3;
    // Ham 3;
    // Beef 5;
    public List<PizzasModel> fakePizzaDB = new List<PizzasModel>()
    {
        new PizzasModel()
        {
            ImageTitle = "https://storage.pizzapizza.ca/phx2/ppl_images/products/en/2x/Pepperoni.png?cache_key=27",
            PizzaName = "PEPPERONI",
            BasePrice = (float)7.99,
            Peperoni = true,
            FinalPrice = (float)10.99,
            Description = "The all-time favourite - It doesn't get any more iconic than this. Savoury pepperoni, home style sauce"
        },

        new PizzasModel()
        {
            ImageTitle = "https://storage.pizzapizza.ca/phx2/ppl_images/products/en/2x/Pepperoni.png?cache_key=27",
            PizzaName = "Cheese1",
            BasePrice = (float)7.99,
            ExtraCheese = true,
            FinalPrice = (float)12.99,
            Description = "The all-time favourite - It doesn't get any more iconic than this. Savoury pepperoni, home style sauce"
        },

        new PizzasModel()
        {
            ImageTitle = "https://storage.pizzapizza.ca/phx2/ppl_images/products/en/2x/Pepperoni.png?cache_key=27",
            PizzaName = "Cheese2",
            BasePrice = (float)7.99,
            ExtraCheese = true,
            FinalPrice = (float)12.99,
            Description = "The all-time favourite - It doesn't get any more iconic than this. Savoury pepperoni, home style sauce"
        },

        new PizzasModel()
        {
            ImageTitle = "https://storage.pizzapizza.ca/phx2/ppl_images/products/en/2x/Pepperoni.png?cache_key=27",
            PizzaName = "Cheese3",
            BasePrice = (float)7.99,
            ExtraCheese = true,
            FinalPrice = (float)12.99,
            Description = "The all-time favourite - It doesn't get any more iconic than this. Savoury pepperoni, home style sauce"
        }
    };

    public void OnGet()
    {
    }
}