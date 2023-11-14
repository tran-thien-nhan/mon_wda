using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace day1_HelloWorld
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) //trang web chạy lại
            {
                chRemeber.Checked = false;
            }
            else //trang web chạy lần đầu
            {
                chRemeber.Checked = true;
            }
        }

        protected void Unnamed1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtUsername.Text;
            string p = txtPassword.Text;
            if (u == "aptech" && p == "123")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lbResult.Text = "Invalid username or password";
            }
        }
    }
}