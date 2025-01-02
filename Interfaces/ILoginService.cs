using ElderlyCareSupport.Client.Models;

namespace ElderlyCareSupport.Client.Interfaces;

public interface ILoginService
{
    Task<ApiResponseWrapper<T>?> AuthenticateUser<T>(string email, string password, UserType userType);
}