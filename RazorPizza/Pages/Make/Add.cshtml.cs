using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.Main;
using PizzaClub.Web.Models.ViewModels;
using PizzaClub.Web.Repositories;

namespace PizzaClub.Web.Pages.Make;

public class Add : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IMakePizzaRepository _makePizzaRepository;
    private string UserID;

    public float TotalPrice { get; set; }
    public float BasePrice { get; set; }

    [BindProperty]
    public AddMakePizza AddMakePizza { get; set; }

    public Add(SignInManager<IdentityUser> signInManager, IMakePizzaRepository makePizzaRepository)
    {
        _signInManager = signInManager;
        _makePizzaRepository = makePizzaRepository;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var UserIn = await _signInManager.UserManager.GetUserAsync(User);
        UserID = UserIn.Id;
        
        TotalPrice = 0;
        BasePrice = (float)8.99;
        TotalPrice += BasePrice;

        if (AddMakePizza.Bacon)
        {
            TotalPrice += 3;
        }
        
        if (AddMakePizza.ButterChicken)
        {
            TotalPrice += 3;
        }
        
        if (AddMakePizza.GrilledChicken)
        {
            TotalPrice += 3;
        }
        
        if (AddMakePizza.GroundBeef)
        {
            TotalPrice += 4;
        }
        
        if (AddMakePizza.ItalianHam)
        {
            TotalPrice += 2;
        }
        
        if (AddMakePizza.Pepperoni)
        {
            TotalPrice += 3;
        }
        
        if (AddMakePizza.Salami)
        {
            TotalPrice += 3;
        }
        
        if (AddMakePizza.Sausage)
        {
            TotalPrice += 3;
        }
        
        // Veg
        if (AddMakePizza.Broccoli)
        {
            TotalPrice += 3;
        }
        
        if (AddMakePizza.RedPeppers)
        {
            TotalPrice += 2;
        }
        
        if (AddMakePizza.Mushrooms)
        {
            TotalPrice += 4;
        }
        
        if (AddMakePizza.GreenOlives)
        {
            TotalPrice += 2;
        }
        
        if (AddMakePizza.GreenPeppers)
        {
            TotalPrice += 2;
        }
        
        if (AddMakePizza.RedOnions)
        {
            TotalPrice += 1;
        }
        
        if (AddMakePizza.Pineapple)
        {
            TotalPrice += 2;
        }
        
        if (AddMakePizza.Spinach)
        {
            TotalPrice += 2;
        }
        
        if (AddMakePizza.ExtraCheese)
        {
            TotalPrice += 4;
        }
        
        if (AddMakePizza.FetaCheese)
        {
            TotalPrice += 4;
        }
        
        if (AddMakePizza.GoatCheese)
        {
            TotalPrice += 4;
        }

        if (string.IsNullOrWhiteSpace(AddMakePizza.PizzaName))
        {
            AddMakePizza.PizzaName = "My New Pizza";
        }

        var MakePizzaNew = new MakePizza()
        {
            PizzaName = AddMakePizza.PizzaName,
            FinalPrice = TotalPrice,

            Bacon = AddMakePizza.Bacon,
            ButterChicken = AddMakePizza.ButterChicken,
            GrilledChicken = AddMakePizza.GrilledChicken,
            GroundBeef = AddMakePizza.GroundBeef,
            ItalianHam = AddMakePizza.ItalianHam,
            Pepperoni = AddMakePizza.Pepperoni,
            Salami = AddMakePizza.Salami,
            Sausage = AddMakePizza.Sausage,

            Broccoli = AddMakePizza.Broccoli,
            RedPeppers = AddMakePizza.RedPeppers,
            Mushrooms = AddMakePizza.Mushrooms,
            GreenOlives = AddMakePizza.GreenOlives,
            GreenPeppers = AddMakePizza.GreenPeppers,
            RedOnions = AddMakePizza.RedOnions,
            Pineapple = AddMakePizza.Pineapple,
            Spinach = AddMakePizza.Spinach,

            ExtraCheese = AddMakePizza.ExtraCheese,
            FetaCheese = AddMakePizza.FetaCheese,
            GoatCheese = AddMakePizza.GoatCheese,
            
            UserID = UserID
        };

        await _makePizzaRepository.AddAsync(MakePizzaNew);
        
        return RedirectToPage("/Make/Pizza");
    }
}