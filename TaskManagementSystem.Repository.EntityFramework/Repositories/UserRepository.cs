using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;

namespace TaskManagementSystem.Repository.EntityFramework.Repositories
{
    public enum Type { User = 0, Admin = 1 }

    public class UserRepository : IUserRepository
    {
        DataBase_UserManagementSystem db = new DataBase_UserManagementSystem();

        public User ValidateUsername(string username)
        {
            var tempUser = db.Users.FirstOrDefault(x => x.Username == username);
            return tempUser;
        }
        public User ValidatePassword(string password)
        {
            var tempUser = db.Users.FirstOrDefault(x => x.Password == password);
            return tempUser;
        }

        public bool ActivateUser(int id)
        {
            var dbUser = GetById(id);
            if(dbUser != null)
            {
                dbUser.IsActivated = true;
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeactivateUser(int id)
        {
            var dbUser = GetById(id);
            if (dbUser != null)
            {
                dbUser.IsActivated = false;
                db.SaveChanges();

                return true;
            }

            return false;
        }
        
        //Create
        public bool Create(User user)
        {
            user.DateCreated = DateTime.Now;
            user.IsActive = true;
            user.IsActivated = false;
            user.Type = (int)Type.User;

            db.Users.Add(user);
            db.SaveChanges();

            return true;
        }

        //Delete
        public bool Delete(int id)
        {
            var dbUser = GetById(id);
            if(dbUser != null)
            {
                dbUser.IsActive = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Get all
        public List<User> GetAll()
        {
            return db.Users.Where(x => x.IsActive == true).ToList();
        }

        //Get by ID
        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        //Update
        public bool Update(User user)
        {
            var dbUser = GetById(user.ID);

            if(dbUser != null)
            {
                dbUser.Email = user.Email;
                dbUser.Password = user.Password;
                dbUser.Type = user.Type;
                dbUser.Username = user.Username;
                dbUser.Tasks = user.Tasks;
                dbUser.IsActive = user.IsActive;
                dbUser.Type = user.Type;

                return true;
            }
            return false;
        }
    }
}
