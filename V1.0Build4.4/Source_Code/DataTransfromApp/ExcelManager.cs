using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using System.Data;

namespace eCommerceInterfaceApp
{
	class ExcelManager
	{

		// This is the Second Release of the Article:
		// http://www.codeproject.com/Articles/680421/Create-Read-Edit-Advance-Excel-2007-2010-Report-in
		// Sample 1 shows you the following:
		/*
		 * 1. Creating a New Workbook
		 * 2. Creating a New Worksheet
		 * 3. Accessing Cells by Row Index and Column Index
		 * 4. Accessing Cells by its Address
		 * 5. Inserting Values in Cells
		 * 6. Setting Relative Formula Reference
		 * 7. Adding Excel Function SUBTOTAL()
		 * 8. Formatting the Style of a Range of Cells
		 * 9. Setting Number Format for a Range of Cells
		 * 10. Enabling Filter Feature of MS Excel
		 * 11. Enabling 'AutoFit' of Cells
		 * 12. Setting Header and Footer of the Worksheet
		 * 13. Setting Printer Properties
		 * 14. Setting Page Layout
		 * 15. Setting Custom Property
		 */
		// You will find the published article about above topics here:
		// http://www.codeproject.com/Tips/681412/Insert-Access-Format-Filter-Setting-Formula-Header
		public static string RunSample1(DirectoryInfo outputDir)
		{
			FileInfo newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
			// If any file exists in this directory having name 'Sample1.xlsx', then delete it
			if (newFile.Exists)
			{
				newFile.Delete(); // ensures we create a new workbook
				newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
			}
			using (ExcelPackage package = new ExcelPackage(newFile))
			{
				// Add a worksheet to the empty workbook
				ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Inventry");

				// Add the headers
				// Note: Accessing cells by row index and column index
				worksheet.Cells[1, 1].Value = "ID";
				worksheet.Cells[1, 2].Value = "Product";
				worksheet.Cells[1, 3].Value = "Quantity";
				worksheet.Cells[1, 4].Value = "Price";
				worksheet.Cells[1, 5].Value = "Value";

				// Add some items...
				// Inserting values in the first row for: ID, Product, Quantity & Price respectively
				// Note: Accessing cells by its address
				worksheet.Cells["A2"].Value = 12001;
				worksheet.Cells["B2"].Value = "Nails";
				worksheet.Cells["C2"].Value = 37;
				worksheet.Cells["D2"].Value = 3.99;

				// Inserting values in the second row for the same...
				worksheet.Cells["A3"].Value = 12002;
				worksheet.Cells["B3"].Value = "Hammer";
				worksheet.Cells["C3"].Value = 5;
				worksheet.Cells["D3"].Value = 12.10;

				// Inserting values in the third row for the same...
				worksheet.Cells["A4"].Value = 12003;
				worksheet.Cells["B4"].Value = "Saw";
				worksheet.Cells["C4"].Value = 12;
				worksheet.Cells["D4"].Value = 15.37;

				// Note: we didn't do anything with the column 'Value'
				// Actually, the value of the column 'Value' will be the product of 'Qauntity' and 'Price'
				// So, we need to add a formula in the cells under column 'Value'
				// Adding formula to the column 'Value'
				worksheet.Cells["E2:E4"].Formula = "C2*D2";
				// Note: We take the advantage of the one feature of MS Excel i.e. Relative Formula Reference
				// For further reading about RELATIVE REFERENCE, click the link below:
				// http://office.microsoft.com/en-in/excel-help/switch-between-relative-absolute-and-mixed-references-HP010342940.aspx

				// Formatting style of the header
				using (var range = worksheet.Cells[1, 1, 1, 5])
				{
					// Setting bold font
					range.Style.Font.Bold = true;
					// Setting fill type solid
					range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
					// Setting background color dark blue
					range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					// Setting font color
					range.Style.Font.Color.SetColor(Color.White);
				}

				// Formatting the footer row
				// Setting top border of the footer row
				worksheet.Cells["A5:E5"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
				// Setting font bold of the footer row
				worksheet.Cells["A5:E5"].Style.Font.Bold = true;

				// Now, we want to show the Sub total in the footer row for the 'Quantity', 'Price' and 'Value' column
				// Seeting formula for the footer row...
				worksheet.Cells[5, 3, 5, 5].Formula = string.Format("SUBTOTAL(9, {0})", new ExcelAddress(2, 3, 4, 3).Address);
				// Note: SUBTOTAL() is a Excel Function. If you don't know about this function, read this:
				// http://office.microsoft.com/en-in/excel-help/subtotal-function-HP010062463.aspx

				//Now we need to format the values, as the values here, some are string, some are double, some are int
				//Setting Number Format...
				//Setting integer format for the column 'Quantity' and Setting decimal format for the column 'Price' and 'Value'
				worksheet.Cells["C2:C5"].Style.Numberformat.Format = "#,##0";   // Setting integer format
				worksheet.Cells["D2:E5"].Style.Numberformat.Format = "#,##0.00";    // Setting decimal format
																					// Here number format is the excel number format, if you don't know, please click and read:
																					// http://office.microsoft.com/en-in/excel-help/create-a-custom-number-format-HP010342372.aspx

				// Now we enabling filter features of Excel in the cells
				// If you don't know Excel Filtering, please click and read:
				// http://office.microsoft.com/en-001/excel-help/filter-data-in-a-range-or-table-HP010073941.aspx
				// Creating an Auto Filter for the range
				worksheet.Cells["A1:E4"].AutoFilter = true;
				// Setting text format for the column 'Product', as it will helps you during filtering
				worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";

				// Setting AutoFit for all cells
				worksheet.Cells.AutoFitColumns(0);

				// Lets set the header text
				worksheet.HeaderFooter.OddHeader.CenteredText = "&24&U&\"Arial,Regular Bold\" Inventry";

				// Add the page number to the right of the footer + total number of pages
				worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);

				// Add the sheet name to center of the footer
				worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

				// Add the filepath to the left of the footer
				worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;

				// At the time of printing, when page page breaks, then the header will come in the next page by enabling this settings...
				worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:1"];
				worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:E"];

				// Change the sheet view to show it in page layout mode
				worksheet.View.PageLayoutView = true;

				// Setting some document properties
				package.Workbook.Properties.Title = "Invertory";
				package.Workbook.Properties.Author = "Debopam Pal";
				package.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 workbook using EPPlus";

				// set some extended property values
				package.Workbook.Properties.Company = "AdventureWorks Inc.";

				// set some custom property values
				package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Jan Källman");
				package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");
				// save our new workbook and we are done!
				package.Save();
			}

			return newFile.FullName;
		}
		public static string RunSample2(DirectoryInfo outputDir)
		{
			// Taking the file produced by the Sample 1 i.e. 'Sample1.xlsx'. Here 'Sample1.xlsx' is treated as template file
			FileInfo templateFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
			// Making a new file 'Sample2.xlsx'
			FileInfo newFile = new FileInfo(outputDir.FullName + @"\Sample2.xlsx");

			// If there is any file having same name as 'Sample2.xlsx', then delete it first
			if (newFile.Exists)
			{
				newFile.Delete();
				newFile = new FileInfo(outputDir.FullName + @"\Sample2.xlsx");
			}

			using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
			{
				// Openning first Worksheet of the template file i.e. 'Sample1.xlsx'
				ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
				// I'm adding 5th & 6th rows as 1st to 4th rows are filled up with values in 'Sample1.xlsx'
				worksheet.InsertRow(5, 2);

				// Inserting values in the 5th row
				worksheet.Cells["A5"].Value = "12010";
				worksheet.Cells["B5"].Value = "Drill";
				worksheet.Cells["C5"].Value = 20;
				worksheet.Cells["D5"].Value = 8;

				// Inserting values in the 6th row
				worksheet.Cells["A6"].Value = "12011";
				worksheet.Cells["B6"].Value = "Crowbar";
				worksheet.Cells["C6"].Value = 7;
				worksheet.Cells["D6"].Value = 23.48;

				// Adding formula for the 'E' column i.e. 'Value' column
				// Now see how you write R1C1 formula
				// About FORMULA R1C1: http://msdn.microsoft.com/en-us/library/office/bb213527%28v=office.12%29.aspx
				worksheet.Cells["E2:E6"].FormulaR1C1 = "RC[-2]*RC[-1]";

				// Now adding SUBTOTAL() function as was in Sample 1
				// But here you'll see how to add 'Named Range'
				var name = worksheet.Names.Add("SubTotalName", worksheet.Cells["C7:E7"]);
				name.Formula = "SUBTOTAL(9, C2:C6)";

				// Formatting newly added rows i.e. Row 5th and 6th
				worksheet.Cells["C5:C6"].Style.Numberformat.Format = "#,##0";
				worksheet.Cells["D5:E6"].Style.Numberformat.Format = "#,##0.00";

				// Now we are going to create the Pie Chart
				// Read about Pie Chart: http://office.microsoft.com/en-in/excel-help/present-your-data-in-a-pie-chart-HA010211848.aspx
				var chart = (worksheet.Drawings.AddChart("PieChart", OfficeOpenXml.Drawing.Chart.eChartType.Pie3D) as ExcelPieChart);

				// Setting title text of the Chart
				chart.Title.Text = "Total";

				// Setting 5 pixel offset from 5th column of the first row
				chart.SetPosition(0, 0, 5, 5);

				// Setting width & height of the chart area
				chart.SetSize(600, 300);

				//In the Pie Chart value will come from 'Value' column
				//and show in the form of percentage
				//Now I'll show you how to take values from the 'Value' column
				ExcelAddress valueAddress = new ExcelAddress(2, 5, 6, 5);
				// Setting Series and XSeries of the chart
				// Product name will be the item of the Chart
				var ser = (chart.Series.Add(valueAddress.Address, "B2:B6") as ExcelPieChartSerie);

				// Setting chart properties
				chart.DataLabel.ShowCategory = true;
				chart.DataLabel.ShowPercent = true;
				// Formatting Looks of the Chart
				chart.Legend.Border.LineStyle = eLineStyle.Solid;
				chart.Legend.Border.Fill.Style = eFillStyle.SolidFill;
				chart.Legend.Border.Fill.Color = Color.DarkBlue;

				// Switch the page layout view back to the normal
				worksheet.View.PageLayoutView = false;

				// Save our new workbook, we are done
				package.Save();
			}

			return newFile.FullName;
		}
		public DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
		{
			int totalRows = oSheet.Dimension.End.Row;
			int totalCols = oSheet.Dimension.End.Column;
			DataTable dt = new DataTable(oSheet.Name);
			DataRow dr = null;
			Boolean IsRowNotnull = false;
			for (int i = 1; i <= totalRows; i++)
			{
				if (i > 1) dr = dt.Rows.Add();

				for (int j = 1; j <= totalCols; j++)
				{
					IsRowNotnull = false;
					if (oSheet.Cells[i, j].Value != null)
					{
						IsRowNotnull = true;
					};

					if (i == 1)
					{
						// dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());

						if (IsRowNotnull) //Check header Fist ROW
						{
							dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
						};

					}
					else
					{
						//  dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
						if (i > 1)
						{

							if (null == oSheet.Cells[i, j].Value)
							{
								dr[j - 1] = "";
							}
							else
							{
								dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
							};
						}
					}
					// dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
				}
			}
			return dt;
		}

