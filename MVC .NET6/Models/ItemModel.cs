using Newtonsoft.Json;

namespace MVC_.NET6.Models;

public class ItemModel
{
    public int Id { get; set; } 
    
    public string? Name { get; init; }
    
    public string? Description { get; init; }

    public int Cost { get; set; }
    
    public int Amount { get; set; }
    
    public string? Action { get; set; }
}