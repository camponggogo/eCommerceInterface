using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data;
using OfficeOpenXml;
using System.Drawing.Imaging;

namespace eCommerceInterfaceApp
{
    class DataTransfrom
    {
        public string LoadAllOrdersfile()
        {

            try
            {

                // Check Files
                string stasus = "";
                ConfigManager objCof = new ConfigManager();
                string Datafile = ""; // iChkConfFilesname.Split('|')[1].ToString();
                List<string> LisFiles = objCof.GetOderFilesNames();
                string strFullfile = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder;
                string[] filePaths = Directory.GetFiles(strFullfile, "*.xlsx");
                Boolean OKGO = false;
                List<string> DatafileList = new List<string>();
                foreach (string istrfname in LisFiles)  // Loop  all Order file in Config File
                {
                    //MessageBox.Show(istrfname);    
                    string[] Xfile = istrfname.Split('|');
                    string iFilesname = Xfile[1];
                    // Look at file
                    //iFilesname = "Lazada_Orders.xlsx";
                    string CongFilesname = iFilesname.Substring(0, iFilesname.IndexOf("_"));
                    //***** Log up FOlder to Get List File .xlsx *****  
                    foreach (string iflist in filePaths)
                    {
                        string[] strArr = iflist.Split('\\');
                        string Findir = strArr[strArr.Length - 1].ToString();

                        // if (iflist.Split('\\')[1].Substring(0, iflist.Split('\\')[1].IndexOf("_")).Contains(iFilesname))
                        if (Findir.Contains(CongFilesname))
                        {
                            Datafile = Findir; //iflist.Split('\\')[1];

                            string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder + "\\" + Datafile;
                            if (File.Exists(filepath))
                            {
                                OKGO = true;
                                DatafileList.Add(Datafile);
                                break;
                            }
                        };

                    };

                    //}// End Lopp
                };


                //***** List For each file to Lopp Loading*******

                // Begin Loop file in Folder
                // in Main Lopp {
                if (OKGO && DatafileList.Count > 0)
                {

                    OKGO = false;
                    //**********PROCESS************
                    foreach (string FileNames in DatafileList)
                    {

                        string iFilesname = FileNames.Substring(0, FileNames.IndexOf('_'));
                        string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder + "\\" + FileNames;
                        //if (!File.Exists(filepath))
                        //{
                        //    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                        //    objlog.DataLog("Error fil in Config as FileName:" + iFilesname + "  Not found", "I", "F", "O");
                        //    stasus = "Failed File  Not found";

                        //};
                        if (File.Exists(filepath))
                        {
                            // do load lazada Orders
                            // Get td of the file
                            // Get Mapping
                            // MappingShoppeOrders(StorFileOrdersDT(filepath));

                            TempOrders objtOder = new TempOrders();
                            Orders objOder = new Orders();
                            stasus = objtOder.LoadTempOrders(iFilesname, this.StorFileOrdersDT(FileNames), filepath);

                            //Orders objOrders = new Orders();
                            // stasus = objOrders.LoadOrders(iFilesname, this.StorFileOrdersDT(FileNames), filepath);


                            //   stasus = objOrders.MappingOrdersDynamic(iFilesname, this.StorFileOrdersDT(iFilesname), filepath); 

                            // mapping to Table Orders
                            // Load to orders Save Done
                            //}

                            if (stasus.Contains("Success"))
                            {
                                LogTextManager objlog = new LogTextManager(); // WriteTexttLog(); 

                                stasus = stasus + ", File From:" + iFilesname;
                               // objlog.DataLog(stasus, "I", "S", "O");
                                DataTransfrom objtrans = new DataTransfrom();
                                objtrans.MoveFileInOrderToBakup(filepath);
                            }
                            else
                            {
                                // Rollabck
                                objOder.RollbacktableOrder(iFilesname.ToUpper());
                                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                                objlog.DataLog("RollbacktableOrder" + stasus, "I", "F", "O");
                                return "";
                            };
                        };
                        //**********PROCESS************
                    };
                };
                // End Loop file in  Folder
                 return stasus;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("ERROR: LoadAllOrdersfile() :" + ex.Message, "I", "F", "O");
                return "Failed";
            }

        }
        private DataTable StorFileOrdersDT(string istrfname)
        {   // StorFileOrdersDT by File name
            try
            {
                DataTable iDXt = new DataTable();  //Output DT

                //MessageBox.Show(istrfname);                  
                ConfigManager objCof = new ConfigManager();
                string iFilesname = istrfname;
                // Check input file is existing
                string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder + "\\" + iFilesname;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.DataLog("Error File Not found", "I", "F", "O");
                }
                else
                {
                    // Store Excel in to Datatable
                    // DataTable dtTable = new DataTable();  //input DT
                    if (iFilesname.Contains("ECOMM"))
                    {
                        iDXt = StorXlsinDatabaleNN(filepath, 1);
                    }
                    else
                    {
                        iDXt = StorXlsinDatabale(filepath);
                    }
                    

                }


                return iDXt;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error StorFileOrdersDT:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        private DataTable StorFiletoDT(string istrfname)
        {   // StorFileOrdersDT by File name
            try
            {
                DataTable iDXt = new DataTable();  //Output DT

                //MessageBox.Show(istrfname);                  
                ConfigManager objCof = new ConfigManager();
                string iFilesname = istrfname;
                // Check input file is existing
                string filepath = istrfname; //AppDomain.CurrentDomain.BaseDirectory + objCof.ProductsFolder + "\\" + iFilesname;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.DataLog("Error File Not found", "I", "F", "O");
                }
                else
                {
                    // Store Excel in to Datatable
                    // DataTable dtTable = new DataTable();  //input DT
                    iDXt = StorXlsinDatabale(filepath);

                }


                return iDXt;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error StorFileOrdersDT:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        private DataTable StorFileProductDT(string istrfname)
        {   // StorFileOrdersDT by File name
            try
            {
                DataTable iDXt = new DataTable();  //Output DT
                
                //MessageBox.Show(istrfname);                  
                ConfigManager objCof = new ConfigManager();
                string iFilesname = istrfname;
                // Check input file is existing
                string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.ProductsFolder + "\\" + iFilesname;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.DataLog("Error File Not found", "I", "F", "O");
                }
                else
                {
                    // Store Excel in to Datatable
                    // DataTable dtTable = new DataTable();  //input DT
                    iDXt = StorXlsinDatabale(filepath);

                }


                return iDXt;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error StorFileOrdersDT:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        private DataTable StorDTCustomeronline()
        {
            try
            {
                DataTable iDXt = new DataTable();  //Output DT
                ConfigManager objCof = new ConfigManager();
                List<string> LisFiles = objCof.GetCustFilesNames();
                foreach (string istrfname in LisFiles)  // Loop  Load File
                {
                    //MessageBox.Show(istrfname);                  
                    string[] Xfile = istrfname.Split('|');
                    string iFilesname = Xfile[1];
                    // Check input file is existing
                    string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.InCustFolder + "\\" + iFilesname;
                    if (!File.Exists(filepath))
                    {
                        LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                        objlog.DataLog("Error File  Not found", "I", "F", "C");
                    }
                    else
                    {
                        // Get Mapping

                        // Store Excel in to Datatable
                        DataTable dtTable = new DataTable();  //input DT

                        dtTable = StorXlsinDatabaleX(filepath);
                        // On all tables' rows
                        Customersonline ObjtdCustOnline = new Customersonline();  //Output DT
                        string KeyCutID = "";                                                       // foreach (DataRow dtRow in dtTable.Rows)
                        int j = 1;
                        for (int i = 0; i < dtTable.Rows.Count; i++)
                        {
                            KeyCutID = dtTable.Rows[i].ItemArray[0].ToString();
                            if (KeyCutID.Trim() == "ประเภทลูกหนี้") ObjtdCustOnline.debtorTyp = dtTable.Rows[i].ItemArray[1].ToString();

                            // if (i > 1)
                            // {


                            if (i == 1 || i == j)
                            {
                                ObjtdCustOnline.custid = dtTable.Rows[i].ItemArray[0].ToString();
                                ObjtdCustOnline.custname = dtTable.Rows[i].ItemArray[1].ToString();

                                j = i + 2;
                            };

                            if (i >= 2 && i == j - 1)
                            {
                                ObjtdCustOnline.orgname = dtTable.Rows[i].ItemArray[2].ToString();
                                ObjtdCustOnline.branchnum = dtTable.Rows[i].ItemArray[3].ToString();
                                ObjtdCustOnline.debtorID = dtTable.Rows[i].ItemArray[4].ToString();
                                ObjtdCustOnline.custaddr1 = dtTable.Rows[i].ItemArray[5].ToString();
                                ObjtdCustOnline.custaddr2 = dtTable.Rows[i].ItemArray[6].ToString();
                                ObjtdCustOnline.custaddr3 = dtTable.Rows[i].ItemArray[7].ToString();
                                ObjtdCustOnline.custzone = dtTable.Rows[i].ItemArray[8].ToString();
                                ObjtdCustOnline.postcode = dtTable.Rows[i].ItemArray[9].ToString();
                                ObjtdCustOnline.phonenum = dtTable.Rows[i].ItemArray[10].ToString();
                                ObjtdCustOnline.faxnum = dtTable.Rows[i].ItemArray[11].ToString();
                                ObjtdCustOnline.business = dtTable.Rows[i].ItemArray[12].ToString();
                                ObjtdCustOnline.Status = dtTable.Rows[i].ItemArray[13].ToString();
                                ObjtdCustOnline.Email = dtTable.Rows[i].ItemArray[14].ToString();
                                ObjtdCustOnline.HomePage = dtTable.Rows[i].ItemArray[15].ToString();

                            };

                            // ObjtdCustOnline.Custonlinetable.Rows.Add(CustOnlinedr);
                            if (i >= 4 && i == j - 1 && ObjtdCustOnline.custid.Length > 0 && ObjtdCustOnline.custid.Trim() != "ประเภทลูกหนี้")
                            {
                                ObjtdCustOnline.Custonlinetable.Rows.Add(
                                 ObjtdCustOnline.custid,
                                 ObjtdCustOnline.custname,
                                 ObjtdCustOnline.orgname,
                                 ObjtdCustOnline.branchnum,
                                 ObjtdCustOnline.debtorID,
                                 ObjtdCustOnline.custaddr1,
                                 ObjtdCustOnline.custaddr2,
                                 ObjtdCustOnline.custaddr3,
                                 ObjtdCustOnline.custzone,
                                 ObjtdCustOnline.postcode,
                                 ObjtdCustOnline.phonenum,
                                 ObjtdCustOnline.faxnum,
                                 ObjtdCustOnline.business,
                                 ObjtdCustOnline.Status,
                                 ObjtdCustOnline.Email,
                                 ObjtdCustOnline.HomePage,
                                 ObjtdCustOnline.debtorTyp
                                 );
                                j = i + 1;
                            };

                            //}

                        }
                        iDXt = ObjtdCustOnline.Custonlinetable;
                        // Log to Done


                    }
                }

                return iDXt;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog(ex.Message, "I", "F", "C");
                return new DataTable();
            }
        }

        public string LoadCustOnlin(DataTable DTCust)
        {
            try
            {
                //***** Laod ?Mast Customer to database*****
                // On all tables' rows
                if (DTCust.Rows.Count > 0)
                {
                    Customersonline objCustOnlin = new Customersonline();
                    objCustOnlin.Custonlinetable = DTCust;
                    Customers objMastCust = new Customers();

                    foreach (DataRow dtRow in objCustOnlin.Custonlinetable.Rows)
                    {
                        // On all tables' columns
                        //foreach (DataColumn dc in objCustOnlin.Custonlinetable.Columns)
                        // {
                        objMastCust.custid = dtRow[0].ToString();


                        //}
                    }
                };


                return "Success";
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog(ex.Message, "I", "F", "C");
                return "Failed";
            }
        }

        public string LoadFirstMastCustomers()
        {
            try
            {
                string stasus = "";
                DataTable dtCutOnlin = StorDTCustomeronline();
                Customers ObjCust = new Customers();
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 

                if (dtCutOnlin.Rows.Count > 0)
                {
                    ObjCust.BackuptableCust();
                    stasus = ObjCust.LoadFirstonlinetomastCustomers(dtCutOnlin);
                    //if completed  // Move Complated Input File  to Backup
                    if (stasus.Contains("Success"))
                    {
                        DataTransfrom objtrans = new DataTransfrom();
                        objtrans.MoveInCustToBakup();
                       // objlog.DataLog("LoadFirstMastCustomers : " + stasus, "I", "S", "C");
                    };
                }
                else
                {
                    stasus = "Failed";
                    ObjCust.RollbacktableCust();
                    //objlog.DataLog("LoadFirstMastCustomers : " + stasus, "I", "f", "C");
                    // return 0;
                }


                return stasus;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("ERROR: LoadFirstMastCustomers() :" + ex.Message, "I", "F", "C");
                //Customers ObjCust = new Customers();
               // ObjCust.RollbacktableCust();
                return "Failed";
            }
        }

        public string LoadFileDisCount(string FullFileName)
        {
            try
            {
                  string stasus = "";
                DataTable dtDiscnt = StorFiletoDT(FullFileName);
                Discounts objDisCnt = new Discounts();

                if (dtDiscnt.Rows.Count > 0)
                {
                    stasus = objDisCnt.LoadDiscount(dtDiscnt);
                    //if completed  // Move Complated Input File  to Backup
                    if (stasus.Contains("Success"))
                    {
                        DataTransfrom objtrans = new DataTransfrom();
                        objtrans.MoveFileDisciuntToBakup(FullFileName);
                        
                        LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                        objlog.DataLog(stasus, "I", "S", "O");
                    };
                }
                else
                {
                    stasus = "Failed";
                    // return 0;
                }


                return stasus;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("ERROR: LoadFileDisCount() : " + ex.Message, "I", "F", "O");
                return "Failed";
            }
        }
        public string LoadFirstProduct()
        {
            try
            {
                string strFile = "";
                ConfigManager objCof = new ConfigManager();
                List<string> LisFiles = objCof.GetProdFilesNames();
               foreach(string strFl in LisFiles)
                {
                    strFile = strFl.Split('|')[1];
                }

                string stasus = "";
                DataTable dtProd = StorFileProductDT(strFile);
                Products objProd = new Products();
                
                if (dtProd.Rows.Count > 0)
                {
                    stasus = objProd.LoadProductsItems(dtProd);
                    //if completed  // Move Complated Input File  to Backup
                    if (stasus.Contains("Success"))
                    {
                        DataTransfrom objtrans = new DataTransfrom();
                        LogTextManager objlog = new LogTextManager();

                        objtrans.MoveInProdToBakup();
                       // objlog.DataLog(stasus, "I", "S", "P");
                    };
                }
                else
                {
                    stasus = "Failed";
                    // return 0;
                }


                return stasus;
            }
            catch (Exception ex)
            {
               LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("ERROR: LoadFirstProduct() :" + ex.Message, "I", "F", "P");
                return "Failed";
            }
        }


        private DataTable StorXlsinDatabale(string XlsFileNames)
        {
            try
            {
                // Found Input to Load process
                //***** Open Excel  stor in Data Table*****
                string sheetName;
                using (ExcelPackage excelPkg = new ExcelPackage())
                using (FileStream stream = new FileStream(XlsFileNames, FileMode.Open))
                {
                    excelPkg.Load(stream);
                    sheetName = excelPkg.Workbook.Worksheets[1].Name;
                    ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
                    ExcelManager objXls = new ExcelManager();
                    DataTable dt = objXls.WorksheetToDataTable(oSheet);
                    excelPkg.Dispose();
                    return dt;
                    //***** Laod to database*****
                    // DataTransfrom objTranfrom = new DataTransfrom();
                    //objTranfrom.LoadCustomer(dt);
                    //MessageBox.Show("Successfully");
                }
            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog();                 
                sobjlog.SystemLog("System Error: StorXcelinDatatale:" + ex.Message);
                return new DataTable();

            }
        }

        private DataTable StorXlsinDatabaleX(string XlsFileNames)
        {
            try
            {
                // Found Input to Load process
                //***** Open Excel  stor in Data Table*****
                string sheetName;
                using (ExcelPackage excelPkg = new ExcelPackage())
                using (FileStream stream = new FileStream(XlsFileNames, FileMode.Open))
                {
                    excelPkg.Load(stream);
                    sheetName = excelPkg.Workbook.Worksheets[1].Name;
                    ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
                    ExcelManager objXls = new ExcelManager();
                    DataTable dt = objXls.WorksheetToDataTable(oSheet,16);
                    excelPkg.Dispose();
                    return dt;
                    //***** Laod to database*****
                    // DataTransfrom objTranfrom = new DataTransfrom();
                    //objTranfrom.LoadCustomer(dt);
                    //MessageBox.Show("Successfully");
                }
            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog();                 
                sobjlog.SystemLog("System Error: StorXcelinDatatale:" + ex.Message);
                return new DataTable();

            }
        }

        private DataTable StorXlsinDatabaleNN(string XlsFileNames,int startDataRow)
        {
            try
            {
                // Found Input to Load process
                //***** Open Excel  stor in Data Table*****
                string sheetName;
                using (ExcelPackage excelPkg = new ExcelPackage())
                using (FileStream stream = new FileStream(XlsFileNames, FileMode.Open))
                {
                    excelPkg.Load(stream);
                    sheetName = excelPkg.Workbook.Worksheets[1].Name;
                    ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
                    ExcelManager objXls = new ExcelManager();
                    DataTable dt = objXls.WorksheetToDataTableNoHeader(oSheet, startDataRow);
                    excelPkg.Dispose();
                    return dt;
                    //***** Laod to database*****
                    // DataTransfrom objTranfrom = new DataTransfrom();
                    //objTranfrom.LoadCustomer(dt);
                    //MessageBox.Show("Successfully");
                }
            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog();                 
                sobjlog.SystemLog("System Error: StorXcelinDatatale:" + ex.Message);
                return new DataTable();

            }
        }

        //public void MoveInputFiletoCompleted(string FolderInOut)
        //{
        //    //ConfigManager objCong = new ConfigManager();
        //    //DirectoryInfo ioutputDir = new DirectoryInfo(FolderInOut);
        //    //FileInfo newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
        //    //FileInfo newFile = new FileInfo(ioutputDir.FullName + @"\" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + istrNewfile);
        //    //// If any file exists in this directory having name 'Sample1.xlsx', then delete it
        //    //if (newFile.Exists)
        //    //{
        //    //    newFile.Delete(); // ensures we create a new workbook
        //    //    newFile = new FileInfo(ioutputDir.FullName + @"\" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + istrNewfile);
        //    //}

        //}
        //public void MoveInputtoBackuptoCompleted()
        //{
        //    //String directoryName = "C:\\Consolidated";
        //    //DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
        //    //if (dirInfo.Exists == false)
        //    //    Directory.CreateDirectory(directoryName);

        //    //List<String> MyMusicFiles = Directory.GetFiles("C:\\Music", "*.*", SearchOption.AllDirectories).ToList();

        //    //foreach (string file in MyMusicFiles)
        //    //{
        //    //    FileInfo mFile = new FileInfo(file);
        //    //    // to remove name collisions
        //    //    if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
        //    //    {
        //    //        mFile.MoveTo(dirInfo + "\\" + mFile.Name);
        //    //    }
        //    //}
        //}
        public void CopyDir(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            };


            // Get Files & Copy
            string[] files = Directory.GetFiles(sourceFolder, "*.xlsx");
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);

                // ADD Unique File Name Check to Below!!!!
                string DesFileNeme = destFolder + @"\" + name;
                if (File.Exists(DesFileNeme))
                {
                    File.Delete(DesFileNeme);
                };

                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
                File.Delete(file);
            }

            //// Get dirs recursively and copy files
            //string[] folders = Directory.GetDirectories(sourceFolder);
            //foreach (string folder in folders)
            //{
            //    string name = Path.GetFileName(folder);
            //    string dest = Path.Combine(destFolder, name);
            //    CopyDir(folder, dest);
            //}
        }
        public void DeleteExcelInDir(string sourceFolder)
        {
           


            // Get Files & Copy
            //string[] files = Directory.GetFiles(sourceFolder, "*.xlsx");
            //foreach (string file in files)
            //{
            //    string name = Path.GetFileName(file);

            //    // ADD Unique File Name Check to Below!!!!
            //    string DesFileNeme = sourceFolder + @"\" + name;
                if (File.Exists(sourceFolder))
                {
                    File.Delete(sourceFolder);
                };

               
            //}

           
        }
        public Boolean CheckProdExsiting()
        {
            try
            {
                Boolean IsExsit = false;
                ConfigManager objCof = new ConfigManager();
                List<string> LisFiles = objCof.GetProdFilesNames();
                foreach (string istrfname in LisFiles)  // Loop  Load File
                {
                    //MessageBox.Show(istrfname);                  
                    string[] Xfile = istrfname.Split('|');
                    string iFilesname = Xfile[1];
                    // Check input file is existing
                    string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.ProductsFolder + "\\" + iFilesname;
                    if (!File.Exists(filepath))
                    {
                        IsExsit = false;
                    }
                    else
                    {
                        IsExsit = true;
                    }
                }
                return IsExsit;
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                return false;

            }
        }

