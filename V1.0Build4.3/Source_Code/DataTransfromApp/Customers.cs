using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
namespace eCommerceInterfaceApp
{
    class Customers
    {
        public DataTable Custtable;// = new DataTable();
        public string custid;
        public string custname;
        public string custaddr1;
        public string custaddr2;
        public string custaddr3;
        public string province;
        public string phonenum;
        public string faxnum;
        public string postcode;
        public string branchnum;
        public string taxcode;
        public string debtortype;
        public string custgroup;
        public string custtype;
        public string custzone;
        public string divisioncode;
        public string selarea;
        public string selid;
        public string paidperiod;
        public string creditbalance;
        public Customers()
        {
            Custtable = new DataTable();
            Custtable.Columns.Add("custid", typeof(string));
            Custtable.Columns.Add("custname", typeof(string));
            Custtable.Columns.Add("custaddr1", typeof(string));
            Custtable.Columns.Add("custaddr2", typeof(string));
            Custtable.Columns.Add("custaddr3", typeof(string));
            Custtable.Columns.Add("province", typeof(string));
            Custtable.Columns.Add("phonenum", typeof(string));
            Custtable.Columns.Add("faxnum", typeof(string));
            Custtable.Columns.Add("postcode", typeof(string));
            Custtable.Columns.Add("branchnum", typeof(string));
            Custtable.Columns.Add("taxcode", typeof(string));
            Custtable.Columns.Add("debtortype", typeof(string));
            Custtable.Columns.Add("custgroup", typeof(string));
            Custtable.Columns.Add("custtype", typeof(string));
            Custtable.Columns.Add("custzone", typeof(string));
            Custtable.Columns.Add("divisioncode", typeof(string));
            Custtable.Columns.Add("selarea", typeof(string));
            Custtable.Columns.Add("selid", typeof(string));
            Custtable.Columns.Add("paidperiod", typeof(string));
            Custtable.Columns.Add("creditbalance", typeof(string));

        }
        public string LoadFirstonlinetomastCustomers(DataTable MastCustDT)
        {
            List<string> SQLList = new List<string>();
            try
            {
                string Status = "";
                int iRowCount = 0;
                //***** Laod ?Mast Customer to database*****
                // On all tables' rows
                if (MastCustDT.Rows.Count > 0)
                {
                    Custtable = MastCustDT;

                    foreach (DataRow dtRow in Custtable.Rows)
                    {
                        // On all tables' columns
                        //foreach (DataColumn dc in objCustOnlin.Custonlinetable.Columns)
                        // {
                        this.custid = dtRow[0].ToString();
                        this.custname = dtRow[1].ToString();
                        this.custaddr1 = dtRow[5].ToString();
                        this.custaddr2 = dtRow[6].ToString();
                        this.custaddr3 = dtRow[7].ToString();
                        this.province = ""; // dtRow[5].ToString();
                        this.phonenum = dtRow[10].ToString() ;
                        this.faxnum = dtRow[11].ToString();
                        this.postcode = dtRow[9].ToString();
                        this.branchnum = dtRow[3].ToString();
                        this.taxcode = "";// dtRow[10].ToString();
                        this.debtortype = dtRow[16].ToString();
                        this.custgroup = "";//dtRow[12].ToString();
                        this.custtype = "";//dtRow[13].ToString();
                        this.custzone = "";//dtRow[14].ToString();
                        this.divisioncode = "";//dtRow[15].ToString();
                        this.selarea = "";//dtRow[16].ToString();
                        this.selid = "";//dtRow[17].ToString();
                        this.paidperiod = "";//dtRow[18].ToString();
                        this.creditbalance = "";//dtRow[19].ToString();
                        bool isAscii = false;
                        int x = 0;
                        if (this.phonenum != "") {
                            //if (this.phonenum == "ฺ")
                            //{
                            //    phonenum = "ฺ";
                            //}
                            char[] ch = phonenum.ToCharArray();
                            if (ch.Length > 0)
                            {
                                foreach (char c in ch)
                                {
                                    x = x + 1;
                                    isAscii = c < 128; ;
                                }
                            }
                                                    
                           
                            if (x > 9 && isAscii)
                            {
                                if (this.phonenum.Substring(0, 2) == "66" && this.phonenum.Length > 2)
                                {
                                    this.phonenum = "0" + this.phonenum.Substring(2, this.phonenum.Length - 2);
                                }
                            }
                        }

                        // "'" + this.phonenum.Substring(0, 2) == "66" ? "0" + this.phonenum.Substring(2, this.phonenum.Length - 2) : this.phonenum + "'," +

                        //}
                        string strbacSlach = @"\'";
                        //**** Save ****
                        if (this.phonenum != "" && custaddr1 != "" )
                        {
                            string SQLCmd = @" INSERT INTO `mastcustomers`
                                        (`custid`,
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
                                        `creditbalance`)
                                        VALUES
                                        (" + "'" + this.custid + "'," +
                                                "'" + this.custname.Replace("'", strbacSlach) + "'," +
                                                "'" + this.custaddr1.Replace("'", strbacSlach) + "'," +
                                                "'" + this.custaddr2.Replace("'", strbacSlach) + "'," +
                                                "'" + this.custaddr3.Replace("'", strbacSlach) + "'," +
                                                "'" + this.province + "'," +
                                                "'" + this.phonenum + "'," +
                                                "'" + this.faxnum + "'," +
                                                "'" + this.postcode + "'," +
                                                "'" + this.branchnum + "'," +
                                                "'" + this.taxcode + "'," +
                                                "'" + this.debtortype + "'," +
                                                "'" + this.custgroup + "'," +
                                                "'" + this.custtype + "'," +
                                                "'" + this.custzone + "'," +
                                                "'" + this.divisioncode + "'," +
                                                "'" + this.selarea + "'," +
                                                "'" + this.selid + "'," +
                                                "'" + this.paidperiod + "'," +
                                                "'" + this.creditbalance + "') ;";
                            SQLList.Add(SQLCmd);
                            //"'" + this.phonenum + "'," +
                        }
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
                        srtExstatus = objDB.ExcuteSQL("loadreplace mast Customer:" + iRowCount, strSQL.Replace("\r\n", ""));

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
                        Status = "Failed  loadreplace mast Customer  at rows :";
                        foreach (int X in FailedIndxrowList)
                        {
                            Status = Status + "," + X.ToString();
                        }

                        objlog.DataLog(Status, "I", "F", "C");

                    }else
                    {
                        Status = "Success for loadreplace mast Customer" + iRowCount + "  Record";                        
                        objlog.DataLog(Status, "I", "S", "C");
                    }

                }
                catch (Exception ex)
                {
                    Status = "Failed for Loading Custinorders_Temp :" + ex.Message;
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                    objlog.DataLog("Error: LoadFirstonlinetomastCustomers() Insert Custinorders_Temp failed:" + ex.Message, "I", "F", "C");
                }



                //if (iRowCount == 0)
                //{
                //    this.RollbacktableCust();
                //    LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                //    Status = "Failed";
                //    objlog.DataLog(Status + "No row inserted", "I", "F", "C");
                //}
                //else { Status = "Success for loadreplace mast Customer" + iRowCount + "  Record"; }

                return Status;// "Success for first loading mast Customer" + iRowCount+ "  Record";
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("ERROR: LoadFirstonlinetomastCustomers(): " + ex.Message, "I", "F", "C");
                return "Failed";
            }

        }
        public void BackuptableCust()
        {
            // Truncate  table `mastcustomers_bk`
            // Copy table  `mastcustomers` to `mastcustomers_bk`
            try
            {
                // Loop List to Laod
                DBConn objDB = new DBConn();
                string strEx = "";
                string strSQL = "truncate table `mastcustomers_bk`";
                strEx= objDB.ExcuteSQL("BackuptableCust",strSQL);
                strSQL = "INSERT INTO `mastcustomers_bk` select * FROM `mastcustomers` ";
                strEx= objDB.ExcuteSQL("BackuptableCust", strSQL);
                strSQL = "truncate table  `mastcustomers`";
                strEx = objDB.ExcuteSQL("BackuptableCust", strSQL);
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog(ex.Message, "I", "F", "C");
            }

        }
        public void RollbacktableCust()
        {
            // Truncate  table `mastcustomers`
            // Copy table `mastcustomers_bk`   to  `mastcustomers`            
            try
            {
                // Loop List to Laod
                DBConn objDB = new DBConn();
                string SteExcc;
                string strSQL = "delete  from  `mastcustomers`";
                SteExcc = objDB.ExcuteSQL("RollbacktableCust",strSQL);
                strSQL = " INSERT INTO `mastcustomers`  Select * from `mastcustomers_bk`";
                SteExcc = objDB.ExcuteSQL("RollbacktableCust",strSQL);
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog(ex.Message, "I", "F", "C");
            }
        }

        public DataTable GetTDCustomer()
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = @"SELECT `mastcustomers`.`custid`,
                            `mastcustomers`.`custname`,
                            `mastcustomers`.`custaddr1`,
                            `mastcustomers`.`custaddr2`,
                            `mastcustomers`.`custaddr3`,
                            `mastcustomers`.`province`,
                            `mastcustomers`.`phonenum`,
                            `mastcustomers`.`faxnum`,
                            `mastcustomers`.`postcode`,
                            `mastcustomers`.`branchnum`,
                            `mastcustomers`.`taxcode`,
                            `mastcustomers`.`debtortype`,
                            `mastcustomers`.`custgroup`,
                            `mastcustomers`.`custtype`,
                            `mastcustomers`.`custzone`,
                            `mastcustomers`.`divisioncode`,
                            `mastcustomers`.`selarea`,
                            `mastcustomers`.`selid`,
                            `mastcustomers`.`paidperiod`,
                            `mastcustomers`.`creditbalance`
                        FROM `mastcustomers`";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Export mastcustomers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetTDCustomer:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        public DataTable GetTDNewCustomerbyChn( string Chanel)
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = "";
              
                SQL = @"SELECT  `custid`,
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
                        `creditbalance`
                        FROM `newcustomer`  where `custid` LIKE '%" + Chanel.ToUpper() + @"%' ;";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Export New customers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetTDNewCustomer:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        public DataTable GetTDNewCustomer()
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = "";
                //SQL = @"select distinct `orderchanel` as `custid`,`custname`,`custaddr1`,`custaddr2`,`custaddr3`,`province`,trim(replace(`phonenum`,'66','')) as`phonenum`
                //                ,`faxnum`,`postcode`,`branchnum`,`taxcode`,`debtortype`,`custgroup`
                //                ,`custtype`,`custzone`,`divisioncode`,`selarea`,`selid`,`paidperiod`,`creditbalance`
                //                from  `custinorders_Temp` 
                //                where  `trnsid` not in ( 
		              //                             select DISTINCT `trnsid` from (
						          //                      select `trnsid`from  `custinorders_Temp` 
						          //                      where  trim(replace(`phonenum`,'66','')) in (select distinct trim(`phonenum`) from `mastcustomers`)
						          //                      UNION ALL
						          //                      select `trnsid`
						          //                      from  `custinorders_Temp` 
						          //                      where  trim(`custname`) in  (select distinct trim(`custname`) from `mastcustomers`) 
						          //                      and trim(replace(`phonenum`,'66','')) in (select distinct trim(`phonenum`) from `mastcustomers`)
			             //                            ) as OldCust
		              //                        )";

                SQL = @"SELECT  `custid`,
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
                        `creditbalance`
                        FROM `newcustomer`;";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Export New customers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetTDNewCustomer:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        public DataTable GetMastCustomer(string iCustID)
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = "";


                SQL = @"SELECT `custid`,`custname`,`custaddr1`,`custaddr2`,`custaddr3`,`province`,`phonenum`,`faxnum`,`postcode`,`branchnum`
                        ,`taxcode`,`debtortype`,`custgroup`,`custtype`,`custzone`,`divisioncode`,`selarea`,`selid`,`paidperiod`,`creditbalance`
                         FROM `mastcustomers` 
                         where  `custid` = '" + iCustID + "' ;";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

                //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                //objlog.DataLog("Export New customers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetMastCustomer():" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }

        public DataTable GetOneTDGrayCustomer(string iransID)
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = "";


                SQL = @"SELECT Distinct CONCAT(`isNewCust`,' Matched Existing') as `Double Click to Check` , 
                        case when `isNewCust` = 'ChkPhone' then ( SELECT c.`custid`  FROM `mastcustomers` c where RIGHT(TRIM(`c`.`phonenum`),10) = RIGHT(TRIM(`t`.`phonenum`),10) and LEFT(c.`custid`,5)  like left(t.`orderchanel`,5) limit 1)
                         when `isNewCust` = 'ChkName' then ( SELECT c.`custid`  FROM `mastcustomers`  c where replace(TRIM(`c`.`custname`),' ','') = replace(TRIM(`t`.`custname`),' ','')  and LEFT(c.`custid`,5)  like left(t.`orderchanel`,5) limit 1 )
                        else `custid` end as `Matching to Bplus CustId`
                        ,  case when `isNewCust` = 'Existing' then `custid` else '' end as `To be New CustId`, 
                        `custname`,
                        `phonenum`,
                        `custaddr1`,
                        `custaddr2`,
                        `custaddr3`,
                        `province`,                       
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
                         `AddrInOrders`,`trnsid`                        
                        FROM `newcustomer_temp` t where `isNewCust` not in ( 'New','Existing')  and `trnsid` = " + iransID + " ;";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

                //LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                //objlog.DataLog("Export New customers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetOneTDGrayCustomer():" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }
        public DataTable GetTDGrayCustomer(string iorderchanel)
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
                string SQL = "";
                

                SQL = @"SELECT Distinct CONCAT(`isNewCust`,' Matched Existing') as `Double Click to Check` , 
                        case when `isNewCust` = 'ChkPhone' then ( SELECT c.`custid`  FROM `mastcustomers` c where RIGHT(TRIM(`c`.`phonenum`),10) = RIGHT(TRIM(`t`.`phonenum`),10) and LEFT(c.`custid`,5)  like left(t.`orderchanel`,5) limit 1)
                         when `isNewCust` = 'ChkName' then ( SELECT c.`custid`  FROM `mastcustomers`  c where replace(TRIM(`c`.`custname`),' ','') = replace(TRIM(`t`.`custname`),' ','')  and LEFT(c.`custid`,5)  like left(t.`orderchanel`,5) limit 1 )
                        else `custid` end as `Matching to Bplus CustId`, '' as `To be New CustId`,
                        `custname`,
                        `phonenum`,
                        `custaddr1`,
                        `custaddr2`,
                        `custaddr3`,
                        `province`,                        
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
                         `AddrInOrders`,
                         (select tt.`trnsid` FROM `newcustomer_temp` tt where tt.`custname` = t.`custname` or tt.`phonenum` = t.`phonenum`  limit 1) as `trnsid` 
                        FROM `newcustomer_temp` t where `isNewCust` not in ( 'New','Existing') and `orderchanel` Like'" + iorderchanel +"%';";

                iDt = objDB.GetDtselect(SQL);


                //ExcelManager objExl = new ExcelManager();
                //ConfigManager objCong = new ConfigManager();
                //objExl.GenExcelfromdatatable(iDt, objCong.OutputOrdersfiles);

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Export New customers Completed", "O", "S", "C");
                //return "Get for Loading Orders";
                return iDt;
            }
            catch (Exception ex)
            {

                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error  GetTDNewCustomer:" + ex.Message, "I", "F", "O");
                return new DataTable();
            }
        }



