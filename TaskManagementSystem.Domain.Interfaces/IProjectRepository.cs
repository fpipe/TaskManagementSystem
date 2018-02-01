using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Project GetById(int id);
        bool Create(Project project);
        bool Update(Project project);
        bool Delete(int id);
        bool DeleteTaskFromProject(int projectId, int taskId);
    }
}
