using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace eCommerceInterfaceApp
{
    class ConfigManager
    {

        public string InCustFolder = ConfigurationManager.AppSettings["CutFolder"];
        public string InOrdersFolder = ConfigurationManager.AppSettings["OrdersFolder"];
        public string ProductsFolder = ConfigurationManager.AppSettings["ProductsFolder"];

        public string BackupFolder = ConfigurationManager.AppSettings["BackupFolder"];
        public string OutputFolder = ConfigurationManager.AppSettings["OutputFolder"];
        public string OutputOrdersfiles = ConfigurationManager.AppSettings["OutputOrdersfile"];
        public string ReportOrdersDailySummary = ConfigurationManager.AppSettings["ReportOrdersDailySummary"];
        
        public string OutputCustomerfiles = ConfigurationManager.AppSettings["OutputCustomersfiles"];
        public string OutputGrayCustomerfiles = ConfigurationManager.AppSettings["OutputGrayCustomerfiles"];
        public string systemLogFolder = ConfigurationManager.AppSettings["systemLogFolder"];
        public string FlagExportAllOnStop = ConfigurationManager.AppSettings["ExportAllOnStop"];
        public Double TiemtoDelay = Convert.ToDouble(ConfigurationManager.AppSettings["Delay"].ToString());
        public string EnbleEditCustmer = ConfigurationManager.AppSettings["EnbleEditCustmer"];
        public string EnbleShowData = ConfigurationManager.AppSettings["EnbleShowData"];
        public List<string> GetCustFilesNames()
        {
            string CustFileCong = AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigurationManager.AppSettings["CustMapList"];
            // int Imax = GetMAXListFiles(CustFileCong);
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            try
            {
                LisFiles = GetListFilesName(CustFileCong);
                return LisFiles;
            }
            catch (Exception)
            {
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }
        public List<string> GetProdFilesNames()
        {
            string ProdFileCong = AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigurationManager.AppSettings["ProductsMapList"];
            // int Imax = GetMAXListFiles(CustFileCong);
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            try
            {
                LisFiles = GetListFilesName(ProdFileCong);
                return LisFiles;
            }
            catch (Exception)
            {
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }
        public List<string> GetDisCountFilesNames()
        {
            string ProdFileCong = AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigurationManager.AppSettings["ProductsMapList"];
            // int Imax = GetMAXListFiles(CustFileCong);
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            try
            {
                LisFiles = GetListFilesName(ProdFileCong);
                return LisFiles;
            }
            catch (Exception)
            {
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }
        public List<string> GetOderFilesNames()
        {
            string CustFileCong = AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfigurationManager.AppSettings["OdersMapList"];
            //int Imax = GetMAXListFiles(CustFileCong);
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            try
            {
                LisFiles = GetListFilesName(CustFileCong);
                return LisFiles;
            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog(ex.Message);
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }



        // Get List Files Name
        private List<string> GetListFilesName(string ConfFIleName)
        {
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            try
            {
                string filepath = ConfFIleName;// AppDomain.CurrentDomain.BaseDirectory + "\\Config\\" + ConfFIleName;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.SystemLog("Error File Config Not found");
                }
                else
                {
                    // for(int i = 0; i < MAXFiles; i++)
                    // {
                    //LisFiles[i] = new List<string>();

                    foreach (string line in File.ReadLines(filepath))
                    {
                        // Printing the file contents 
                        // Console.WriteLine(line);
                        int iLen = line.Length;
                        if (line.Contains(".xl") || line.Contains(".csv"))
                        {
                            //int iMax = Int32.Parse(line.Trim().Substring(1, 1));
                            LisFiles.Add(line);
                        };
                    }
                    //}
                    // if (LisFiles.Count != MAXFiles) ;// Failed List Error ;
                }

                return LisFiles;

            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog(ex.Message);
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }
        // Get Max Files
        private int GetMAXListFiles(string ConfFIleName)
        {
            try
            {
                int iMax = 0, iLen = 0;
                string filepath = ConfFIleName; //AppDomain.CurrentDomain.BaseDirectory + "\\Config\\" + ConfFIleName;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.SystemLog("Error File Config Not found");
                }
                else
                {
                    foreach (string line in File.ReadLines(filepath))
                    {
                        // Printing the file contents 
                        // Console.WriteLine(line);
                        iLen = line.Length;
                        if (line.Contains("MAXFILE"))
                        {
                            iMax = Int32.Parse(line.Trim().Substring(iLen - 1, 1));
                        };

                    }
                }

                return iMax;
            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog(ex.Message);
                return 0;
                // MessageBox.Show(ex.Message);
            }
        }

        public List<string> GetOrderMapping(string KeyOption, string ConfFIleName)
        {
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            //  KeyOption = "SKIP_HEADER";  //  cehck Skip Header or Not;
            //  KeyOption = "MAPPING"; //  Get Mapping List Not;
            try
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfFIleName;
                // filepath = ConfFIleName;// AppDomain.CurrentDomain.BaseDirectory + "\\Config\\" + ConfFIleName;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.SystemLog("Error File Config Not found");
                }
                else
                {
                    // for(int i = 0; i < MAXFiles; i++)
                    // {
                    //LisFiles[i] = new List<string>();
                    int i = 0;
                    foreach (string line in File.ReadLines(filepath))
                    {
                        i++;
                        // Printing the file contents 
                        // Console.WriteLine(line);
                        int iLen = line.Length;
                        if (KeyOption == "SKIP_HEADER")
                        {
                            if (line.Contains("SKIP_HEADER"))
                            {
                                LisFiles.Add(line);
                            };
                        };
                        if (KeyOption == "MAPPING" && i > 3)
                        {
                            if (line.Contains("|"))
                            {
                                LisFiles.Add(line);
                            };
                        };
                    }
                    //}
                    // if (LisFiles.Count != MAXFiles) ;// Failed List Error ;
                }

                return LisFiles;

            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog(ex.Message);
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }

        public List<string> GetTempOrderMapping(string KeyOption, string ConfFIleName)
        {
            List<string> LisFiles = new List<string>();
            //list[0] = new List<string>();
            //  KeyOption = "SKIP_HEADER";  //  cehck Skip Header or Not;
            //  KeyOption = "MAPPING"; //  Get Mapping List Not;
            try
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "Config\\" + ConfFIleName;
                // filepath = ConfFIleName;// AppDomain.CurrentDomain.BaseDirectory + "\\Config\\" + ConfFIleName;
                if (!File.Exists(filepath))
                {
                    LogTextManager objlog = new LogTextManager();// WriteTexttLog();                                                               
                    objlog.SystemLog("Error File Config Not found");
                }
                else
                {
                    // for(int i = 0; i < MAXFiles; i++)
                    // {
                    //LisFiles[i] = new List<string>();
                    int i = 0;
                    foreach (string line in File.ReadLines(filepath))
                    {
                        i++;
                        // Printing the file contents 
                        // Console.WriteLine(line);
                        int iLen = line.Length;
                        if (KeyOption == "SKIP_HEADER")
                        {
                            if (line.Contains("SKIP_HEADER"))
                            {
                                LisFiles.Add(line);
                            };
                        };
                        if (KeyOption == "MAPPING" && i > 3)
                        {
                            if (line.Contains("|"))
                            {
                                LisFiles.Add(line);
                            };
                        };
                    }
                    //}
                    // if (LisFiles.Count != MAXFiles) ;// Failed List Error ;
                }

                return LisFiles;

            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog(ex.Message);
                return new List<string>(); ;
                // MessageBox.Show(ex.Message);
            }
        }

    }
}
