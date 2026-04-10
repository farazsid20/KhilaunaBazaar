using KhilaunaBazaar.Api.Models;
using KhilaunaBazaar.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KhilaunaBazaar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductStore _store;

    public ProductsController(ProductStore store)
    {
        _store = store;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => Ok(_store.GetAll());

    [HttpGet("featured")]
    public ActionResult<IEnumerable<Product>> GetFeatured([FromQuery] int count = 4) =>
        Ok(_store.GetFeatured(count));

    [HttpGet("category/{categorySlug}")]
    public ActionResult<IEnumerable<Product>> GetByCategory(string categorySlug)
    {
        var products = _store.GetByCategory(categorySlug);
        if (products.Count == 0)
            return NotFound();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _store.GetById(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}
