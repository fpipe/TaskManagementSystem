using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //1 to many relation
        public virtual ICollection<Project> Projects { get; set; }
    }
}
