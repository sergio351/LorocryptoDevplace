using lorodevplace.Models;

namespace lorodevplace.Services.Interfaces
{
    public interface IConsumeUserService
    {
        Task<UserLoginDto> Login(UserLoginDto dto);
    }
}
