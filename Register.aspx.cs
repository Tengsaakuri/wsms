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
    public partial class Register : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();
        protected void Page_Load(object sender, EventArgs e)
        {
            success_msg.Visible = false;
            error_msg.Visible = false;
        }

        protected void btn_Register_ServerClick(object sender, EventArgs e)
        {
            string sqlquery = "SELECT * FROM [tbl_User]" +
               " WHERE _Role = @Role";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Role", "Admin");
            con.Close();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                error_Label.Text = "Admin already exist! <strong>Login instead</strong>";
                error_msg.Visible = true;
                txt_Username.Text = "";
                First_Name.Text = "";
                Last_Name.Text = "";
                ddl_Gender.SelectedIndex = 0;
                txt_Phone.Text = "";
                txt_Email.Text = "";
                txt_Password.Text = "";
                return;
            }
            else
            {
                if (txt_Username.Text == "")
                {
                    error_Label.Text = "Enter username";
                    error_msg.Visible = true;
                    return;
                }
                if (First_Name.Text == "")
                {
                    error_Label.Text = "Enter first name";
                    error_msg.Visible = true;
                    return;
                }
                if (Last_Name.Text == "")
                {
                    error_Label.Text = "Enter last name";
                    error_msg.Visible = true;
                    return;
                }
                if (ddl_Gender.SelectedIndex == 0)
                {
                    error_Label.Text = "Select gender";
                    error_msg.Visible = true;
                    return;
                }
                if (txt_Password.Text == "")
                {
                    error_Label.Text = "Enter password";
                    error_msg.Visible = true;
                    txt_Password.Text = "";
                    txt_Password.Focus();
                    return;
                }
                if (txt_Confirm.Text == "")
                {
                    error_Label.Text = "Confirm password";
                    error_msg.Visible = true;
                    txt_Password.Text = "";
                    txt_Password.Focus();
                    return;
                }
                if (!txt_Password.Text.Equals(txt_Confirm.Text))
                {
                    error_Label.Text = "Passwords don not match";
                    error_msg.Visible = true;
                    txt_Password.Text = "";
                    txt_Password.Focus();
                    return;
                }
                else
                {
                    string encryptpass = EncryptionDecryption.Encrypt(txt_Password.Text);
                    try
                    {
                        SqlCommand com = new SqlCommand("[dbo].[insertUser]", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Username", txt_Username.Text);
                        com.Parameters.AddWithValue("@First_Name", First_Name.Text);
                        com.Parameters.AddWithValue("@Last_Name", Last_Name.Text);
                        com.Parameters.AddWithValue("@Gender", ddl_Gender.Text);
                        com.Parameters.AddWithValue("@Number", txt_Phone.Text);
                        com.Parameters.AddWithValue("@Email", txt_Email.Text);
                        com.Parameters.AddWithValue("@Role", "Admin");
                        com.Parameters.AddWithValue("@Password", encryptpass);
                        con.Close();
                        con.Open();
                        int i = com.ExecuteNonQuery();
                        if (i == 1)
                        {
                            success_Label.Text = "Customer saved successfully.";
                            success_msg.Visible = true;
                            txt_Username.Text = "";
                            First_Name.Text = "";
                            Last_Name.Text = "";
                            ddl_Gender.SelectedIndex = 0;
                            txt_Phone.Text = "";
                            txt_Email.Text = "";
                            txt_Password.Text = "";
                            con.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.StackTrace + ex.Message);
                    }
                }              
            }           
        }
    }
}