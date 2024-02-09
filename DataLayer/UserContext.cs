using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {
        private readonly LearnWizardDBContext dbContext;

        public UserContext(LearnWizardDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(User item)
        {
            try
            {
                dbContext.Users.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Courses);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(a => a.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Courses);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                User userFromDb = await ReadAsync(key, false, false);

                if (userFromDb is null)
                {
                    throw new ArgumentException("Author with that Id does not exist!");
                }

                dbContext.Users.Remove(userFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(User item, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                User userFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

                if (userFromDb == null) { await CreateAsync(item); }

                dbContext.Entry(userFromDb).CurrentValues.SetValues(item);

                if (useNavigationalProperties)
                {
                    List<Course> courses = new List<Course>(item.Courses.Count);

                    foreach (var course in item.Courses)
                    {
                        Course courseFromDb = await dbContext.Courses.FindAsync(course.Id);

                        if (courseFromDb is null)
                        {
                            courses.Add(course);
                        }
                        else
                        {
                            courses.Add(courseFromDb);
                        }
                    }

                    userFromDb.Courses = courses;
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
