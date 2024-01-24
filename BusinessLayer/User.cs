using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Incorrect email!")]
        public string Email { get; set; }

        // Add type of User (admin/normal)

        // Add img for pfp
        [Required]
        public DateOnly BirtDate { get; set; }

        public List<Course> Courses { get; set; }
        public User()
        {
            this.Courses = new List<Course>();
        }

        public User(string firstName_, string lastName_, string email_, DateOnly dateOfBirth_)
        {
            this.UserName = firstName_;
            this.Email = email_;
            this.BirtDate = dateOfBirth_;
            
        }
    }
}
