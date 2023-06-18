using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore_BE.Data;
using ProductStore_BE.Models;

namespace ProductStore_BE.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController : Controller
{
    private readonly ProductStoreDbContext _dbContext;
    public ProductsController(ProductStoreDbContext productStoreDbContext)
    {
        _dbContext = productStoreDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _dbContext.Products.ToListAsync();

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        product.Id = Guid.NewGuid();

        await _dbContext.Products.AddAsync(product);

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    [Route("{id:Guid")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if(product == null)
            return NotFound();

        return Ok(product);
    }
}
