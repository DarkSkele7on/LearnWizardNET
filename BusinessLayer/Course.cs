using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    public enum ExpertiseLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public enum LearningStyle
    {
        Visual,
        Auditory,
        ReadingWriting,
        Kinesthetic
    }

    public enum ContentPreference
    {
        Theoretical,
        Practical,
        Mixed
    }

    public enum FeedbackFrequency
    {
        Weekly,
        Biweekly,
        Monthly
    }

    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)] // Increased length for description
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }
        
        
        // Enum fields
        [Required]
        public ExpertiseLevel ExpertiseLevel { get; set; }

        [Required]
        [MaxLength(500)]
        public string LearningGoals { get; set; }

        [Required]
        public LearningStyle LearningStyle { get; set; }

        [Required]
        public ContentPreference ContentPreferences { get; set; }

        [MaxLength(500)]
        public string SupportNeeds { get; set; } // Additional support needs

        public Course()
        {
            // Default constructor
        }
        
        public Course(string name, string description, User user, ExpertiseLevel expertiseLevel, string learningGoals, LearningStyle learningStyle, ContentPreference contentPreferences, string supportNeeds)
        {
            this.Name = name;
            this.Description = description;
            this.User = user;
            this.UserId = user.Id;
            this.ExpertiseLevel = expertiseLevel;
            this.LearningGoals = learningGoals;
            this.LearningStyle = learningStyle;
            this.ContentPreferences = contentPreferences;
            this.SupportNeeds = supportNeeds;
        }
    }
}
