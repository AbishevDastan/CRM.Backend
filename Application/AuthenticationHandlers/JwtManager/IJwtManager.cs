using Domain.Entities;

namespace Application.AuthenticationHandlers.JwtManager
{
    public interface IJwtManager
    {
        string GenerateJwtToken(Admin admin);
    }
}