        public DataTable GetmatchPhone(string PhoneNo)
        {
            try
            {
                DataTable iDt = new DataTable();
                DBConn objDB = new DBConn();
               // string SQL = "";


                string SQLDel = "select `custid`,`phonenum`  FROM  `mastcustomers` where `phonenum` ='" + PhoneNo + "' limit 1 ;";

                iDt = objDB.GetDtselect(SQLDel);

                return iDt;
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                return new DataTable();
            }
        }
        public string UpdateAllGraytoExistingID( string iChanel)
        {
            string Status;

            try
            {
                Status = "";
                string SQLUpdate = "";
                // string SQLDel = "";
                DBConn onjDB = new DBConn();

                SQLUpdate = @"UPDATE `newcustomer_temp` o
                             , (SELECT case when `isNewCust` = 'ChkPhone' then(SELECT c.`custid`  FROM `mastcustomers` c where RIGHT(TRIM(`c`.`phonenum`), 10) = RIGHT(TRIM(`t`.`phonenum`), 10) and LEFT(c.`custid`, 5)  like left(t.`orderchanel`, 5) limit 1)
                                 when `isNewCust` = 'ChkName' then(SELECT c.`custid`  FROM `mastcustomers`  c where replace(TRIM(`c`.`custname`), ' ', '') = replace(TRIM(`t`.`custname`), ' ', '')  and LEFT(c.`custid`, 5)  like left(t.`orderchanel`, 5) limit 1)
                                 else `custid` end as `BplusCustId`, `trnsid`,`orderchanel`
                                 FROM `epndb`.`newcustomer_temp` t
                                where `isNewCust` not in ('New', 'Existing')
                                and upper(`orderchanel`)= '" + iChanel.ToUpper() + @"'
					          ) nc

                     set o.`custid` = nc.`BplusCustId`,o.`isNewCust`= 'Existing'
                     where o.`trnsid` = nc.`trnsid` 
                    and o.`orderchanel`= nc.`orderchanel`  
                     and upper(o.`orderchanel`)= '" + iChanel.ToUpper() + "'";

                
                Status = onjDB.ExcuteSQL("UpdateTempCustomerID", SQLUpdate);

                SQLUpdate = @" update `custinorders_Temp` o ,`newcustomer_temp` nc
                         set o.custid = nc.custid,o.`isNewCust`= nc.`isNewCust`
                         where o.trnsid = nc.trnsid and o.`orderchanel`= nc.`orderchanel` and o.`orderchanel` like '" + iChanel.ToUpper() + "%';";
                Status = onjDB.ExcuteSQL("UpdateCustIDNewCust", SQLUpdate);

                return Status;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error UpdateAllGraytoExistingID():" + ex.Message, "I", "F", "O");
                return "";
            }
        }

