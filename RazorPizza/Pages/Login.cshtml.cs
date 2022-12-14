using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.ViewModels;

namespace PizzaClub.Web.Pages;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    [BindProperty]
    public Login LoginViewModel { get; set; }

    public LoginModel(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public void OnGet() {}
    
    public async Task<IActionResult> OnPost(string ReturnUrl)
    {
        var signInResult =  await _signInManager.PasswordSignInAsync(
            LoginViewModel.Username, LoginViewModel.Password, false, false);

        if (signInResult.Succeeded)
        {
            if (!string.IsNullOrWhiteSpace(ReturnUrl))
            {
                return RedirectToPage(ReturnUrl);
            }
            return RedirectToPage("Index");
        }
        else
        {
            return Page();
        }
    }
}