        public Boolean CheckCustExsiting()
        {
            try
            {
                Boolean IsExsit = false;
                ConfigManager objCof = new ConfigManager();
                List<string> LisFiles = objCof.GetCustFilesNames();
                foreach (string istrfname in LisFiles)  // Loop  Load File
                {
                    //MessageBox.Show(istrfname);                  
                    string[] Xfile = istrfname.Split('|');
                    string iFilesname = Xfile[1];
                    // Check input file is existing
                    string filepath = AppDomain.CurrentDomain.BaseDirectory + objCof.InCustFolder + "\\" + iFilesname;
                    if (!File.Exists(filepath))
                    {
                        IsExsit = false;
                    }
                    else
                    {
                        IsExsit = true;
                    }
                }
                return IsExsit;
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                return false;

            }
        }

        public Boolean CheckOrderExsiting()
        {
            try
            {
                Boolean IsExsit = false;
                ConfigManager objCof = new ConfigManager();
               // string iExsitFilesname = "";
                //***** Log up FOlder to Get List File .xlsx *****
                string BackFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder;

                string[] LisFileinOrderDir = Directory.GetFiles(BackFromCompath, "*.xlsx");

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                // objlog.DataLog("Cehck Dir LisFileinOrderDir Length:  " + LisFileinOrderDir.Length.ToString(), "I", "S", "O"); ;

                if (LisFileinOrderDir.Length > 0)
                {
                    List<string> LisFilesinConfig = objCof.GetOderFilesNames();
                    foreach (string iflist in LisFileinOrderDir)
                    {
                        // LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                        //   objlog.DataLog("Cehck Dir 1Exsit" + iflist, "I", "S", "O"); ;
                        if (IsExsit)
                        {
                            //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                          //  objlog.DataLog("Second Loop Stop Check to break", "I", "S", "O");
                            break;
                        };
                        foreach (string iConfFilesname in LisFilesinConfig)
                        {
                            string iChkConfFilesname = iConfFilesname.Substring(0, iConfFilesname.IndexOf("_"));
                            // objlog.DataLog("Cehck in Dir:" + iflist + "  and Conf: " + iConfFilesname, "I", "S", "O");
                            string[] strArr = iflist.Split('\\');
                            //string Findir = iflist.Split('\\')[strArr.Length - 1].Substring(0, iflist.Split('\\')[strArr.Length - 1].IndexOf("_"));
                            string Findir = strArr[strArr.Length - 1].ToString();
                            string FinConf = iChkConfFilesname.Split('|')[1].ToString();

                            //objlog.DataLog("Check Conf Exsit Findir :" + Findir + "  FinConf: " + FinConf, "I", "S", "O");
                            //if (iflist.Split('\\')[1].Substring(0, iflist.Split('\\')[1].IndexOf("_")).Contains(iChkConfFilesname.Split('|')[1].ToString()))
                            if (Findir.Contains(FinConf))
                            {
                                // iExsitFilesname = iflist.Split('\\')[1];
                                if (Findir.Length > 0)
                                {
                                    IsExsit = true;
                                    objlog.DataLog("Check Found" + iflist, "I", "S", "O");
                                    break;
                                };
                            };
                        }
                    }
                }
                else
                {
                    // exit Do nothing bye
                    IsExsit = false;
                    objlog.SystemLog("System Error:CheckOrderExsiting: File Not Found in InputOrderFolder");

                };
                return IsExsit;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.SystemLog("System Error: CheckOrderExsiting:" + ex.Message);
                return false;

            }
        }
        public void CopyTo(string FFrom,string FTo)
        {
            //DataTransfrom obj = new DataTransfrom();
            ConfigManager objCofig = new ConfigManager();
            string BackFromCompath = FFrom; // AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder;
           // string SubFolderBack = FTo; //DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToBackuppath = FTo; // AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Customer\" + SubFolderBack;
                                       // CopyDir(BackFromCompath, ToBackuppath);
            if (File.Exists(ToBackuppath))
            {
                File.Delete(ToBackuppath);
            };
            File.Copy(BackFromCompath, ToBackuppath);

        }
        public void MoveInCustToBakup()
        {
            //DataTransfrom obj = new DataTransfrom();
            ConfigManager objCofig = new ConfigManager();
            string BackFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder;
            string SubFolderBack = DateTime.Now.ToString("yyyy-MM-dd");// DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Customer\" + SubFolderBack;
            CopyDir(BackFromCompath, ToBackuppath);

        }
        public void MoveInProdToBakup()
        {
            //DataTransfrom obj = new DataTransfrom();
            ConfigManager objCofig = new ConfigManager();
            string BackFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.ProductsFolder;
            string SubFolderBack = DateTime.Now.ToString("yyyy-MM-dd"); // DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Products\" + SubFolderBack;
            CopyDir(BackFromCompath, ToBackuppath);

        }

