using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public Course()
        {
            // Default constructor
        }
        public Course(string name, string description, User user)
        {
            this.UserId = user.Id;
            this.Name = name;
            this.Description = description;
            this.User = user;
        }
    }
}
