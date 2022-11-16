using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaClub.Web.Models.Main;
using PizzaClub.Web.Repositories;

namespace PizzaClub.Web.Pages;

public class Pizza : PageModel
{
    private readonly IPizzaInfoRepository _pizzaInfoRepository;
    
    public List<PizzaInfo> PizzaList { get; set; }

    public Pizza(IPizzaInfoRepository pizzaInfoRepository)
    {
        _pizzaInfoRepository = pizzaInfoRepository;
    }
    public async Task OnGet()
    {
        PizzaList = (await _pizzaInfoRepository.GetAllAsync())?.ToList();
    }
}