namespace RazorPizza.Models;

public class PizzasModel
{
    public string ImageTitle { get; set; }
    public string PizzaName { get; set; }
    public float BasePrice { get; set; }
    public bool ExtraSauce { get; set; }
    public bool ExtraCheese { get; set; }
    public bool Peperoni { get; set; }
    public bool Mushroom { get; set; }
    public bool Pineapple { get; set; }
    public bool Ham { get; set; }
    public bool Beef { get; set; }
    public float FinalPrice { get; set; }
}