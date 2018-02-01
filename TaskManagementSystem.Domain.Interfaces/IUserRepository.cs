using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
        User ValidateUsername(string username);
        User ValidatePassword(string password);
        bool ActivateUser(int id);
        bool DeactivateUser(int id);
    }
}
