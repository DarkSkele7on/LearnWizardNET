using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, string>
    {
        private readonly LearnWizardAppDbContext _appDbContext;

        public UserContext(LearnWizardAppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task CreateAsync(User item)
        {
            try
            {
                _appDbContext.Users.Add(item);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = _appDbContext.Users;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Courses);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(u=>u.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false,
            bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = _appDbContext.Users;

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

        public async Task DeleteAsync(string key)
        {
            try
            {
                User userFromDb = await ReadAsync(key, false, false);

                if (userFromDb is null)
                {
                    throw new ArgumentException("User with that Id does not exist!");
                }

                _appDbContext.Users.Remove(userFromDb);
                await _appDbContext.SaveChangesAsync();
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
                User userFromDb = await ReadAsync(item.Id,false, false);

                if (userFromDb == null)
                {
                    await CreateAsync(item);
                }

                _appDbContext.Entry(userFromDb).CurrentValues.SetValues(item);

                if (useNavigationalProperties)
                {
                    List<Course> courses = new List<Course>(item.Courses.Count);

                    foreach (var course in item.Courses)
                    {
                        Course courseFromDb = await _appDbContext.Courses.FindAsync(course.Id);

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

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
