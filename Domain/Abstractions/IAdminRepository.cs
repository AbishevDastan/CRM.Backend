using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IAdminRepository
    {
        Task<int> Register(Admin admin, string password);
        Task<bool> AnyAdminExists();
        Task<Admin> GetAdminByEmail(string email);
    }
}
