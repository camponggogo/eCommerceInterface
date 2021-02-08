using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace eCommerceInterfaceApp
{
    class LogTextManager
    {


        public void SystemLog(string Message)
        {
            try
            {
                ConfigManager objCofig = new ConfigManager();
                // Check File are exsiting then let start
                string filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.systemLogFolder;  //"\\System";
                Message = DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ":" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": " + Message;

                // string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                //filepath = StrFullFileName; // AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                //string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Logformanual_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                // string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + StrlogName +"_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') +"_"+ DateTime.Now.TimeOfDay.ToString().Substring(0,8).Replace(":", "") + ".txt";
                filepath = filepath + @"\Servcielog.txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    // AppendText a file to write to. 
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("System Error: Write SystemLog :" + ex.Message,
                               "ERROR",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
                return;
               
            }

        }
        public void DataLog(string Message, string InOROut, string SuccORFail, string CustOrOrders)
        {
            try
            {
                ConfigManager objCofig = new ConfigManager();
                string filepath = "";
                // Check File are In or Out then let start
                //  InOROut : I = Input Folder ,O = Output Folder
                if (InOROut == "I")
                {
                    //  CustOrOrders :C = Input Customer Folder ,O = Output Folder        
                    if (CustOrOrders == "C")
                    {
                        filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder;  //"\\System";
                    };
                    if (CustOrOrders == "O")
                    {
                        filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder;  //"\\System";
                    };
                    if (CustOrOrders == "P")
                    {
                        filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.ProductsFolder;  //"\\System";
                    };
                };
                if (InOROut == "O")
                {
                    filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.OutputFolder;
                };
                // Check Fail or Completed then let start
                //  SuccORFail : S = Log to Success ,F =Log to Failed
                string FIleTail = DateTime.Now.ToString("yyyy-MM-dd");
                if (SuccORFail == "S")
                {
                    filepath = filepath + "\\Sucess_" + FIleTail + ".txt"; // + "_" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8).Replace(":", "") + ".txt"; 
                }
                if (SuccORFail == "F")
                {
                    filepath = filepath + "\\Failed_" + FIleTail + ".txt"; //+ "_" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8).Replace(":", "") + ".txt"; 

                };

                Message = DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ":" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": " + Message;

                // string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                // filepath = StrFullFileName; // AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                //if (!Directory.Exists(filepath))
                //{
                //    Directory.CreateDirectory(filepath);
                //}
                //string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Logformanual_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                // string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + StrlogName +"_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') +"_"+ DateTime.Now.TimeOfDay.ToString().Substring(0,8).Replace(":", "") + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    // AppendText a file to write to. 
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: Write DataLog :" + ex.Message,
                              "ERROR",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1);
                return;
                // MessageBox.Show(ex.Message);
            }

        }

        public void FailedDataLog(string Message, string InOROut, string SuccORFail, string CustOrOrders)
        {
            try
            {
                ConfigManager objCofig = new ConfigManager();
                string filepath = "";
                // Check File are In or Out then let start
                //  InOROut : I = Input Folder ,O = Output Folder
                string FileTail = DateTime.Now.ToString("yyyy-MM-dd");
                if (InOROut == "I")
                {
                    //  CustOrOrders :C = Input Customer Folder ,O = Output Folder        
                    if (CustOrOrders == "C")
                    {
                        filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InCustFolder;  //"\\System";
                    };
                    if (CustOrOrders == "O")
                    {
                        filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.InOrdersFolder;  //"\\System";
                    };

                };
                if (InOROut == "O")
                {
                    filepath = AppDomain.CurrentDomain.BaseDirectory + objCofig.OutputFolder;
                };
                // Check Fail or Completed then let start
                //  SuccORFail : S = Log to Success ,F =Log to Failed
                if (SuccORFail == "S")
                {
                    filepath = filepath + "\\DataSucess_" + FileTail  + ".CSV"; // + "_" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8).Replace(":", "") + ".txt"; 
                }
                if (SuccORFail == "F")
                {
                    filepath = filepath + "\\DataFailed_" + FileTail + ".CSV"; //+ "_" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8).Replace(":", "") + ".txt"; 

                };

               // Message = DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ":" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": " + Message;
              

                // string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                // filepath = StrFullFileName; // AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                //if (!Directory.Exists(filepath))
                //{
                //    Directory.CreateDirectory(filepath);
                //}
                //string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Logformanual_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                // string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + StrlogName +"_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') +"_"+ DateTime.Now.TimeOfDay.ToString().Substring(0,8).Replace(":", "") + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    // AppendText a file to write to. 
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: Write FailedDataLog :" + ex.Message,
                               "ERROR",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
                return;
                // MessageBox.Show(ex.Message);
            }

        }

        //public void WriteToLogFile(string Message)
        //{
        //    string path = AppDomain.CurrentDomain.BaseDirectory + "\\System";
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\System\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
        //    if (!File.Exists(filepath))
        //    {
        //        // Create a file to write to. 
        //        using (StreamWriter sw = File.CreateText(filepath))
        //        {
        //            sw.WriteLine(Message);
        //        }
        //    }
        //    else
        //    {
        //        using (StreamWriter sw = File.AppendText(filepath))
        //        {
        //            sw.WriteLine(Message);
        //        }
        //    }
        //}

        //private void WriteTexttLog(string Message,string StrFullFileName)
        //{
        //    try
        //    {
        //        Message = DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ":" + DateTime.Now.TimeOfDay.ToString().Substring(0, 8) + ": " + Message;

        //        // string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        //        string filepath = StrFullFileName; // AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        //        if (!Directory.Exists(filepath))
        //        {
        //            Directory.CreateDirectory(filepath);
        //        }
        //        //string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Logformanual_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
        //        // string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + StrlogName +"_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') +"_"+ DateTime.Now.TimeOfDay.ToString().Substring(0,8).Replace(":", "") + ".txt";
        //        if (!File.Exists(filepath))
        //        {
        //            // Create a file to write to. 
        //            using (StreamWriter sw = File.CreateText(filepath))
        //            {
        //                sw.WriteLine(Message);
        //            }
        //        }
        //        else
        //        {
        //            using (StreamWriter sw = File.AppendText(filepath))
        //            {
        //                sw.WriteLine(Message);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
        //        sobjlog.SystemLog(ex.Message);
        //        return ;
        //       // MessageBox.Show(ex.Message);
        //    }


        //}

    }
}
