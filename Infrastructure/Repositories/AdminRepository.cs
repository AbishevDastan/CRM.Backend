using Application.AuthenticationHandlers.HashManager;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHashManager _hashManager;

        public AdminRepository(ApplicationDbContext dbContext, IHashManager hashManager)
        {
            _dbContext = dbContext;
            _hashManager = hashManager;
        }

        public async Task<Admin> GetAdminByEmail(string email)
        {
            var admin = await _dbContext.Admins
                .FirstOrDefaultAsync(admin => admin.Email.ToLower() == email.ToLower());
            if (admin == null)
            {
                throw new Exception("Адрес эл. почты неверен.");
            }
            return admin;
        }

        public async Task<bool> AnyAdminExists()
        {
            if (await _dbContext.Admins.AnyAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<int> Register(Admin admin, string password)
        {
            _hashManager.CreateHash(password, out byte[] hash, out byte[] salt);
            admin.Hash = hash;
            admin.Salt = salt;
            _dbContext.Admins.Add(admin);
            await _dbContext.SaveChangesAsync();

            return admin.Id;
        }
    }
}
