using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;

namespace TaskManagementSystem.Repository.EntityFramework.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        DataBase_UserManagementSystem db = new DataBase_UserManagementSystem();

        //Create
        public bool Create(Customer customer)
        {
            customer.DateCreated = DateTime.Now;
            customer.IsActive = true;

            db.Customers.Add(customer);
            db.SaveChanges();
           
            return true;
        }

        //Delete
        public bool Delete(int id)
        {
            var dbCustomer = GetById(id);
            if(dbCustomer != null)
            {
                dbCustomer.IsActive = false;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        //Get all
        public List<Customer> GetAll()
        {
            return db.Customers.Where(x => x.IsActive == true).ToList();
        }

        //Get by ID
        public Customer GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        //Update
        public bool Update(Customer customer)
        {
            var dbCustomer = GetById(customer.ID);

            if(dbCustomer != null)
            {
                dbCustomer.Company = customer.Company;
                dbCustomer.Email = customer.Email;
                dbCustomer.Name = customer.Name;
                dbCustomer.Projects = customer.Projects;
                dbCustomer.IsActive = customer.IsActive;

                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
