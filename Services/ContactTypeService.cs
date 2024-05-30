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

    public async Task<ContactType> CreateAsync(ContactTypeDto data, int userId)
    {   
        var newContactType = new ContactType
        {
            Name = data.Name,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Voided = false,
            CreatedBy = userId,
            UpdatedBy = null
        }; 
        _dbContext.ContactTypes.Add(newContactType);
        await _dbContext.SaveChangesAsync();
        return newContactType;
    }

    public async Task UpdateAsync(int id, ContactTypeDto data, int userId)
    {
        var contactType = await _dbContext.ContactTypes.FindAsync(id);
        if (contactType == null || contactType.Voided)
        {
            throw new Exception("ContactType not found");
        }
        contactType.Name = data.Name;
        contactType.UpdatedAt = DateTime.Now;
        contactType.UpdatedBy = userId;
        _dbContext.ContactTypes.Update(contactType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id, int userId)
    {
        var contactType = await _dbContext.ContactTypes.FindAsync(id);
        if (contactType != null)
        {
            contactType.Voided = true;
            contactType.VoidedOn = DateTime.Now;
            contactType.VoidedBy = userId;
            _dbContext.ContactTypes.Update(contactType);
            await _dbContext.SaveChangesAsync();
        }
    }
}