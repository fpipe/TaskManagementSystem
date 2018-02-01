using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Entities
{
    public class Project : BaseEntity
    {
        [Required]
        public string Name { get; set; }
   
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        //1 to many relation
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
