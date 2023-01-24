using Lab1_ASPNetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class EmployeeDB
    {
        public static void SaveRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Employees VALUES (" + emp.EmployeeId + ",'" + emp.FirstName + "','" +emp.LastName + "','" +emp.JobTitle + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}