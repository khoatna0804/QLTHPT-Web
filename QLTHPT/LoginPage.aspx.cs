using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Loginbtn_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        conn.Open();
        string checkuser = "Select count(*) from [UserInfo] where Username='" + UNLogintxt.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        if (temp == 1)
        {
            //conn.Open();
            string checkpassword = "Select password from [UserInfo] where Password='" + PWLogintxt.Text + "'";
            SqlCommand pcom = new SqlCommand(checkpassword, conn);
            string password = pcom.ExecuteScalar().ToString().Replace(" ", "");
            if (password == PWLogintxt.Text)
            {
                Session["New"] = UNLogintxt.Text;
                string scripts = "alert(\"Password is correct\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scripts, true);
                Response.Redirect("Manage.aspx");
            }
            else
            {
                string scripte = "alert(\"Password is incorrect\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scripte, true);
            }
            //conn.Close();
        }
        conn.Close();
    }
}