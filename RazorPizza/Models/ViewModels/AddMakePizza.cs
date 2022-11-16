using System.ComponentModel;

namespace PizzaClub.Web.Models.ViewModels;

public class AddMakePizza
{
    [DisplayName("Pizza Name")]
    public string PizzaName { get; set; }
    
    [DisplayName("Final Price")]
    public float FinalPrice { get; set; }
    
    public bool Bacon { get; set; }
    
    [DisplayName("Butter Chicken")]
    public bool ButterChicken { get; set; }
    
    [DisplayName("Grilled Chicken")]
    public bool GrilledChicken { get; set; }
    
    [DisplayName("Ground Beef")]
    public bool GroundBeef { get; set; }
    
    [DisplayName("Italian Ham")]
    public bool ItalianHam { get; set; }
    
    public bool Pepperoni { get; set; }
    
    public bool Salami { get; set; }
    
    public bool Sausage { get; set; }
    
    public bool Broccoli { get; set; }

    [DisplayName("Red Peppers")]
    public bool RedPeppers { get; set; }
    
    public bool Mushrooms { get; set; }
    
    [DisplayName("Green Olives")]
    public bool GreenOlives { get; set; }
    
    [DisplayName("Green Peppers")]
    public bool GreenPeppers { get; set; }
    
    [DisplayName("Red Onions")]
    public bool RedOnions { get; set; }
    
    public bool Pineapple { get; set; }
    
    public bool Spinach { get; set; }
    
    [DisplayName("Extra Cheese")]
    public bool ExtraCheese { get; set; }
    
    [DisplayName("Feta Cheese")]
    public bool FetaCheese { get; set; }
    
    [DisplayName("Goat Cheese")]
    public bool GoatCheese { get; set; }
}