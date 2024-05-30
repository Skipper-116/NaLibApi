using NaLibApi.Data;
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

    public async Task<List<ContactType>> GetAsync() =>
        await _dbContext.ContactTypes.ToListAsync();


    public async Task<ContactType?> GetAsync(int id) =>
        await _dbContext.ContactTypes.FindAsync(id);

    public async Task CreateAsync(ContactType newContactType)
    {
        _dbContext.ContactTypes.Add(newContactType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, ContactType updatedContactType)
    {
        _dbContext.ContactTypes.Update(updatedContactType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var contactType = await _dbContext.ContactTypes.FindAsync(id);
        if (contactType != null)
        {
            _dbContext.ContactTypes.Remove(contactType);
            await _dbContext.SaveChangesAsync();
        }
    }
}