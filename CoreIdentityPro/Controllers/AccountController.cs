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
        [HttpGet("register")]
        public ActionResult<string> Register()
        {
            return "";
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterUser(Employee employee)
        {
            if (ModelState.IsValid) 
            {
                var user = new  IdentityUser 
                 {
                    UserName =employee.Email,
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

    }
}
