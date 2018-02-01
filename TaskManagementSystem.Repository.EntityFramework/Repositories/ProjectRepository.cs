using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;

namespace TaskManagementSystem.Repository.EntityFramework.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        DataBase_UserManagementSystem db = new DataBase_UserManagementSystem();
        ICustomerRepository _customerRepository = new CustomerRepository();

        public bool DeleteTaskFromProject(int projectId,int taskId)
        {
            var dbProject = GetById(projectId);
            dynamic tempTasks = db.Tasks.Where(x => x.ID != taskId).ToList();
            dbProject.Tasks = tempTasks;
            db.SaveChanges();
            return true;
        }

        //Create
        public bool Create(Project project)
        {
            var dbCustomer = _customerRepository.GetById(project.CustomerId);

            if(dbCustomer != null)
            {
                project.DateCreated = DateTime.Now;
                project.IsActive = true;

                db.Projects.Add(project);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        //Delete
        public bool Delete(int id)
        {
            var dbProject = GetById(id);

            if(dbProject != null)
            {
                dbProject.IsActive = false;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Get all
        public List<Project> GetAll()
        {
            return db.Projects.Where(x => x.IsActive == true).ToList();
        }

        //get by ID
        public Project GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        //Update
        public bool Update(Project project)
        {
            var dbProject = GetById(project.ID);

            if(dbProject != null)
            {
                dbProject.Customer = project.Customer;
                dbProject.CustomerId = project.CustomerId;
                dbProject.Name = project.Name;
                dbProject.Tasks = project.Tasks;

                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
