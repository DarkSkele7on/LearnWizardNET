using BusinessLayer;
using DataLayer;
using System;
using System.Linq;

public class CourseService
{
    private readonly LearnWizardDBContext _context;

    public CourseService(LearnWizardDBContext context)
    {
        _context = context;
    }

    public bool AddCourse(Course newCourse)
    {
        if (newCourse == null || string.IsNullOrWhiteSpace(newCourse.Name))
        {
            Console.WriteLine("Invalid course data.");
            return false;
        }

        try
        {
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding course: {ex.Message}");
            return false;
        }
    }


    public Course GetCourse(int courseId)
    {
        try
        {
            // Retrieving the course by ID
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
            return course;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving course: {ex.Message}");
            return null;
        }
    }

    public bool UpdateCourse(Course updatedCourse)
    {
        try
        {
            var existingCourse = _context.Courses.FirstOrDefault(c => c.Id == updatedCourse.Id);

            if (existingCourse == null)
            {
                Console.WriteLine("Course not found.");
                return false;
            }

            // Update properties
            existingCourse.Name = updatedCourse.Name;
            // Add other properties to update as needed

            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating course: {ex.Message}");
            return false;
        }
    }

    public bool DeleteCourse(int courseId)
    {
        try
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return false;
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting course: {ex.Message}");
            return false;
        }
    }
}
