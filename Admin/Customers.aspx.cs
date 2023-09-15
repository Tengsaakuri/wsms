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
    public partial class Customers : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();

        private bool _modalOpened = false;

        public bool ModalOpened
        {
            get { return _modalOpened; }
            set { _modalOpened = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            success_msg.Visible = false;
            error_msg.Visible = false;
            getCustomers();

            if (!Page.IsPostBack)
            {
                GetCustomerId();
                getMeters();
            }
        }

        public void GetCustomerId()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select cast (max(cast(substring(Customer_Id, 4, 4)" +
                " as int))+1 as int) CustomerId from tbl_Customers", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                txt_ID.Text = ds.Rows[0]["CustomerId"].ToString();
                if (txt_ID.Text.Length < 2)
                {
                    txt_ID.Text = "CUS" + "1001" +
                    DateTime.Now.ToString("yy");
                }

                else
                {
                    txt_ID.Text = "CUS" + ds.Rows[0]["CustomerId"].ToString() +
                    DateTime.Now.ToString("yy");
                }

                con.Close();
            }
        }

        private void getCustomers()
        {
            string sqlquery = "[dbo].[getCustomers]";
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

        public void getMeter()
        {
            string sqlquery = "SELECT DISTINCT Meter_Number FROM [tbl_Meters]" +
                " WHERE Meter_Number IN (SELECT Meter FROM [tbl_Customers])";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            ddl_Meter.Items.Clear();
            ddl_Meter.Items.Add("- Select One -");
            ddl_Meter.DataSource = data;
            ddl_Meter.DataTextField = "Meter_Number";
            ddl_Meter.DataValueField = "Meter_Number";
            ddl_Meter.DataBind();
            con.Close();
        }

        public void getMeters()
        {
            string sqlquery = "SELECT DISTINCT Meter_Number FROM [tbl_Meters]" +
                " WHERE Meter_Number NOT IN (SELECT Meter FROM [tbl_Customers]" +
                " WHERE Meter > '')";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            ddl_Meter.Items.Clear();
            ddl_Meter.Items.Add("- Select One -");
            ddl_Meter.DataSource = data;
            ddl_Meter.DataTextField = "Meter_Number";
            ddl_Meter.DataValueField = "Meter_Number";
            ddl_Meter.DataBind();
            con.Close();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_First.Text == "")
            {
                txt_First.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter first name";
                error_msg.Visible = true;
                txt_First.Focus();
                return;
            }
            if (txt_Last.Text == "")
            {
                txt_Last.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter last name";
                error_msg.Visible = true;
                txt_Last.Focus();
                return;
            }
            if (cmb_Gender.SelectedIndex == 0)
            {
                error_Label.Text = "Select gender";
                error_msg.Visible = true;
                return;
            }
            if (txt_Number.Text == "")
            {
                txt_Number.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter phone number";
                error_msg.Visible = true;
                txt_Number.Focus();
                return;
            }
            if (txt_Address.Text == "")
            {
                txt_Address.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter address";
                error_msg.Visible = true;
                txt_Address.Focus();
                return;
            }
            if (txt_House_Number.Text == "")
            {
                txt_House_Number.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter house number";
                error_msg.Visible = true;
                txt_House_Number.Focus();
                return;
            }
            if (ddl_Meter.SelectedIndex == 0)
            {
                error_Label.Text = "Select meter";
                error_msg.Visible = true;
                return;
            }
            else
            {
                txt_First.BorderColor = System.Drawing.Color.Empty;
                txt_Last.BorderColor = System.Drawing.Color.Empty;
                txt_Number.BorderColor = System.Drawing.Color.Empty;
                txt_Address.BorderColor = System.Drawing.Color.Empty;
                txt_House_Number.BorderColor = System.Drawing.Color.Empty;

                string choice = btn_Save.Text;

                switch (choice)
                {
                    case "Update":
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[dbo].[updateCustomer]", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@First", txt_First.Text);
                            cmd.Parameters.AddWithValue("@Last", txt_Last.Text);
                            cmd.Parameters.AddWithValue("@Gender", cmb_Gender.Text);
                            cmd.Parameters.AddWithValue("@DOB", txt_DOD.Text);
                            cmd.Parameters.AddWithValue("@Number", txt_Number.Text);
                            cmd.Parameters.AddWithValue("@Address", txt_Address.Text);
                            cmd.Parameters.AddWithValue("@Hse_Number", txt_House_Number.Text);
                            cmd.Parameters.AddWithValue("@Meter", ddl_Meter.Text);
                            cmd.Parameters.AddWithValue("@Customer_Id", txt_ID.Text);
                            con.Close();
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Customer's updated successfully.";
                                success_msg.Visible = true;
                                txt_ID.Text = "";
                                txt_First.Text = "";
                                txt_Last.Text = "";
                                txt_Number.Text = "";
                                txt_Address.Text = "";
                                txt_House_Number.Text = "";
                                ddl_Meter.SelectedIndex = 0;
                                cmb_Gender.SelectedIndex = 0;
                                getMeters();
                                getCustomers();
                                GetCustomerId();
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

                            SqlCommand com = new SqlCommand("[dbo].[insertCustomer]", con);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@Customer_Id", txt_ID.Text);
                            com.Parameters.AddWithValue("@First_Name", txt_First.Text);
                            com.Parameters.AddWithValue("@Last_Name", txt_Last.Text);
                            com.Parameters.AddWithValue("@Gender", cmb_Gender.Text);
                            com.Parameters.AddWithValue("@DOB", txt_DOD.Text);
                            com.Parameters.AddWithValue("@Number", txt_Number.Text);
                            com.Parameters.AddWithValue("@Address", txt_Address.Text);
                            com.Parameters.AddWithValue("@Hse_Number", txt_House_Number.Text);
                            com.Parameters.AddWithValue("@Meter", ddl_Meter.Text);
                            com.Parameters.AddWithValue("@Date", DateTime.Now.ToString("ddd, dd MMM, yyyy | hh:mm:ss"));
                            con.Close();
                            con.Open();
                            int i = com.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Customer saved successfully.";
                                success_msg.Visible = true;
                                txt_First.Text = "";
                                txt_Last.Text = "";
                                txt_DOD.Text = "";
                                cmb_Gender.SelectedIndex = 0;
                                txt_Number.Text = "";
                                txt_Address.Text = "";
                                txt_House_Number.Text = "";
                                ddl_Meter.SelectedIndex = 0;
                                txt_First.Focus();
                                getMeters();
                                getCustomers();
                                GetCustomerId();
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

        protected void edit_Click(object sender, EventArgs e)
        {
            string Id = ((sender as LinkButton).NamingContainer.FindControl("Id_Label") as Label).Text;
            try
            {
                con.Close();
                con.Open();
                SqlCommand comd = new SqlCommand("[dbo].[editCustomer]", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", Id);
                comd.ExecuteNonQuery();
                DataTable dat = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                da.Fill(dat);
                //String Pass;
                if (dat.Rows.Count > 0 && dat.Rows[0]["Meter"].ToString() == "")
                {
                    getMeters();
                    txt_ID.Text = dat.Rows[0]["Customer_Id"].ToString();
                    txt_First.Text = dat.Rows[0]["First_Name"].ToString();
                    txt_Last.Text = dat.Rows[0]["Last_Name"].ToString();
                    cmb_Gender.Text = dat.Rows[0]["Gender"].ToString();
                    txt_DOD.Text = dat.Rows[0]["DOB"].ToString();
                    txt_Number.Text = dat.Rows[0]["Phone_Number"].ToString();
                    txt_Address.Text = dat.Rows[0]["_Address"].ToString();
                    txt_House_Number.Text = dat.Rows[0]["Hse_Number"].ToString();
                    btn_Save.Text = "Update";
                }
                else
                {
                    getMeter();
                    txt_ID.Text = dat.Rows[0]["Customer_Id"].ToString();
                    txt_First.Text = dat.Rows[0]["First_Name"].ToString();
                    txt_Last.Text = dat.Rows[0]["Last_Name"].ToString();
                    cmb_Gender.Text = dat.Rows[0]["Gender"].ToString();
                    txt_DOD.Text = dat.Rows[0]["DOB"].ToString();
                    txt_Number.Text = dat.Rows[0]["Phone_Number"].ToString();
                    txt_Address.Text = dat.Rows[0]["_Address"].ToString();
                    txt_House_Number.Text = dat.Rows[0]["Hse_Number"].ToString();
                    ddl_Meter.Text = dat.Rows[0]["Meter"].ToString();
                    btn_Save.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace + ex.Message);
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string Id = ((sender as LinkButton).NamingContainer.FindControl("Id_Label") as Label).Text;
            con.Close();
            con.Open();
            SqlCommand comd = new SqlCommand("[dbo].[deleteCustomer]", con);
            {
                con.Close();
                con.Open();
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", Id);
                int i = comd.ExecuteNonQuery();
                if (i > 0)
                {
                    getCustomers();
                    GetCustomerId();
                }
                con.Close();
            }
        }

        protected void cmb_Meter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlquery = "[getMeterCategory]";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Meter", ddl_Meter.Text);
            con.Close();
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                txt_Category.Text = data.Rows[0]["Category"].ToString();
                con.Close();
            }
            else
            {
                txt_Category.Text = "";
                con.Close();
            }
        }
    }
}