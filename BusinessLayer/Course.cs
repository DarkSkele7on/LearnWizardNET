using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User _User { get; set; }

        public Course() 
        { 
            
        }
        public Course(string _name, string _description, User _user)
        {
            this.Name = _name;
            this.Description = _description; 
            this._User = _user;
        }
    }
}