		public DataTable WorksheetToDataTable(ExcelWorksheet oSheet,int iFirstRow)
		{
			int totalRows = oSheet.Dimension.End.Row;
			int totalCols = oSheet.Dimension.End.Column;
			DataTable dt = new DataTable(oSheet.Name);
			DataRow dr = null;
			Boolean IsRowNotnull = false;
			for (int i = 1; i <= totalRows; i++)
			{
				if (i > 1) dr = dt.Rows.Add();

				for (int j = 1; j <= totalCols; j++)
				{
					IsRowNotnull = false;
					if (oSheet.Cells[i, j].Value != null)
					{
						IsRowNotnull = true;
					};

					if (i == iFirstRow)
					{
						// dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());

						if (IsRowNotnull) //Check header Fist ROW
						{
							dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
						};

					}
					else
					{
						//  dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
						if (i > iFirstRow)
						{

							if (null == oSheet.Cells[i, j].Value)
							{
								dr[j - 1] = "";
							}
							else
							{
								dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
							};
						}
					}
					// dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
				}
			}
			return dt;
		}

		public DataTable WorksheetToDataTableNoHeader(ExcelWorksheet oSheet, int iFirstRow)
		{
			try { 
			int totalRows = oSheet.Dimension.End.Row;
			int totalCols = oSheet.Dimension.End.Column;
			DataTable dt = new DataTable(oSheet.Name);
			DataRow dr = null;
			Boolean IsRowNotnull = false;
			for (int i = 1; i <= totalRows; i++)
			{
				 dr = dt.Rows.Add();

				for (int j = 1; j <= totalCols; j++)
				{
					IsRowNotnull = false;
					if (oSheet.Cells[i, j].Value != null)
					{
						IsRowNotnull = true;
					};

					if ( iFirstRow == i)
					{
						// dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());

						//if (IsRowNotnull) //Check header Fist ROW
						//{						

							if (null == oSheet.Cells[i, j].Value)
							{
									dt.Columns.Add(j.ToString());
									dr[j - 1] = "";
							}
							else
							{
									dt.Columns.Add(j.ToString());
									dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
								   // dr[j - 1] = oSheet.Cells[i, j].Value;
							};
						//};

					}
                    else
                    {
                      
                        //if (i > iFirstRow)
                        //{

                            if (null == oSheet.Cells[i, j].Value)
                            {
                                dr[j - 1] = "";
                            }
                            else
                            {
                                dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
                            };
                        //}
                    }
                    // dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
                }
			}
			return dt;
		   }
            catch (Exception ex)
            {
                  LogTextManager sobjlog = new LogTextManager();// WriteTexttLog();                 
		         sobjlog.SystemLog("System Error: StorXcelinDatatale:" + ex.Message);
                return new DataTable();

	        }
}

