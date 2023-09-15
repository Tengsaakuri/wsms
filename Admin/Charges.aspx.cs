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
    public partial class Charges : System.Web.UI.Page
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
            success_msg.Visible = false;
            error_msg.Visible = false;
            GetCharges();

            if (!Page.IsPostBack)
            {
                loadCategories();
            }

        }

        private void GetCharges()
        {
            string sqlquery = "Select * From tbl_Charges";
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

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Amount.Text == "")
            {
                txt_Amount.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter meter Charge";
                error_msg.Visible = true;
                return;
            }
            if (cmb_Category.SelectedIndex == 0)
            {
                cmb_Category.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Select Category";
                error_msg.Visible = true;
                return;
            }
            else
            {
                float amount = float.Parse(txt_Amount.Text.ToString());
                cmb_Category.BorderColor = System.Drawing.Color.Empty;

                string choice = btn_Save.Text;

                switch (choice)
                {
                    case "Update":
                        try
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE tbl_Charges SET Amount = @Amount," +
                                " Category = @Category WHERE Id = @Id", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Id", txt_Id.Text);
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@Category", cmb_Category.Text);
                            con.Close();
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Charges updated successfully.";
                                success_msg.Visible = true;
                                txt_Id.Text = "ID";
                                txt_Amount.Text = "";
                                cmb_Category.SelectedIndex = 0;
                                txt_Amount.Focus();
                                GetCharges();
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

                            SqlCommand com = new SqlCommand("INSERT INTO tbl_Charges (Amount, Category)" +
                                " VALUES (@Amount, @Category)", con);
                            com.CommandType = CommandType.Text;
                            com.Parameters.AddWithValue("@Amount", amount);
                            com.Parameters.AddWithValue("@Category", cmb_Category.Text);
                            con.Close();
                            con.Open();
                            int i = com.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Charge saved successfully.";
                                success_msg.Visible = true;
                                txt_Amount.Text = "";
                                cmb_Category.SelectedIndex = 0;
                                GetCharges();
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
            int Id = Convert.ToInt32(((sender as LinkButton).NamingContainer.FindControl("Id_Label") as Label).Text);
            try
            {
                con.Close();
                con.Open();
                SqlCommand comd = new SqlCommand("Select * From tbl_Charges WHERE Id = @Id", con);
                comd.CommandType = CommandType.Text;
                comd.Parameters.AddWithValue("@Id", Id);
                comd.ExecuteNonQuery();
                DataTable dat = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                da.Fill(dat);
                //String Pass;
                if (dat.Rows.Count > 0)
                {
                    txt_Id.Text = dat.Rows[0]["Id"].ToString();
                    txt_Amount.Text = dat.Rows[0]["Amount"].ToString();
                    cmb_Category.Text = dat.Rows[0]["Category"].ToString();
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
            int Id = Convert.ToInt32(((sender as LinkButton).NamingContainer.FindControl("Id_Label") as Label).Text);
            con.Close();
            con.Open();
            SqlCommand comd = new SqlCommand("DELETE From tbl_Charges WHERE Id = @Id", con);
            {
                con.Close();
                con.Open();
                comd.CommandType = CommandType.Text;
                comd.Parameters.AddWithValue("@Id", Id);
                int i = comd.ExecuteNonQuery();
                if (i > 0)
                {
                    success_Label.Text = "Charge details delected";
                    GetCharges();
                }
                con.Close();
            }
        }
    }
}