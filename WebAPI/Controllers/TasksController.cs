using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Repository.EntityFramework.Repositories;

namespace WebAPI.Controllers
{
    public class TasksController : ApiController
    {
        private ITaskRepository _taskRepository = new TaskRepository();

        // GET: api/Tasks
        [Route("api/tasks")]
        [HttpGet]
        public List<Task> GetTasks()
        {
            var tasks = _taskRepository.GetAll().ToList();

            return tasks;
        }
    }
}