		public void GenExcelfromdatatable(DataTable iDataTable, string istrNewfile)
		{
			ConfigManager objCong = new ConfigManager();
			DirectoryInfo ioutputDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + objCong.OutputFolder);
			//FileInfo newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
			FileInfo newFile = new FileInfo(ioutputDir.FullName + @"\" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + istrNewfile);
			// If any file exists in this directory having name 'Sample1.xlsx', then delete it
			if (newFile.Exists)
			{
				newFile.Delete(); // ensures we create a new workbook
				newFile = new FileInfo(ioutputDir.FullName + @"\" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + istrNewfile);
			}
			//Select Order
			using (ExcelPackage pck = new ExcelPackage(newFile))
			{
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
				ws.Cells["A1"].LoadFromDataTable(iDataTable, true);
				pck.Save();
			}
		}

		public void GenExcelfromdatatable(DataTable iDataTable, string istrNewfile,bool IncloudHD)
		{
			string FIleTail = DateTime.Now.ToString("yyyy-MM-dd");
			ConfigManager objCong = new ConfigManager();
			DirectoryInfo ioutputDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + objCong.OutputFolder);
			//FileInfo newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
			FileInfo newFile = new FileInfo(ioutputDir.FullName + @"\" + FIleTail + istrNewfile);
			// If any file exists in this directory having name 'Sample1.xlsx', then delete it
			if (newFile.Exists)
			{
				newFile.Delete(); // ensures we create a new workbook
				newFile = new FileInfo(ioutputDir.FullName + @"\" + FIleTail + istrNewfile);
			}
			//Select Order
			using (ExcelPackage pck = new ExcelPackage(newFile))
			{
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
				ws.Cells["A1"].LoadFromDataTable(iDataTable, IncloudHD);
				pck.Save();
			}
		}
		private static void DataSetToExcel(DataSet dataSet, string filePath)
		{
			using (ExcelPackage pck = new ExcelPackage())
			{
				foreach (DataTable dataTable in dataSet.Tables)
				{
					ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add(dataTable.TableName);
					workSheet.Cells["A1"].LoadFromDataTable(dataTable, true);
				}

				pck.SaveAs(new FileInfo(filePath));
			}
		}
	}

}