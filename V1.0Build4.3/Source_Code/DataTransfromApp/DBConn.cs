using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace eCommerceInterfaceApp
{
    class DBConn
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private readonly string password;


        //Constructor
        public DBConn()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
            //server = "localhost";
            //database = "dbcompong";
            //uid = "sysdba";
            //password = "xsw@1qaZ1234!";           
            //connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }



        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        LogTextManager objlog = new LogTextManager();// WriteTexttLog(); 
                        objlog.DataLog("Cannot connect to server.Contact administrator", "I", "S", "O");
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                        sobjlog.DataLog("Invalid username / password, please try again", "I", "S", "O");
                        // MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                // MessageBox.Show(ex.Message);
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog("System Error: CloseConnection." + ex.Message);
                return false;
            }
        }

        // ExcuteNonQuery
        public string ExcuteSQL(string FunctionName,string CommandSQL)
        {
            string strReturn = "";
            try
            {
                // string CommandSQL = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(CommandSQL, connection);

                    //Execute command
                    int x = cmd.ExecuteNonQuery();
                    strReturn = "Success";// + x.ToString();

                    //close connection
                    this.CloseConnection();
                }
                return strReturn;
            }
            catch (Exception ex)
            {
                this.CloseConnection();
             
                LogTextManager objlog = new LogTextManager();// WriteTexttLog();
                // MessageBox.Show(ex.Message);
                objlog.SystemLog("System Error: ExcuteSQL." + ex.Message);
                strReturn = "*** Error:" + FunctionName + ex.Message;

                //MessageBox.Show("System Error: ExcuteSQL." + ex.Message,
                //  "ERROR",
                //  MessageBoxButtons.OK,
                //  MessageBoxIcon.Error,
                //  MessageBoxDefaultButton.Button1);

                return strReturn;
            }
        }



        public DataTable GetDtselect(string SQL)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                MySqlDataAdapter returnVal = new MySqlDataAdapter(SQL, connection);
                DataTable dt = new DataTable("CharacterInfo");
                returnVal.Fill(dt);
                this.CloseConnection();
                return dt;
            }
            catch (Exception ex)
            {
                LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
                sobjlog.SystemLog("System Error: GetDtselect." + ex.Message);
                
                MessageBox.Show("System Error: GetDtselect." + ex.Message,
                                  "ERROR",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error,
                                  MessageBoxDefaultButton.Button1);
                return new DataTable();
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.OpenConnection() == true) this.CloseConnection(); ;
            }
        }


        ////public List<string>[] querySelect(string query)
        ////{
        ////    // string query = "SELECT * FROM mastcustomers";

        ////    //Create a list to store the result
        ////    List<string>[] list = new List<string>[3];
        ////    //list[0] = new List<string>();
        ////    //list[1] = new List<string>();
        ////    //list[2] = new List<string>();

        ////    //Open connection
        ////    if (this.OpenConnection() == true)
        ////    {
        ////        //Create Command
        ////        MySqlCommand cmd = new MySqlCommand(query, connection);
        ////        //Create a data reader and Execute the command
        ////        MySqlDataReader dataReader = cmd.ExecuteReader();

        ////        if (dataReader.FieldCount > 0)
        ////        {

        ////            for (int i = 0; i < dataReader.FieldCount; i++)
        ////            {
        ////                list[i] = new List<string>();
        ////            }

        ////            while (dataReader.Read())
        ////            {
        ////                for (var j = 0; j < list.Count(); j++)
        ////                {
        ////                    // Console.WriteLine("Amount is {0} and type is {1}", myMoney[i].amount, myMoney[i].type);
        ////                    list[j].Add(dataReader[j] + "");

        ////                }
        ////            }
        ////        }

        ////        //Read the data and store them in the list
        ////        //while (dataReader.Read())
        ////        //{
        ////        //    list[0].Add(dataReader["custid"] + "");
        ////        //    list[1].Add(dataReader["custname"] + "");
        ////        //    list[2].Add(dataReader["phonenum"] + "");
        ////        //}



        ////        //close Data Reader
        ////        dataReader.Close();

        ////        //close Connection
        ////        this.CloseConnection();

        ////        //return list to be displayed
        ////        return list;
        ////    }
        ////    else
        ////    {
        ////        return list;
        ////    }
        ////}
        ///
        //////Backup
        ////public void Backup()
        ////{
        ////    try
        ////    {
        ////        DateTime Time = DateTime.Now;
        ////        int year = Time.Year;
        ////        int month = Time.Month;
        ////        int day = Time.Day;
        ////        int hour = Time.Hour;
        ////        int minute = Time.Minute;
        ////        int second = Time.Second;
        ////        int millisecond = Time.Millisecond;

        ////        //Save file to C:\ with the current date as a filename
        ////        string path;
        ////        path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
        ////        StreamWriter file = new StreamWriter(path);


        ////        ProcessStartInfo psi = new ProcessStartInfo();
        ////        psi.FileName = "mysqldump";
        ////        psi.RedirectStandardInput = false;
        ////        psi.RedirectStandardOutput = true;
        ////        psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
        ////        psi.UseShellExecute = false;

        ////        Process process = Process.Start(psi);

        ////        string output;
        ////        output = process.StandardOutput.ReadToEnd();
        ////        file.WriteLine(output);
        ////        process.WaitForExit();
        ////        file.Close();
        ////        process.Close();
        ////    }
        ////    catch (IOException ex)
        ////    {
        ////        // MessageBox.Show("Error , unable to backup!");
        ////        LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
        ////        sobjlog.SystemLog(ex.Message);
        ////    }
        ////}

        //////Restore
        ////public void Restore()
        ////{
        ////    try
        ////    {
        ////        //Read file from C:\
        ////        string path;
        ////        path = "C:\\MySqlBackup.sql";
        ////        StreamReader file = new StreamReader(path);
        ////        string input = file.ReadToEnd();
        ////        file.Close();


        ////        ProcessStartInfo psi = new ProcessStartInfo();
        ////        psi.FileName = "mysql";
        ////        psi.RedirectStandardInput = true;
        ////        psi.RedirectStandardOutput = false;
        ////        psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
        ////        psi.UseShellExecute = false;


        ////        Process process = Process.Start(psi);
        ////        process.StandardInput.WriteLine(input);
        ////        process.StandardInput.Close();
        ////        process.WaitForExit();
        ////        process.Close();
        ////    }
        ////    catch (IOException ex)
        ////    {
        ////        // MessageBox.Show("Error , unable to Restore!");
        ////        LogTextManager sobjlog = new LogTextManager();// WriteTexttLog(); 
        ////        sobjlog.SystemLog(ex.Message);
        ////    }
        ////}





        // //This is my connection string i have assigned the database file address path
        // string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";
        // //This is my insert query in which i am taking input from the user through windows forms
        // string Query = "insert into student.studentinfo(idStudentInfo,Name,Father_Name,Age,Semester) values('" +this.IdTextBox.Text+ "','" +this.NameTextBox.Text+ "','" +this.FnameTextBox.Text+ "','" +this.AgeTextBox.Text+ "','" +this.SemesterTextBox.Text+ "');";
        // //This is  MySqlConnection here i have created the object and pass my connection string.
        // MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
        ////This is command class which will handle the query and connection object.
        // MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
        // MySqlDataReader MyReader2;
        // MyConn2.Open();
        // MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
        // MessageBox.Show("Save Data");
        // while (MyReader2.Read())
        // {

        //// }
        //// MyConn2.Close();
        ////This is my connection string i have assigned the database file address path
        //string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";
        ////This is my update query in which i am taking input from the user through windows forms and update the record.
        //string Query = "update student.studentinfo set idStudentInfo='" + this.IdTextBox.Text + "',Name='" + this.NameTextBox.Text + "',Father_Name='" + this.FnameTextBox.Text + "',Age='" + this.AgeTextBox.Text + "',Semester='" + this.SemesterTextBox.Text + "' where idStudentInfo='" + this.IdTextBox.Text + "';";
        ////This is  MySqlConnection here i have created the object and pass my connection string.
        //MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
        //MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
        //MySqlDataReader MyReader2;
        //MyConn2.Open();
        //        MyReader2 = MyCommand2.ExecuteReader();
        //        MessageBox.Show("Data Updated");
        //        while (MyReader2.Read())
        //        {

        //        }
        //        MyConn2.Close();//Connection closed here

        //string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";
        //string Query = "delete from student.studentinfo where idStudentInfo='" + this.IdTextBox.Text + "';";
        //MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
        //MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
        //MySqlDataReader MyReader2;
        //MyConn2.Open();
        //MyReader2 = MyCommand2.ExecuteReader();
        //MessageBox.Show("Data Deleted");
        //while (MyReader2.Read())
        //{

        //}
        //MyConn2.Close();
    }
}
