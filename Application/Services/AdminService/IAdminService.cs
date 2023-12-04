using Domain.Entities;

namespace Application.Services.AdminService
{
    public interface IAdminService
    {
        Task<int> Register(Admin admin, string password);
        Task<string> Login(string email, string password);

    }
}
