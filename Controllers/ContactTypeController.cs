using Microsoft.AspNetCore.Authorization;
using NaLibApi.Models;
using NaLibApi.DTO;
using NaLibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace NaLibApi.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class ContactTypeController : ControllerBase
{
    private readonly ContactTypeService _contactTypeService;

    public ContactTypeController(ContactTypeService contactTypeService) =>
        _contactTypeService = contactTypeService;

    [HttpGet]
    public async Task<List<ContactType>> Get() =>
        await _contactTypeService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactType>> Get(int id)
    {
        var contactType = await _contactTypeService.GetAsync(id);

        if (contactType is null)
        {
            return NotFound();
        }

        return contactType;
    }

    [HttpPost]
    public async Task<ActionResult<ContactType>> Post(ContactTypeDto data)
    {
        var userId = HttpContext.Items["UserId"] != null ? int.Parse(HttpContext.Items["UserId"].ToString()) : 0;
        var result = await _contactTypeService.CreateAsync(data, userId);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ContactTypeDto updatedContactType)
    {
        var userId = HttpContext.Items["UserId"] != null ? int.Parse(HttpContext.Items["UserId"].ToString()) : 0;
        var contactType = await _contactTypeService.GetAsync(id);

        if (contactType is null)
        {
            return NotFound();
        }

        await _contactTypeService.UpdateAsync(id, updatedContactType, userId);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = HttpContext.Items["UserId"] != null ? int.Parse(HttpContext.Items["UserId"].ToString()) : 0;
        var contactType = await _contactTypeService.GetAsync(id);

        if (contactType is null)
        {
            return NotFound();
        }

        await _contactTypeService.RemoveAsync(id, userId);

        return NoContent();
    }
}