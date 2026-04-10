using KhilaunaBazaar.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhilaunaBazaar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private static readonly List<Category> Categories = new()
    {
        new() { Slug = "action-figures", Name = "Action Figures", Description = "Superheroes & Characters", IconClass = "fa-robot" },
        new() { Slug = "dolls", Name = "Dolls & Accessories", Description = "Fashion & Baby Dolls", IconClass = "fa-doll" },
        new() { Slug = "building-blocks", Name = "Building Blocks", Description = "LEGO & Construction Sets", IconClass = "fa-cubes" },
        new() { Slug = "outdoor-toys", Name = "Outdoor Toys", Description = "Sports & Garden Toys", IconClass = "fa-baseball" },
        new() { Slug = "board-games", Name = "Board Games", Description = "Family & Strategy Games", IconClass = "fa-chess-board" },
        new() { Slug = "stuffed-animals", Name = "Stuffed Animals", Description = "Plush & Cuddly Friends", IconClass = "fa-paw" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Category>> GetAll() => Ok(Categories);

    [HttpGet("{slug}")]
    public ActionResult<Category> GetBySlug(string slug)
    {
        var category = Categories.FirstOrDefault(c => string.Equals(c.Slug, slug, StringComparison.OrdinalIgnoreCase));
        if (category == null)
            return NotFound();
        return Ok(category);
    }
}
