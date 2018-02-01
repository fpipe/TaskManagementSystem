using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Repository.EntityFramework.Repositories;

namespace TaskManagementSystem.WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        IProjectRepository _projectRepository = new ProjectRepository();
        ICustomerRepository _customerRepository = new CustomerRepository();
        // GET: Projects

        public ActionResult ProjetWithLeftTasks()
        {
            var dbProjects = _projectRepository.GetAll();
            Dictionary<string, int> report = new Dictionary<string, int>();
            foreach (var project in dbProjects)
            {
                var tempUser = project.Name;
                var leftTasks = project.Tasks.Where(x => x.Status.ToString() != "Done").ToList().Count;
                report.Add(tempUser, leftTasks);
            }
            return View(report);
        }

        public ActionResult ListAll()
        {
            var projects = _projectRepository.GetAll();

            return View(projects);
        }
        public ActionResult ListTasksForProject(int id)
        {
            var project = _projectRepository.GetById(id);
            return View(project.Tasks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.customers = _customerRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            
            if (ModelState.IsValid)
            {
                if (_projectRepository.Create(project))
                    return RedirectToAction("ListAll");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.customers = _customerRepository.GetAll();
            try
            {
                var project = _projectRepository.GetById(id);
                return View(project);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Project project)
        {
            if (ModelState.IsValid)
            {
                if (_projectRepository.Update(project))
                {
                    return RedirectToAction("ListAll");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var project = _projectRepository.GetById(id);

            return View(project);
        }

        [HttpPost]
        public ActionResult Delete(Project project)
        {
            if (_projectRepository.Delete(project.ID))
                return RedirectToAction("ListAll");

            return View();
        }
    }
}