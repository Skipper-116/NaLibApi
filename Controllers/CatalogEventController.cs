using NaLibApi.Models;
using NaLibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NaLibApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogEventController : ControllerBase
{
    private readonly CatalogEventService _catalogEventService;

    public CatalogEventController(CatalogEventService CatalogEventService) =>
        _catalogEventService = CatalogEventService;

    [HttpGet]
    public async Task<List<CatalogEvent>> Get() =>
        await _catalogEventService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CatalogEvent>> Get(string id)
    {
        var CatalogEvent = await _catalogEventService.GetAsync(id);

        if (CatalogEvent is null)
        {
            return NotFound();
        }

        return CatalogEvent;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CatalogEvent newCatalog)
    {
        await _catalogEventService.CreateAsync(newCatalog);

        return CreatedAtAction(nameof(Get), new { id = newCatalog.Id }, newCatalog);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CatalogEvent updatedBook)
    {
        var CatalogEvent = await _catalogEventService.GetAsync(id);

        if (CatalogEvent is null)
        {
            return NotFound();
        }

        updatedBook.Id = CatalogEvent.Id;

        await _catalogEventService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var CatalogEvent = await _catalogEventService.GetAsync(id);

        if (CatalogEvent is null)
        {
            return NotFound();
        }

        await _catalogEventService.RemoveAsync(id);

        return NoContent();
    }
}