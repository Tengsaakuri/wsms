using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSMS.Codes;

namespace WSMS
{
    public partial class index : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();
        protected void Page_Load(object sender, EventArgs e)
        {
            error_msg.Visible = false;
        }

        protected void btn_Login_ServerClick(object sender, EventArgs e)
        {
            string encryptpass = EncryptionDecryption.Encrypt(txt_Password.Text);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand comd = new SqlCommand("SELECT * FROM [tbl_User]" +
               " WHERE Username = @Username AND _password = @password", con);
            comd.CommandType = CommandType.Text;
            comd.Parameters.AddWithValue("@Username", txt_Id.Text);
            comd.Parameters.AddWithValue("@password", encryptpass);
            DataSet data = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(comd);
            sda.Fill(data);
            //String StaffID;
            //String Pass;
            if (data.Tables[0].Rows.Count > 0)
            {
                Session["Role"] = data.Tables[0].Rows[0]["_Role"].ToString();
                Session["Name"] = data.Tables[0].Rows[0]["First_Name"].ToString() + " " + data.Tables[0].Rows[0]["Last_Name"].ToString();

                if (Session["Role"].ToString() == "Admin")
                {
                    Response.Redirect("~/Admin/Dashboard.aspx");
                    con.Close();
                }

                if (Session["Role"].ToString() == "User")
                {
                    Response.Redirect("~/User/Dashboard");
                    con.Close();
                }
            }
            //}

            else
            {
                txt_Id.Text = "";
                txt_Password.Text = "";
                error_Label.Text = "Wrong Username or password";
                error_msg.Visible = true;
                txt_Id.Focus();
            }
        }
    }
}