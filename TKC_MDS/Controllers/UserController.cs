using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TKC_MDS.Data;
using TKC_MDS.Models.DTO;

namespace TKC_MDS.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _user;
        private readonly RoleManager<Roles> _role;
        private readonly MSD_Context _db;
        public UserController(UserManager<AppUser> user, RoleManager<Roles> role,MSD_Context db,SignInManager<AppUser> signIn)
        {
            _user = user;
            _role = role;
            _db = db;
            _signInManager = signIn;
        }

        [Authorize(Roles = ConstanceRoles.ViewUser)]
        public async Task<IActionResult> Index()
        {
            var listRole = await _role.Roles.ToListAsync();
            var userlist = await _db.Users.AsNoTracking().ToListAsync();
            var users = new List<ListUser>();
            foreach (var user in userlist)
            {
                users.Add(new ListUser { Id = user.Id, Email = user.Email, Name = user.UserName, Roles = await _user.GetRolesAsync(user) });
            }
            //userlist.Select( async user =>); 
            ViewData["listRole"] = listRole;
			ViewData["listUser"] = users;

			return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? user_name,string? password)
        {
            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))  return View();

            var user = await _user.FindByNameAsync(user_name);
            if (user != null) {
				var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                {
					var claims = new List<Claim>();
					var rolesStr = await _user.GetRolesAsync(user);
					if (rolesStr != null)
					{
						
						foreach (var role in rolesStr)
						{
							var roles = await _role.FindByNameAsync(role);
							var all_claim = await _db.ClaimRoles.AsNoTracking().Where(x => x.RoleId.Equals(Guid.Parse(roles.Id)) && x.IsAllow == true).ToListAsync();
							foreach (var claimRole in all_claim)
							{
								claims.Add(new Claim(ClaimTypes.Role, claimRole.RoleName!));
							}
						}
					}
					await _signInManager.SignInWithClaimsAsync(user, true, claims);
                    //redirect
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
				}
				ViewData["Error"] = "รหัสผ่านไม่ถูกต้อง";
				return View();
			}
            ViewData["Error"] = "ไม่พบ user";
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        [HttpPost]
        [Authorize(Roles = ConstanceRoles.CreateUser)]
        public async Task<IActionResult> AddUser([FromForm]AddUser input)
        {
            if (ModelState.IsValid)
            {
				var newUser = new AppUser()
				{
					Address = input?.Address,
					Email = input?.Email,
					UserName = input?.UserName,
				};

                var have_user = await _user.FindByEmailAsync(newUser.Email);
                if(have_user != null) return Json(new { error = "มี email นี้แล้ว" });
				var have_name = await _user.FindByNameAsync(newUser.UserName);
				if (have_name != null) return Json(new { error = "มี user name นี้แล้ว" });

				var create_user = await _user.CreateAsync(newUser,input.Password);
                if (create_user.Succeeded) {
                    var user = await _user.FindByEmailAsync(input.Email);
                    var resault = await _user.AddToRoleAsync(user,input.Role);
                    if (resault.Succeeded)
                    {
                        return Json(new { msg = "สร้าง user ไหม่เรียบร้อย" });
                    }
					return Json(new { error = "เกิดข้อผิดพลาด add roleไม่สำเร็จ" });
                }
                return Json(new {error="เกิดข้อผิดพลาด สร้าง user ไม่สำเร็จ"});
			}
            else
            {
                return Json(new {error="กรุณาป้อนข้อมูลให้ครบและตรวจสอบรหัสผ่านว่าตรงกันหรือไม่"});
            }
        }
        
        [HttpPost]
        [Authorize(Roles = ConstanceRoles.DeleteUser)]
        public async Task<IActionResult> DeleteUser(string id)
        {
           var user = await _user.FindByIdAsync(id);
            if (user != null)
            {

                await _user.DeleteAsync(user);
                return Json(new {msg="ลบข้อมูลเรียบร้อย"});
            }
			return Json(new { error = "เกิดข้อผิดพลาด" });
		}
		[HttpPost]
		public async Task<IActionResult> JsonUser(string id)
		{
            var user = await _user.FindByIdAsync(id);
            if (user != null)
            {

                return Json(new {name=user.UserName, email=user.Email,address=user.Address,roles= await _user.GetRolesAsync(user) });
            }
            return Json(new {error ="ไม่พบข้อมูล"});
		}
        [HttpGet]
        public async Task<IActionResult> JsonSearchUser([FromQuery]string userName)
        {
			var listRole = await _role.Roles.ToListAsync();
			var userlist = await _db.Users.AsNoTracking().Where(u => u.UserName.ToLower().StartsWith(userName.ToLower())).ToListAsync();
			var users = new List<ListUser>();
			foreach (var user in userlist)
			{
				users.Add(new ListUser { Id = user.Id, Email = user.Email, Name = user.UserName, Roles = await _user.GetRolesAsync(user) });
			}
            return Json(users);
		}
        [HttpPost]
        [Authorize(Roles =ConstanceRoles.EditUser)]
        public async Task<IActionResult> EditUser([FromForm] EditUser input)
        {

                var user = await _user.FindByIdAsync(input.UserId);
                if (user != null)
                {
                    if (string.IsNullOrEmpty(input.OldRole)) //empty role
                    {
					user.Address = input.Address;
					user.Email = input.Email;
					user.UserName = input.UserName;
					var resault = await _user.AddToRoleAsync(user, input.NewRole);
					if (resault.Succeeded)
					{
						if (!string.IsNullOrEmpty(input.Password))
						{
							await _user.RemovePasswordAsync(user);
							await _user.AddPasswordAsync(user, input.Password);
						}
						await _user.UpdateAsync(user);
						return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
					}
				}

                    var reomve_role = await _user.RemoveFromRoleAsync(user, input.OldRole);
                    if (reomve_role.Succeeded)
                    {
                        user.Address = input.Address;
                        user.Email = input.Email;
                        user.UserName = input.UserName;
                        var resault = await _user.AddToRoleAsync(user, input.NewRole);
                        if (resault.Succeeded)
                        {
                            if (!string.IsNullOrEmpty(input.Password))
                            {
                                await _user.RemovePasswordAsync(user);
                                await _user.AddPasswordAsync(user, input.Password);
                            }
                            await _user.UpdateAsync(user);
                            return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
                        }
                        return Json(new { error = "เพิ่ม role ไม่สำเร็จ" });

                    }
                    return Json(new { error = "ลบ role ไม่สำเร็จ" });
                }
                return Json(new { error = "ไม่พบข้อมูล" });
            }

	}
}
