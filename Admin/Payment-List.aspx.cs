using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSMS.Codes;

namespace WSMS.Admin
{
    public partial class Payment_List : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCharges();
        }

        private void GetCharges()
        {
            string sqlquery = "Select * From tbl_Payment";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            repeat.DataSource = data;
            repeat.DataBind();
            con.Close();
        }

        protected void btn_Details_ServerClick(object sender, EventArgs e)
        {

        }
    }
}