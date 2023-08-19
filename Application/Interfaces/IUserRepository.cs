using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(Guid id);

        User CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUser(Guid id);
    }
}