using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace eCommerceInterfaceApp
{
    

    class Discounts
    {
        public DataTable Discounttable;// = new DataTable();
        public string Discountid;
        public string OrderNo;
        public string OrderDate;
        public string OrderItemId;
        public string UnitPrice;
        public string Commission;
        public string PaymentFee;
        public string CustShippingFee;
        public string ShippingCost;
        public string Promotions;
        public string Other;
        public string PayoutAmount;
        public string OrderStatus;
        public string StatementNumbers;
        public string PayoutStatus;

        public Discounts()
        {
            Discounttable = new DataTable();
            Discounttable.Columns.Add("Discountid", typeof(string));
            Discounttable.Columns.Add("OrderNo", typeof(string));
            Discounttable.Columns.Add("OrderDate", typeof(string));
            Discounttable.Columns.Add("OrderItemId", typeof(string));
            Discounttable.Columns.Add("UnitPrice", typeof(string));
            Discounttable.Columns.Add("Commission", typeof(string));
            Discounttable.Columns.Add("PaymentFee", typeof(string));
            Discounttable.Columns.Add("CustShippingFee", typeof(string));
            Discounttable.Columns.Add("ShippingCost", typeof(string));
            Discounttable.Columns.Add("Promotions", typeof(string));
            Discounttable.Columns.Add("Other", typeof(string));
            Discounttable.Columns.Add("PayoutAmount", typeof(string));
            Discounttable.Columns.Add("OrderStatus", typeof(string));
            Discounttable.Columns.Add("StatementNumbers", typeof(string));
            Discounttable.Columns.Add("PayoutStatus", typeof(string));

          }
        public string LoadDiscount(DataTable DisCountDT)
        {
            List<string> SQLList = new List<string>();
            try
            {
                string Status = "";
                int iRowCount = 0;
                //***** Laod ?Mast Customer to database*****
                // On all tables' rows
                if (DisCountDT.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in DisCountDT.Rows)
                    {
                        // On all tables' columns
                       // this.Discountid = dtRow[0].ToString();
                        this.OrderNo = dtRow[0].ToString();
                        this.OrderDate = dtRow[1].ToString();
                        this.OrderItemId = dtRow[2].ToString();
                        this.UnitPrice =  dtRow[3].ToString().Trim().Length > 0 ? dtRow[3].ToString().Trim() : "0";     // decimal
                        this.Commission = dtRow[4].ToString().Trim().Length > 0 ? dtRow[4].ToString().Trim() : "0";     // decimal
                        this.PaymentFee = dtRow[5].ToString().Trim().Length > 0 ? dtRow[5].ToString().Trim() : "0";     // decimal
                        this.CustShippingFee = dtRow[6].ToString().Trim().Length > 0 ? dtRow[6].ToString().Trim() : "0";     // decimal
                        this.ShippingCost = dtRow[7].ToString().Trim().Length > 0 ? dtRow[7].ToString().Trim() : "0";     // decimal
                        this.Promotions = dtRow[8].ToString().Trim().Length > 0 ? dtRow[8].ToString().Trim() : "0";     // decimal
                        this.Other = dtRow[9].ToString().Trim().Length > 0 ? dtRow[9].ToString().Trim() : "0";     // decimal
                        this.PayoutAmount = dtRow[10].ToString().Trim().Length > 0 ? dtRow[10].ToString().Trim() : "0";     // decimal
                        this.OrderStatus = dtRow[11].ToString();
                        this.StatementNumbers = dtRow[12].ToString();
                        this.PayoutStatus = dtRow[13].ToString();



                        //}
                        //this.BackuptableProd();
                        //**** Save ****
                        string SQLCmd = @" INSERT INTO `discountinorders`(`OrderNo`,`OrderDate`,`OrderItemId`,`UnitPrice`,`Commission`,`PaymentFee`,`CustShippingFee`,`ShippingCost`,`Promotions`,`Other`,`PayoutAmount`,`OrderStatus`,`StatementNumbers`,`PayoutStatus`)
                                        VALUES
                                                (" + "'" + this.OrderNo + "'," +
                                                     "'" + this.OrderDate + "'," +
                                                     "'" + this.OrderItemId + "'," +
                                                     "'" + this.UnitPrice + "'," +
                                                     "'" + this.Commission + "'," +
                                                     "'" + this.PaymentFee + "'," +
                                                     "'" + this.CustShippingFee + "'," +
                                                     "'" + this.ShippingCost + "'," +
                                                     "'" + this.Promotions + "'," +
                                                     "'" + this.Other + "'," +
                                                     "'" + this.PayoutAmount + "'," +
                                                     "'" + this.OrderStatus + "'," +
                                                     "'" + this.StatementNumbers + "'," +
                                                     "'" + this.PayoutStatus + "'" + ") ;";
                        SQLList.Add(SQLCmd);
                    }

                };

                try
                {
                    // Loop List to Laod
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                    Boolean JustFailed = false;
                    DBConn objDB = new DBConn();
                    iRowCount = 0;
                    List<int> FailedIndxrowList = new List<int>();

                    foreach (string strSQL in SQLList)
                    {
                        string srtExstatus = "";
                        iRowCount++;
                        srtExstatus = objDB.ExcuteSQL("LoadDiscount:" + iRowCount, strSQL.Replace("\r\n", ""));

                        if (srtExstatus.Contains("Success"))
                        {
                            if (JustFailed == false) { JustFailed = false; }
                        }
                        else
                        {  // Add List Error
                            FailedIndxrowList.Add(iRowCount);
                            JustFailed = true;
                            int sidx, endinx;
                            string strXSQL = strSQL.Replace("\r\n", "");
                            sidx = strXSQL.IndexOf("VALUES(") + 7;
                            endinx = strXSQL.Length - sidx;
                            string strFaileData = strXSQL.Substring(sidx, endinx - 1);

                            objlog.FailedDataLog(strFaileData, "I", "F", "O");
                        }
                    }

                    if (JustFailed)
                    {
                        Status = "Failed  LoadDiscount  at rows :";
                        foreach (int X in FailedIndxrowList)
                        {
                            Status = Status + "," + X.ToString();
                        }

                        objlog.DataLog(Status, "I", "F", "O");

                    }
                    else
                    {
                        Status = "Success for LoadDiscount" + iRowCount + "  Record";
                    }

                }
                catch (Exception ex)
                {
                    Status = "Failed for LoadDiscount :" + ex.Message;
                    //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                   // objlog.DataLog("Error: LoadDiscount ExcuteSQL:" + ex.Message, "I", "F", "O");
                    MessageBox.Show("Error: LoadDiscount ExcuteSQL:" + ex.Message);
                    //RollbacktableDiscount();
                }

                return Status;// "Success for first loading mast Customer" + iRowCount+ "  Record";
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("ERROR: LoadDiscount();" + ex.Message, "I", "F", "O");

                // this.RollbacktableDiscount();
                return "Failed";
            }

        }
        private void BackuptableProd()
        {
            // Truncate  table `mastcustomers_bk`
            // Copy table  `mastcustomers` to `mastcustomers_bk`
            try
            {
                // Loop List to Laod
                DBConn objDB = new DBConn();
                string strEx = "";
                string strSQL = "truncate table `products_bk`";
                strEx = objDB.ExcuteSQL("BackuptableProd", strSQL);

                strSQL = "INSERT INTO `products_bk` select * FROM `products` ";
                strEx = objDB.ExcuteSQL("BackuptableProd", strSQL);
                strSQL = "Delete from  `products`";
                strEx = objDB.ExcuteSQL("BackuptableProd", strSQL);
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog(ex.Message, "I", "F", "C");
            }

        }
        private void RollbacktableDiscount()
        {
            // Truncate  table `mastcustomers`
            // Copy table `mastcustomers_bk`   to  `mastcustomers`            
            try
            {
                // Loop List to Laod
                DBConn objDB = new DBConn();
                string SteExcc;
                string strSQL = "Delete from `discountinorders`";
                SteExcc = objDB.ExcuteSQL("RollbacktableCust", strSQL);
                //strSQL = " INSERT INTO `products`  Select * from `products_bk`";
               // SteExcc = objDB.ExcuteSQL("RollbacktableCust", strSQL);
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog(ex.Message, "I", "F", "C");
            }
        }

        public DataTable GetTDDisCount()
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = @"SELECT `Discountid`,
                                `OrderNo`,
                                `OrderDate`,
                                `OrderItemId`,
                                `UnitPrice`,
                                `Commission`,
                                `PaymentFee`,
                                `CustShippingFee`,
                                `ShippingCost`,
                                `Promotions`,
                                `Other`,
                                `PayoutAmount`,
                                `OrderStatus`,
                                `StatementNumbers`,
                                `PayoutStatus`
                            FROM `discountinorders`;";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

               // LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
               // objlog.DataLog("Export mastcustomers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetTDDisCount():" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }



    }
}
