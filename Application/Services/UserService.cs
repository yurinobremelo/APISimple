using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
           user = _userRepository.CreateUser(user);
           return user;
        }

        public List<User> GetAllUsers()
        {

           var users = _userRepository.GetAllUsers();
           return users;
        }

        public User GetUserById(Guid id)
        {
           User user= _userRepository.GetUserById(id);
           return user;

        }
        public User UpdateUser(User user)
        {
            User _user = _userRepository.UpdateUser(user);
            return _user;

        }
        public void DeleteUser(Guid id)
        {
            _userRepository.DeleteUser(id);

        }



    }
}
