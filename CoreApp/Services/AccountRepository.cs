using AutoMapper;
using CoreApp.Entities;
using CoreApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly capstoneContext _capstoneContext;

        public AccountRepository(IMapper mapper, capstoneContext capstoneContext)
        {
            _mapper = mapper;
            _capstoneContext = capstoneContext;
        }

        public void Register(UserRegistrationModel userRegistrationModel)
        {
            var user = _mapper.Map<User>(userRegistrationModel);
            user.UserType = 2;
            _capstoneContext.Add(user);
        }

        public User Login(UserLoginModel userLogin)
        {
            return _capstoneContext.User.Where(u => u.Email == userLogin.Email ).Where(u=> u.Password == userLogin.Password).First();
        }
    }
}
