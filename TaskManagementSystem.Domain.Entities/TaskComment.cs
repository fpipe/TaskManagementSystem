using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Entities
{
    public class TaskComment : BaseEntity
    {
        [Required]
        public string Comment { get; set; }

        //many to 1 relation
        public virtual int TaskId { get; set; }
        public virtual Task Task { get; set; }

        //weak entity, find user by task
        public int? UserId { get; set; }
    }
}
