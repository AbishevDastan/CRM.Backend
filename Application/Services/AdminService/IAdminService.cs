using Application.UseCases.Admin;
using Domain.Entities;

namespace Application.Services.AdminService
{
    public interface IAdminService
    {
        Task<int> Register(Admin admin, string password);
        Task<TokenModel> Login(string email, string password);
    }
}
