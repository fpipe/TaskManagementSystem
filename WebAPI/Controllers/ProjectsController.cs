using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Repository.EntityFramework.Repositories;


namespace WebAPI.Controllers
{
    public class ProjectsController : ApiController
    {
        private IProjectRepository _projectRepository = new ProjectRepository();

        // GET: api/Projects
        [Route("api/projects")]
        [HttpGet]
        public List<Project> Get()
        {
            var projects = _projectRepository.GetAll().ToList();

            return projects;
        }
    }
}
