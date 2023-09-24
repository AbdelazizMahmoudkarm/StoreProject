using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace StoreProject.ApiController
{
    /// <summary>
    /// For authotcation
    /// </summary>
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public static Dictionary<string, string> Online
        {
            get;
            set;
        } = new Dictionary<string, string>();
        /// <summary>
        /// Constractor which intialize the users and logins actions      
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            if (Online.Count < 0)
            {
                return NoContent();
            }
            return Ok(Online);
        }
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Register([FromBody]Registration registration)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registration.UserName, Email = registration.UserName };
                var result = await _userManager.CreateAsync(user, registration.Password);
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = registration.UserRole });
                    var userdata = await _userManager.FindByNameAsync(registration.UserName);
                    if (registration.UserRole is null)
                        return BadRequest("Please input the user Role ");
                    await _userManager.AddToRoleAsync(userdata, registration.UserRole);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    Online.Add(registration.UserName, "OnLine");
                    return NoContent();
                }
            }
            return BadRequest("Please Input the Correct Data");
        }

        [HttpPost, AllowAnonymous]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody]Login login)
        {
            if (!_userManager.Users.Any())
            {
                var addUser = await _userManager.CreateAsync(new IdentityUser { UserName = "Abdelaziz"},"Koko_yasmin2020");
                if(addUser.Succeeded)
                {
                    var addRole= await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                    if(addRole.Succeeded)
                    {
                        var role = await _roleManager.FindByNameAsync("Admin");
                        await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("Abdelaziz"), role.Name);
                    }
                }
            }
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
                if (result.Succeeded)
                {
                    if (!Online.ContainsKey(login.UserName))
                    {
                        Online.Add(login.UserName, "OnLine");
                    }
                    return NoContent();
                }
                return BadRequest("The username Or Password is incorrect");
            }
            return BadRequest("Please Input the Correct Data");
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            if(Online.ContainsKey(User.Identity.Name))
            Online.Remove(User.Identity.Name);
            await _signInManager.SignOutAsync();
            return NoContent();
        }
        [HttpPut,Authorize(Roles ="Admin")]
        public async Task<IActionResult> Put(String olduser, String UserName)
        {
            var user = await _userManager.FindByNameAsync(olduser);
            user.UserName = UserName;
            user.Email = UserName;
            user.NormalizedEmail = UserName.ToUpper();
            user.NormalizedUserName = UserName.ToUpper();
            await _userManager.UpdateAsync(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(String id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                return NoContent();
            }
            return BadRequest();
        }

    }

}
