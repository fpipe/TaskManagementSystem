using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Repository.EntityFramework
{
    public class DataBase_UserManagementSystem : DbContext
    {
        public DataBase_UserManagementSystem() /*: base("SQLConnection")*/ { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
