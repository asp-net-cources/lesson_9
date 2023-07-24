using Lesson9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson9.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly List<Product> _products = new()
    {
        new() { Name = "Молоко", Description = "Простоквашино", Count = 100 },
        new() { Name = "Часы", Description = "Ролекс", Count = 1 },
        new() { Name = "Книга", Description = "Властелин колец", Count = 10 }
    };
    
    [HttpGet("{id}")]
    public Product GetProduct([FromRoute]int id)
    {
        return _products[id];
    }
    
    [HttpPost("{id}")]
    public Product UpdateProduct([FromRoute]int id, [FromBody] Product updatedProduct)
    {
        _products[id] = updatedProduct;
        return _products[id];
    }
}