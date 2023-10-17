using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using TKC_MDS.Data;
using TKC_MDS.Models;
using TKC_MDS.Models.DTO;

namespace TKC_MDS.Controllers
{
    public class RoleController : Controller
    {
        private readonly MSD_Context _db;

        private readonly RoleManager<Roles> _role;
        public RoleController(MSD_Context db, RoleManager<Roles> role) {
            _db = db;
            _role = role;
        }
        public async Task<IActionResult> Index()
        {
            var Rols = await _db.Roles.AsNoTracking().ToListAsync();
            var ClaimRole = await _db.ClaimRoles.AsNoTracking().ToListAsync();
            
            var SaveOrder = await _db.SaveOrderRoles.AsNoTracking().ToListAsync();
            var AdjustOrder = await _db.AdjustOrderRoles.AsNoTracking().ToListAsync();
            var DataTypeRole = await _db.DataTypeRoles.AsNoTracking().ToListAsync();
            var ReportRole = await _db.ReportRoles.AsNoTracking().ToListAsync();
            var ManageUser = await _db.ManageUserRoles.AsNoTracking().ToListAsync();
            
            var listRoles = new List<ListRoles>();
            foreach (var role in Rols)
            {
                listRoles.Add(new ListRoles {
                    RoleId=role.Id,
                    RoleName=role.Name,
                    claimRole= ClaimRole.Where(x => x.RoleId.Equals(Guid.Parse(role.Id))).ToList(),

				});

			}

            ViewData["ListRole"] = listRoles;

            ViewData["SaveOrder"] = SaveOrder;
			ViewData["AdjustOrder"] = AdjustOrder;
			ViewData["DataTypeRole"] = DataTypeRole;
			ViewData["ReportRole"] = ReportRole;
			ViewData["ManageUser"] = ManageUser;

			return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromForm] AddRole input)
        {
            var role = await _role.FindByNameAsync(input.RoleName);
            if(role == null)
            {
                var new_role = new Roles {  Name = input.RoleName };
                var r = await _role.CreateAsync(new_role);
                if (r.Succeeded)
                {
					var claims = input.Assign.Select(c => new ClaimRole { RoleId = Guid.Parse(new_role.Id) , AccessRolesId=c.AccessRolesId, IsAllow=c.IsAllow, RoleName=c.RoleName, Name=c.Name}).ToList();
					await _db.ClaimRoles.AddRangeAsync(claims);
                    await _db.SaveChangesAsync();
					return Json(new { msg = "บันทำข้อมูลเรียบร้อย" });
				}
                return Json(new { error = "เกิดข้อผิดพลาด" });
			}
            else
            {
                return Json(new {error="มี role นี้อยู่แล้ว"});
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
           var role =  await _role.FindByIdAsync(roleId);
            if(role != null)
            {
                await _role.DeleteAsync(role);
                var roles =  _db.ClaimRoles.Where(r => r.RoleId.Equals(Guid.Parse(role.Id)));
                _db.ClaimRoles.RemoveRange(roles);
                await _db.SaveChangesAsync();
				return Json(new { msg = "ลบเรียบร้อย" });
			}
            else
            {
				return Json(new { error = "ไม่มี role นี้อยู่แล้ว" });
			}
        }
        [HttpPost]
        public async Task<IActionResult> JsonEditRole(string roleId){
            var role = await _role.FindByIdAsync(roleId);
            if(role != null)
            {
                var claim = await _db.ClaimRoles.AsNoTracking().Where(c => c.RoleId.Equals(Guid.Parse(role.Id))).ToListAsync();
				var SaveOrder = claim.Take(4).ToList();
				var AdjOrder = claim.Skip(4).Take(4).ToList(); 
				var DataTypeOrder = claim.Skip(8).Take(4).ToList();
				var ReportOrder = claim.Skip(12).Take(4).ToList();
				var manageUserOrder = claim.Skip(16).Take(4).ToList();
                var listRole = new List<JsonType>()
                {
                    new JsonType{ name= "บันทึก Order :",assign=SaveOrder},
					new JsonType{ name= "ปรับ Order :",assign=AdjOrder},
					new JsonType{ name= "รูปแบบข้อมูล :",assign=DataTypeOrder},
					new JsonType{ name= "พิมพ์รายงาน :",assign=ReportOrder},
					new JsonType{ name= "User Management :",assign=manageUserOrder}
				};
                return Json(new { roleId = role.Id, roleName = role.Name, list = listRole });
			}
            return Json(new { error = "ไม่พบ role นี้" });
        }
        [HttpPost]
        public async Task<IActionResult> EditRole([FromForm] EditRole input)
        {
            var role = await _role.FindByIdAsync(input.RoleId);
            if(role != null)
            {
                role.Name = input.RoleName;
                _db.ClaimRoles.UpdateRange(input.Assign);
                await _db.SaveChangesAsync();
				return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
			}
            return Json(new {error="ไม่พบ role"});
        }

    }
	class JsonType
	{
		public string name { get; set; }
		public List<ClaimRole> assign { get; set; } = new List<ClaimRole>();
	}
}
