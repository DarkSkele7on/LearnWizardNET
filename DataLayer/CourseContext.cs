using BusinessLayer;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CourseContext : IDb<Course, int>
    {
        private readonly LearnWizardAppDbContext _appDbContext;

        public CourseContext(LearnWizardAppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task CreateAsync(Course item)
        {
            try
            {
                User authorFromDb = await _appDbContext.Users.FindAsync(item.Id);

                if (authorFromDb != null)
                {
                    item.User = authorFromDb;
                }

                _appDbContext.Courses.Add(item);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Course> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Course> query = _appDbContext.Courses;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b.User);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(b => b.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<Course>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Course> query = _appDbContext.Courses;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b.User);
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
                Course courseFromDb = await ReadAsync(key, false, false);

                if (courseFromDb == null)
                {
                    throw new ArgumentException($"Course with id: {key} does not exist!");
                }

                _appDbContext.Courses.Remove(courseFromDb);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Course item, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                Course coursekFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

                coursekFromDb.Name = item.Name;
                coursekFromDb.Description = item.Description;

                if (useNavigationalProperties)
                {
                    User userFromDb = await _appDbContext.Users.FindAsync(item.User.Id);

                    if (userFromDb != null)
                    {
                        coursekFromDb.User = userFromDb;
                    }
                    else
                    {
                        coursekFromDb.User = item.User;
                    }
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
