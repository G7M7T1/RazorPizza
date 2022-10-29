using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Data;
using RazorPizza.Models;

namespace RazorPizza.Pages.Checkout;

[BindProperties(SupportsGet = true)]
public class Checkout : PageModel
{
    private readonly ApplicationDbContext _context;
    
    public float PizzaPrice { get; set; }
    public float BasePrice { get; set; }
    public string PizzaName { get; set; }
    public string ImageTitle { get; set; }
    
    public PizzasModel Pizza { get; set; }

    public Checkout(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        if (string.IsNullOrWhiteSpace(PizzaName))
        {
            PizzaName = "Custom Pizza";
        }

        if (string.IsNullOrWhiteSpace(ImageTitle))
        {
            ImageTitle = "New Pizza";
        }

        PizzaOrder pizzaOrder = new PizzaOrder();
        pizzaOrder.PizzaName = PizzaName;
        pizzaOrder.BasePrice = PizzaPrice;

        _context.PizzaOrders.Add(pizzaOrder);
        _context.SaveChanges();
    }
}