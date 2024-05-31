using Microsoft.AspNetCore.Authorization;
using NaLibApi.Models;
using NaLibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NaLibApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogService _catalogService;

    public CatalogController(CatalogService CatalogService) =>
        _catalogService = CatalogService;

    [HttpGet]
    [Authorize]
    public async Task<List<Catalog>> Get() =>
        await _catalogService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    public async Task<ActionResult<Catalog>> Get(string id)
    {
        var Catalog = await _catalogService.GetAsync(id);

        if (Catalog is null)
        {
            return NotFound();
        }

        return Catalog;
    }

    // search by term action method
    [HttpGet("search/{searchTerm}")]
    public async Task<List<Catalog>> Search(string searchTerm) =>
        await _catalogService.SearchAsync(searchTerm);

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(Catalog newCatalog)
    {
        await _catalogService.CreateAsync(newCatalog);

        return CreatedAtAction(nameof(Get), new { id = newCatalog.Id }, newCatalog);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, Catalog updatedBook)
    {
        var Catalog = await _catalogService.GetAsync(id);

        if (Catalog is null)
        {
            return NotFound();
        }

        updatedBook.Id = Catalog.Id;

        await _catalogService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var Catalog = await _catalogService.GetAsync(id);

        if (Catalog is null)
        {
            return NotFound();
        }

        await _catalogService.RemoveAsync(id);

        return NoContent();
    }
}