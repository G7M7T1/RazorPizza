using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Models;

namespace RazorPizza.Pages.Forms;

public class CustomPizza : PageModel
{
    [BindProperty]
    public PizzasModel Pizza { get; set; }
    public float PizzaPrice { get; set; }
    public float BasePrice { get; set; }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        BasePrice = 8;
        
        PizzaPrice = BasePrice;

        if (Pizza.ExtraCheese) PizzaPrice += 5;
        if (Pizza.ExtraSauce) PizzaPrice += 2;
        if (Pizza.Peperoni) PizzaPrice += 3;
        if (Pizza.Mushroom) PizzaPrice += 3;
        if (Pizza.Pineapple) PizzaPrice += 3;
        if (Pizza.Ham) PizzaPrice += 3;
        if (Pizza.Beef) PizzaPrice += 5;

        return RedirectToPage("/Checkout/Checkout", new
        {
            Pizza.PizzaName,
            BasePrice,
            PizzaPrice
        });
    }
}