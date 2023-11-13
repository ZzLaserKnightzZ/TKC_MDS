using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
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
		private readonly Dapper_Context _dapperContext;
		public OrderController(ILogger<OrderController> logger, Dapper_Context dapper_Context)
		{
			_logger = logger;
			_dapperContext = dapper_Context;
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
			var order = await _dapperContext.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustID='{custId}' AND TypeCode='{typeCode}'");
			return Json(order);
		}

		//public async Task<IActionResult> JsonOrdersPart(string custId,string dataType)
		//{
		//	var order = await Dapper_Context.QueryTableAsync<T_SchOrdersPart>($"SELECT * FROM T_SchOrdersPart WHERE CustID = {custId} AND DataType={dataType}");
		//	return Json(order);
		//}

		public async Task<IActionResult> JsonOrders()
		{
			try
			{
				var order = await _dapperContext.QueryTableAsync<T_SchOrdersPart>("SELECT * FROM T_SchOrdersPart");
				return Json(order);

			}
			catch (Exception ex)
			{
				throw new Exception($"{ex.Message} iinner{ex.InnerException}");
			}

		}
		public async Task<IActionResult> JsonCustumer()
		{
			try
			{
				var user = await _dapperContext.QueryTableAsync<Q_SchCustomer>("SELECT * FROM Q_SchCustomers");
				return Json(user);
			}
			catch (Exception error)
			{
				throw new Exception("error : " + error.Message + "   inner : " + error.InnerException);
			}
		}
		public async Task<IActionResult> JsonDataType_MS()
		{
			var dataType = await _dapperContext.QueryTableAsync<T_SchDataType_MS>("SELECT * FROM T_SchDataType_MS");
			return Json(dataType);
		}
		[HttpPost]
		public async Task<IActionResult> AddDataType(string name)
		{

			try
			{
				if (name == null) throw new Exception("name can't null");
				//ดึงค่าตัวเลขสุดท้ายแล้วเซตค่าไหม่
				var data = await _dapperContext.QueryTableAsync<T_SchDataType_MS>("SELECT * FROM T_SchDataType_MS");
				var maxId = data.OrderByDescending(x => x.TypeCode).Select(x => x.TypeCode).FirstOrDefault();
				var updateDate = DateTime.Now;
				await _dapperContext.Insert<T_SchDataType_MS>("INSERT INTO T_SchDataType_MS (TypeCode,TypeName, UpdatedBy,UpdatedDate) VALUES (@TypeCode,@TypeName, @UpdatedBy,@UpdatedDate)", new T_SchDataType_MS { TypeCode = (Convert.ToInt16(maxId) + 1) + "", UpdatedBy = User?.Identity?.Name.Length > 0 ? User?.Identity?.Name : "", TypeName = name, UpdatedDate = $"{updateDate.Year}-{updateDate.Month}-{updateDate.Day} {updateDate.Hour}:{updateDate.Minute}:{updateDate.Second}" }); //ระวัง user ชื่อยาวเกิน 20
				return Json(new { msg = "บันทึกข้อมูลเรียยบร้อย" });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return Json(new { error = ex.Message });
			}

		}

		public async Task<IActionResult> JsonGetDataType(string custId,string dataTypeId)
		{
			try
			{
				var dataTypeCust = await _dapperContext.QueryTableAsync<T_SchDataType_Cust>($"SELECT * FROM T_SchDataType_Cust WHERE CustID='{custId}' AND TypeCode='{dataTypeId}'");
				var formConv = await _dapperContext.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustId='{custId}' AND TypeCode='{dataTypeId}'");

				return Json(new { dataType = dataTypeCust.FirstOrDefault(), form = formConv });
			}catch(Exception ex)
			{
				return Json(new { error = ex.Message });	
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDataType([FromForm] AddDataType input)
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
					SepMDSbyFlag01 = input.SepMDSbyFlag01,
					ShowInSch = input.ShowInSch,
					UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",
					Note = input.Note,
					UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
				};

				await _dapperContext.Update<T_SchDataType_Cust>($"UPDATE T_SchDataType_Cust SET DeleteOld = @DeleteOld,SepMDSbyFlag01 = @SepMDSbyFlag01,FirmOrder = @FirmOrder,MakeMDS = @MakeMDS,ShowInSch = @ShowInSch,MixedSchWith = @MixedSchWith,UpdatedBy = @UpdatedBy,UpdatedDate = @UpdatedDate,RowManyDue = @RowManyDue,ManyDueType = @ManyDueType,ManyDueDataNo = @ManyDueDataNo,ManyDueSetNo = @ManyDueSetNo,ManyDueDataLong = @ManyDueDataLong,ForPOS = @ForPOS,Note = @Note WHERE CustID='{input.CustID}' AND TypeCode='{input.TypeCode}';", model);

				foreach (var form in input.FieldsList!)
				{
					try
					{
						if (!string.IsNullOrEmpty(form.Name))
						{
							var conv_model = new T_SchFormConv
							{
								CustId = input.CustID,
								TypeCode = input.TypeCode,
								Separater = input.Seperator,
								RowManyDue = input.RowManyDue,
								UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",

								DataSize = form.EndPosition,
								StartPosition = form.StartPosition,
								FieldName = form.Name,
								FieldId = Convert.ToByte(form.FieldId),
								UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
							};
							try
							{
								var formDb = await _dapperContext.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustId='{conv_model.CustId}' AND FieldId={conv_model.FieldId} AND TypeCode='{conv_model.TypeCode}';");
								if(formDb.Count() > 0)
								{
									//ไม่บันทึก 1.DataType  2.FormType  3.Remark
									await _dapperContext.Update<T_SchFormConv>($"UPDATE T_SchFormConv SET RowManyDue = @RowManyDue,FieldId = @FieldId,FieldName = @FieldName,StartPosition = @StartPosition,DataSize = @DataSize,Separater = @Separater,UpdatedBy = @UpdatedBy,UpdatedDate = @UpdatedDate WHERE CustId='{conv_model.CustId}' AND FieldId={conv_model.FieldId} AND TypeCode='{conv_model.TypeCode}';", conv_model);
								}
								else
								{
									await _dapperContext.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", conv_model);
								}

							}
							catch (Exception ex)
							{
								return Json(new { error = ex.Message });
							}

						}
					}
					catch (Exception ex)
					{
						return Json(new { error = ex.Message });
					}
				}

				return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
				return Json(new { error = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddCustDataType([FromForm] AddDataType input)
		{
			//if (ModelState.IsValid)
			//{
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
						SepMDSbyFlag01 = input.SepMDSbyFlag01,
						ShowInSch = input.ShowInSch,
						UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",
						Note = input.Note,
						UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
					};

					await _dapperContext.Insert<T_SchDataType_Cust>("INSERT INTO T_SchDataType_Cust (CustID,TypeCode,DeleteOld,SepMDSbyFlag01,FirmOrder,MakeMDS,ShowInSch,MixedSchWith,UpdatedBy,UpdatedDate,RowManyDue,ManyDueType,ManyDueDataNo,ManyDueSetNo,ManyDueDataLong,ForPOS,Note) VALUES (@CustID,@TypeCode,@DeleteOld,@SepMDSbyFlag01,@FirmOrder,@MakeMDS,@ShowInSch,@MixedSchWith,@UpdatedBy,@UpdatedDate,@RowManyDue,@ManyDueType,@ManyDueDataNo,@ManyDueSetNo,@ManyDueDataLong,@ForPOS,@Note)", model);

					foreach (var form in input.FieldsList!)
					{
						try
						{
							if (!string.IsNullOrEmpty(form.Name))
							{
								var conv_model = new T_SchFormConv
								{
									CustId = input.CustID,
									TypeCode = input.TypeCode,
									Separater = input.Seperator,
									RowManyDue = input.RowManyDue,
									UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",

									DataSize = form.EndPosition,
									StartPosition = form.StartPosition,
									FieldName = form.Name,
									FieldId = Convert.ToByte(form.FieldId),
									UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
								};
								await _dapperContext.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", conv_model);
							}
						}
						catch (Exception ex)
						{
							return Json(new { error = ex.Message });
						}
					}

					return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });
				}
				catch (Exception ex)
				{
					_logger.LogError(ex.Message);
					return Json(new { error = ex.Message });
				}
			//}
			//return Json(new { error = "กรุณากรอกข้อมูลให้ครบ" });

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
					if (input.Count == 0) return Json(new { error = "ไม่มีข้อมูลที่ต้องบันทึก" });

					foreach (var part in input)
					{
						var culture = new CultureInfo("en-US");
						var dueDate = DateTime.Parse(part.DueDate, culture); //input date format mm/dd/yyyy
						var dueYear = dueDate.Year >= 2500 ? dueDate.Year - 543 : dueDate.Year;
						part.DueDate = $"{dueYear}-{dueDate.Month}-{dueDate.Day} {dueDate.Hour}:{dueDate.Minute}:{dueDate.Second}";
						//part.DataType = part.DataType == "true" ? "1" : "0";
						var current_date = DateTime.Now;
						var importDate = new DateTime((current_date.Year <= 2500 ? current_date.Year : current_date.Year - 543), DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
						part.ImportDate = $"{importDate.Year}-{importDate.Month}-{importDate.Day} {importDate.Hour}:{importDate.Minute}:{importDate.Second}";

						await _dapperContext.Insert<T_SchOrdersPart>("INSERT INTO T_SchOrdersPart (CustID,OrdersNo,PONo,PlantCode,DueDate,Period,DueTime,PartNo,Qty,SentQty,Flag01,Flag02,Flag03,Flag04,Flag05,DataType,Status,ImportBy,ImportDate,FirmOrder,Exported,InvcNo,DataFileName,Flag06,Flag07,Flag08,Flag09,Flag10,PackageCD) VALUES (@CustID,@OrdersNo,@PONo,@PlantCode,@DueDate,@Period,@DueTime,@PartNo,@Qty,@SentQty,@Flag01,@Flag02,@Flag03,@Flag04,@Flag05,@DataType,@Status,@ImportBy,@ImportDate,@FirmOrder,@Exported,@InvcNo,@DataFileName,@Flag06,@Flag07,@Flag08,@Flag09,@Flag10,@PackageCD)", part);
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
				return Json(new { error = "เกิดข้อผิดพลาด " + ex.Message });
			}

		}


		public async Task<IActionResult> JsonAdjOrder(string? custId, string? dataTypeId)
		{
			return Json(await _dapperContext.QueryTableAsync<T_SchOrdersPart>($"SELECT * FROM T_SchOrdersPart WHERE CustID={custId} AND DataType={dataTypeId}"));
		}

		[HttpPost]
		public async Task<IActionResult> CancelOrder(string custId,string dataType,string orderNo,string po,string partNo)
		{
			var date = DateTime.Now;
			if(!string.IsNullOrEmpty(orderNo) && !string.IsNullOrEmpty(po) && !string.IsNullOrEmpty(partNo))//IsNullOrEmpty for all
			{
				await _dapperContext.Update($"UPDATE T_SchOrdersPart SET Qty=0 WHERE CustID='{custId}' AND DataType ='{dataType}' AND OrdersNo='{orderNo}' AND PONo='{po}' AND PartNo='{partNo}' AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 10",new {});
				return Json(new { msg = "แก้ไขเรียบร้อย" });
			}
			if (!string.IsNullOrEmpty(orderNo) && !string.IsNullOrEmpty(po))
			{
				var v= await _dapperContext.Update($"UPDATE T_SchOrdersPart SET Qty = 0 WHERE CustID='{custId}' AND DataType ='{dataType}' AND OrdersNo='{orderNo}' AND PONo='{po}' AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 10",new {});
				return Json(new { msg = "แก้ไขเรียบร้อย" });
			}
			if (!string.IsNullOrEmpty(orderNo))
			{
				await _dapperContext.Update($"UPDATE T_SchOrdersPart SET Qty=0 WHERE CustID='{custId}' AND DataType ='{dataType}' AND OrdersNo='{orderNo}' AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 10", new { });
				return Json(new { msg = "แก้ไขเรียบร้อย" });
			}
			if (!string.IsNullOrEmpty(po))
			{
				await _dapperContext.Update($"UPDATE T_SchOrdersPart SET Qty=0 WHERE CustID='{custId}' AND DataType ='{dataType}' AND PONo='{po}' AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 10", new { });
				return Json(new { msg = "แก้ไขเรียบร้อย" });
			}
			if (!string.IsNullOrEmpty(partNo))
			{
				await _dapperContext.Update($"UPDATE T_SchOrdersPart SET Qty = 0 WHERE CustID='{custId}' AND DataType ='{dataType}' AND PartNo='{partNo}' AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 10", new { });
				return Json(new { msg = "แก้ไขเรียบร้อย" });
			}
			return Json(new {error = "ไม่พบข้อมูล"});
		}

		public IActionResult ShiftDateTime(string date,string todo)
		{
			try
			{
				var culture = new CultureInfo("en-US");
				var dateTime = DateTime.Parse(date, culture);// mm/dd/yyyy
				if (todo == "out")
				{
					var added = dateTime.AddDays(1);
					var resDate = $"{added.Month}/{added.Day}/{added.Year}";
					return Json(new { date = resDate });
				}
				if (todo == "in")
				{
					var added = dateTime.AddDays(-1);
					var resDate = $"{added.Month}/{added.Day}/{added.Year}";
					return Json(new { date = resDate });
				}

			}
			catch(Exception ex) {
				return Ok(new { error = "เกิดข้อผิดพลาด "+ex.Message });
			}
			return Ok(new { error = "ป้อนข้อมูลไม่ถูกต้อง" });

		}
		public async Task<IActionResult> Slide(SlideDueDate input)
		{
			try
			{

			}catch(Exception ex)
			{

			}

			return Ok();
		}
	}
}