        public string UpdateTemptoExistingID(string icustid, string iPhonText,string strChanel,string CheckOption,string iChanel)
        {
            string Status;

            try
            {
                Status = "";
                string SQLUpdate = "";
               // string SQLDel = "";

                DBConn onjDB = new DBConn();
                if (CheckOption == "ChkPhone")
                {
                    SQLUpdate = "Update newcustomer_temp set  `custid`=  '" + icustid + "' , `isNewCust` ='Existing' where `phonenum` = '" + iPhonText + "' and `isNewCust` = 'ChkPhone';";
                   // SQLDel = "delete from newcustomer_temp  where `custname` = '" + iPhonText + "' and `isNewCust` = 'New';";
                }

                if (CheckOption == "ChkName")
                {
                    SQLUpdate = "Update newcustomer_temp set  `custid`=  '" + icustid + "' , `isNewCust` ='Existing' where `custname` = '" + iPhonText + "' and `isNewCust` = 'ChkName';";
                  //  SQLDel = "delete from newcustomer_temp  where `custname` = '" + iPhonText + "' and `isNewCust` = 'New';";
                }

                Status = onjDB.ExcuteSQL("UpdateTempCustomerID", SQLUpdate);

                SQLUpdate = @" update `custinorders_Temp` o ,`newcustomer_temp` nc
                         set o.custid = nc.custid,o.`isNewCust`= nc.`isNewCust`
                         where o.trnsid = nc.trnsid and o.`orderchanel`= nc.`orderchanel` and o.`orderchanel` like '" + iChanel + "%';";
                Status = onjDB.ExcuteSQL("UpdateCustIDNewCust", SQLUpdate);


                // Status = onjDB.ExcuteSQL("UpdateTempCustomerID", SQLDel);


                //TempOrders iTempOrders = new TempOrders();
                //    Status = iTempOrders.GenCustID(strChanel);
                //    Status = iTempOrders.InsertNewCust(strChanel);

                //    // GenCustID
                //    string strStatus;
                //    TempOrders objTempOder = new TempOrders();
                //    strStatus = objTempOder.UpdateCustIDInOrderTemp(strChanel.ToUpper());

                //    strStatus = objTempOder.LoadOdersfromOrderTem(strChanel.ToUpper());

                return Status;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error UpdateCustomer to be Existing Cust ID:" + ex.Message, "I", "F", "O");
                return "";
            }
        }

