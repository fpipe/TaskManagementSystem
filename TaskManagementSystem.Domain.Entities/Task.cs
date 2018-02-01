using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Entities
{
    public class Task : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int EstimatedHours { get; set; }

        //nullable start and end datetime, because can be null
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }

        public TaskType Type { get; set; }
        public TaskStatus Status { get; set; }

        //1 to many relation
        public virtual ICollection<TaskComment> Comments { get; set; }

        //many to 1 relation
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //many to 1 relation
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        //status of a task
        public enum TaskStatus
        {
            ToDo = 0,
            InProgress = 1,
            InTesting = 2,
            Done = 3
        }

        //type of a task
        public enum TaskType
        {
            Task = 0,
            Bug = 1,
            Other = 2
        }

    }

}
