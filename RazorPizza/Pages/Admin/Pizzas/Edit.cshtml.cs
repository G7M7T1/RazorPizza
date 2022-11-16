using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.Main;
using PizzaClub.Web.Repositories;

namespace PizzaClub.Web.Pages.Admin.Pizzas;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IPizzaInfoRepository _pizzaInfoRepository;
    
    [BindProperty]
    public PizzaInfo PizzaInfo { get; set; }
    
    [BindProperty]
    public IFormFile ImageFile { get; set; }

    public EditModel(IPizzaInfoRepository pizzaInfoRepository)
    {
        _pizzaInfoRepository = pizzaInfoRepository;
    }
    public async Task OnGet(Guid id)
    {
        PizzaInfo = await _pizzaInfoRepository.GetAsync(id);
    }

    public async Task<IActionResult> OnPostEdit()
    {
        await _pizzaInfoRepository.UpdateAsync(PizzaInfo);
        return RedirectToPage("/Admin/Pizzas/List");
    }

    public async Task<IActionResult> OnPostDelete()
    {
        var deleted = await _pizzaInfoRepository.DeleteAsync(PizzaInfo.Id);

        if (deleted)
        {
            return RedirectToPage("/Admin/Pizzas/List");
        }

        return Page();
    }
}