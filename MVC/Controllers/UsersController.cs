using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<User> _userManager;
    
        public UsersController(IdentityContext identityContext, UserManager<User> userManager)
        {
            _identityContext = identityContext;
            _userManager = userManager;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _identityContext.ReadAllUsersAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.ReadUserAsync(id, useNavigationalProperties: true);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,PasswordHash,Age")] User user)
        {
            if (ModelState.IsValid)
            {
                // Create user using IdentityContext
                var result = await _identityContext.CreateUserAsync(user.UserName, user.PasswordHash, user.Email, user.Age, Role.User);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                return new ContentResult() { Content = result.ToString() };
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.ReadUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,EmailAge,Courses")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _identityContext.UpdateUserAsync(id, user.UserName, user.Age);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.ReadUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await _identityContext.DeleteUserByIdAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                // Handle the case where the user is not found
                // For example, you can redirect to an error page or return a specific view
                return NotFound();
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                // For example, you can log the exception and return a generic error view
                return View("Index");
            }
        }
    }
}
