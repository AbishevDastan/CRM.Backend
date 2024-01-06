//using Application.AuthenticationHandlers.HashManager;
//using Application.Contracts.Persistence;
//using Domain;
//using Microsoft.EntityFrameworkCore;
//using Persistence.DatabaseContext;
//using Persistence.Repositories.Common;

//namespace Infrastructure.Repositories
//{
//    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
//    {
//        private readonly IHashManager _hashManager;

//        public AdminRepository(CrmDatabaseContext context,
//            IHashManager hashManager) : base(context)
//        {
//            _hashManager = hashManager;
//        }

//        public async Task<Admin> GetAdminByEmail(string email)
//        {
//            var admin = await _context.Admins
//                .FirstOrDefaultAsync(admin => admin.Email.ToLower() == email.ToLower());
//            if (admin == null)
//            {
//                throw new Exception("Адрес эл. почты неверен.");
//            }
//            return admin;
//        }

//        public async Task<bool> AnyAdminExists()
//        {
//            if (await _context.Admins.AnyAsync())
//            {
//                return true;
//            }
//            return false;
//        }

//        public async Task<int> Register(Admin admin, string password)
//        {
//            _hashManager.CreateHash(password, out byte[] hash, out byte[] salt);
//            admin.Hash = hash;
//            admin.Salt = salt;
//            _context.Admins.Add(admin);
//            await _context.SaveChangesAsync();

//            return admin.Id;
//        }
//    }
//}