        public void MoveInOrderToBakupall(string ChanalFilse)
        {

            //DataTransfrom obj = new DataTransfrom();
            ConfigManager objCofig = new ConfigManager();
            string BackOFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder;
            string SubOFolderBack = DateTime.Now.ToString("yyyy-MM-dd");//DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToOBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Orders\" + SubOFolderBack;
            //ChanalFilse

            CopyDir(BackOFromCompath, ToOBackuppath);
        }

        public void MovelastOutputToBakup()
        {
            //DataTransfrom obj = new DataTransfrom();
            ConfigManager objCofig = new ConfigManager();
            string BackOFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.OutputFolder;
            string SubOFolderBack = DateTime.Now.ToString("yyyy-MM-dd");// DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToOBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\out\" + SubOFolderBack;
            CopyDir(BackOFromCompath, ToOBackuppath);
        }
        public void MoveFileInOrderToBakup(string Fromfile)
        {
            string MoveFileName = "";
            string[] FnameArry = Fromfile.Split('\\');
            MoveFileName = FnameArry[FnameArry.Length - 1].ToString();

            ConfigManager objCofig = new ConfigManager();
            // string BackOFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder;
            string SubOFolderBack = DateTime.Now.ToString("yyyy-MM-dd");// DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToOBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Orders\" + SubOFolderBack;
            // ADD Unique File Name Check to Below!!!!
            string Destdest = ToOBackuppath + @"\" + MoveFileName;
            if (!Directory.Exists(ToOBackuppath))
            {
                Directory.CreateDirectory(ToOBackuppath);
            };

            if (File.Exists(Destdest))
            {
                File.Delete(Destdest);
            };
            // string dest = Path.Combine(destFolder, name);
            File.Copy(Fromfile, Destdest);
            File.Delete(Fromfile);

        }

        public void MoveFileDisciuntToBakup(string Fromfile)
        {
            string MoveFileName = "";
            string[] FnameArry = Fromfile.Split('\\');
            MoveFileName = FnameArry[FnameArry.Length - 1].ToString();

            ConfigManager objCofig = new ConfigManager();
            // string BackOFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder;
            string SubOFolderBack = DateTime.Now.ToString("yyyy-MM-dd");//DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            string ToOBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Orders\" + SubOFolderBack;
            // ADD Unique File Name Check to Below!!!!
            string Destdest = ToOBackuppath + @"\" + MoveFileName;
            if (!Directory.Exists(ToOBackuppath))
            {
                Directory.CreateDirectory(ToOBackuppath);
            };

            if (File.Exists(Destdest))
            {
                File.Delete(Destdest);
            };
            // string dest = Path.Combine(destFolder, name);
            File.Copy(Fromfile, Destdest);
            File.Delete(Fromfile);

        }

    }
}

