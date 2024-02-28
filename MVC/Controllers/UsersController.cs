using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;

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

        public async Task<IActionResult> Index()
        {
            var users = await _identityContext.ReadAllUsersAsync();
            return View(users);
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.ReadUserAsync(id, useNavigationalProperties: true);

            return View(user);
        }

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
                if (user.UserName != null)
                {
                    if (user.PasswordHash != null)
                    {
                        if (user.Email != null)
                        {
                            var result = await _identityContext.CreateUserAsync(user.UserName, user.PasswordHash, user.Email, user.Age, Role.User);
                            if (result.Succeeded)
                            {
                                return RedirectToAction(nameof(Index));
                            }
                            return BadRequest(result.Errors);
                        }
                    }
                }
            }
            return View(user);
        }

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
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Email,Age,Courses")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (user.Email != null)
                        if (user.UserName != null)
                            await _identityContext.UpdateUserAsync(id, user.Email, user.UserName, user.Age);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

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
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500); // Internal Server Error
            }
        }
    }
}
