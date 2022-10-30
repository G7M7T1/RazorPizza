using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Models;

namespace RazorPizza.Pages.Forms;

public class CustomPizza : PageModel
{
    [BindProperty]
    public PizzasModel Pizza { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Pizza.BasePrice = 8;

        Pizza.FinalPrice += Pizza.BasePrice;

        if (Pizza.ExtraCheese) Pizza.FinalPrice += 5;
        if (Pizza.ExtraSauce) Pizza.FinalPrice += 2;
        if (Pizza.Peperoni) Pizza.FinalPrice += 3;
        if (Pizza.Mushroom) Pizza.FinalPrice += 3;
        if (Pizza.Pineapple) Pizza.FinalPrice += 3;
        if (Pizza.Ham) Pizza.FinalPrice += 3;
        if (Pizza.Beef) Pizza.FinalPrice += 5;

        return RedirectToPage("/Checkout/Checkout", new
        {
            Pizza
        });
    }
}