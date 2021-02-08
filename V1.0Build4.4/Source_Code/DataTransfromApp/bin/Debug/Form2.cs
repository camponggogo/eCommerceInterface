using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Drawing;
using System.Diagnostics;
using System.Threading;

namespace eCommerceInterfaceApp
{
    public partial class Form2 : Form
    {
        // private DBConn dbConnect;

        public Form2()
        {
            InitializeComponent();
            string dir = AppDomain.CurrentDomain.BaseDirectory;// @"C:\Users\hikuma\Documents\IR"
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect;
                BuildTree(directoryInfo, treeView1.Nodes);
            }
        }
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);
            //foreach ( DirectoryInfo idr in directoryInfo.GetDirectories())
            //    {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                        {
                                           
                            BuildTree(subdir, curNode.Nodes);
                        }

                //}
           
        }
        private void ExportOrder()
        {

            Orders objOders = new Orders();
            DataTable iDt = objOders.GetTDOrders();
            ExcelManager objExl = new ExcelManager();
            ConfigManager objCong = new ConfigManager();
            if (iDt.Rows.Count > 0)
            {
                objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles,false);

                //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                //objlog.DataLog("Get Orders Completed", "O", "S", "O");
                //return "Get for Loading Orders";
            }
            else
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Get Orders Faailed", "O", "F", "O");
            }


        }

        private void ExportCustomer()
        {

            Customers objCust = new Customers();
            DataTable iDt = objCust.GetTDCustomer();
            ExcelManager objExl = new ExcelManager();
            ConfigManager objCong = new ConfigManager();

            if (iDt.Rows.Count > 0)
            {
                objExl.GenExcelfromdatatable(iDt, objCong.OutputCustomerfiles);

                //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                //objlog.DataLog("Get Orders Completed", "O", "S", "O");
                //return "Get for Loading Orders";
            }
            else
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Get Customer Faailed", "O", "F", "O");
            }


        }

        private void ExportNewCustomer()
        {
            Customers objCust = new Customers();
            DataTable iDt = objCust.GetTDNewCustomer();
            ExcelManager objExl = new ExcelManager();
            ConfigManager objCong = new ConfigManager();
            if (iDt.Rows.Count > 0)
            {
                objExl.GenExcelfromdatatable(iDt, objCong.OutputCustomerfiles);
            
            }
            else
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Get Customer Faailed", "O", "F", "O");
            }

        }
        //private void GetGrayCustomer()
        //{
        //    Customers objCust = new Customers();
        //    DataTable iDt = objCust.GetTDGrayCustomer();
        //    ExcelManager objExl = new ExcelManager();
        //    ConfigManager objCong = new ConfigManager();
        //    if (iDt.Rows.Count > 0)
        //    {
        //        objExl.GenExcelfromdatatable(iDt, objCong.OutputGrayCustomerfiles);

        //    }
        //    else
        //    {
        //        LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
        //        objlog.DataLog("Get Customer Faailed", "O", "F", "O");
        //    }

        //}
        

        //private void ShowProgressClick()
        //{
        //    button1.Enabled = false;
        //    progressBar1.Style = ProgressBarStyle.Marquee;
        //    progressBar1.MarqueeAnimationSpeed = 50;

        //    BackgroundWorker bw = new BackgroundWorker();
        //    bw.DoWork += bw_DoWork;
        //    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        //    bw.RunWorkerAsync();
        //}

        //void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // INSERT TIME CONSUMING OPERATIONS HERE
        //    // THAT DON'T REPORT PROGRESS
        //    Thread.Sleep(10000);
        //}

        //void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    progressBar1.MarqueeAnimationSpeed = 0;
        //    progressBar1.Style = ProgressBarStyle.Blocks;
        //    progressBar1.Value = progressBar1.Minimum;

        //    button1.Enabled = true;
        //    MessageBox.Show("Done!");
        //}

        private  void  ShowProgress(bool IsStart)
        {
            progressBar1.Value = 20;
            progressBar1.Visible = IsStart;
          
            if (IsStart)
            {
                timer1.Enabled = IsStart;
                timer1.Start();

            }
            else
            {
                timer1.Stop();
                timer1.Enabled = IsStart;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {    //***** Load Customeronline  to be MASTER *****
            this.label7.Text = "Loading Master Customer ...";
            
            string filePath = null;
            string filePathTo = null;

            openFileDialog1.Filter = "Excel 2007 Files|*.xlsx";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                filePath = openFileDialog1.FileName;
            else return;
            label7.Text = filePath;
            ConfigManager objCof = new ConfigManager();

            filePathTo = AppDomain.CurrentDomain.BaseDirectory + objCof.InCustFolder + @"\" + "MasterCustomer.xlsx";
            ShowProgress(true);
            try
            {
                //***** BEGIN Onstart*******
                ConfigManager objCmag = new ConfigManager();
               
                Boolean isAllDone = false;
                //***** Check Iput file Cust
                Boolean isCustExsiting = false;
                Boolean isOrdExsiting = false;
                DataTransfrom objTrans = new DataTransfrom();

                objTrans.CopyTo(filePath, filePathTo);
                isCustExsiting = objTrans.CheckCustExsiting();
                isOrdExsiting = objTrans.CheckOrderExsiting();

               

                //***** Check Iput file Cust            
                if (isCustExsiting)
                {
                   
                    //*****  if found file Cust do load
                    //*****  {
                    //*****       Loop List input
                    //*****           { Load ,Log } 
                    ///*****/  }

                    try
                    {
                      
                        //***** Load Customeronline  to be MASTER *****
                        // Store to DT 
                        string Status = "";
                        Status = objTrans.LoadFirstMastCustomers();
                        if (Status.Contains("Success"))
                        {
                            //***** Backup Input File // move to Completed // Delete Input File 

                                                     
                            isAllDone = true;
                           // ShowProgress(false);
                            //MessageBox.Show("Loading Master Customer :" + Status);
                            // this.label7.Text = "Loading Master Customer Completed ";

                            //label7.Text = "Load : " + Status;

                        }
                        //else
                        //{

                        //    // MOve to Failed Folder Input File
                        //    // Delete Input File
                        //    MessageBox.Show("System Error: Loading Master Customer Failed ",
                        //          "ERROR",
                        //          MessageBoxButtons.OK,
                        //          MessageBoxIcon.Error,
                        //          MessageBoxDefaultButton.Button1);

                        //};

                        // M     essageBox.Show("Process completed Status:" + Status);
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show("System Error:Loading Master Customer Failed: " + ex.Message,
                                 "ERROR",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1);

                        // MessageBox.Show(ex.Message);
                    }
                };
                //*****  esle not yet  
                //*****  if All completd go to Export
                if (isAllDone)
                {
                    // DataTransfrom objTrsn = new DataTransfrom();
                    objTrans.MovelastOutputToBakup();
                    //Backup Last output
                  //  ExportOrder();
                    // ExportCustomer();
                  //  ExportNewCustomer();
                    //Backup Log
                                     
                    MessageBox.Show("Process Loading Master Customer Completed" );
                    this.label7.Text = "Process Loading Master Customer completed ";
                   // ShowProgress(false);

                    // Binding to Grid
                    Customers objCust = new Customers();
                   DataTable dtNewCust = objCust.GetTDCustomer();
                    dataGridView1.DataSource = dtNewCust;
                    this.label7.Text = "BPlus Master Customer Data ";
                    ShowProgress(false);
                }
                else
                {
                  
                   // MessageBox.Show("Process Incompleted Status isAllDone:" + isAllDone);
                    this.label7.Text = "Loading Master Customer Failed ";
                    MessageBox.Show("System Error: Loading Master Customer Failed " ,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                    ShowProgress(false);
                }
                //***** END Onstart ********



                
            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: Loading Master Customer Failed ",
                                 "ERROR" + ex.Message,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1);
            }
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = null;
                string sheetName = null;

                openFileDialog1.Filter = "Excel 2007 Files|*.xlsx";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    filePath = openFileDialog1.FileName;
                else return;
                label7.Text = filePath;
                using (ExcelPackage excelPkg = new ExcelPackage())
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    excelPkg.Load(stream);

                    sheetName = excelPkg.Workbook.Worksheets[1].Name;
                    this.txtSheetName.Text = sheetName;

                    ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
                    ExcelManager objXls = new ExcelManager();
                    DataTable dt = objXls.WorksheetToDataTable(oSheet);
                    dataGridView1.DataSource = dt;
                    excelPkg.Dispose();


                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("System Error: Can't open file !:" + ex.Message,
                 "ERROR",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);
            }
        }
        // Reading a simple excel sheet that contains only text and numbers into DataTable...



        private void TestDTstroGridviw()
        {

            try
            {
                ConfigManager objCofig = new ConfigManager();
                //***** Check File are exsiting then let start*****
                string path = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder;  //"\\Logs";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + StrlogName + "_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                // string filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder + "StrlogName"+ "_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                string filepath = path + "\\InputCustomers\\MasterCustomer.xlsx";   // + objCofig.InCustFileLits;
                if (!File.Exists(filepath))
                {
                    // No Input to end . 
                    return;
                }
                else
                {
                    // Found Input to Load process
                    //***** Open Excel  stor in Data Table*****
                    string sheetName;
                    using (ExcelPackage excelPkg = new ExcelPackage())
                    using (FileStream stream = new FileStream(filepath, FileMode.Open))
                    {
                        excelPkg.Load(stream);
                        sheetName = excelPkg.Workbook.Worksheets[1].Name;

                        this.txtSheetName.Text = sheetName;

                        ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
                        ExcelManager objXls = new ExcelManager();
                        DataTable dt = objXls.WorksheetToDataTable(oSheet);
                        dataGridView1.DataSource = dt;
                        excelPkg.Dispose();

                        //***** Laod to database*****
                        // DataTransfrom objTranfrom = new DataTransfrom();
                        //objTranfrom.LoadCustomer(dt);
                        MessageBox.Show("Successfully");


                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadOrders_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (this.cmbOrdersOf.SelectedItem == null)
                {
                    // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                    DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
                  "WARNING",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button2);
                    return;
                }
                string SelectedChanel = "";
                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString().ToUpper();
                }
                string Status;
                TempOrders objtOder = new TempOrders();
                Status = objtOder.LoadOdersfromOrderTem(SelectedChanel);
                
                    this.btnSelectOrders.Enabled = true;
                //iDt = objDB.GetDtselect(SQL);
                DataTable iDt = new DataTable();
                Orders objOrer = new Orders();
                btnSelectOrders.Enabled = true;
                iDt = objOrer.GetTDOrders(); //objOrer.GetTDOrders(true);
                this.label7.Text = "Orders ready for Export to Bplus";

                MessageBox.Show("Process completed Ready to Export Order to BPlus");
             
                // objOrer.GetTDOrders(true);
                dataGridView1.DataSource = iDt;
                //    }




            }
            catch (Exception ex)
            {
               
                MessageBox.Show("System Error: Lead Orders failed:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }



        private void btnSelectOrders_Click(object sender, EventArgs e)
        {
            try
            {


                // Get Data to dt
                // Gen Excel Order to Text2Bplus  to Output Folder 
                // Test Gen Orders

                ConfigManager objCong = new ConfigManager();

                DataTable iDt = new DataTable();
                Orders objOrer = new Orders();
                iDt = objOrer.GetTDOrders(); // GetTDOrders(true);
                dataGridView1.DataSource = iDt;
                if (iDt.Rows.Count > 0) { 
                         ExportOrder();

                             this.label7.Text = "Orders ready for Export to Bplus";
                        MessageBox.Show("ExportOrder  to Folder:" + objCong.OutputOrdersfiles + "Completed");
                }

                ////DataTransfrom objTrans = new DataTransfrom();
                ////LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                ////                                             //if (isAllDone)
                ////                                             //{
                ////                                             // DataTransfrom objTrsn = new DataTransfrom();
                ////objTrans.MovelastOutputToBakup();
                //////Backup Last output
                ////ExportOrder();
                //////ExportCustomer();
                ////ExportNewCustomer();
                //////Backup Log
                //////delete System Log 
                ////objlog.SystemLog("Service runing OnElapsedTime process  All Step Done ");
                ////MessageBox.Show("Export All Done ready to import in to Bplus");
                ///
            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: ExportOrder failed:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }

        }

        private void btnSelectCust_Click(object sender, EventArgs e)
        {
            try
            {

            
            // Get Data to dt
            // Gen Excel Cust to Text2Bplus  to Output Folder 
            // Test Gen Cust
            //ExportCustomer();
            ExportNewCustomer();
            ConfigManager objCong = new ConfigManager();          

            MessageBox.Show("ExportNewCustomer  to Folder:" + objCong.OutputCustomerfiles + "Completed");

            Customers objCust = new Customers();
            DataTable dtNewCust = objCust.GetTDNewCustomer();
            dataGridView1.DataSource = dtNewCust;
            this.label7.Text = "New Customer ready for Export to Bplus ";
            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: ExportNewCustomer failed:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                Customers objCust = new Customers();
                DataTable dtNewCust = objCust.GetTDCustomer();
                dataGridView1.DataSource = dtNewCust;
                this.label7.Text = "BPlus Master Customer Data ";



            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: GetTDCustomer failed:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }
        //public void ExportCUstomer()
        //{
        //    try
        //    {
        //        DataTable iDt = new DataTable();
        //        DBConn objDB = new DBConn();
        //        string SQL = @"SELECT `mastcustomers`.`custid`,
        //                    `mastcustomers`.`custname`,
        //                    `mastcustomers`.`custaddr1`,
        //                    `mastcustomers`.`custaddr2`,
        //                    `mastcustomers`.`custaddr3`,
        //                    `mastcustomers`.`province`,
        //                    `mastcustomers`.`phonenum`,
        //                    `mastcustomers`.`faxnum`,
        //                    `mastcustomers`.`postcode`,
        //                    `mastcustomers`.`branchnum`,
        //                    `mastcustomers`.`taxcode`,
        //                    `mastcustomers`.`debtortype`,
        //                    `mastcustomers`.`custgroup`,
        //                    `mastcustomers`.`custtype`,
        //                    `mastcustomers`.`custzone`,
        //                    `mastcustomers`.`divisioncode`,
        //                    `mastcustomers`.`selarea`,
        //                    `mastcustomers`.`selid`,
        //                    `mastcustomers`.`paidperiod`,
        //                    `mastcustomers`.`creditbalance`
        //                FROM `mastcustomers`";

        //        iDt = objDB.GetDtselect(SQL);
        //        ExcelManager objExl = new ExcelManager();
        //        ConfigManager objCong = new ConfigManager();
        //        objExl.GenExcelfromdatatable(iDt, objCong.OutputCustomerfiles);

        //        MessageBox.Show("Export Customer Done");

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}


        //public void ExportOrder()
        //{
        //    try
        //    {
        //        DataTable iDt = new DataTable();
        //        DBConn objDB = new DBConn();
        //        string SQL = @"SELECT  `orders`.`ordernumber`,
        //                `orders`.`di_date`,
        //                `orders`.`di_ref`,
        //                `orders`.`vat_date`,
        //                `orders`.`vat_ref`,
        //                `orders`.`ap_code`,
        //                `orders`.`trd_sh_code`,
        //                `orders`.`trd_sh_qty`,
        //                `orders`.`trd_sh_free`,
        //                `orders`.`trd_sh_unitprice`,
        //                `orders`.`trd_discount`,
        //                `orders`.`wlcode1`,
        //                `orders`.`wlcode2`,
        //                `orders`.`totdiscount`,
        //                `orders`.`remark`                        
        //            FROM  `orders`";

        //        iDt = objDB.GetDtselect(SQL);
        //        ExcelManager objExl = new ExcelManager();
        //        ConfigManager objCong = new ConfigManager();
        //        objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

        //        MessageBox.Show(" Export orders Done");

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void btbGetCust_Click(object sender, EventArgs e)
        {
            try
            {
               


                Customers objCust = new Customers();
            DataTable dtNewCust = objCust.GetTDNewCustomer();
            dataGridView1.DataSource = dtNewCust;
            this.label7.Text = "New Customer ready for Export to Bplus ";
            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: GetTDNewCustomer failed:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }


        }
    
         private void btnGetOrder_Click(object sender, EventArgs e)
           {
            try
            {

            DataTable iDt = new DataTable();
            Orders objOrer = new Orders();
                iDt= objOrer.GetTDOrders();  // GetTDOrders(true);
                    dataGridView1.DataSource = iDt;
            this.label7.Text = "Orders ready for Export to Bplus";
            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: GetTDOrders failed:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }


        }

        ////private void btnOnstartService_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {

            
        ////    ConfigManager objCmag = new ConfigManager();
        ////    LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
        ////    Boolean isAllDone = false;


        ////    //***** Check Iput file Cust
        ////    Boolean isCustExsiting = false;
        ////    Boolean isOrdExsiting = false;
        ////    DataTransfrom objTrans = new DataTransfrom();
        ////    isCustExsiting = objTrans.CheckCustExsiting();
        ////    isOrdExsiting = objTrans.CheckOrderExsiting();

        ////    objlog.SystemLog("Service runing OnElapsedTime start Check  Found Cust =" + isCustExsiting + " Found Odrer=" + isOrdExsiting);

        ////    //***** Check Iput file Cust            
        ////    if (isCustExsiting)
        ////    {
        ////        //*****  if found file Cust do load
        ////        //*****  {
        ////        //*****       Loop List input
        ////        //*****           { Load ,Log } 
        ////        ///*****/  }

        ////        try
        ////        {
        ////            //***** Load Customeronline  to be MASTER *****
        ////            // Store to DT 
        ////            string Status = "";
        ////            Status = objTrans.LoadFirstMastCustomers();
        ////            if (Status.Contains("Success"))
        ////            {
        ////                //***** Backup Input File // move to Completed // Delete Input File 

        ////                objlog.DataLog(Status, "I", "S", "C");
        ////                objlog.SystemLog("Service Process Load Customer Status:" + Status);
        ////                isAllDone = true;
        ////                //label7.Text = "Load : " + Status;
        ////                ExportNewCustomer();
        ////            }
        ////            else
        ////            {

        ////                // MOve to Failed Folder Input File
        ////                // Delete Input File
        ////                objlog.DataLog(Status, "I", "F", "C");
        ////                objlog.SystemLog("Service Process Load Customer Status:" + Status);
        ////                objlog.SystemLog("Service runing OnElapsedTime every  " + objCmag.TiemtoDelay.ToString() + " seccone Load Customer  Step Done ");


        ////            };

        ////            // M     essageBox.Show("Process completed Status:" + Status);
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            objlog.SystemLog("Service Error SMS:" + ex.Message);
        ////            // MessageBox.Show(ex.Message);
        ////        }
        ////    };
        ////    //*****  esle not yet
        ////    //*****  if found file Cust do load
        ////    if (isOrdExsiting)
        ////    {
        ////        //*****  {
        ////        //*****       Loop List input
        ////        // Load Orders Staging
        ////        //    OK - Back up table ,load file, backup file and log,done
        ////        //Not OK-  Roll abck table ,not move file and log
        ////        try
        ////        {
        ////            DataTransfrom objTrsn = new DataTransfrom();
        ////            string Status = objTrsn.LoadAllOrdersfile();
        ////            if (Status.Contains("Success"))
        ////            {
        ////                isAllDone = true;
        ////                objlog.SystemLog("Service Process Load Order Status:" + Status);
        ////                objlog.SystemLog("Service runing OnElapsedTime every  " + objCmag.TiemtoDelay.ToString() + " seccone Load Oder Step Done ");
        ////                ExportOrder();
        ////            }

        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            objlog.SystemLog("Service Process Load Order Status:" + ex.Message);
        ////            // 
        ////        }
        ////        //*****  }
        ////    };
        ////    //*****  esle not yet



        ////    //*****  if All completd go to Export
        ////    if (isAllDone)
        ////    {
        ////        // DataTransfrom objTrsn = new DataTransfrom();
        ////        objTrans.MovelastOutputToBakup();
        ////        //Backup Last output
        ////        ExportOrder();
        ////        ExportNewCustomer();
        ////        //Backup Log
        ////        //delete System Log 
        ////        objlog.SystemLog("Service runing OnElapsedTime process  All Step Done ");
        ////    }
        ////    else
        ////    {
        ////        objlog.SystemLog("Service runing OnElapsedTime stop  No any process");

        ////    }

        ////    MessageBox.Show("Service runing OnElapsedTime process  All Step Done");

        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        MessageBox.Show("System Error: GetTDNewCustomer failed:" + ex.Message,
        ////                        "ERROR",
        ////                        MessageBoxButtons.OK,
        ////                        MessageBoxIcon.Error,
        ////                        MessageBoxDefaultButton.Button1);
        ////    }
        ////}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {

            

            if (e.Node.Name.EndsWith("txt") )
            {
                this.richTextBox1.Visible = true;
                this.richTextBox1.Clear();
                StreamReader reader = new StreamReader(e.Node.Name);
                this.richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
               
            }
            if (e.Node.Name.EndsWith("txt") || e.Node.Name.EndsWith("xlsx") || e.Node.Name.EndsWith("config") || e.Node.Name.EndsWith("exe") || e.Node.Name.EndsWith("dll") || e.Node.Name.EndsWith("pdb"))
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory);
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: on Get Folders:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {

            
            treeView1.Nodes.Clear();
            string dir = AppDomain.CurrentDomain.BaseDirectory;// @"C:\Users\hikuma\Documents\IR"
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect;
                BuildTree(directoryInfo, treeView1.Nodes);
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: on Get Folders:" + ex.Message,
                                "ERROR",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }

        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    //DataTransfrom obj = new DataTransfrom();
        //    //ConfigManager objCofig = new ConfigManager();
        //    ////***** Check File are exsiting then let start*****
        //    //string Frompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder;
        //    //string Topath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder + @"\Completed";
        //    //obj.CopyDir(Frompath, Topath);

        //    //string CFrompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder;
        //    //string CTopath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder + @"\Completed";
        //    //obj.CopyDir(CFrompath, CTopath);


        //    //string BackFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder + @"\Completed";
        //    //string SubFolderBack = DateTime.Now.Date.ToShortDateString().Replace('/', '_');
        //    //string ToBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Customer\" + SubFolderBack;
        //    //obj.CopyDir(BackFromCompath, ToBackuppath);

        //    //string BackOFromCompath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder + @"\Completed";
        //    //string SubOFolderBack = DateTime.Now.Date.ToShortDateString().Replace('/', '_');
        //    //string ToOBackuppath = AppDomain.CurrentDomain.BaseDirectory + objCofig.BackupFolder + @"\In\Orders\" + SubOFolderBack;
        //    //obj.CopyDir(BackOFromCompath, ToOBackuppath);
        //}

        //private void label5_Click(object sender, EventArgs e)
        //{

        //}

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //Products objProd = new Products();
            //objProd.LoadProductsItems();
            this.label7.Text = "Loading Products ... ";
            ShowProgress(true);

            string filePath = null;
            string filePathTo = null;           

            openFileDialog1.Filter = "Excel 2007 Files|*.xlsx";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                filePath = openFileDialog1.FileName;
            else return;
            label7.Text = filePath;
            ConfigManager objCof = new ConfigManager();

            filePathTo = AppDomain.CurrentDomain.BaseDirectory + objCof.ProductsFolder + @"\" + "Products_ItemList.xlsx";
           

            try
            {
                
                //***** BEGIN Onstart*******
                ConfigManager objCmag = new ConfigManager();
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                Boolean isAllDone = false;
                //***** Check Iput file Cust
                Boolean isProdExsiting = false;
               
                DataTransfrom objTrans = new DataTransfrom();
                objTrans.CopyTo(filePath, filePathTo);
                isProdExsiting = objTrans.CheckProdExsiting();

                //***** Check Iput file Cust            
                if (isProdExsiting)
                {
                   
                    //*****  if found file Cust do load
                    //*****  {
                    //*****       Loop List input
                    //*****           { Load ,Log } 
                    ///*****/  }

                    try
                    {
                        //***** Load Customeronline  to be MASTER *****
                        // Store to DT 
                        string Status = "";
                        Status = objTrans.LoadFirstProduct();
                        if (Status.Contains("Success"))
                        {
                            //***** Backup Input File // move to Completed // Delete Input File 

                           // objlog.DataLog(Status, "I", "S", "P");
                          
                            isAllDone = true;
                            this.label7.Text = "Process Load Products Completd ";
                            //MessageBox.Show("Process Load Products Completd");


                            MessageBox.Show("Process Products load completed ");
                            // bindign to Grid;
                            Products objProd = new Products();
                            DataTable dtProd = objProd.GetTDProducts();
                            dataGridView1.DataSource = dtProd;
                            this.label7.Text = "BPlus Master Product Items List load completed ";

                            ShowProgress(false);
                            //label7.Text = "Load : " + Status;
                            //ExportCustomer();
                            // ExportNewCustomer();
                        }
                        else
                        {

                            // MOve to Failed Folder Input File
                            // Delete Input File
                           // objlog.DataLog(Status, "I", "F", "P");
                         
                            this.label7.Text = "Process Load Products Failed ";
                            ShowProgress(false);
                            MessageBox.Show("System Error: Loading Products Failed:" + Status,
                              "ERROR",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1);

                        };

                        // M     essageBox.Show("Process completed Status:" + Status);
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show("System Error: Loading Products Failed:" + ex.Message,
                              "ERROR",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1);

                        // MessageBox.Show(ex.Message);
                    }
                }
                else {
                    MessageBox.Show("No data for loading Products ");
                };
                //*****  esle not yet  
                //*****  if All completd go to Export
               
                //***** END Onstart ********

            }
            catch (Exception ex)
            {

              
                MessageBox.Show("System Error: Loading Products Failed:" + ex.Message,
                               "ERROR",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
            }

        }

        private void btnShowProd_Click(object sender, EventArgs e)
        {
            Products objProd = new Products();
            DataTable dtProd = objProd.GetTDProducts();
            dataGridView1.DataSource = dtProd;
            this.label7.Text = "BPlus Master Product Items List ";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try { 
            
                    Orders objOders = new Orders();
                    DataTable iDt = objOders.GetTDOrdersSummay();
                    ExcelManager objExl = new ExcelManager();
                    ConfigManager objCong = new ConfigManager();
                    if (iDt.Rows.Count > 0)
                    {
                        objExl.GenExcelfromdatatable(iDt, objCong.ReportOrdersDailySummary, true);
                        MessageBox.Show("Gennerate Report Order summary in " + objCong .ReportOrdersDailySummary + "completed ");

                        dataGridView1.DataSource = iDt;
                        this.label7.Text = "Report Order summary completed ";
                        //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                        //objlog.DataLog("Get Orders Completed", "O", "S", "O");
                        //return "Get for Loading Orders";
                    }
                    else
                    {
                        LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                        objlog.DataLog("Get Orders Faailed", "O", "F", "O");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: GetTDOrdersSummay()." + ex.Message,
                  "ERROR",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            //this.btnSelectOrders.Enabled = false;
            //this.btnSelectCust.Enabled = false;
            string filePath = null;
            string filePathTo = null;

           if  ( this.cmbOrdersOf.SelectedItem == null)
            {
               // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }

            //if (this.cmbOrdersOf.SelectedItem.ToString() == "PiPPER Web") {
            //    DialogResult result3 = MessageBox.Show("Function to load PiPPER Web oders  in construction.",
            //    "WARNING",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2);
            //    return;
            //}

            this.label7.Text = "Loading Customer in Orders from " + this.cmbOrdersOf.SelectedItem.ToString();
            openFileDialog1.Filter = "Excel 2007 Files|*.xlsx";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                filePath = openFileDialog1.FileName;
            else return;
            label7.Text = filePath;
            ConfigManager objCof = new ConfigManager();
            string SelectedChanel = "";
            if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
            {
                SelectedChanel = "ECOMM";
            } else {
                SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString().ToUpper();
            }


            filePathTo = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder +  @"\" + SelectedChanel.ToUpper() + "_Orders.xlsx";

           try
            {

                ConfigManager objCmag = new ConfigManager();
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 

                Boolean isOrdExsiting = false;
                DataTransfrom objTrans = new DataTransfrom();
                objTrans.DeleteExcelInDir(filePathTo);
                objTrans.CopyTo(filePath,  filePathTo);

                isOrdExsiting = objTrans.CheckOrderExsiting();

                 ShowProgress(true);
                //*****  if found file Cust do load
                if (isOrdExsiting)
                {
                    this.label7.Text = "Loading Customer in Orders from " + this.cmbOrdersOf.SelectedItem.ToString();

                    try
                    {
                      
                        DataTransfrom objTrsn = new DataTransfrom();
                        string Status = objTrsn.LoadAllOrdersfile();
                        if (Status.Contains("Success"))
                        {
                            // isAllDone = true;   
                            // ShowProgress(false);
                            MessageBox.Show("Check Existing Customer in  File Orders Completed");

                            Customers objCust = new Customers();
                            DataTable dtNewCust = objCust.GetTDNewCustomerbyChn(SelectedChanel);
                            dataGridView1.DataSource = dtNewCust;
                            this.label7.Text = "New Customer In Orders Files ";
                        }
                        else {
                         //   MessageBox.Show("Failed to Check Existing Customer in  File Orders . Please check log failed on load Orders.");
                            MessageBox.Show("Error to load Orders and Check Existing Customer in files Orders . Please check log failed on load Orders.",
                                       "ERROR",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error,
                                       MessageBoxDefaultButton.Button1);
                        }

                    }
                    catch (Exception ex)
                    {
                    
                        // MessageBox.Show(ex.Message);
                        MessageBox.Show("System Error: LoadAllOrdersfile()." + ex.Message,
                                         "ERROR",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error,
                                         MessageBoxDefaultButton.Button1);

                    }

                   ShowProgress(false);
                    //*****  }
                }
                else
                {
                    ShowProgress(false);

                    MessageBox.Show("System Error: File Not found !",
                  "ERROR",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: CheckOrderExsiting()." + ex.Message,
                  "ERROR",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error,
                  MessageBoxDefaultButton.Button1);
                
            }

        }

        private void btnGrayCustomer_Click(object sender, EventArgs e)
        {
            string SelectedChanel;
            //  GetGrayCustomer();
            // MessageBox.Show("Export data File: Customer Lilst to manual ");
            if (this.cmbOrdersOf.SelectedItem == null)
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString().ToUpper();
                }
            }

            try
            {
                dataGridView1.DataSource = null;
                Customers objCust = new Customers();
                DataTable dtNewCust = objCust.GetTDGrayCustomer(SelectedChanel.ToUpper());

                if (dtNewCust.Rows.Count > 0 || dtNewCust != null)
                {
                    dataGridView1.DataSource = dtNewCust;
                    this.label7.Text = " Gray area Customer to manual adjust ";
                }
                else
                {
                    //Customers objCust = new Customers();
                    //DataTable dtNewCust = objCust.GetTDNewCustomer();
                    dataGridView1.DataSource = dtNewCust;
                    this.label7.Text = "New Customer ready for Export to Bplus ";
                }
                



            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error: GetTDGrayCustomer()." + ex.Message,
                               "ERROR",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
            }

        }

        private void RebindGrayCust()
        {
            try
            {
                string SelectedChanel;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString().ToUpper();
                }

                Customers objCust = new Customers();
                DataTable dtNewCust = objCust.GetTDGrayCustomer(SelectedChanel.ToUpper());
                dataGridView1.DataSource = dtNewCust;
                this.label7.Text = " Gray area Customer to manual setup ";



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //MessageBox.Show(e.RowIndex.ToString());
        //}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            //DataTable iDT = new DataTable();
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 ) { 
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string iText = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();// row.Cells[1].Value;
                if (!iText.Contains("Chk")) { 
                    return; 
                };

            string iChenel;
            string iCheckOption = "";
            string iPhonText = "";
            string EnbleEditCustmer = "";
            string iTransID = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();// row.Cells[1].Value;
            string iCustID = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();// row.Cells[1].Value;

            ConfigManager objConf = new ConfigManager();
            EnbleEditCustmer = objConf.EnbleEditCustmer;





            if (iText.Contains("Phone Matched Existing"))
            {
                iCheckOption = "ChkPhone";
                iPhonText = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            else if (iText.Contains("Name Matched Existing"))
            {
                iCheckOption = "ChkName";
                iPhonText = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {

                if (iText.Contains("Existing Matched Existing") == true && EnbleEditCustmer == "YES")
                {
                    iCheckOption = "ChkPhone";
                    iPhonText = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
                else
                {
                    return;
                }
            }
            string SelectedChanel;
            if (this.cmbOrdersOf.SelectedItem == null)
            {

                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select Source system of Orders  : in dropdown list?.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                this.cmbOrdersOf.Focus();
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString();
                }
            }

            iChenel = SelectedChanel.ToUpper();



            FormPopUp frmPop = new FormPopUp();
            frmPop.CustTempID = iTransID;
            frmPop.CustID = iCustID;
            frmPop.iChenel = iChenel;


            frmPop.Show();
            //Register form closed event
            frmPop.FormClosed += new FormClosedEventHandler(frmPop_FormClosed);
            //String value = "";

            }

        }

        void frmPop_FormClosed(object sender, FormClosedEventArgs e)
        {
            RebindGrayCust();
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }//public static DialogResult InputBox(string title, string promptText, ref string value)



        //public void ShowMyDialogBox()
        //{
        //    FrmDialog testDialog = new FrmDialog();

        //    // Show testDialog as a modal dialog and determine if DialogResult = OK.
        //    if (testDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        // Read the contents of testDialog's TextBox.
        //        this.label7.Text = testDialog.getCustText();
        //    }
        //    else
        //    {
        //        this.label7.Text = "Cancelled";
        //    }
        //    testDialog.Dispose();
        //}



        private void btnLoadDiscnt_Click(object sender, EventArgs e)
        {
            if (this.cmbOrdersOf.SelectedItem == null  || this.cmbOrdersOf.SelectedItem != "Lazada")
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select Order from: LAZADA in dropdown list!.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                this.cmbOrdersOf.Focus();
                return;
            }

            string filePath = null;
            string filePathTo = null;

            openFileDialog1.Filter = "Excel 2007 Files|*.xlsx";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                filePath = openFileDialog1.FileName;
            else return;
            label7.Text = filePath;
            ConfigManager objCof = new ConfigManager();

            filePathTo = AppDomain.CurrentDomain.BaseDirectory + objCof.InOrdersFolder + @"\Lazada_Discount.xlsx";

            try
            {

                ConfigManager objCmag = new ConfigManager();
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                DataTransfrom objTrans = new DataTransfrom();

                objTrans.CopyTo(filePath, filePathTo);

                //objProd.LoadProductsItems();
                this.label7.Text = "Loading Discount ... ";
                ShowProgress(true);

                try
                    {
                        //***** Load Customeronline  to be MASTER *****
                        // Store to DT 
                        string Status = "";
                        Status = objTrans.LoadFileDisCount(filePathTo);
                        if (Status.Contains("Success"))
                        {
                            //***** Backup Input File // move to Completed // Delete Input File 

                            objlog.DataLog(Status, "I", "S", "C");
                            
                            //isAllDone = true;
                            this.label7.Text = "Process Load Discount Completd ";
                        ShowProgress(false);
                        DataTable iDt = new DataTable();
                                Discounts objDis = new Discounts();
                                iDt = objDis.GetTDDisCount();
                                dataGridView1.DataSource = iDt;
                                this.label7.Text = "Discount as Imported in Database";

                        //label7.Text = "Load : " + Status;
                        //ExportCustomer();
                        // ExportNewCustomer();
                        MessageBox.Show("Process Load Discount completed ");
                    }
                        else
                        {

                            // MOve to Failed Folder Input File
                            // Delete Input File
                           /// objlog.DataLog(Status, "I", "F", "C");
                           
                            this.label7.Text = "Process Load Discount Failed ";
                            MessageBox.Show("Process Load Discount Failed !.",
                                         "ERROR",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error,
                                         MessageBoxDefaultButton.Button1);
                        ShowProgress(false);
                    };

                      
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show("System ERROR : LoadFileDisCount():" + ex.Message,
                                 "ERROR",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1);

                    }
              
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("System ERROR : Loading Discount :" + ex.Message,
                                 "ERROR",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error,
                                 MessageBoxDefaultButton.Button1);
             }

         }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string SelectedChanel;
            if (this.cmbOrdersOf.SelectedItem == null)
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString();
                }
            }

            dataGridView1.DataSource = null;
            Customers objCust = new Customers();
            DataTable dtNewCust = objCust.GetTDGrayCustomer(SelectedChanel.ToUpper());
            dataGridView1.DataSource = dtNewCust;
            this.label7.Text = " Gray area Customer to manual setup ";

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string SelectedChanel ;
            if (this.cmbOrdersOf.SelectedItem == null)
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString();
                }
            }


            DataTable iDt = new DataTable();
            DBConn objDB = new DBConn();
            string SQL = @"SELECT Distinct CONCAT(`isNewCust`, ' Matched Existing') as `Click to Check` ,`custid` as  `BPlus custid`,
                        `custname`,
                        `custaddr1`,
                        `custaddr2`,
                        `custaddr3`,
                        `province`,
                        `phonenum`,
                        `faxnum`,
                        `postcode`,
                        `branchnum`,
                        `taxcode`,
                        `debtortype`,
                        `custgroup`,
                        `custtype`,
                        `custzone`,
                        `divisioncode`,
                        `selarea`,
                        `selid`,
                        `paidperiod`,
                        `creditbalance`,                        
                         `AddrInOrders`                        
                        FROM `newcustomer_temp` where `isNewCust` = 'Existing' and `orderchanel` like '" + SelectedChanel.ToUpper() + "%'";           

            iDt = objDB.GetDtselect(SQL);
           
            dataGridView1.DataSource = iDt;
            this.label7.Text = "Existing Customer Group 1 All  Matched Existing";
        }

        private void btn_Discount_Click(object sender, EventArgs e)
        {
            DataTable iDt = new DataTable();
            Discounts objDis = new Discounts();
            iDt = objDis.GetTDDisCount();
            dataGridView1.DataSource = iDt;
            this.label7.Text = "Discount as Imported in Database";
        }

        private  void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value >= 200)
            {
                progressBar1.Value = 0;
               // timer1.Enabled = false;
                return;

            }
            progressBar1.Value += 20;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btnSelectOrders.Enabled = false;
            ConfigManager objConf = new ConfigManager();
            if (objConf.EnbleShowData == "YES")
            {
                groupBox3.Visible = true;
            }
            else { groupBox3.Visible = false; };
           // progressBar1.Visible = true;
        }

        private void btnShowNewCustbyChn_Click(object sender, EventArgs e)
        {
            string SelectedChanel;

            if (this.cmbOrdersOf.SelectedItem == null)
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString();
                }
            }
            dataGridView1.DataSource = null;
            Customers objCust = new Customers();
            DataTable dtNewCust = objCust.GetTDNewCustomerbyChn(SelectedChanel.ToUpper());
            dataGridView1.DataSource = dtNewCust;
            this.label7.Text = " Gray area Customer to manual setup ";
        }

        private void btnClearbyChn_Click(object sender, EventArgs e)
        {
            string SelectedChanel;
            if (this.cmbOrdersOf.SelectedItem == null)
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString();
                }
            }

            DialogResult result = MessageBox.Show("Confirmed to Clear Customer in order  and Order Data ", "Confirmed to Clear Order Data",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes )
            {
                //...               
               Orders objOrer = new Orders();
               objOrer.ClearTDOrders(SelectedChanel.ToUpper());
            
                MessageBox.Show("Clear Customer in order  and Order Data Completed");

            }
            dataGridView1.DataSource = null;
            
            this.label7.Text = " Clear Order Data by Chanel ";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmed to Clear All Customers in orders and All Orders Data ", "Confirmed to Clear Order Data",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Question,
         MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                //...               
                Orders objOrer = new Orders();
                objOrer.ClearAllTDOrders();

                MessageBox.Show("Clear All Customer in order  and All Order Data Completed");

            }
            dataGridView1.DataSource = null;

            this.label7.Text = " Clear Order Data by Chanel ";
        }

        private void btnFourcetoExisting_Click(object sender, EventArgs e)
        {
         
          
                 string SelectedChanel;
            if (this.cmbOrdersOf.SelectedItem == null)
            {
                // MessageBox.Show("TranX","Please select Platfrom of the Orders file.");
                DialogResult result3 = MessageBox.Show("Please select channel of Orders.",
              "WARNING",
              MessageBoxButtons.OK,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2);
                return;
            }
            else
            {
                //string SelectedChanel ;

                if (this.cmbOrdersOf.SelectedItem.ToString().Contains("eComm"))
                {
                    SelectedChanel = "ECOMM";
                }
                else
                {
                    SelectedChanel = this.cmbOrdersOf.SelectedItem.ToString();
                }
            }

            DialogResult result = MessageBox.Show("Confirmed to set all Gray Are to be existing ", "Confirmed to  Update Customer Info.",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                //... 
                Customers objOrer = new Customers();
                objOrer.UpdateAllGraytoExistingID(SelectedChanel);


                MessageBox.Show("Set All Gray Are to existing Completed");

            }
            dataGridView1.DataSource = null;

            this.label7.Text =  "Set All Gray Are to existing Completed";
        }
    }


}
    

