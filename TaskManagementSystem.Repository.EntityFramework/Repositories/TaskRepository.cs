using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
//using System.Threading.Tasks;

namespace TaskManagementSystem.Repository.EntityFramework.Repositories
{
   
    public class TaskRepository : ITaskRepository
    {
        DataBase_UserManagementSystem db = new DataBase_UserManagementSystem();
        IProjectRepository _projectRepository = new ProjectRepository();
        IUserRepository _userRepository = new UserRepository();
        //status of a task
        public enum TaskStatus
        {
            ToDo = 0,
            InProgress = 1,
            InTesting = 2,
            Done = 3
        }

        //type of a task
        //public enum TaskType
        //{
        //    Task = 0,
        //    Bug = 1,
        //    Other = 2
        //}
        public List<string> GetStatuses()
        {
            List<string> statuses = new List<string>();
            foreach (var value in Enum.GetValues(typeof(Task.TaskStatus)))
            {
                statuses.Add(value.ToString());
            }
            return statuses;
        }
        public List<string> GetTypes()
        {
            List<string> types = new List<string>();
            foreach (var value in Enum.GetValues(typeof(Task.TaskType)))
            {
                types.Add(value.ToString());
            }
            return types;
        }
        //Create
        public bool Create(Task task)
        {
            var taskProject = _projectRepository.GetById(task.ProjectId);
            var taskUser = _userRepository.GetById(task.UserId);
            if(taskProject != null && taskUser != null)
            {
                TimeSpan difference = task.EndDateTime.Subtract(task.StartDateTime);
                task.EstimatedHours = (int) difference.TotalHours;
                task.DateCreated = DateTime.Now;
                task.IsActive = true;

                db.Tasks.Add(task);
                db.SaveChanges();

                return true;
            }
            return false;
            
        }

        //Delete
        public bool Delete(int id)
        {
            var dbTask = GetById(id);
            var projectId = dbTask.ProjectId;
            //dont work because in the model use ICollection for Tasks in project
            //_projectRepository.DeleteTaskFromProject(projectId,id);
            if (dbTask != null)
            {
                dbTask.IsActive = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Get all
        public List<Task> GetAll()
        {
            return db.Tasks.Where(x => x.IsActive == true).ToList();
        }

        //Get asignee
        public string GetAssignee(int taskId)
        {
            var dbTask = GetById(taskId);

            return dbTask.User.ToString();
        }

        //Get by id
        public Task GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        //Get comments
        public List<TaskComment> GetComments(int taskId)
        {
            var dbTask = GetById(taskId);

            return dbTask.Comments.ToList();
        }

        //Update
        public bool Update(Task task)
        {
            var dbTask = GetById(task.ID);
            if(dbTask != null)
            {
                dbTask.Comments = task.Comments;
                dbTask.Description = task.Description;
                TimeSpan difference = task.EndDateTime.Subtract(task.StartDateTime);
                dbTask.EstimatedHours = (int)difference.TotalHours;
                dbTask.StartDateTime = task.StartDateTime;
                dbTask.EndDateTime = task.EndDateTime;
                dbTask.Name = task.Name;
                dbTask.Project = task.Project;
                dbTask.ProjectId = task.ProjectId;
                dbTask.Type = task.Type;
                dbTask.User = task.User;
                dbTask.UserId = task.UserId;
                dbTask.Status = task.Status;

                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
