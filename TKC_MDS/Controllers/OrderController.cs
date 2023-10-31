using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using TKC_MDS.Data;
using TKC_MDS.Models;
using TKC_MDS.Models.DTO;

namespace TKC_MDS.Controllers
{
	public class OrderController : Controller
	{
		private readonly ILogger<OrderController> _logger;
		//private readonly SaleDev_Context _saleContext;
		public OrderController(ILogger<OrderController> logger /*SaleDev_Context saleContext*/)
		{
			_logger = logger;
			//_saleContext = saleContext;
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

		public async Task<IActionResult> JsonFormConv(string custId, string typeCode)//order page
		{
			var order = await Dapper_Context.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustID='{custId}' AND TypeCode='{typeCode}'");
			//var order = await _saleContext.t_SchFormConv.AsNoTracking().FirstOrDefaultAsync(conv => conv.CustId == custId && conv.TypeCode == typeCode);
			return Json(order);
		}
		//public async Task<IActionResult> JsonOrdersPart(string custId,string dataType)
		//{
		//	var order = await Dapper_Context.QueryTableAsync<T_SchOrdersPart>($"SELECT * FROM T_SchOrdersPart WHERE CustID = {custId} AND DataType={dataType}");
		//	return Json(order);
		//}
		public async Task<IActionResult> JsonOrders()
		{
			var order = await Dapper_Context.QueryTableAsync<T_SchOrdersPart>("SELECT * FROM T_SchOrdersPart");
			//var order = await _saleContext.t_SchOrdersParts.AsNoTracking().ToListAsync();
			return Json(order);
		}
		public async Task<IActionResult> JsonCustumer()
		{
			var user = await Dapper_Context.QueryTableAsync<Q_SchCustomer>("SELECT * FROM Q_SchCustomers");
			//var user = await _saleContext.q_SchCustomers.AsNoTracking().ToListAsync();
			return Json(user);
		}
		public async Task<IActionResult> JsonDataType_MS()
		{
			var dataType = await Dapper_Context.QueryTableAsync<T_SchDataType_MS>("SELECT * FROM T_SchDataType_MS");
			//var dataType = await _saleContext.t_SchDataType_Ms.AsNoTracking().ToListAsync();
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
						Note = input.Note
					};

					await Dapper_Context.Insert<T_SchDataType_Cust>("INSERT INTO T_SchDataType_Cust (CustID,TypeCode,DeleteOld,SepMDSbyFlag01,FirmOrder,MakeMDS,ShowInSch,MixedSchWith,UpdatedBy,UpdatedDate,RowManyDue,ManyDueType,ManyDueDataNo,ManyDueSetNo,ManyDueDataLong,ForPOS,Note) VALUES (@CustID,@TypeCode,@DeleteOld,@SepMDSbyFlag01,@FirmOrder,@MakeMDS,@ShowInSch,@MixedSchWith,@UpdatedBy,@UpdatedDate,@RowManyDue,@ManyDueType,@ManyDueDataNo,@ManyDueSetNo,@ManyDueDataLong,@ForPOS,@Note)", model);
					
					foreach(var form in input.FieldsList)
					{
						try
						{
							//var conv_model = new T_SchFormConv
							//{
							//	CustId = input.CustID,
							//	TypeCode = input.TypeCode,
							//	Separater = input.Seperator,
							//	RowManyDue = input.RowManyDue,
							//	UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",

							//};
							await Dapper_Context.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", conv_model);
						}
						catch (Exception ex)
						{
							Debug.WriteLine(ex.Message);
						}
					}

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
		//public async Task<IActionResult> SaveOrder(List<T_SchFormConv> input)
		//{
		//	if(input != null)
		//	{
		//		//foreach (T_SchFormConv model in input)
		//		//await Dapper_Context.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", model);
		//		return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
		//	}
		//	return Json(new { error="ไม่มีข้อมูล"});
		//}

		[HttpPost]
		public async Task<IActionResult> SaveOrder(List<T_SchOrdersPart> input)
		{
			try
			{
				
				if (input != null)
				{
					if(input.Count == 0) return Json(new { error = "ไม่มีข้อมูลที่ต้องบันทึก" });

					foreach (var part in input)
					{
						var dueDate = DateTime.Parse(part.DueDate);
						part.DueDate = dueDate.ToString("yyyy-MM-dd HH:mm:ss");
						part.DataType =  part.DataType == "true" ? "1":"0";
						
						//var dueDate = part.DueDate.ToString("yyyy-MM-dd HH:mm:ss");
						//part.DueDate = DateTime.Parse(dueDate);
						await Dapper_Context.Insert<T_SchOrdersPart>("INSERT INTO T_SchOrdersPart (CustID,OrdersNo,PONo,PlantCode,DueDate,Period,DueTime,PartNo,Qty,SentQty,Flag01,Flag02,Flag03,Flag04,Flag05,DataType,Status,ImportBy,ImportDate,FirmOrder,Exported,InvcNo,DataFileName,Flag06,Flag07,Flag08,Flag09,Flag10,PackageCD) VALUES (@CustID,@OrdersNo,@PONo,@PlantCode,@DueDate,@Period,@DueTime,@PartNo,@Qty,@SentQty,@Flag01,@Flag02,@Flag03,@Flag04,@Flag05,@DataType,@Status,@ImportBy,@ImportDate,@FirmOrder,@Exported,@InvcNo,@DataFileName,@Flag06,@Flag07,@Flag08,@Flag09,@Flag10,@PackageCD)", part);
					}
						return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
				}
				else
				{
					return Json(new { error = "ไม่มีข้อมูล" });
				}

			}
			catch (Exception ex)
			{
				return Json(new { error = "เกิดข้อผิดพลาด "+ex.Message });
			}
			  	
		}


	}
}
