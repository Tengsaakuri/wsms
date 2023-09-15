using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WSMS.Codes;

namespace WSMS.Admin
{
    public partial class Payment : System.Web.UI.Page
    {
        static SqlConnection con = DB.Con();
        string receipt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                ddl_Months.Items.Clear();
                ddl_Months.Items.Add("- Select month -");

                for (int i = 1; i <= 12; i++)
                {
                    DateTime month = new DateTime(1, i, 1);
                    string year = DateTime.Now.ToString("yyyy");
                    ddl_Months.Items.Add(new ListItem(month.ToString("MMMM"), i.ToString()) + ", " + year);
                }

                loadCustomers();
            }
            error_msg.Visible = false;
            success_msg.Visible = false;
        }

        public void loadCustomers()
        {
            string sqlquery = "SELECT DISTINCT [Customer_Id] FROM [tbl_Customers]";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            ddl_IDs.Items.Clear();
            ddl_IDs.Items.Add("- Select Customer -");
            ddl_IDs.DataSource = data;
            ddl_IDs.DataTextField = "Customer_Id";
            ddl_IDs.DataValueField = "Customer_Id";
            ddl_IDs.DataBind();
            con.Close();
        }

        public void getMeters()
        {
            string sqlquery = "SELECT DISTINCT Meter FROM [tbl_Customers]" +
                " WHERE Customer_Id = @Customer";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Customer", ddl_IDs.Text);
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            ddl_Meters.Items.Clear();
            ddl_Meters.Items.Add("- Select meter -");
            ddl_Meters.DataSource = data;
            ddl_Meters.DataTextField = "Meter";
            ddl_Meters.DataValueField = "Meter";
            ddl_Meters.DataBind();
            con.Close();
        }

        protected void btn_Calculate_ServerClick(object sender, EventArgs e)
        {
            float amount = 0;
            float unit = 0;
            if (txt_Consumption.Text == "")
            {
                txt_Consumption.Text = "0";
                error_Label.Text = "Enter consumption";
                error_msg.Visible = true;
                txt_Consumption.Focus();
                return;
            }
            if (txt_Charge.Text == "")
            {
                txt_Charge.Text = "0";
                error_Label.Text = "Enter amount";
                error_msg.Visible = true;
                return;
            }
            else
            {
                error_Label.Text = "";
                error_msg.Visible = false;
                amount = float.Parse(txt_Charge.Text.ToString());
                unit = float.Parse(txt_Consumption.Text.ToString());
                float total = amount * unit;
                txt_Total.Text = total.ToString();
            }
        }

        protected void ddl_IDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                SqlCommand comd = new SqlCommand("[dbo].[editCustomer]", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", ddl_IDs.Text);
                comd.ExecuteNonQuery();
                DataTable dat = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                da.Fill(dat);
                //String Pass;
                if (dat.Rows.Count > 0)
                {
                    txt_Name.Text = dat.Rows[0]["First_Name"].ToString() + " " + dat.Rows[0]["Last_Name"].ToString();
                    txt_Gender.Text = dat.Rows[0]["Gender"].ToString();
                    txt_Number.Text = dat.Rows[0]["Phone_Number"].ToString();
                    txt_Address.Text = dat.Rows[0]["_Address"].ToString();
                    txt_House_Number.Text = dat.Rows[0]["Hse_Number"].ToString();
                    getMeters();
                    con.Close();
                }
                else
                {
                    txt_Name.Text = "Full name";
                    txt_Gender.Text = "Gender";
                    txt_Number.Text = "Phone number";
                    txt_Address.Text = "Address";
                    txt_House_Number.Text = "Hse. Number";
                    ddl_Meters.Items.Clear();
                    ddl_Meters.Items.Add("- Select meter -");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace + ex.Message);
            }
        }

        protected void ddl_Meters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "getBalance";
            string sqlquery = "[getMeterDetail]";
            SqlCommand sc = new SqlCommand(query, con);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Meter", ddl_Meters.Text);
            con.Close();
            con.Open();
            sc.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dta = new DataTable();
            da.Fill(dta);

            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Meter", ddl_Meters.Text);
            con.Close();
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                txt_Charge.Text = data.Rows[0]["Amount"].ToString();
                txt_Category.Text = data.Rows[0]["Category"].ToString();
                con.Close();
            }
            if (data.Rows.Count < 1)
            {
                txt_Charge.Text = "0";
                txt_Category.Text = "Category";
                con.Close();
            }
            if (dta.Rows.Count > 0)
            {
                txt_Balance.Text = dta.Rows[0]["_Balance"].ToString();
                con.Close();
            }
            if (dta.Rows.Count < 1)
            {
                txt_Balance.Text = "0";
                con.Close();
            }
        }

        public void GetReceiptNumber()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select cast (max(cast(substring(Receipt_Number, 2, 9)" +
                " as int))+1 as int) ReceiptNumber from tbl_Payment", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                receipt = ds.Rows[0]["ReceiptNumber"].ToString();
                if (receipt.Length < 2)
                {
                    receipt = "#" + "100000001";
                }

                else
                {
                    receipt = "#" + ds.Rows[0]["ReceiptNumber"].ToString();
                }

                con.Close();
            }
        }

        protected void btn_Save_ServerClick(object sender, EventArgs e)
        {
            if (ddl_IDs.SelectedIndex == 0)
            {
                error_Label.Text = "Select Customer ID";
                error_msg.Visible = true;
                return;
            }
            if (ddl_Meters.SelectedIndex == 0)
            {
                error_Label.Text = "Select meter numnber";
                error_msg.Visible = true;
                return;
            }
            if (ddl_Months.SelectedIndex == 0)
            {
                error_Label.Text = "Select payment period";
                error_msg.Visible = true;
                return;
            }
            if (txt_Consumption.Text == "")
            {
                txt_Consumption.Text = "0";
                error_Label.Text = "Enter monthly consumption";
                error_msg.Visible = true;
                txt_Consumption.Focus();
                return;
            }

            if (txt_Amount.Text == "")
            {
                txt_Amount.Text = "0";
                error_Label.Text = "Enter amount";
                error_msg.Visible = true;
                return;
            }
            else
            {
                float total = Convert.ToInt32(txt_Total.Text.ToString());
                float amount = Convert.ToInt32(txt_Amount.Text.ToString());
                float balance = Convert.ToInt32(txt_Balance.Text.ToString());
                float newBalance = (amount - total) + balance;

                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].insertConsumption", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Meter", ddl_Meters.Text);
                    cmd.Parameters.AddWithValue("@Consumption", txt_Consumption.Text);
                    cmd.Parameters.AddWithValue("@Period", ddl_Months.Text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("ddd, dd MMM yyyy | hh:mm:ss"));
                    con.Close();
                    con.Open();
                    int x = cmd.ExecuteNonQuery();
                    if (x == 1)
                   
                    {
                        try
                        {
                            GetReceiptNumber();
                            SqlCommand com = new SqlCommand("[dbo].[insertPayment]", con);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@Receipt", receipt);
                            com.Parameters.AddWithValue("@Customer", ddl_IDs.Text);
                            com.Parameters.AddWithValue("@Name", txt_Name.Text);
                            com.Parameters.AddWithValue("@Meter", ddl_Meters.Text);
                            com.Parameters.AddWithValue("@Total", total);
                            com.Parameters.AddWithValue("@Amount", amount);
                            com.Parameters.AddWithValue("@Balance", newBalance);
                            com.Parameters.AddWithValue("@Period", ddl_Months.Text);
                            com.Parameters.AddWithValue("@Receiver", Session["Name"]);
                            com.Parameters.AddWithValue("@Date", DateTime.Now.ToString("ddd, dd MMM yyyy | hh:mm:ss"));
                            con.Close();
                            con.Open();
                            int i = com.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Payment successfully.";
                                success_msg.Visible = true;
                                txt_Name.Text = "Full name";
                                txt_Gender.Text = "Gender";
                                ddl_Months.SelectedIndex = 0;
                                ddl_IDs.SelectedIndex = 0;
                                ddl_Meters.SelectedIndex = 0;
                                txt_Number.Text = "Phone number";
                                txt_Address.Text = "Address";
                                txt_Total.Text = "0";
                                txt_Category.Text = "Category";
                                txt_Consumption.Text = "0";
                                txt_Balance.Text = "0";
                                txt_Charge.Text = "0";
                                txt_Amount.Text = "0";
                                txt_House_Number.Text = "Hse number";
                                getMeters();
                                con.Close();
                            }

                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.StackTrace + ex.Message);
                        }
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