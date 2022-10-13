using lorodevplace.Models;

namespace lorodevplace.Services.Interfaces
{
    public interface IConsumeApiUser
    {
        Task<UserLoginDto> Login(UserLoginDto dto);
        Task<UserRegisterDto> Register(UserRegisterDto user);
    }
}
