using CoreIdentityPro.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreIdentityPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<IdentityUser> userManager,
                                   SignInManager<IdentityUser> signInManager) : ControllerBase
    {        
        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterUser(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = employee.Email,
                    Email = employee.Email,
                };
                var result = await userManager.CreateAsync(user, employee.Name!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return "SignIn Successful";
                    //return RedirectToAction();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError($"{error}", error.Description);
                }
            }
            return "";
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(email, password, isPersistent: false, /*Lock Account o Failure*/false);

                if (result.Succeeded)
                {
                    return "Successfully Login In";
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }

            return "An Error Occured Please Contact Admin";
        }

        [HttpPost]
        public async Task<ActionResult<string>> Logout()
        {
            await signInManager.SignOutAsync();
            //  return RedirectToAction();
            return "SignOut Successful";
        }
    }
}
