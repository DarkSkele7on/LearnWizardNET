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
        LearnWizardDBContext dbContext;
        public UserContext(LearnWizardDBContext _dBContext) 
        {
            this.dbContext = _dBContext;
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

        public async Task DeleteAsync(int key)
        {
            try
            {
                User userFromDb = await ReadAsync(key, false, false);
                dbContext.Users.Remove(userFromDb);
                await dbContext.SaveChangesAsync();
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
                if(useNavigationalProperties)
                {
                    query = query.Include(a => a.Courses);
                }
                return await query.ToArrayAsync();
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
                return await query.FirstOrDefaultAsync(x => x.Id == key);
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
                User userFromDB = await ReadAsync(item.Id, useNavigationalProperties, false);

                if(userFromDB == null) { await CreateAsync(item); }

                dbContext.Entry(userFromDB).CurrentValues.SetValues(item);

                if(useNavigationalProperties)
                {
                    userFromDB.Courses = item.Courses;
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
