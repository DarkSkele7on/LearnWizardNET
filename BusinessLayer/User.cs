using Microsoft.AspNetCore.Identity;

namespace BusinessLayer
{
    public sealed class User : IdentityUser
    {
        public int Age { get; set; }

        public ICollection<Course> Courses { get; set; }

        public User()
        {
            Courses = new List<Course>();
            Id = Guid.NewGuid().ToString();
        }

        public User(string username ,string email, int age)
        {
            UserName = username;
            Email = email;
            Age = age;
        }
        public override string ToString()
        {
            return string.Format($"{Id} {UserName}");
        }
    }
}
