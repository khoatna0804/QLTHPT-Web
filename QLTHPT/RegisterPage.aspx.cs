using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class RegisterPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [UserInfo] where Username='" + txtUsername.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = 0;
            temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                string script1 = "alert(\"User already exist\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script1, true);

            }
            conn.Close();
        }
    }

    protected void SaveUserbtn_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        conn.Open();
        string insertuser = "insert into [UserInfo] (Username,Email,Password) values (@username, @email, @password)";
        SqlCommand com = new SqlCommand(insertuser, conn);
        com.Parameters.AddWithValue("@username", txtUsername.Text);
        com.Parameters.AddWithValue("@email", txtEmail.Text);
        com.Parameters.AddWithValue("@password", txtPW.Text);
        com.ExecuteNonQuery();
        string script = "alert(\"Registration is completed\");";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        Response.Redirect("Login.aspx");
        conn.Close();
    }
}