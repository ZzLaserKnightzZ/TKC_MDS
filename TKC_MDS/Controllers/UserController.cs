using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TKC_MDS.Data;
using TKC_MDS.Models.DTO;

namespace TKC_MDS.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _user;
        private readonly RoleManager<Roles> _role;
        private readonly MSD_Context _db;
        public UserController(UserManager<AppUser> user, RoleManager<Roles> role,MSD_Context db)
        {
            _user = user;
            _role = role;
            _db = db;
        }

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

        [HttpPost]
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
                var create_user = await _user.CreateAsync(newUser,input.Password);
                if (create_user.Succeeded) {
                    var user = await _user.FindByEmailAsync(input.Email);
                    var resault = await _user.AddToRoleAsync(user,input.Role);
                    if (resault.Succeeded)
                    {
                        return Json(new { msg = "สร้าง user ไหม่เรียบร้อย" });
                    }
                    else
                    {
						return Json(new { error = "เกิดข้อผิดพลาด" });
					}
                }
                return Json(new {error="เกิดข้อผิดพลาด"});
			}
            else
            {
                return Json(new {error="กรุณาป้อนข้อมูลให้ครบและตรวจสอบรหัสผ่านว่าตรงกันหรือไม่"});
            }
        }
        
        [HttpDelete]
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
        public async Task<IActionResult> EditUser([FromForm] EditUser input)
        {

                var user = await _user.FindByIdAsync(input.UserId);
                if (user != null)
                {

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
