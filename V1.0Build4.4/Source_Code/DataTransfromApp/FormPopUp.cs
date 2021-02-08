using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCommerceInterfaceApp
{
    public partial class FormPopUp : Form
    {
        public string CustTempID;
        public string CustID;
        public string iChenel;
        public FormPopUp()
        {
            InitializeComponent();
        }

        private void FormPopUp_Load(object sender, EventArgs e)
        {
           // MessageBox.Show ("CustTempID =" + CustTempID);
           // MessageBox.Show ("CustID =" + CustID);
            RebindGrayCust(CustTempID);
            RebindMasterCust(CustID);
        }

        private void RebindGrayCust(string iTransID)
        {
            try
            {

                Customers objCust = new Customers();
                DataTable dtNewCust = objCust.GetOneTDGrayCustomer(iTransID);
                this.GridCustInOrders.DataSource = dtNewCust;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RebindMasterCust(string iCustID)
        {
            try
            {

                Customers objCust = new Customers();
                DataTable dtNewCust = objCust.GetMastCustomer(iCustID);
                this.GridCustExisting.DataSource = dtNewCust;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void UpdateTemptoExistingID()
        {
            try
            {
                string iCheckOption, iPhonText;
                string iTransID = GridCustInOrders.Rows[0].Cells[23].Value.ToString();
                string iText = GridCustInOrders.Rows[0].Cells[0].Value.ToString();
              //  string iChenel = GridCustInOrders.Rows[0].Cells[0].Value.ToString();  
                string iCustID = txtExistingCustID.Text;
                DataTable iDT = new DataTable();                
                Customers iCust = new Customers();


                if (iText.Contains("Phone Matched Existing"))
                {
                    iCheckOption = "ChkPhone";
                    iPhonText = GridCustInOrders.Rows[0].Cells[4].Value.ToString();
                }
                else if (iText.Contains("Name Matched Existing"))
                {
                    iCheckOption = "ChkName";
                    iPhonText = GridCustInOrders.Rows[0].Cells[3].Value.ToString();
                }
                else
                {

                    if (iText.Contains("Existing Matched Existing"))
                    {
                        iCheckOption = "ChkPhone";
                        iPhonText = GridCustInOrders.Rows[0].Cells[4].Value.ToString();
                    }
                    else
                    {
                        return;
                    }
                }

               
                if (iCustID.Length == 0)
                {
                    MessageBox.Show("You are not key in Existing BPlus Customer ID ! " + "\n " + " Please try again.");
                    return;
                }

                iDT = iCust.GetmatchPhone(iPhonText);
                if (iDT.Rows.Count > 0)
                {
                    foreach (DataRow dr in iDT.Rows)
                    {
                        iCustID = dr[0].ToString();
                    }
                }



                DialogResult result = MessageBox.Show("This is existing customer ? :Found matched existing BPlus customer on :" + iPhonText + "\n " + "Click Yes: Update Customer ID to " + iCustID + "\n" + "No: Go to manual adjust in BPlus and Re-do all process again", "Update to be Existing Customer Information",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);


                if (result == DialogResult.Yes && iCustID != "")
                {
                   // Customers iCust = new Customers();
                    //...               
                    iCust.UpdateTemptoExistingID(iCustID, iPhonText, iChenel, iCheckOption,this.iChenel);

                    RebindMasterCust(CustTempID);
                    RebindGrayCust(CustTempID);

                    MessageBox.Show("Update to be Existing Customer Completed");
                    this.Close();

                }
                else if (iCustID == "")
                {
                    //...
                    MessageBox.Show("You are not input BPlus Customer ID ! " + "\n " + " Please try again.");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTemptoExistingID();
            this.txtExistingCustID.Text = "";
        }

        private void AddNewCustomerID(string iTransID,string Chanel)
        {
            try
            {


                 DialogResult result = MessageBox.Show("Confrime to Add New Customer ID " + "\n"  + "Yes: Save New Customer ID " +"\n"  + "No: Go to manual adjust in BPlus and Re-do all process again", "Confrimetion to Add New Customer from Oders Info.",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button2);


                if (result == DialogResult.Yes && iTransID != "")
                {
                    TempOrders iCust = new TempOrders();
                    //...               
                    iCust.AddNewCustTemp(iTransID, Chanel);

                    RebindMasterCust(iTransID);
                    RebindGrayCust(iTransID);

                    MessageBox.Show("Generate New Customer ID Completed");
                    this.Close();
                }
                else if (iTransID == "")
                {
                    //...
                    MessageBox.Show("You are not input BPlus Customer ID ! " + "\n " + " Please try again.");

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {

                AddNewCustomerID(this.CustTempID,this.iChenel);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }
