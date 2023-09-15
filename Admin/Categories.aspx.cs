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
    public partial class Categories : System.Web.UI.Page
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
            GetCategories();

            if (!Page.IsPostBack)
            {
                GetCategoryID();
            }
        }

        private void GetCategories()
        {
            string sqlquery = "[dbo].[getCategories]";
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

        public void GetCategoryID()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select cast (max(cast(substring(Category_Id, 5, 4)" +
                " as int))+1 as int) CategoryId from tbl_Categories", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                txt_ID.Text = ds.Rows[0]["CategoryId"].ToString();
                if (txt_ID.Text.Length < 2)
                {
                    txt_ID.Text = "CAT-" + "1001";
                }
                else
                {
                    txt_ID.Text = "CAT-" + ds.Rows[0]["CategoryId"].ToString();
                }
                con.Close();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Category.Text == "")
            {
                txt_Category.BorderColor = System.Drawing.Color.Red;
                error_Label.Text = "Enter meter category";
                error_msg.Visible = true;
                txt_Category.Focus();
                return;
            }
            else
            {
                txt_Category.BorderColor = System.Drawing.Color.Empty;

                string choice = btn_Save.Text;

                switch (choice)
                {
                    case "Update":
                        try
                        {
                            SqlCommand cmd = new SqlCommand("[dbo].[updateCategory]", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", txt_ID.Text);
                            cmd.Parameters.AddWithValue("@Category", txt_Category.Text);
                            con.Close();
                            con.Open();
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Catgory updated successfully.";
                                success_msg.Visible = true;
                                txt_ID.Text = "";
                                txt_Category.Text = "";
                                txt_Category.Focus();
                                GetCategoryID();
                                GetCategories();
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

                            SqlCommand com = new SqlCommand("[dbo].[insertCategory]", con);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@Category_Id", txt_ID.Text);
                            com.Parameters.AddWithValue("@Category", txt_Category.Text);
                            com.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dddd, dd MMM, yyyy | hh:mm:ss"));
                            con.Close();
                            con.Open();
                            int i = com.ExecuteNonQuery();
                            if (i == 1)
                            {
                                success_Label.Text = "Catgory saved successfully.";
                                success_msg.Visible = true;
                                txt_Category.Text = "";
                                txt_Category.Focus();
                                GetCategoryID();
                                GetCategories();
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
                SqlCommand comd = new SqlCommand("[dbo].[editCategory]", con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", Id);
                comd.ExecuteNonQuery();
                DataTable dat = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comd);
                da.Fill(dat);
                //String Pass;
                if (dat.Rows.Count > 0)
                {
                    txt_ID.Text = dat.Rows[0]["Category_ID"].ToString();
                    txt_Category.Text = dat.Rows[0]["Category"].ToString();
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
            SqlCommand comd = new SqlCommand("[dbo].[deleteCategory]", con);
            {
                con.Close();
                con.Open();
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.AddWithValue("@Id", Id);
                int i = comd.ExecuteNonQuery();
                if (i > 0)
                {
                    success_Label.Text = "Catgory details delected";
                    GetCategories();
                }
                con.Close();
            }
        }
    }
}