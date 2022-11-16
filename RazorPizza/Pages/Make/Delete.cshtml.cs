using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.Main;
using PizzaClub.Web.Repositories;

namespace PizzaClub.Web.Pages.Make;

[Authorize(Roles = "User")]
public class Delete : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IMakePizzaRepository _makePizzaRepository;
    
    private string UserID;

    public Delete(SignInManager<IdentityUser> signInManager, IMakePizzaRepository makePizzaRepository)
    {
        _signInManager = signInManager;
        _makePizzaRepository = makePizzaRepository;
    }
    public async Task<IActionResult> OnGet(Guid id)
    {
        var UserIn = await _signInManager.UserManager.GetUserAsync(User);
        UserID = UserIn.Id;

        var MakePizzaInDb = await _makePizzaRepository.GetAsync(id);

        if (MakePizzaInDb.UserID == UserID)
        {
            await _makePizzaRepository.DeleteAsync(id);

            return RedirectToPage("/Make/Pizza");
        }

        return RedirectToPage("/Make/Pizza");
    }
}