using BusinessLayer;
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
        LearnWizardDBContext dbContext;
        public CourseContext(LearnWizardDBContext _dBContext)
        {
            this.dbContext = _dBContext;
        }
        public async Task CreateAsync(Course item)
        {
            try
            {
                dbContext.Courses.Add(item);
                await dbContext.SaveChangesAsync();
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
                dbContext.Courses.Remove(courseFromDb);
                await dbContext.SaveChangesAsync();
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
                    query = query.Include(a => a._User);
                }
                return await query.ToArrayAsync();
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
                    query = query.Include(a => a._User);
                }
                return await query.FirstOrDefaultAsync(x => x.Id == key);
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
                Course courseFromDB = await ReadAsync(item.Id, useNavigationalProperties, false);

                if (courseFromDB == null) { await CreateAsync(item); }

                dbContext.Entry(courseFromDB).CurrentValues.SetValues(item);

                if (useNavigationalProperties)
                {
                    courseFromDB._User = item._User;
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
