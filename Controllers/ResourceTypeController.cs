using NaLibApi.Models;
using NaLibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NaLibApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ResourceTypeController : ControllerBase
{
    private readonly ResourceTypeService _resourceTypeService;

    public ResourceTypeController(ResourceTypeService ResourceTypeService) =>
        _resourceTypeService = ResourceTypeService;

    [HttpGet]
    public async Task<List<ResourceType>> Get() =>
        await _resourceTypeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ResourceType>> Get(string id)
    {
        var ResourceType = await _resourceTypeService.GetAsync(id);

        if (ResourceType is null)
        {
            return NotFound();
        }

        return ResourceType;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ResourceType newCatalog)
    {
        await _resourceTypeService.CreateAsync(newCatalog);

        return CreatedAtAction(nameof(Get), new { id = newCatalog.Id }, newCatalog);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ResourceType updatedBook)
    {
        var ResourceType = await _resourceTypeService.GetAsync(id);

        if (ResourceType is null)
        {
            return NotFound();
        }

        updatedBook.Id = ResourceType.Id;

        await _resourceTypeService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ResourceType = await _resourceTypeService.GetAsync(id);

        if (ResourceType is null)
        {
            return NotFound();
        }

        await _resourceTypeService.RemoveAsync(id);

        return NoContent();
    }
}