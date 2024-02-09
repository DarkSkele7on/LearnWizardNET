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
        private readonly LearnWizardDBContext dbContext;

        public CourseContext(LearnWizardDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Course item)
        {
            try
            {
                User authorFromDb = await dbContext.Users.FindAsync(item.Id);

                if (authorFromDb != null)
                {
                    item._User = authorFromDb;
                }

                dbContext.Courses.Add(item);
                await dbContext.SaveChangesAsync();
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
                IQueryable<Course> query = dbContext.Courses;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b._User);
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
                IQueryable<Course> query = dbContext.Courses;

                if (useNavigationalProperties)
                {
                    query = query.Include(b => b._User);
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

                dbContext.Courses.Remove(courseFromDb);
                await dbContext.SaveChangesAsync();
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
                    User userFromDb = await dbContext.Users.FindAsync(item._User.Id);

                    if (userFromDb != null)
                    {
                        coursekFromDb._User = userFromDb;
                    }
                    else
                    {
                        coursekFromDb._User = item._User;
                    }
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
