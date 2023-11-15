
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
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
		private readonly IWebHostEnvironment _env;
		public OrderController(ILogger<OrderController> logger, Dapper_Context dapper_Context, IWebHostEnvironment env)
		{
			_logger = logger;
			_dapperContext = dapper_Context;
			_env = env;
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
					var resDate = $"{added.Month}/{added.Day}/{added.Year} {added.Hour}:{added.Minute}:{added.Second}";
					return Json(new { date = resDate });
				}
				if (todo == "in")
				{
					var added = dateTime.AddDays(-1);
					var resDate = $"{added.Month}/{added.Day}/{added.Year} {added.Hour}:{added.Minute}:{added.Second}";
					return Json(new { date = resDate });
				}

			}
			catch(Exception ex) {
				return Ok(new { error = "เกิดข้อผิดพลาด "+ex.Message });
			}
			return Ok(new { error = "ป้อนข้อมูลไม่ถูกต้อง" });

		}
		[HttpPost]
		public async Task<IActionResult> SlideIn([FromForm] SlideDueDate input)
		{
			try
			{
				foreach(var shiftDate in input.ShiftDate)
				{
					var culture = new CultureInfo("en-US");
					var toDate = DateTime.Parse(shiftDate.ToDate,culture);
					var fromDate = DateTime.Parse(shiftDate.FromDate, culture);
					var date = DateTime.Now;
					string cmd = $"UPDATE T_SchOrdersPart SET DueDate = '{toDate.Year}-{toDate.Month}-{date.Day} {toDate.Hour}:{toDate.Minute}:{toDate.Second}',Period='{shiftDate.ToPeriod}',DueTime='{shiftDate.ToTime}' WHERE CustID='{input.CustID}' AND DataType ='{input.DataType}' AND DueDate='{fromDate.Year}-{fromDate.Month}-{fromDate.Day} {fromDate.Hour}:{fromDate.Minute}:{fromDate.Second}' {((!string.IsNullOrEmpty(input.PlantCode)) ? $"AND PlantCode='{input.PlantCode}'" : "")} {((!string.IsNullOrEmpty(input.OrdersNo)) ? $"AND OrdersNo='{input.OrdersNo}'" : "")} {((!string.IsNullOrEmpty(input.PONo)) ? $"AND PONo='{input.PONo}'" : "")} AND DATEDIFF(day, T_SchOrdersPart.DueDate,'{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}') <= 40";
					var update = await _dapperContext.Update(cmd, new { });
				}
				return Json(new { msg = "บันทึกข้อมูลเรียบร้อย" });

			}
			catch(Exception ex)
			{
				return Json(new { error = "เกิดข้อผิดพลาด > "+ex.Message });
			}

			
		}
		[HttpPost]
		public async Task<IActionResult> SlideOut([FromForm] SlideDueDate input)
		{
			try
			{

			}
			catch (Exception ex)
			{

			}

			return Ok();
		}

		/*
		public IActionResult CreatePdf(string html)
		{
			var show_path = System.IO.Path.Combine("Pdf", "test.pdf");
			var path = System.IO.Path.Combine(_env.WebRootPath, show_path);

			SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
			converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
			converter.Options.PdfPageOrientation = SelectPdf.PdfPageOrientation.Landscape;
			converter.Options.MarginLeft = 10;
			converter.Options.MarginRight = 10;
			converter.Options.MarginTop = 10;
			converter.Options.MarginBottom = 10;
			//SelectPdf.PdfDocument doc = converter.ConvertUrl("https://www.w3schools.com/");
			var doc = converter.ConvertHtmlString(@"<style>h1{color:red;}</style><h1>fsdf<1h>");
			doc.Save(path);
			
			doc.Close();
			return RedirectToAction(show_path);
		}*/
		public async Task<ActionResult> Recruitment_Print_PDF()
		{
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
			float[] ColumnWidth = { 50f, 50f,50f,50f,150f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f };
			iText.Layout.Element.Table table = new iText.Layout.Element.Table(ColumnWidth);

			table.AddCell(new Cell().Add(new Paragraph("MOD").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
			table.AddCell(new Cell().Add(new Paragraph("KBNo").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
			table.AddCell(new Cell().Add(new Paragraph("CUST PART").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
			table.AddCell(new Cell().Add(new Paragraph("TKC PART").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
			table.AddCell(new Cell().Add(new Paragraph("PART NAME").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
			for (var i=1;i<=31;i++)
			{
				table.AddCell(new Cell().Add(new Paragraph(i+"").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
			}
			table.AddCell(new Cell().Add(new Paragraph("TOTAL").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));

			document.Add(table);


			//data
			var factoryPlant = new Paragraph("factory: 2 Plant: SPIMIT").SetTextAlignment(TextAlignment.LEFT).SetPadding(3).SetFontSize(7);
			document.Add(factoryPlant);
			for(var row=0;row < 50; row++)
			{
				iText.Layout.Element.Table tabledata = new iText.Layout.Element.Table(ColumnWidth);

				tabledata.AddCell(new Cell().Add(new Paragraph("MOD").SetTextAlignment(TextAlignment.CENTER)).SetFontSize(5));
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


			document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

			document.Close();
			return File(memoryStream.ToArray(), "application/pdf", "test.pdf");
		}
	}
}
