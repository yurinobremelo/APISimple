using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(Guid id);

        User CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUser(Guid id);
    }
}
