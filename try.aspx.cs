using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSMS.Codes;

namespace WSMS
{
    public partial class _try : System.Web.UI.Page
    {
        
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Encrypted.Text = EncryptionDecryption.Encrypt(txt_Encrypt.Text);
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace + ex.Message);
            }
        }

        protected void btn_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Decrypted.Text = EncryptionDecryption.Decrypt(txt_Decrypt.Text);
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace + ex.Message);
            }
        }
    }
}