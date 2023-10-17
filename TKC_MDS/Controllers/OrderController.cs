using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TKC_MDS.Data;
using TKC_MDS.Models;
using TKC_MDS.Models.DTO;

namespace TKC_MDS.Controllers
{
    public class OrderController : Controller
    {

		public IActionResult DataType()
        {
            return View();
        }

        public IActionResult SaveOrder()
        {
            return View();
        }

        public IActionResult AdjustOrder() 
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }
		public async Task<IActionResult> JsonUsers()
		{
			var user = await Dapper_Context.QueryTableAsync<Q_SchCustomer>("SELECT * FROM Q_SchCustomers");
			return Json(user);
		}
		public async Task<IActionResult> JsonDataType_MS()
		{
			var dataType = await Dapper_Context.QueryTableAsync<T_SchDataType_MS>("SELECT * FROM T_SchDataType_MS");
			return Json(dataType);
		}
        [HttpPost]
        public async Task<IActionResult> AddDataType(string name)
		{
            
			try
            {
                if (name == null) throw new Exception("name can't null");
				
				var data = await Dapper_Context.QueryTableAsync<T_SchDataType_MS>("SELECT * FROM T_SchDataType_MS");
                var maxId = data.OrderByDescending( x => x.TypeCode).Select(x => x.TypeCode).FirstOrDefault();
				await Dapper_Context.Insert<T_SchDataType_MS>("INSERT INTO T_SchDataType_MS (TypeCode,TypeName, UpdatedBy,UpdatedDate) VALUES (@TypeCode,@TypeName, @UpdatedBy,@UpdatedDate)", new T_SchDataType_MS { TypeCode= (Convert.ToInt16(maxId)+1)+"", UpdatedBy = User?.Identity?.Name, TypeName = name} ); //ระวัง user ชื่อยาวเกิน 20
                return Json(new {msg="บันทึกข้อมูลเรียยบร้อย"});
			}
			catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> AddDataType(AddDataType input)
        {

        }
    }
}
