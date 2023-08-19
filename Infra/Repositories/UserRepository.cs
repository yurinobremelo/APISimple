using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appdbcontext) {
            _appDbContext = appdbcontext;
        }
        public User CreateUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
           return _appDbContext.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            User? user = _appDbContext.Users.Where(b => b.Id == id)
                    .FirstOrDefault();

            return user?? new User();
        }
        public User UpdateUser(User user)
        {
            User userDB = _appDbContext.Users.First(User=> User.Id == user.Id);
            userDB.Numero = user.Numero;
            userDB.Endereco = user.Endereco;

            _appDbContext.SaveChanges();
                       
            return userDB;
        }
        public void DeleteUser(Guid id)
        {
            _appDbContext.Users.Where(d => d.Id == id).ExecuteDelete();
            _appDbContext.SaveChanges();
        }

    }
}
