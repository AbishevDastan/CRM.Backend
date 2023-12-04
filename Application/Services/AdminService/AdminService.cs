using Application.AuthenticationHandlers.HashManager;
using Application.AuthenticationHandlers.JwtManager;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IHashManager _hashManager;
        private readonly IJwtManager _jwtManager;

        public AdminService(IAdminRepository adminRepository, IHashManager hashManager, IJwtManager jwtManager)
        {
            _adminRepository = adminRepository;
            _hashManager = hashManager;
            _jwtManager = jwtManager;
        }

        public async Task<int> Register(Admin admin, string password)
        {
            if (await _adminRepository.AnyAdminExists())
            {
                throw new Exception("Регистрация невозможна, поскольку Администратор уже существует в системе.");
            }

            await _adminRepository.Register(admin, password);

            return admin.Id;
        }

        public async Task<string> Login(string email, string password)
        {
            var user  = await _adminRepository.GetAdminByEmail(email);

            if (user == null)
            {
                throw new Exception("Администратор с такой эл. почтой не найден.");
            }
            else if (!_hashManager.VerifyHash(password, user.Hash, user.Salt))
            {
                throw new Exception("Пароль неверен, попробуйте ещё раз.");
            }
            else
            {
                return _jwtManager.GenerateJwtToken(user);
            }
        }
    }
}
