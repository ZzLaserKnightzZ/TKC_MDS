
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Channels;
using TKC_MDS.Data;
using TKC_MDS.Models;
using TKC_MDS.Models.DTO;
using TKC_MDS.ReportModel;

namespace TKC_MDS.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		private readonly ILogger<OrderController> _logger;
		private readonly Dapper_Context _dapperContext;
		private readonly IWebHostEnvironment _env;
		public OrderController(ILogger<OrderController> logger, Dapper_Context dapper_Context, IWebHostEnvironment env)
		{
			_logger = logger;
			_dapperContext = dapper_Context;
			_env = env;
		}
		[Authorize(Roles =ConstanceRoles.DataType)]
		public IActionResult DataType()
		{
			return View();
		}
		[Authorize(Roles =ConstanceRoles.SaveOrder)]
		public IActionResult SaveOrder()
		{
			return View();
		}
		[Authorize(Roles = ConstanceRoles.AdjustOrder)]
		public IActionResult AdjustOrder()
		{
			return View();
		}
		[Authorize(Roles = ConstanceRoles.Report)]
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
		public async Task<IActionResult> JsondataType_cust(string custId, string typeCode)
		{
			var dataType_cust = await _dapperContext.QueryTableAsync<T_SchDataType_Cust>($"SELECT * FROM T_SchDataType_Cust WHERE CustID='{custId}' AND TypeCode='{typeCode}'");
			return Json(dataType_cust.FirstOrDefault());
		}

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
				await _dapperContext.Insert<T_SchDataType_MS>("INSERT INTO T_SchDataType_MS (TypeCode,TypeName, UpdatedBy,UpdatedDate) VALUES (@TypeCode,@TypeName, @UpdatedBy,@UpdatedDate)", new T_SchDataType_MS { TypeCode = (Convert.ToInt16(maxId) + 1) + "", UpdatedBy = User?.Identity?.Name?.Length > 0 ? User?.Identity?.Name : "", TypeName = name, UpdatedDate = $"{updateDate.Year}-{updateDate.Month}-{updateDate.Day} {updateDate.Hour}:{updateDate.Minute}:{updateDate.Second}" }); //ระวัง user ชื่อยาวเกิน 20
				return Json(new { msg = "บันทึกข้อมูลเรียยบร้อย" });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return Json(new { error = ex.Message });
			}

		}

		public async Task<IActionResult> JsonGetDataType(string custId, string dataTypeId)
		{
			try
			{
				var dataTypeCust = await _dapperContext.QueryTableAsync<T_SchDataType_Cust>($"SELECT * FROM T_SchDataType_Cust WHERE CustID='{custId}' AND TypeCode='{dataTypeId}'");
				var formConv = await _dapperContext.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustId='{custId}' AND TypeCode='{dataTypeId}'");

				return Json(new { dataType = dataTypeCust.FirstOrDefault(), form = formConv });
			}
			catch (Exception ex)
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
					Note = (input.Note == null ? "" : input.Note),
					UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
				};

				await _dapperContext.Update<T_SchDataType_Cust>($"UPDATE T_SchDataType_Cust SET DeleteOld = @DeleteOld,SepMDSbyFlag01 = @SepMDSbyFlag01,FirmOrder = @FirmOrder,MakeMDS = @MakeMDS,ShowInSch = @ShowInSch,MixedSchWith = @MixedSchWith,UpdatedBy = @UpdatedBy,UpdatedDate = @UpdatedDate,RowManyDue = @RowManyDue,ManyDueType = @ManyDueType,ManyDueDataNo = @ManyDueDataNo,ManyDueSetNo = @ManyDueSetNo,ManyDueDataLong = @ManyDueDataLong,ForPOS = @ForPOS,Note = @Note WHERE CustID='{input.CustID}' AND TypeCode='{input.TypeCode}';", model);

				foreach (var form in input.FieldsList!)
				{
					try
					{
						var conv_model = new T_SchFormConv
						{
							CustId = input.CustID,
							TypeCode = input.TypeCode,
							Separater = input.Seperator,
							RowManyDue = input.RowManyDue,
							DataType = false,
							UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",

							DataSize = form.EndPosition,
							StartPosition = form.StartPosition,
							FieldName = form.Name,
							FieldId = Convert.ToByte(form.FieldId),
							UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
						};

						if (!string.IsNullOrEmpty(form.Name))
						{

							try
							{
								var formDb = await _dapperContext.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustId='{conv_model.CustId}' AND FieldId={conv_model.FieldId} AND TypeCode='{conv_model.TypeCode}';");

								if (formDb.Count() > 0) //ถ้ามีของเดิม update ถ้าไม่มีเพิ่มไหม่
								{
									//ไม่บันทึก 1.DataTypeX  2.FormType  3.Remark
									await _dapperContext.Update<T_SchFormConv>($"UPDATE T_SchFormConv SET RowManyDue = @RowManyDue,FieldId = @FieldId,FieldName = @FieldName,StartPosition = @StartPosition,DataSize = @DataSize,Separater = @Separater,UpdatedBy = @UpdatedBy,UpdatedDate = @UpdatedDate WHERE CustId='{conv_model.CustId}' AND FieldId={conv_model.FieldId} AND TypeCode='{conv_model.TypeCode}';", conv_model);
								}
								else
								{
									//add
									await _dapperContext.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", conv_model);
								}

							}
							catch (Exception ex)
							{
								return Json(new { error = ex.Message });
							}

						}
						else
						{

							//remove no field
							if (string.IsNullOrEmpty(conv_model.FieldName))
							{
								var formDb = await _dapperContext.QueryTableAsync<T_SchFormConv>($"SELECT * FROM T_SchFormConv WHERE CustId='{conv_model.CustId}' AND FieldId={conv_model.FieldId} AND TypeCode='{conv_model.TypeCode}';");
								if (formDb.Count() > 0)
								{
									var remove = formDb.FirstOrDefault();
									if (remove != null)
										await _dapperContext.Update<T_SchFormConv>($"DELETE FROM T_SchFormConv WHERE  CustId='{remove.CustId}' AND FieldId={remove.FieldId} AND TypeCode='{remove.TypeCode}' AND FieldName='{remove.FieldName}'", new T_SchFormConv { });
								}
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
			catch (Exception ex)
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
					Note = (input.Note != null ? input.Note : ""),
					UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
				};

				await _dapperContext.Insert<T_SchDataType_Cust>("INSERT INTO T_SchDataType_Cust (CustID,TypeCode,DeleteOld,SepMDSbyFlag01,FirmOrder,MakeMDS,ShowInSch,MixedSchWith,UpdatedBy,UpdatedDate,RowManyDue,ManyDueType,ManyDueDataNo,ManyDueSetNo,ManyDueDataLong,ForPOS,Note) VALUES (@CustID,@TypeCode,@DeleteOld,@SepMDSbyFlag01,@FirmOrder,@MakeMDS,@ShowInSch,@MixedSchWith,@UpdatedBy,@UpdatedDate,@RowManyDue,@ManyDueType,@ManyDueDataNo,@ManyDueSetNo,@ManyDueDataLong,@ForPOS,@Note)", model);
				//sort
				var f = input.FieldsList.Where(x => !string.IsNullOrEmpty(x.Name));
				var i = 1;
				foreach (var ff in f)
				{
					ff.FieldId = i;
					i++;
				}
				//end sort

				//get FormType name
				var select_dataType = $"SELECT * FROM T_SchDataType_MS WHERE TypeCode='{input.TypeCode}'";
				var dataTypes = await _dapperContext.QueryTableAsync<T_SchDataType_MS>(select_dataType);
				var dataType = dataTypes.FirstOrDefault();
				//end get FormType name

				foreach (var form in f)
				{
					try
					{
						//if (!string.IsNullOrEmpty(form.Name))
						//{
						var conv_model = new T_SchFormConv
						{
							CustId = input.CustID,
							TypeCode = input.TypeCode,
							Separater = input.Seperator,
							RowManyDue = input.RowManyDue,
							DataType = false,
							UpdatedBy = User.Identity?.Name != null ? User.Identity?.Name : "",

							DataSize = form.EndPosition,
							StartPosition = form.StartPosition,
							FieldName = form.Name,
							FieldId = Convert.ToByte(form.FieldId),
							FormType = dataType?.TypeName,
							UpdatedDate = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}"
						};
						await _dapperContext.Insert<T_SchFormConv>("INSERT INTO T_SchFormConv (CustId,DataType,RowManyDue,FieldId,FieldName,StartPosition,DataSize,Separater,FormType,Remark,TypeCode,UpdatedBy,UpdatedDate) VALUES (@CustId,@DataType,@RowManyDue,@FieldId,@FieldName,@StartPosition,@DataSize,@Separater,@FormType,@Remark,@TypeCode,@UpdatedBy,@UpdatedDate)", conv_model);
						//}
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


		[HttpPost]
		public async Task<IActionResult> SaveOrders([FromBody] List<T_SchOrdersPart> input)
		{
			try
			{


				if (input != null)
				{
					//old part
					var first_part = input.FirstOrDefault();
					if (first_part != null)
					{
						var old_file = await _dapperContext.QueryTableAsync<T_SchDataType_Cust>($"SELECT * FROM T_SchDataType_Cust WHERE CustID='{first_part.CustID}' AND TypeCode='{first_part.DataType}'");
						if (old_file != null)
						{
							var isDelete = old_file.FirstOrDefault();
							if (isDelete != null)
								if (isDelete.DeleteOld) //is delete old part
								{
									try //for none column
									{
										await _dapperContext.Update($"DELETE FROM T_SchOrdersPart WHERE CustID='{first_part.CustID}' AND DataType='{first_part.DataType}' AND DataFileName='{first_part.DataFileName}'", new { });
									}
									catch (Exception ex)
									{

									}
								}
						}
					}

					if (input.Count == 0) return Json(new { error = "ไม่มีข้อมูลที่ต้องบันทึก" });
					var updated = 0;
					var error = "";
					var error_count = 0;

                    foreach (var part in input.OrderByDescending(x => x.DueDate)) //protect date 00/00/0000
					{
						try
						{
							var culture = new CultureInfo("en-US");
							var dueDate = DateTime.Parse(part.DueDate, culture); //input date format mm/dd/yyyy
							var dueYear = dueDate.Year >= 2500 ? dueDate.Year - 543 : dueDate.Year; //if พศ.
							part.DueDate = $"{dueYear}-{dueDate.Month}-{dueDate.Day} {dueDate.Hour}:{dueDate.Minute}:{dueDate.Second}";
							//part.DataType = part.DataType == "true" ? "1" : "0";
							#region remove speacial char
							StringBuilder sb = new StringBuilder();
							foreach (char c in part.PartNo)
							{
								if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
								{
									sb.Append(c);
								}
							}
							part.PartNo = sb.ToString();
							#endregion
							var current_date = DateTime.Now;
							var importDate = new DateTime((current_date.Year <= 2500 ? current_date.Year : current_date.Year - 543), DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
							part.ImportDate = $"{importDate.Year}-{importDate.Month}-{importDate.Day} {importDate.Hour}:{importDate.Minute}:{importDate.Second}";
                            //default
                            part.Status = part.Status != null ? part.Status:false;
							part.ImportBy = User?.Identity?.Name != null ? User?.Identity?.Name : "";
							part.FirmOrder = part.FirmOrder != null ? part.FirmOrder :false;
							part.Exported = part.Exported != null ? part.Exported : false;
							part.InvcNo = part.InvcNo != null ? part.InvcNo : "";
							part.PackageCD = part.PackageCD != null ? part.PackageCD : "";
                            //end default
                            updated += await _dapperContext.Insert<T_SchOrdersPart>("INSERT INTO T_SchOrdersPart (CustID,OrdersNo,PONo,PlantCode,DueDate,Period,DueTime,PartNo,Qty,SentQty,Flag01,Flag02,Flag03,Flag04,Flag05,DataType,Status,ImportBy,ImportDate,FirmOrder,Exported,InvcNo,DataFileName,Flag06,Flag07,Flag08,Flag09,Flag10,PackageCD) VALUES (@CustID,@OrdersNo,@PONo,@PlantCode,@DueDate,@Period,@DueTime,@PartNo,@Qty,@SentQty,@Flag01,@Flag02,@Flag03,@Flag04,@Flag05,@DataType,@Status,@ImportBy,@ImportDate,@FirmOrder,@Exported,@InvcNo,@DataFileName,@Flag06,@Flag07,@Flag08,@Flag09,@Flag10,@PackageCD)", part);
						}
						catch (Exception ex)
						{
							//error datetime
							error += ex.Message;
							error_count++;
                        }
					}
					return Json(new { msg = "บันทึกข้อมูลเรียบร้อย " + updated + " รายการ ผิดพลาด "+error_count+" รายการ error => " +error });
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
			var date = DateTime.Now;
			var orders = await _dapperContext.QueryTableAsync<T_SchOrdersPart>($"SELECT * FROM T_SchOrdersPart WHERE CustID={custId} AND DataType={dataTypeId} AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 100");
			if (orders != null)
			{
				var orderList = orders.ToList();
				//convert date mm/dd/yyyy to dd/mm/yyyy
				orderList.ForEach(or =>
				{
					or.DueDate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(or.DueDate);
				}); 

				return Json(orderList);
			}
			else
			{
				return NoContent();
			}
			
		}

		[HttpPost]
		public async Task<IActionResult> CancelOrder([FromForm] SlideDueDate cancel) //string custId, string dataType, string orderNo, string po, string partNo,string plant
		{

			var order = 0;
			var strMultiPart = string.Empty;
			if (cancel?.PartsNo?.Count > 0) //filter part
			{
				strMultiPart += " AND ";
				int isLast = 0;
				cancel.PartsNo.ForEach(part =>
				{
					strMultiPart += $"PartNo='{part}' ";
					isLast++;
					if (isLast < cancel.PartsNo.Count) //if (isLast < cancel.PartsNo.Count - 1)
					{
						strMultiPart += $"OR ";
					}
				});
			}

			try
			{
				if (cancel.ShiftDate.Count > 0) //qty=0 selected 
				{
					foreach (var dueDate in cancel.ShiftDate)
					{
						try
						{
							var culture = new CultureInfo("en-US");
							var newDate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(dueDate.FromDate); //convert date dd/mm/yyyy to mm/dd/yyyy
							var date = DateTime.Parse(newDate, culture);
							order += await _dapperContext.Update($"UPDATE T_SchOrdersPart SET Qty=0 WHERE CustID='{cancel.CustID}' AND DataType ='{cancel.DataType}'{(!string.IsNullOrEmpty(cancel.OrdersNo) ? $" AND OrdersNo='{cancel.OrdersNo}'" : "")}{(!string.IsNullOrEmpty(cancel.PONo) ? $" AND PONo='{cancel.PONo}'" : "")}{(!string.IsNullOrEmpty(strMultiPart) ? strMultiPart : "")} AND DueDate='{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}'", new { });
						}
						catch (Exception ex)
						{

						}
					}
				}
				else //set qty=0 all ต้องมี order part
				{
					var strSql = $"UPDATE T_SchOrdersPart SET Qty=0 WHERE CustID='{cancel.CustID}' AND DataType ='{cancel.DataType}'{(!string.IsNullOrEmpty(cancel.OrdersNo) ? $" AND OrdersNo='{cancel.OrdersNo}'" : "")}{(!string.IsNullOrEmpty(cancel.PONo) ? $" AND PONo='{cancel.PONo}'" : "")}{(!string.IsNullOrEmpty(strMultiPart) ? strMultiPart : "")}";
					order = await _dapperContext.Update(strSql, new { });
				}

				return Json(new { msg = "แก้ไขเรียบร้อย " + order + " รายการ" });
			}
			catch (Exception ex)
			{
				return Json(new { error = "เกิดข้อผิดพลาด > " + ex.Message });
			}
		}

		public IActionResult ShiftDateTime(string date, string todo)
		{
			try
			{
				var culture = new CultureInfo("en-US");
				var newDate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(date); //convert date dd/mm/yyyy to mm/dd/yyyy
				var dateTime = DateTime.Parse(newDate, culture);// mm/dd/yyyy
				if (todo == "out")
				{
					var added = dateTime.AddDays(1);
					var resDate = $"{added.Day:00}/{added.Month:00}/{ (added.Year > 2500 ? added.Year -543:added.Year)} {added.Hour:00}:{added.Minute:00}:{added.Second:00}";
					return Json(new { date = resDate });
				}
				if (todo == "in")
				{
					var added = dateTime.AddDays(-1);
					var resDate = $"{added.Day:00}/{added.Month:00}/{(added.Year > 2500 ? added.Year - 543 : added.Year)} {added.Hour:00}:{added.Minute:00}:{added.Second:00}";
					return Json(new { date = resDate });
				}

			}
			catch (Exception ex)
			{
				return Ok(new { error = "เกิดข้อผิดพลาด " + ex.Message });
			}
			return Ok(new { error = "ป้อนข้อมูลไม่ถูกต้อง" });

		}

		/*
		 1.Status ทั้งสอง table +T_SchOrdersPart +T_SchAdjust_Data
		 2.where Status=1
		 3.มีการใส่วันที่หุกวันหรือไม่ การกำหนด multipartวันที่เดียวกัน ทำให้เกิดข้อผิดพลาดอัพเดททั้งหมด เรื่อง Duedate peraid 
		 */
		[HttpPost]
		public async Task<IActionResult> SlideIn([FromForm] SlideDueDate input)
		{
			try
			{
				var updated = 0;
				var error = string.Empty;
				var strMultiPart = string.Empty;
				if (input?.PartsNo?.Count > 0)
				{
					strMultiPart += " AND ";
					int isLast = 0;
					input.PartsNo.ForEach(part =>
					{
						strMultiPart += $"PartNo='{part}' ";

						if (isLast < input.PartsNo.Count - 1)
						{
							strMultiPart += $"OR ";
						}
						isLast++;
					});
				}

				foreach (var shiftDate in input.ShiftDate.OrderBy(x => DateTime.Parse(ConvertDate_MMDDYYYY_swap_DDMMYYYY(x.ToDate), new CultureInfo("en-US")) ))
				{

					try
					{
						var culture = new CultureInfo("en-US");
						var newTodate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(shiftDate.ToDate); //convert date dd/mm/yyyy to mm/dd/yyyy
						var toDate = DateTime.Parse(newTodate, culture);
						var strToDate = $"'{toDate.Year}-{toDate.Month:00}-{toDate.Day:00} {toDate.Hour:00}:{toDate.Minute:00}:{toDate.Second:00}'";

						var newFromDate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(shiftDate.FromDate); //convert date dd/mm/yyyy to mm/dd/yyyy
						var fromDate = DateTime.Parse(newFromDate, culture);
						var strFromDate = $"'{fromDate.Year}-{fromDate.Month:00}-{fromDate.Day:00} {fromDate.Hour:00}:{fromDate.Minute:00}:{fromDate.Second:00}'";
						
						var date = DateTime.Now;
						var strDate = $"'{date.Year}-{date.Month:00}-{date.Day:00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}'";


						string query_part = $"SELECT * FROM T_SchOrdersPart WHERE CustID='{input.CustID}' AND DataType ='{input.DataType}' AND DueDate={strFromDate} {((!string.IsNullOrEmpty(input.PlantCode)) ? $"AND PlantCode='{input.PlantCode}'" : "")} {((!string.IsNullOrEmpty(input.OrdersNo)) ? $"AND OrdersNo='{input.OrdersNo}'" : "")} {((!string.IsNullOrEmpty(input.PONo)) ? $"AND PONo='{input.PONo}'" : "")} {strMultiPart} AND DATEDIFF(day, T_SchOrdersPart.DueDate,{strDate}) <= 100";
						var order_part = await _dapperContext.QueryTableAsync<T_SchOrdersPart>(query_part);

						string cmd = $"UPDATE T_SchOrdersPart SET DueDate = {strToDate},Period='{shiftDate.ToPeriod}',DueTime='{shiftDate.ToTime}',Status=1 WHERE CustID='{input.CustID}' AND DataType ='{input.DataType}' AND DueDate={strFromDate} {((!string.IsNullOrEmpty(input.PlantCode)) ? $"AND PlantCode='{input.PlantCode}'" : "")} {((!string.IsNullOrEmpty(input.OrdersNo)) ? $"AND OrdersNo='{input.OrdersNo}'" : "")} {((!string.IsNullOrEmpty(input.PONo)) ? $"AND PONo='{input.PONo}'" : "")} {strMultiPart} AND DATEDIFF(day, T_SchOrdersPart.DueDate,{strDate}) <= 100";
						var update = await _dapperContext.Update(cmd, new { });
						updated += update;
						//update log
						if (update > 0)//if update success
						{
							foreach (var orderUpdated in order_part)
							{
								/*
								 //PartCheck
								คือค่า 0,1
								0= ไม่มีการกำหนดพาร์ท
								1= มีการกำหนดพาร์ท
								//ActDate
								คือค่า วันที่และเวลา ในการปรับ
								AdjustType คือค่า 0,1
								0= เลือนออก
								1= เลือนเข้า
								 */
								var DueDateF = strFromDate.Substring(1, strFromDate.Length - 2); //remove ''
								var DueDateT = strToDate.Substring(1, strToDate.Length - 2);  //remove ''
								var actDate = strDate.Substring(1, strDate.Length - 2);  //remove ''

								var dataType = new T_SchAdjust_Data
								{
									DataType = orderUpdated.DataType,
									CustID = orderUpdated.CustID,
									OrdersNo = orderUpdated.OrdersNo,
									AdjustType = true, //what
									Status = true,//updated
									PlantCode = orderUpdated.PlantCode,
									PONo = orderUpdated.PONo,
									DueDateF = DueDateF,
									DueDateT = DueDateT,
									DueTimeF = shiftDate.FromTime,
									DueTimeT = shiftDate.ToTime,
									PeriodF = shiftDate.FromPeriod,
									PeriodT = shiftDate.ToPeriod,
									ActDate = actDate,
									PartCheck = string.IsNullOrEmpty(strMultiPart) ? false : true,
									sUser = User?.Identity?.Name?.Length > 0 ? User.Identity.Name : ""
								};
								var adj_dataType_cmd = $"INSERT INTO T_SchAdjust_Data (CustID,DataType,AdjustType,PlantCode,OrdersNo,PONo,PartCheck,DueDateF,PeriodF,DueTimeF,DueDateT,PeriodT,DueTimeT,Status,sUser,ActDate) VALUES (@CustID,@DataType,@AdjustType,@PlantCode,@OrdersNo,@PONo,@PartCheck,@DueDateF,@PeriodF,@DueTimeF,@DueDateT,@PeriodT,@DueTimeT,@Status,@sUser,@ActDate)";
								await _dapperContext.Insert(adj_dataType_cmd, dataType);
								var itemlist = new T_SchAdjust_ItemList
								{
									CustID = orderUpdated.CustID,
									DataType = orderUpdated.DataType,
									PartNo = orderUpdated.PartNo,
									sUser = User?.Identity?.Name?.Length > 0 ? User.Identity.Name : ""
								};
								var ajd_item_list_cmd = $"INSERT INTO T_SchAdjust_ItemList (CustID,DataType,PartNo,sUser) VALUES (@CustID,@DataType,@PartNo,@sUser)";
								await _dapperContext.Insert(ajd_item_list_cmd, itemlist);
							}

						}

					}
					catch (Exception ex)
					{
						error += ex.Message;
					}
				}
				return Json(new { msg = "บันทึกข้อมูลเรียบร้อย " + updated + " รายการ error => " + error});

			}
			catch (Exception ex)
			{
				return Json(new { error = "เกิดข้อผิดพลาด > " + ex.Message });
			}
		}
		[HttpPost]
		public async Task<IActionResult> SlideOut([FromForm] SlideDueDate input)
		{
			try
			{
				var updated = 0;
				var error = string.Empty;
				var strMultiPart = string.Empty;
				if (input?.PartsNo?.Count > 0)
				{
					strMultiPart += " AND ";
					int isLast = 0;
					input.PartsNo.ForEach(part =>
					{
						strMultiPart += $"PartNo='{part}' ";

						if (isLast < input.PartsNo.Count - 1)
						{
							strMultiPart += $"OR ";
						}
						isLast++;
					});
				}

				foreach (var shiftDate in input.ShiftDate.OrderByDescending(x => DateTime.Parse(ConvertDate_MMDDYYYY_swap_DDMMYYYY(x.ToDate), new CultureInfo("en-US"))))
				{

					try
					{
						var culture = new CultureInfo("en-US");
						var newTodate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(shiftDate.ToDate); //convert date dd/mm/yyyy to mm/dd/yyyy
						var toDate = DateTime.Parse(newTodate, culture);
						var strToDate = $"'{toDate.Year}-{toDate.Month:00}-{toDate.Day:00} {toDate.Hour:00}:{toDate.Minute:00}:{toDate.Second:00}'";

						var newFromDate = ConvertDate_MMDDYYYY_swap_DDMMYYYY(shiftDate.FromDate); //convert date dd/mm/yyyy to mm/dd/yyyy
						var fromDate = DateTime.Parse(newFromDate, culture);
						var strFromDate = $"'{fromDate.Year}-{fromDate.Month:00}-{fromDate.Day:00} {fromDate.Hour:00}:{fromDate.Minute:00}:{fromDate.Second:00}'";

						var date = DateTime.Now;
						var strDate = $"'{date.Year}-{date.Month:00}-{date.Day:00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}'";


						string query_part = $"SELECT * FROM T_SchOrdersPart WHERE CustID='{input.CustID}' AND DataType ='{input.DataType}' AND DueDate={strFromDate} {((!string.IsNullOrEmpty(input.PlantCode)) ? $"AND PlantCode='{input.PlantCode}'" : "")} {((!string.IsNullOrEmpty(input.OrdersNo)) ? $"AND OrdersNo='{input.OrdersNo}'" : "")} {((!string.IsNullOrEmpty(input.PONo)) ? $"AND PONo='{input.PONo}'" : "")} {strMultiPart} AND DATEDIFF(day, T_SchOrdersPart.DueDate,{strDate}) <= 100";
						var order_part = await _dapperContext.QueryTableAsync<T_SchOrdersPart>(query_part);

						string cmd = $"UPDATE T_SchOrdersPart SET DueDate = {strToDate},Period='{shiftDate.ToPeriod}',DueTime='{shiftDate.ToTime}',Status=1 WHERE CustID='{input.CustID}' AND DataType ='{input.DataType}' AND DueDate={strFromDate} {((!string.IsNullOrEmpty(input.PlantCode)) ? $"AND PlantCode='{input.PlantCode}'" : "")} {((!string.IsNullOrEmpty(input.OrdersNo)) ? $"AND OrdersNo='{input.OrdersNo}'" : "")} {((!string.IsNullOrEmpty(input.PONo)) ? $"AND PONo='{input.PONo}'" : "")} {strMultiPart} AND DATEDIFF(day, T_SchOrdersPart.DueDate,{strDate}) <= 100";
						var update = await _dapperContext.Update(cmd, new { });
						updated += update;
						//update log
						if (update > 0)//if update success
						{
							foreach (var orderUpdated in order_part)
							{
								/*
								 //PartCheck
								คือค่า 0,1
								0= ไม่มีการกำหนดพาร์ท
								1= มีการกำหนดพาร์ท
								//ActDate
								คือค่า วันที่และเวลา ในการปรับ
								AdjustType คือค่า 0,1
								0= เลือนออก
								1= เลือนเข้า
								 */
								var DueDateF = strFromDate.Substring(1, strFromDate.Length - 2); //remove ''
								var DueDateT = strToDate.Substring(1, strToDate.Length - 2);  //remove ''
								var actDate = strDate.Substring(1, strDate.Length - 2);  //remove ''

								var dataType = new T_SchAdjust_Data
								{
									DataType = orderUpdated.DataType,
									CustID = orderUpdated.CustID,
									OrdersNo = orderUpdated.OrdersNo,
									AdjustType = false, //what
									Status = true,//updated
									PlantCode = orderUpdated.PlantCode,
									PONo = orderUpdated.PONo,
									DueDateF = DueDateF,
									DueDateT = DueDateT,
									DueTimeF = shiftDate.FromTime,
									DueTimeT = shiftDate.ToTime,
									PeriodF = shiftDate.FromPeriod,
									PeriodT = shiftDate.ToPeriod,
									ActDate = actDate,
									PartCheck = string.IsNullOrEmpty(strMultiPart) ? false : true,
									sUser = User?.Identity?.Name?.Length > 0 ? User.Identity.Name : ""
								};
								var adj_dataType_cmd = $"INSERT INTO T_SchAdjust_Data (CustID,DataType,AdjustType,PlantCode,OrdersNo,PONo,PartCheck,DueDateF,PeriodF,DueTimeF,DueDateT,PeriodT,DueTimeT,Status,sUser,ActDate) VALUES (@CustID,@DataType,@AdjustType,@PlantCode,@OrdersNo,@PONo,@PartCheck,@DueDateF,@PeriodF,@DueTimeF,@DueDateT,@PeriodT,@DueTimeT,@Status,@sUser,@ActDate)";
								await _dapperContext.Insert(adj_dataType_cmd, dataType);
								var itemlist = new T_SchAdjust_ItemList
								{
									CustID = orderUpdated.CustID,
									DataType = orderUpdated.DataType,
									PartNo = orderUpdated.PartNo,
									sUser = User?.Identity?.Name?.Length > 0 ? User.Identity.Name : ""
								};
								var ajd_item_list_cmd = $"INSERT INTO T_SchAdjust_ItemList (CustID,DataType,PartNo,sUser) VALUES (@CustID,@DataType,@PartNo,@sUser)";
								await _dapperContext.Insert(ajd_item_list_cmd, itemlist);
							}

						}

					}
					catch (Exception ex)
					{
						error += ex.Message;
					}
				}
				return Json(new { msg = "บันทึกข้อมูลเรียบร้อย " + updated + " รายการ error => " + error });

			}
			catch (Exception ex)
			{
				return Json(new { error = "เกิดข้อผิดพลาด > " + ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> GetMounthReport(string custId,string dataType)
		{
			var orders = await _dapperContext.QueryTableAsync<View_Report>($"SELECT * FROM V_MDS_By_Orders  WHERE CustID='{custId}' AND DataType='{dataType}'");
			var orderMonth = orders.Select(x => x.nMonth).Distinct().ToList();
			return Json(orderMonth);
		}

		[HttpPost]
		public async Task<IActionResult> Report([FromForm] Report input)
		{
			//test custid = 4211 datatype = 01
			var orders = await _dapperContext.QueryTableAsync<View_Report>($"SELECT * FROM V_MDS_By_Orders  WHERE CustID='{input.CustId}' AND DataType='{input.DataType}'"); // WHERE CustID='{input.CustId}' AND DataType='{input.DataType}' AND nMonth='{input.ReportMount}'
			if (input.DocReportType == "PDF") //pdf
			{
				#region hearder pdf
				void AddCellNoBorder(iText.Layout.Element.Table t, string paragraph)
				{
					t.AddCell(new Cell().Add(new Paragraph(paragraph).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5).SetBorder(Border.NO_BORDER));//.SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
				}
				void AddCell(iText.Layout.Element.Table t, string paragraph)
				{
					t.AddCell(new Cell().Add(new Paragraph(paragraph).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				}

				var show_path = System.IO.Path.Combine("Pdf", "test.pdf");
				var pathfile = System.IO.Path.Combine(_env.WebRootPath, show_path);

				var memoryStream = new MemoryStream();
				PdfWriter writer = new PdfWriter(memoryStream);
				PdfDocument pdfDocument = new PdfDocument(writer);
				Document document = new Document(pdfDocument, PageSize.A4.Rotate());

				document.Add(new Paragraph("MASTER DELIVERY SCHEDULE").SetTextAlignment(TextAlignment.CENTER));
				var issueDate = DateTime.Now;
				Paragraph p = new Paragraph($"Issue Date {issueDate.Day:00}/{issueDate.Month:00}/{issueDate.Year} Time {issueDate.Hour:00}:{issueDate.Minute:00}:{issueDate.Second:00}");
				p.Add(new Tab());
				p.AddTabStops(new TabStop(400, TabAlignment.CENTER));
				p.Add($"CUSTOMER: {input.CustId} Data Type: {input.DataType}");
				/*
				p.Add(new Tab());
				p.AddTabStops(new TabStop(1000, TabAlignment.RIGHT));
				p.Add("Text to the Left");
				*/
				document.Add(p);
				
				//header
				float[] ColumnWidth = { 30f, 30f, 40f, 30f, 50f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 20f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f };
				iText.Layout.Element.Table table = new iText.Layout.Element.Table(ColumnWidth);
				AddCell(table,"MOD");
				AddCell(table,"KBNo");
				AddCell(table,"CUST PART");
				AddCell(table,"TKC PART");
				AddCell(table,"PART NAME");

				for (var i = 1; i <= 31; i++)
				{
					AddCell(table,i + "");
				}
				AddCell(table,"TOTAL");
				document.Add(table);
				#endregion

				ulong line_counter = 0; //loop counter
				var factorys = orders.Select(order => order.FacNo).Distinct().ToList(); //select facno 
				foreach (var fac in factorys)
				{
					var plants = orders.Where(order => order.FacNo == fac).Select(order => order.PlantCode).Distinct().ToList(); //select plant
					foreach (var plant in plants)
					{
						iText.Layout.Element.Table table_plan = new iText.Layout.Element.Table(ColumnWidth);
						AddCellNoBorder(table_plan,$"Factory: {fac} Plant: {plant}");
						for (int i = 0; i < 35; i++) AddCellNoBorder(table_plan, "");
						document.Add(table_plan);

						foreach (var print_order in orders.Where(order => order.FacNo == fac && order.PlantCode == plant).ToList())//one day
						{
							
							//print
							iText.Layout.Element.Table tabledata = new iText.Layout.Element.Table(ColumnWidth);

							AddCellNoBorder(tabledata, print_order.MODEL == null ? "": print_order.MODEL);
							AddCellNoBorder(tabledata, print_order.KBCd == null ? "" : print_order.KBCd);
							AddCellNoBorder(tabledata, print_order.CustPartNo2 == null ? "" : print_order.CustPartNo2);
							AddCellNoBorder(tabledata, print_order.TKCPartNo == null ? "" : print_order.TKCPartNo);
							AddCellNoBorder(tabledata, print_order.PartName == null ? "" : print_order.PartName);

							#region day
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day1.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day2.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day3.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day4.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day5.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);

							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day6.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day7.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day8.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day9.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day10.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);

							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day11.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day12.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day13.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day14.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day15.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);

							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day16.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day17.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day18.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day19.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day20.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);

							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day21.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day22.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day23.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day24.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day25.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);

							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day26.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day27.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day28.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day29.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day30.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);

							//table.AddCell(new Cell().Add(new Paragraph(print_order.Day31.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							AddCellNoBorder(tabledata, print_order.Day1.ToString());
							AddCellNoBorder(tabledata, print_order.Day2.ToString());
							AddCellNoBorder(tabledata, print_order.Day3.ToString());
							AddCellNoBorder(tabledata, print_order.Day4.ToString());
							AddCellNoBorder(tabledata, print_order.Day5.ToString());

							AddCellNoBorder(tabledata, print_order.Day6.ToString());
							AddCellNoBorder(tabledata, print_order.Day7.ToString());
							AddCellNoBorder(tabledata, print_order.Day8.ToString());
							AddCellNoBorder(tabledata, print_order.Day9.ToString());
							AddCellNoBorder(tabledata, print_order.Day10.ToString());

							AddCellNoBorder(tabledata, print_order.Day11.ToString());
							AddCellNoBorder(tabledata, print_order.Day12.ToString());
							AddCellNoBorder(tabledata, print_order.Day13.ToString());
							AddCellNoBorder(tabledata, print_order.Day14.ToString());
							AddCellNoBorder(tabledata, print_order.Day15.ToString());

							AddCellNoBorder(tabledata, print_order.Day16.ToString());
							AddCellNoBorder(tabledata, print_order.Day17.ToString());
							AddCellNoBorder(tabledata, print_order.Day18.ToString());
							AddCellNoBorder(tabledata, print_order.Day19.ToString());
							AddCellNoBorder(tabledata, print_order.Day20.ToString());

							AddCellNoBorder(tabledata, print_order.Day21.ToString());
							AddCellNoBorder(tabledata, print_order.Day22.ToString());
							AddCellNoBorder(tabledata, print_order.Day23.ToString());
							AddCellNoBorder(tabledata, print_order.Day24.ToString());
							AddCellNoBorder(tabledata, print_order.Day25.ToString());

							AddCellNoBorder(tabledata, print_order.Day26.ToString());
							AddCellNoBorder(tabledata, print_order.Day27.ToString());
							AddCellNoBorder(tabledata, print_order.Day28.ToString());
							AddCellNoBorder(tabledata, print_order.Day29.ToString());
							AddCellNoBorder(tabledata, print_order.Day30.ToString());

							AddCellNoBorder(tabledata, print_order.Day31.ToString());
							#endregion
							//table.AddCell(new Cell().Add(new Paragraph(print_order.Total.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5)).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
							AddCellNoBorder(tabledata, print_order.Total.ToString());

							document.Add(tabledata);
						}
					}

					//regionsum amount of factory
					var day = orders.Where(order => order.FacNo == fac);
					var fday1 = day.Select(order => order.Day1).Sum();
					var fday2 = day.Select(order => order.Day2).Sum();
					var fday3 = day.Select(order => order.Day3).Sum();
					var fday4 = day.Select(order => order.Day4).Sum();
					var fday5 = day.Select(order => order.Day5).Sum();
					var fday6 = day.Select(order => order.Day6).Sum();
					var fday7 = day.Select(order => order.Day7).Sum();
					var fday8 = day.Select(order => order.Day8).Sum();
					var fday9 = day.Select(order => order.Day9).Sum();
					var fday10 = day.Select(order => order.Day10).Sum();
					var fday11 = day.Select(order => order.Day11).Sum();
					var fday12 = day.Select(order => order.Day12).Sum();
					var fday13 = day.Select(order => order.Day13).Sum();
					var fday14 = day.Select(order => order.Day14).Sum();
					var fday15 = day.Select(order => order.Day15).Sum();
					var fday16 = day.Select(order => order.Day16).Sum();
					var fday17 = day.Select(order => order.Day17).Sum();
					var fday18 = day.Select(order => order.Day18).Sum();
					var fday19 = day.Select(order => order.Day19).Sum();
					var fday20 = day.Select(order => order.Day20).Sum();
					var fday21 = day.Select(order => order.Day21).Sum();
					var fday22 = day.Select(order => order.Day22).Sum();
					var fday23 = day.Select(order => order.Day23).Sum();
					var fday24 = day.Select(order => order.Day24).Sum();
					var fday25 = day.Select(order => order.Day25).Sum();
					var fday26 = day.Select(order => order.Day26).Sum();
					var fday27 = day.Select(order => order.Day27).Sum();
					var fday28 = day.Select(order => order.Day28).Sum();
					var fday29 = day.Select(order => order.Day29).Sum();
					var fday30 = day.Select(order => order.Day30).Sum();
					var fday31 = day.Select(order => order.Day31).Sum();
					decimal fTotal = 0;
					foreach (var ftotal in day)
					{
						fTotal += ftotal.Total;
					}
					//print
					iText.Layout.Element.Table table_sum_fac = new iText.Layout.Element.Table(ColumnWidth);
					AddCellNoBorder(table_sum_fac, "");
					AddCellNoBorder(table_sum_fac, "");
					AddCellNoBorder(table_sum_fac, "");
					AddCellNoBorder(table_sum_fac, "");
					AddCellNoBorder(table_sum_fac, "Factory: " + fac + " Plant: " + " Total : "); // plants

					#region day

					AddCellNoBorder(table_sum_fac, fday1.ToString());
					AddCellNoBorder(table_sum_fac, fday2.ToString());
					AddCellNoBorder(table_sum_fac, fday3.ToString());
					AddCellNoBorder(table_sum_fac, fday4.ToString());
					AddCellNoBorder(table_sum_fac, fday5.ToString());

					AddCellNoBorder(table_sum_fac, fday6.ToString());
					AddCellNoBorder(table_sum_fac, fday7.ToString());
					AddCellNoBorder(table_sum_fac, fday8.ToString());
					AddCellNoBorder(table_sum_fac, fday9.ToString());
					AddCellNoBorder(table_sum_fac, fday10.ToString());

					AddCellNoBorder(table_sum_fac, fday11.ToString());
					AddCellNoBorder(table_sum_fac, fday12.ToString());
					AddCellNoBorder(table_sum_fac, fday13.ToString());
					AddCellNoBorder(table_sum_fac, fday14.ToString());
					AddCellNoBorder(table_sum_fac, fday15.ToString());

					AddCellNoBorder(table_sum_fac, fday16.ToString());
					AddCellNoBorder(table_sum_fac, fday17.ToString());
					AddCellNoBorder(table_sum_fac, fday18.ToString());
					AddCellNoBorder(table_sum_fac, fday19.ToString());
					AddCellNoBorder(table_sum_fac, fday20.ToString());

					AddCellNoBorder(table_sum_fac, fday21.ToString());
					AddCellNoBorder(table_sum_fac, fday22.ToString());
					AddCellNoBorder(table_sum_fac, fday23.ToString());
					AddCellNoBorder(table_sum_fac, fday24.ToString());
					AddCellNoBorder(table_sum_fac, fday25.ToString());

					AddCellNoBorder(table_sum_fac, fday26.ToString());
					AddCellNoBorder(table_sum_fac, fday27.ToString());
					AddCellNoBorder(table_sum_fac, fday28.ToString());
					AddCellNoBorder(table_sum_fac, fday29.ToString());
					AddCellNoBorder(table_sum_fac, fday30.ToString());

					AddCellNoBorder(table_sum_fac, fday31.ToString());
					#endregion
					//tabledata.AddCell(new Cell().Add(new Paragraph(fTotal.ToString()).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					AddCellNoBorder(table_sum_fac, fTotal.ToString());
					document.Add(table_sum_fac);
				}
				#region sum all
				//sum all of query
				var day1 = orders.Select(order => order.Day1).Sum();
				var day2 = orders.Select(order => order.Day2).Sum();
				var day3 = orders.Select(order => order.Day3).Sum();
				var day4 = orders.Select(order => order.Day4).Sum();
				var day5 = orders.Select(order => order.Day5).Sum();
				var day6 = orders.Select(order => order.Day6).Sum();
				var day7 = orders.Select(order => order.Day7).Sum();
				var day8 = orders.Select(order => order.Day8).Sum();
				var day9 = orders.Select(order => order.Day9).Sum();
				var day10 = orders.Select(order => order.Day10).Sum();
				var day11 = orders.Select(order => order.Day11).Sum();
				var day12 = orders.Select(order => order.Day12).Sum();
				var day13 = orders.Select(order => order.Day13).Sum();
				var day14 = orders.Select(order => order.Day14).Sum();
				var day15 = orders.Select(order => order.Day15).Sum();
				var day16 = orders.Select(order => order.Day16).Sum();
				var day17 = orders.Select(order => order.Day17).Sum();
				var day18 = orders.Select(order => order.Day18).Sum();
				var day19 = orders.Select(order => order.Day19).Sum();
				var day20 = orders.Select(order => order.Day20).Sum();
				var day21 = orders.Select(order => order.Day21).Sum();
				var day22 = orders.Select(order => order.Day22).Sum();
				var day23 = orders.Select(order => order.Day23).Sum();
				var day24 = orders.Select(order => order.Day24).Sum();
				var day25 = orders.Select(order => order.Day25).Sum();
				var day26 = orders.Select(order => order.Day26).Sum();
				var day27 = orders.Select(order => order.Day27).Sum();
				var day28 = orders.Select(order => order.Day28).Sum();
				var day29 = orders.Select(order => order.Day29).Sum();
				var day30 = orders.Select(order => order.Day30).Sum();
				var day31 = orders.Select(order => order.Day31).Sum();
				decimal total = 0;
				foreach (var ftotal in orders)
				{
					total += ftotal.Total;
				}
				
				iText.Layout.Element.Table t = new iText.Layout.Element.Table(ColumnWidth);
				AddCell(t, "");
				AddCell(t, "");
				AddCell(t, "");
				AddCell(t, "");
				AddCell(t, "Grand Total");

				AddCell(t, day1.ToString());
				AddCell(t, day2.ToString());
				AddCell(t, day3.ToString());
				AddCell(t, day4.ToString());
				AddCell(t, day5.ToString());

				AddCell(t, day6.ToString());
				AddCell(t, day7.ToString());
				AddCell(t, day8.ToString());
				AddCell(t, day9.ToString());
				AddCell(t, day10.ToString());

				AddCell(t, day11.ToString());
				AddCell(t, day12.ToString());
				AddCell(t, day13.ToString());
				AddCell(t, day14.ToString());
				AddCell(t, day15.ToString());

				AddCell(t, day16.ToString());
				AddCell(t, day17.ToString());
				AddCell(t, day18.ToString());
				AddCell(t, day19.ToString());
				AddCell(t, day20.ToString());

				AddCell(t, day21.ToString());
				AddCell(t, day22.ToString());
				AddCell(t, day23.ToString());
				AddCell(t, day24.ToString());
				AddCell(t, day25.ToString());

				AddCell(t, day26.ToString());
				AddCell(t, day27.ToString());
				AddCell(t, day28.ToString());
				AddCell(t, day29.ToString());
				AddCell(t, day30.ToString());

				AddCell(t, day31.ToString());
				#endregion
				AddCell(t,total.ToString());
				/*
				//new page
				document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
				document.Add(new Paragraph("MASTER DELIVERY SCHEDULE").SetTextAlignment(TextAlignment.CENTER));
				document.Add(p);
				document.Add(table);
				*/
				document.Add(t);
				var col = new float[] {500f,100f,100f,100f };
				iText.Layout.Element.Table sign_header = new iText.Layout.Element.Table(col);
				AddCellNoBorder(sign_header, "");
				AddCell(sign_header, "Issue By");
				AddCell(sign_header, "Checked By");
				AddCell(sign_header, "Approve By");
				document.Add(sign_header);
				//------------------licen-----------------
				iText.Layout.Element.Table sign = new iText.Layout.Element.Table(col);
				sign.AddCell(new Cell().Add(new Paragraph("   ").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5).SetBorder(Border.NO_BORDER)).SetHeight(25);
				sign.AddCell(new Cell().Add(new Paragraph("   ").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5)).SetHeight(25);
				sign.AddCell(new Cell().Add(new Paragraph("   ").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5)).SetHeight(25);
				sign.AddCell(new Cell().Add(new Paragraph("   ").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5));
				document.Add(sign);
				//----------------------------------------
				//------------------licen-----------------
				iText.Layout.Element.Table sign_date = new iText.Layout.Element.Table(col);
				AddCellNoBorder(sign_date, "");
				sign_date.AddCell(new Cell().Add(new Paragraph("Date :").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5));
				sign_date.AddCell(new Cell().Add(new Paragraph("Date :").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5));
				sign_date.AddCell(new Cell().Add(new Paragraph("Date :").SetTextAlignment(TextAlignment.LEFT)).SetFontSize(5));
				document.Add(sign_date);
				//----------------------------------------
				document.Close();

				return File(memoryStream.ToArray(), "application/pdf", "CustId: " + input.CustId + " DataType:" + input.DataType + ".pdf");
			}
			else //csv
			{

				StringBuilder file = new StringBuilder();
				var listOrder = orders.ToList();
				//header
				//var header = $"MOD,KBNo,CustPartNo2,TKCPartNo,PartName,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,8,19,20,21,22,23,24,25,26,27,28,29,30,31,Total\r\n";
				//file.Append(header);
				var header = $"MOD,KBNo,CustPartNo2,TKCPartNo,PartName,PartNo,Line,CustPartNo2,Expr1,FacNo,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,8,19,20,21,22,23,24,25,26,27,28,29,30,31,Total\r\n";
				file.Append(header);
				listOrder.ForEach(x =>
				{
					//var line = $"{x.MODEL},{x.KBCd},{x.CustPartNo2},{x.TKCPartNo},{x.PartName},{x.Day1},{x.Day2},{x.Day3},{x.Day4},{x.Day5},{x.Day6},{x.Day7},{x.Day8},{x.Day9},{x.Day10},{x.Day11},{x.Day12},{x.Day13},{x.Day14},{x.Day15},{x.Day16},{x.Day17},{x.Day18},{x.Day19},{x.Day20},{x.Day21},{x.Day22},{x.Day23},{x.Day24},{x.Day25},{x.Day26},{x.Day27},{x.Day28},{x.Day29},{x.Day30},{x.Day31},{x.Total}\r\n";
					var line = $"{x.MODEL},{x.KBCd},{x.CustPartNo2},{x.TKCPartNo},{x.PartName},{x.PartNo},{x.Line},{x.CustPartNo2},{x.Expr1},{x.FacNo},{x.Day1},{x.Day2},{x.Day3},{x.Day4},{x.Day5},{x.Day6},{x.Day7},{x.Day8},{x.Day9},{x.Day10},{x.Day11},{x.Day12},{x.Day13},{x.Day14},{x.Day15},{x.Day16},{x.Day17},{x.Day18},{x.Day19},{x.Day20},{x.Day21},{x.Day22},{x.Day23},{x.Day24},{x.Day25},{x.Day26},{x.Day27},{x.Day28},{x.Day29},{x.Day30},{x.Day31},{x.Total}\r\n";
					file.Append(line);
				});
				return File(Encoding.UTF8.GetBytes(file.ToString()), "text/csv", "CustId: "+input.CustId +" DataType: "+input.DataType+".csv");
			}
		} 
		public IActionResult PrintReportPDF(Report? input)
		{
			try
			{
				if (input == null) return NoContent();

				//var NameFile = "Recruitment_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".pdf";
				var show_path = System.IO.Path.Combine("Pdf", "test.pdf");
				var pathfile = System.IO.Path.Combine(_env.WebRootPath, show_path);

				var memoryStream = new MemoryStream();
				PdfWriter writer = new PdfWriter(memoryStream);
				PdfDocument pdfDocument = new PdfDocument(writer);
				Document document = new Document(pdfDocument, PageSize.A4.Rotate());

				document.Add(new Paragraph("MASTER DELIVERY SCHEDULE").SetTextAlignment(TextAlignment.CENTER));

				Paragraph p = new Paragraph("Text to the left");
				p.Add(new Tab());
				p.AddTabStops(new TabStop(400, TabAlignment.CENTER));
				p.Add("Text to the center");
				p.Add(new Tab());
				p.AddTabStops(new TabStop(1000, TabAlignment.RIGHT));
				p.Add("Text to the right");
				document.Add(p);

				//header
				float[] ColumnWidth = { 50f, 50f, 50f, 50f, 150f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f };
				iText.Layout.Element.Table table = new iText.Layout.Element.Table(ColumnWidth);

				table.AddCell(new Cell().Add(new Paragraph("MOD").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				table.AddCell(new Cell().Add(new Paragraph("KBNo").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				table.AddCell(new Cell().Add(new Paragraph("CUST PART").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				table.AddCell(new Cell().Add(new Paragraph("TKC PART").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				table.AddCell(new Cell().Add(new Paragraph("PART NAME").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				for (var i = 1; i <= 31; i++)
				{
					table.AddCell(new Cell().Add(new Paragraph(i + "").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
				}
				table.AddCell(new Cell().Add(new Paragraph("TOTAL").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));

				document.Add(table);


				//data
				var factoryPlant = new Paragraph("factory: 2 Plant: SPIMIT").SetTextAlignment(TextAlignment.LEFT).SetPadding(3).SetFontSize(7);
				document.Add(factoryPlant);
				for (var row = 0; row < 50; row++)
				{
					iText.Layout.Element.Table tabledata = new iText.Layout.Element.Table(ColumnWidth);

					tabledata.AddCell(new Cell().Add(new Paragraph("MOD" + row).SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					tabledata.AddCell(new Cell().Add(new Paragraph("KBNo").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					tabledata.AddCell(new Cell().Add(new Paragraph("CUST PART").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					tabledata.AddCell(new Cell().Add(new Paragraph("TKC PART").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					tabledata.AddCell(new Cell().Add(new Paragraph("PART NAME").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					for (var i = 1; i <= 31; i++)
					{
						tabledata.AddCell(new Cell().Add(new Paragraph(i + "").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					}
					tabledata.AddCell(new Cell().Add(new Paragraph("TOTAL").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
					document.Add(tabledata);
				}

				//new page
				document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
				document.Add(new Paragraph("MASTER DELIVERY SCHEDULE").SetTextAlignment(TextAlignment.CENTER));
				document.Add(p);
				document.Add(table);

				document.Close();

				return File(memoryStream.ToArray(), "application/pdf", "CustId: " + input.CustId + " DataType:" + input.DataType + ".pdf");
			}
			catch (Exception ex)
			{
				return Json(new { error = ex.Message });
			}
		}
		#region same out put
		private string ConvertDate_MMDDYYYY_swap_DDMMYYYY(string date)
		{
			var dueDate = date.Split(" ");
			var onlyDate = dueDate[0].Split("/");
			var newDateFormatt = onlyDate[1] + "/" + onlyDate[0] + "/" + onlyDate[2];
			return newDateFormatt;
		}
		//private string ConvertDate_DDMMYYYY_to_MMDDYYYY(string date)
		//{
		//	var dueDate = date.Split(" ");
		//	var onlyDate = dueDate[0].Split("/");
		//	var newDateFormatt = onlyDate[1] + "/" + onlyDate[0] + "/" + onlyDate[2];
		//	return newDateFormatt;
		//}
		#endregion
	}
}
