using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            // Default constructor
        }
        public Course(string name, string description, User user)
        {
            this.Name = name;
            this.Description = description;
            this._User = user;
        }
    }
}
