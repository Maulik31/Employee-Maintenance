using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnConnectDB_Click(object sender, EventArgs e)
        {
            SqlConnection connection = UtilityDB.ConnectDB();
            MessageBox.Show(Convert.ToString(connection.State));
        }
    }
}