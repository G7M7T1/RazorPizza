using System.ComponentModel;
namespace PizzaClub.Web.Models.Main;

public class PizzaInfo
{
    public Guid Id { get; set; }
    
    public float Price { get; set; }

    public string Heading { get; set; }
    
    [DisplayName("Page Title")]
    public string PageTitle { get; set; }
    
    public string Description { get; set; }
    
    [DisplayName("Short Description")]
    public string ShortDescription { get; set; }

    [DisplayName("Image Url")]
    public string ImageUrl { get; set; }
    
    [DisplayName("Url Address")]
    public string UrlAddress { get; set; }
    
    // Switch Visible
    public bool Visible { get; set; }
}