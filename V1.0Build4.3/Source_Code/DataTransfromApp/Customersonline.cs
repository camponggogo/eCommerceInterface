using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace eCommerceInterfaceApp
{
    class Customersonline
    {
        public DataTable Custonlinetable;// = new DataTable();
        public string custid; //	0
        public string custname; //	1
        public string orgname; //	2
        public string branchnum; //	3
        public string debtorID; //	4
        public string custaddr1; //	5
        public string custaddr2; //	6
        public string custaddr3; //	7
        public string custzone; //	8
        public string postcode; //	9
        public string phonenum; //	10
        public string faxnum; //	11
        public string business; //	12
        public string Status; //	13
        public string Email;  //	14
        public string HomePage; //	15
        public string debtorTyp; //	16

        public Customersonline()
        {
            Custonlinetable = new DataTable();
            Custonlinetable.Columns.Add("custid", typeof(string));
            Custonlinetable.Columns.Add("custname", typeof(string));
            Custonlinetable.Columns.Add("orgname", typeof(string));
            Custonlinetable.Columns.Add("branchnum", typeof(string));
            Custonlinetable.Columns.Add("debtorID", typeof(string));
            Custonlinetable.Columns.Add("custaddr1", typeof(string));
            Custonlinetable.Columns.Add("custaddr2", typeof(string));
            Custonlinetable.Columns.Add("custaddr3", typeof(string));
            Custonlinetable.Columns.Add("custzone", typeof(string));
            Custonlinetable.Columns.Add("postcode", typeof(string));
            Custonlinetable.Columns.Add("phonenum", typeof(string));
            Custonlinetable.Columns.Add("faxnum", typeof(string));
            Custonlinetable.Columns.Add("business", typeof(string));
            Custonlinetable.Columns.Add("Status", typeof(string));
            Custonlinetable.Columns.Add("Email", typeof(string));
            Custonlinetable.Columns.Add("HomePage", typeof(string));
            Custonlinetable.Columns.Add("debtorTyp", typeof(string));
        }


    }
}
