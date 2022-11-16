using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.ViewModels;

namespace PizzaClub.Web.Pages;

public class RegisterModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManger;

    [BindProperty]
    public Register RegisterViewModel { get; set; }

    public RegisterModel(UserManager<IdentityUser> userManger)
    {
        _userManger = userManger;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var user = new IdentityUser
        {
            UserName = RegisterViewModel.Username,
            Email = RegisterViewModel.Email
        };

        var identityResult = await _userManger.CreateAsync(user, RegisterViewModel.Password);

        if (identityResult.Succeeded) 
        {
            var AddRoleResult =  await _userManger.AddToRoleAsync(user, "User");

            if (AddRoleResult.Succeeded)
            {
                return RedirectToPage("/Index");
            }
        }

        return Page();
    }
}