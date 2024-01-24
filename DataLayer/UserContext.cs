using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {
        public async Task CreateAsync(User item)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User item, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            throw new NotImplementedException();
        }
    }
}
