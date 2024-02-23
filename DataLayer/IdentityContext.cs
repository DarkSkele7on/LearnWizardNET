using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer
{
    public class IdentityContext
    {
        UserManager<User> userManager;
        LearnWizardAppDbContext context;

        public IdentityContext(LearnWizardAppDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        #region CRUD

        public async Task<IdentityResult> CreateUserAsync(string username, string password, string email, int age, Role role)
        {
            try
            {
                User user = new User(username, email, age);
                IdentityResult result = await userManager.CreateAsync(user, password);
                return result;
                // if (!result.Succeeded)
                // {
                //     return new IdentityResultSet<User>(result, user);
                // }
                //
                // if (role == Role.Administrator)
                // {
                //     await userManager.AddToRoleAsync(user, Role.Administrator.ToString());
                // }
                // else
                // {
                //     await userManager.AddToRoleAsync(user, Role.User.ToString());
                // }
                //
                // return new IdentityResultSet<User>(IdentityResult.Success, user);
            }
            catch (Exception ex)
            {
                IdentityResult identityResult = IdentityResult.Failed(new IdentityError() 
                    { Code = "Registration", Description = ex.Message });

                return IdentityResult.Failed(); //Set<User>(identityResult, null);
            }
        }

        public async Task<User> LogInUserAsync(string username, string password)
        {
            try
            {
                User user = await userManager.FindByNameAsync(username);

                if (user == null)
                {
                    return null;
                }

                IdentityResult result = await userManager.PasswordValidators[0].ValidateAsync(userManager, user, password);

                if (result.Succeeded)
                {
                    return await context.Users.FindAsync(user.Id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> ReadUserAsync(string? key, bool useNavigationalProperties = false)
        {
            try
            {
                if (!useNavigationalProperties)
                {
                    return await userManager.FindByIdAsync(key);
                }
                else
                {
                    return await context.Users.Include(u => u.Courses).SingleOrDefaultAsync(u => u.Id == key);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> ReadAllUsersAsync(bool useNavigationalProperties = false)
        {
            try
            {
                if (!useNavigationalProperties)
                {
                    return await context.Users.ToListAsync();
                }

                return await context.Users.Include(u => u.Courses).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateUserAsync(string id, string username, int age)
        {
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    User user = await context.Users.FindAsync(id);
                    user.UserName = username;
                    user.Age = age;
                    await userManager.UpdateAsync(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUserByNameAsync(string name)
        {
            try
            {
                var user = await userManager.FindByNameAsync(name);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found for deletion!");
                }

                await userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> FindUserByNameAsync(string name)
        {
            try
            {
                // Identity return Null if there is no user!
                return await userManager.FindByNameAsync(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> DeleteUserByIdAsync(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                if (user is not null)
                {
                    return await userManager.DeleteAsync(user);
                }

                return IdentityResult.Failed();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

    }
}
