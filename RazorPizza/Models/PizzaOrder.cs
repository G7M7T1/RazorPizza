using System.ComponentModel.DataAnnotations;

namespace RazorPizza.Models;

public class PizzaOrder
{
    [Key]
    public int Id { get; set; }
    
    public string PizzaName { get; set; }
    
    public float BasePrice { get; set; }
}