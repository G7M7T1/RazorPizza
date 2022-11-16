using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.Main;
using PizzaClub.Web.Models.ViewModels;
using PizzaClub.Web.Repositories;

namespace PizzaClub.Web.Pages.Admin.Pizzas;

[Authorize(Roles = "Admin")]
public class Add : PageModel
{
    private readonly IPizzaInfoRepository _pizzaInfoRepository;

    [BindProperty]
    public IFormFile ImageFile { get; set; }
    
    [BindProperty]
    public AddPizzaInfo AddPizzaInfoRequset { get; set; }

    public Add(IPizzaInfoRepository pizzaInfoRepository)
    {
        _pizzaInfoRepository = pizzaInfoRepository;
    }
    
    public void OnGet() {}

    public async Task<IActionResult> OnPost()
    {
        var newPizzaInfo = new PizzaInfo()
        {
            Heading = AddPizzaInfoRequset.Heading,
            Price = AddPizzaInfoRequset.Price,
            PageTitle = AddPizzaInfoRequset.PageTitle,
            ShortDescription = AddPizzaInfoRequset.ShortDescription,
            Description = AddPizzaInfoRequset.Description,
            ImageUrl = AddPizzaInfoRequset.ImageUrl,
            UrlAddress = AddPizzaInfoRequset.UrlAddress,
            Visible = AddPizzaInfoRequset.Visible
        };

        await _pizzaInfoRepository.AddAsync(newPizzaInfo);
        
        return RedirectToPage("/Admin/Pizzas/List");
    }
}