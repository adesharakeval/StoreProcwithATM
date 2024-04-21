using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreProcwithATM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new  SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            //if (!IsPostBack)
            //{
            //    GridView1.DataBind();
            //}
        }

        protected void Transfer_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_ATMTest", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Id1",Convert.ToInt32(DropDownList1.SelectedItem.Text));
            cmd.Parameters.AddWithValue("@Balance",Convert.ToInt32(TextBox1.Text));
            cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(DropDownList2.SelectedItem.Text));
            cmd.Parameters.AddWithValue("@Id2", Convert.ToInt32(DropDownList3.SelectedItem.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            GridView1.DataBind();
        }
    }
}