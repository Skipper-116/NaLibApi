using NaLibApi.Data;
using NaLibApi.DTO;
using NaLibApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace NaLibApi.Services;

public class ContactTypeService
{
    private readonly NaLibDbContext _dbContext;

    public ContactTypeService(NaLibDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ContactType>> GetAsync()
    {
        return await _dbContext.ContactTypes
            .Where(x => !x.Voided)
            .ToListAsync();
    }


    public async Task<ContactType?> GetAsync(int id)
    {
        return await _dbContext.ContactTypes
            .Where(x => x.Id == id && !x.Voided)
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(ContactTypeDto data)
    {   
        var newContactType = new ContactType
        {
            Name = data.Name,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Voided = false
        }; 
        _dbContext.ContactTypes.Add(newContactType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, ContactTypeDto data)
    {
        var contactType = await _dbContext.ContactTypes.FindAsync(id);
        if (contactType == null || contactType.Voided)
        {
            throw new Exception("ContactType not found");
        }
        contactType.Name = data.Name;
        contactType.UpdatedAt = DateTime.Now;
        _dbContext.ContactTypes.Update(contactType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var contactType = await _dbContext.ContactTypes.FindAsync(id);
        if (contactType != null)
        {
            contactType.Voided = true;
            contactType.VoidedOn = DateTime.Now;
            _dbContext.ContactTypes.Remove(contactType);
            await _dbContext.SaveChangesAsync();
        }
    }
}