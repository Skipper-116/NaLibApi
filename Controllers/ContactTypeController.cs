using NaLibApi.Models;
using NaLibApi.DTO;
using NaLibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NaLibApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ContactTypeController : ControllerBase
{
    private readonly ContactTypeService _contactTypeService;

    public ContactTypeController(ContactTypeService ContactTypeService) =>
        _contactTypeService = ContactTypeService;

    [HttpGet]
    public async Task<List<ContactType>> Get() =>
        await _contactTypeService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactType>> Get(int id)
    {
        var ContactType = await _contactTypeService.GetAsync(id);

        if (ContactType is null)
        {
            return NotFound();
        }

        return ContactType;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ContactTypeDto newContactType)
    {
        await _contactTypeService.CreateAsync(newContactType);

        return CreatedAtAction(nameof(Get), new { id = newContactType.Id }, newContactType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ContactTypeDto updatedContactType)
    {
        var ContactType = await _contactTypeService.GetAsync(id);

        if (ContactType is null)
        {
            return NotFound();
        }

        await _contactTypeService.UpdateAsync(id, updatedContactType);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ContactType = await _contactTypeService.GetAsync(id);

        if (ContactType is null)
        {
            return NotFound();
        }

        await _contactTypeService.RemoveAsync(id);

        return NoContent();
    }
}