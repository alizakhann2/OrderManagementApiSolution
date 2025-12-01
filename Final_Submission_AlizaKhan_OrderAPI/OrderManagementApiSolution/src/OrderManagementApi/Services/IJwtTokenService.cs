using OrderManagementApi.Models;

namespace OrderManagementApi.Services;

public interface IJwtTokenService
{
    string GenerateToken(ApplicationUser user);
}
