using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Data;
using PizzaClub.Web.Models.Main;
using PizzaClub.Web.Repositories;

namespace PizzaClub.Web.Pages.Make;

[Authorize(Roles = "User")]
public class Pizza : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    private readonly IMakePizzaRepository _pizzaInfoRepository;

    [BindProperty]
    public List<MakePizza> MakePizzas { get; set; }

    private string UserID { get; set; }

    public Pizza(SignInManager<IdentityUser> signInManager, IMakePizzaRepository makePizzaRepository)
    {
        _signInManager = signInManager;
        _pizzaInfoRepository = makePizzaRepository;
    }

    public async Task OnGet()
    {
        var UserIn = await _signInManager.UserManager.GetUserAsync(User);
        UserID = UserIn.Id;
        MakePizzas = (await _pizzaInfoRepository.GetAllAsync(UserID)).ToList();
    }
}