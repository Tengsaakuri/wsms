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
    public partial class Meters : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            success_msg.Visible = false;
            error_msg.Visible = false;
            GetMeters();

            if (!Page.IsPostBack)
            {
                loadCategories();
                GetMeterID();
            }

        }

        public void GetMeterID()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select cast (max(cast(substring(Meter_Number, 7, 5)" +
                " as int))+1 as int) MeterNumber from tbl_Meters", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                txt_number.Text = ds.Rows[0]["MeterNumber"].ToString();
                if (txt_number.Text.Length < 2)
                {
                    txt_number.Text = "Meter-" + "10001";
                }
                else
                {
                    txt_number.Text = "Meter-" + ds.Rows[0]["MeterNumber"].ToString();
                }
                con.Close();
            }
        }

        public void loadCategories()
        {
            string sqlquery = "SELECT DISTINCT [Category] FROM [tbl_Categories]";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            cmb_Category.Items.Clear();
            cmb_Category.Items.Add("- Select One -");
            cmb_Category.DataSource = data;
            cmb_Category.DataTextField = "Category";
            cmb_Category.DataValueField = "Category";
            cmb_Category.DataBind();
            con.Close();
        }

        private void GetMeters()
        {
            string sqlquery = "[dbo].[getMeters]";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            repeat.DataSource = data;
            repeat.DataBind();
            con.Close();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string Id = ((sender as LinkButton).NamingContainer.FindControl("Id_Label") as Label).Text;
            try
            {
                con.Close();
                con.Open();
                SqlCommand comd = new SqlCommand("[dbo].[editMeter]", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", Id);
                comd.ExecuteNonQuery();
                DataTable dat = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                da.Fill(dat);
                //String Pass;
                if (dat.Rows.Count > 0)
                {
                    txt_number.Text = dat.Rows[0]["Meter_Number"].ToString();
                    cmb_Category.Text = dat.Rows[0]["Category"].ToString();
                    txt_Manu.Text = dat.Rows[0]["Manufacturer"].ToString();
                    btn_Save.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace + ex.Message);
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_number.Text == "")
            {
                txt_number.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter meter number";
                error_msg.Visible = true;
                txt_number.Focus();
                return;
            }
            if (txt_Manu.Text == "")
            {
                txt_Manu.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter meter manufacturer";
                error_msg.Visible = true;
                txt_Manu.Focus();
                return;
            }
            if (cmb_Category.SelectedIndex == 0)
            {
                cmb_Category.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "select meter category";
                error_msg.Visible = true;
                return;
            }
            else
            {
                txt_number.BorderColor = System.Drawing.Color.Empty;
                cmb_Category.BorderColor = System.Drawing.Color.Empty;
                txt_Manu.BorderColor = System.Drawing.Color.Empty;

                string choice = btn_Save.Text;

                switch (choice)
                {
                    case "Update":
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[dbo].[updateMeter]", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Number", txt_number.Text);
                            cmd.Parameters.AddWithValue("@Category", cmb_Category.Text);
                            cmd.Parameters.AddWithValue("@Manu", txt_Manu.Text);
                            con.Close();
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Meter updated successfully.";
                                success_msg.Visible = true;
                                txt_Manu.Text = "";
                                cmb_Category.SelectedIndex = 0;
                                GetMeterID();
                                con.Close();
                                btn_Save.Text = "Save";
                            }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.StackTrace + ex.Message);
                        }

                        break;

                    case "Save":
                        try
                        {

                            SqlCommand com = new SqlCommand("[dbo].[insertMeter]", con);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@Number", txt_number.Text);
                            com.Parameters.AddWithValue("@Category", cmb_Category.Text);
                            com.Parameters.AddWithValue("@Manu", txt_Manu.Text);
                            com.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dddd, dd MMM, yyyy | hh:mm:ss"));
                            con.Close();
                            con.Open();
                            int i = com.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Meter saved successfully.";
                                success_msg.Visible = true;
                                txt_Manu.Text = "";
                                cmb_Category.SelectedIndex = 0;
                                GetMeterID();
                                GetMeters();
                                con.Close();
                            }

                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.StackTrace + ex.Message);
                        }
                        break;
                }
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string Id = ((sender as LinkButton).NamingContainer.FindControl("Id_Label") as Label).Text;
            con.Close();
            con.Open();
            SqlCommand comd = new SqlCommand("[dbo].[deleteMeter]", con);
            {
                con.Close();
                con.Open();
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", Id);
                int i = comd.ExecuteNonQuery();
                if (i > 0)
                {
                    success_Label.Text = "Meter details delected";
                    success_msg.Visible = true;
                    GetMeters();
                    GetMeterID();
                }
                con.Close();
            }
        }
    }
}