        public string UpdateTempCustomerID(string icustid,string iPhonText)
        {
            string Status;

            try
            {
                Status = "";

                DBConn onjDB = new DBConn();
                string SQLDel = "Update newcustomer_temp set  `custid`=  '" + icustid + "' , `isNewCust` ='Existing' where `phonenum` = '" + iPhonText + "' and `isNewCust` = 'ChkPhone';";

                Status = onjDB.ExcuteSQL("UpdateTempCustomerID", SQLDel);


                return Status;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error UpdateCustomerfromOrder:" + ex.Message, "I", "F", "O");
                return "";
            }
        }

        public string UpdateCustomerfromOrder()
        {
            string Status;

            try
            {
                Status = "";

                DBConn onjDB = new DBConn();
                string SQLDel = "select *  FROM  `mastcustomers`";

                Status = onjDB.ExcuteSQL("UpdateCustomerfromOrder", SQLDel);


                return Status;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error UpdateCustomerfromOrder:" + ex.Message, "I", "F", "O");
                return "";
            }
        }


        public string ClearCustomer()
        {
            string Status;

            try
            {
                Status = "";

                DBConn onjDB = new DBConn();
                string SQLDel = "delet  FROM  `mastcustomers`";
                Status = onjDB.ExcuteSQL("ClearCustomer",SQLDel);
                return Status;
            }
            catch (Exception ex)
            {
                LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                objlog.DataLog("Error ClearCustomer:" + ex.Message, "I", "F", "O");
                return "";
            }
        }


    }
}
