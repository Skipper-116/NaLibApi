using NaLibApi.Models;
using NaLibApi.DTO;
using NaLibApi.Data;
using Microsoft.EntityFrameworkCore;

namespace NaLibApi.Services;

public class UserService
{
    private readonly NaLibDbContext _dbContext;

    public UserService(NaLibDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetAsync(int id)
    {
        return await _dbContext.Users
            .Where(x => x.Id == id && !x.Voided)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetAsync(string username)
    {
        return await _dbContext.Users.Where(x => x.Email == username && !x.Voided).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(UserDto data, int userId)
    {
        var newUser = new User
        {
            Email = data.Email,
            FirstName = data.FirstName,
            LastName = data.LastName,
            Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Voided = false,
            CreatedBy = userId,
            LibraryId = data.LibraryId,
            UpdatedBy = null
        };
        _dbContext.Users.Add(newUser);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UserDto data, int userId)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null || user.Voided)
        {
            throw new Exception("User not found");
        }
        user.Email = data.Email;
        user.FirstName = data.FirstName;
        user.LastName = data.LastName;
        user.LibraryId = data.LibraryId;
        user.UpdatedAt = DateTime.Now;
        user.UpdatedBy = userId;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id, int userId)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null || user.Voided)
        {
            throw new Exception("User not found");
        }
        user.Voided = true;
        user.VoidedOn = DateTime.Now;
        user.VoidedBy = userId;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> AuthenticateAsync(CredentialDto data)
    {
        var user = await _dbContext.Users
            .Where(x => x.Email == data.Username && !x.Voided)
            .FirstOrDefaultAsync();
        if (user == null || !BCrypt.Net.BCrypt.Verify(data.Password, user.Password))
        {
            return null;
        }
        return user;
    }

    public async Task UpdatePasswordAsync(int id, string oldPassword, string newPassword)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null || user.Voided)
        {
            throw new Exception("User not found");
        }
        if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
        {
            throw new Exception("Invalid old password");
        }
        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        user.UpdatedAt = DateTime.Now;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}