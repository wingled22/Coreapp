using CoreApp.Entities;
using CoreApp.Models;

namespace CoreApp.Services
{
    public interface IAccountRepository
    {
        void Register(UserRegistrationModel userRegistrationModel);
        User Login(UserLoginModel userLogin);
    }
}