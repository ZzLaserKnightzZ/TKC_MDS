using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TKC_MDS.Data;
using TKC_MDS.Models;
using TKC_MDS.Models.DTO;

namespace TKC_MDS.Controllers
{
	public class OrderController : Controller
	{
		private readonly ILogger<OrderController> _logger;
		public OrderController(ILogger<OrderController> logger)
		{
			_logger = logger;
		}
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
		
		public async Task<IActionResult> JsonOrders()
		{
			var order = await Dapper_Context.QueryTableAsync<T_SchOrdersPart>("SELECT * FROM T_SchOrdersPart");
			return Json(order);
		}
		public async Task<IActionResult> JsonCustumer()
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
				//ดึงค่าตัวเลขสุดท้ายแล้วเซตค่าไหม่
				var data = await Dapper_Context.QueryTableAsync<T_SchDataType_MS>("SELECT * FROM T_SchDataType_MS");
				var maxId = data.OrderByDescending(x => x.TypeCode).Select(x => x.TypeCode).FirstOrDefault();
				await Dapper_Context.Insert<T_SchDataType_MS>("INSERT INTO T_SchDataType_MS (TypeCode,TypeName, UpdatedBy,UpdatedDate) VALUES (@TypeCode,@TypeName, @UpdatedBy,@UpdatedDate)", new T_SchDataType_MS { TypeCode = (Convert.ToInt16(maxId) + 1) + "", UpdatedBy = User?.Identity?.Name, TypeName = name }); //ระวัง user ชื่อยาวเกิน 20
				return Json(new { msg = "บันทึกข้อมูลเรียยบร้อย" });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return Json(new { error = ex.Message });
			}

		}
		[HttpPost]
		public async Task<IActionResult> AddCustDataType([FromForm] AddDataType input)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var model = new T_SchDataType_Cust
					{
						CustID = input.CustID,
						TypeCode = input.TypeCode,
						DeleteOld = input.DeleteOld,
						FirmOrder = input.FirmOrder,
						ForPOS = input.ForPOS,
						MakeMDS = input.MakeMDS,
						ManyDueDataLong = input.ManyDueDataLong,
						ManyDueDataNo = input.ManyDueDataNo,
						ManyDueSetNo = input.ManyDueSetNo,
						ManyDueType = input.ManyDueType,
						MixedSchWith = input.MixedSchWith,
						RowManyDue = input.RowManyDue,
						SepMDSbyFlag01 = true, // input.SepMDSbyFlag01,
						ShowInSch = input.ShowInSch,
						UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",
						UpdatedDate = DateTime.UtcNow,
						Note = input.Note
					};

					await Dapper_Context.Insert<T_SchDataType_Cust>("INSERT INTO T_SchDataType_Cust (CustID,TypeCode,DeleteOld,SepMDSbyFlag01,FirmOrder,MakeMDS,ShowInSch,MixedSchWith,UpdatedBy,UpdatedDate,RowManyDue,ManyDueType,ManyDueDataNo,ManyDueSetNo,ManyDueDataLong,ForPOS,Note) VALUES (@CustID,@TypeCode,@DeleteOld,@SepMDSbyFlag01,@FirmOrder,@MakeMDS,@ShowInSch,@MixedSchWith,@UpdatedBy,@UpdatedDate,@RowManyDue,@ManyDueType,@ManyDueDataNo,@ManyDueSetNo,@ManyDueDataLong,@ForPOS,@Note)", model);
					//var conv_model = new T_SchFormConv
					//{
					//	CustId = input.CustID,
					//	TypeCode = input.TypeCode,
					//	Separater = input.Seperator,
					//	RowManyDue = input.RowManyDue,
					//	UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",

					//};
					//await Dapper_Context.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", conv_model);
					return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
				}
				catch (Exception ex)
				{
					_logger.LogError(ex.Message);
					return Json(new { error = ex.Message });
				}
			}
			return Json(new { error = "กรุณากรอกข้อมูลให้ครบ" });

		}

		//[HttpPost]
		//public async Task<IActionResult> SaveOrder()
		//{

		//}

		//[HttpPost] 
		//public async Task<IActionResult> ImportFile([FromForm]SaveOrder input)
		//{
		//	//1.exac excell
		//	//2.save to data base
		//	//3.return object[]
		//}


	}
}
