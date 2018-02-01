using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public bool IsActivated { get; set;}
        //1 to many realtion
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
