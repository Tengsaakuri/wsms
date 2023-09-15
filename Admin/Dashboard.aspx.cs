using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSMS.Codes;
using System.Data;

namespace WSMS.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCharges();
            Count();
        }

        public void Count()
        {
            SqlCommand sc = new SqlCommand("[dbo].[COUNT]", con);
            sc.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Customers.Text = dt.Rows[0]["TotalCustomer"].ToString();
                Meters.Text = dt.Rows[0]["TotalMeters"].ToString();
                Users.Text = dt.Rows[0]["TotalUsers"].ToString();
                Consumption.Text = dt.Rows[0]["TotalConsumption"].ToString();
            }

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
    }
}