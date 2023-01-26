using Lab1_ASPNetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows;
using System.Windows.Documents;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class EmployeeDB
    {
        public static void SaveRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Employees (EmployeeId,FirstName,LastName,JobTitle) VALUES (@EmployeeId,@FirstName,@LastName,@JobTitle)";
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateRecord(Employee emp)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Employees SET FirstName=@FirstName , LastName=@LastName , JobTitle =@JobTitle WHERE EmployeeId = @EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(int id)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public static List<Employee> ShowAll() {
            List<Employee> listEmployee = new List<Employee>();

            using(SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                SqlDataReader reader = cmd.ExecuteReader();
                Employee employee;
                while (reader.Read())
                {
                    employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.JobTitle = reader["JobTitle"].ToString();
                    listEmployee.Add(employee);
                }
            }

            return listEmployee;
        }

        public static Employee GetEmployee(int empId)
        {   Employee emp = new Employee();  
            using(SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand searchbyId = conn.CreateCommand();
                searchbyId.CommandText = "SELECT * FROM Employees where EmployeeId = @EmployeeId";
                searchbyId.Parameters.AddWithValue("@EmployeeId", empId);
                SqlDataReader reader = searchbyId.ExecuteReader();
              
                    if(reader.Read())
                    {
                        emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        emp.FirstName = reader["FirstName"].ToString();
                        emp.LastName = reader["LastName"].ToString();
                        emp.JobTitle = reader["JobTitle"].ToString();
                    }else
                    {
                        emp = null;
                                            }
                }
            return emp;
        }

        public static bool IsDuplicateId(int Id)
        {
            Employee Employee = new Employee();
            Employee = Employee.SearchById(Id);
            if (Employee != null)
            {
                return false;
            }
            return true;
        }
        public static List<Employee> SearchRecordByFirstName(string inputName)
        {

            List<Employee> listS = new List<Employee>();
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSearch = new SqlCommand("Select * From Employees Where FirstName = @FirstName", conn);
                cmdSearch.Parameters.AddWithValue("@FirstName", inputName);
                SqlDataReader reader = cmdSearch.ExecuteReader();
                Employee Employee;
                while (reader.Read())
                {
                    Employee = new Employee();
                    Employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    Employee.FirstName = reader["FirstName"].ToString().Trim();
                    Employee.LastName = reader["LastName"].ToString().Trim();
                    Employee.JobTitle = reader["JobTitle"].ToString().ToString();
                    listS.Add(Employee);
                }
            }
            return listS;
        }
        public static List<Employee> SearchRecordByLastName(string inputName)
        {

            List<Employee> listS = new List<Employee>();
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSearch = new SqlCommand("Select * From Employees Where LastName = @LastName", conn);
                cmdSearch.Parameters.AddWithValue("@LastName", inputName);
                SqlDataReader reader = cmdSearch.ExecuteReader();
                Employee Employee;
                while (reader.Read())
                {
                    Employee = new Employee();
                    Employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    Employee.FirstName = reader["FirstName"].ToString().Trim();
                    Employee.LastName = reader["LastName"].ToString().Trim();
                    Employee.JobTitle = reader["JobTitle"].ToString().ToString();
                    listS.Add(Employee);
                }
            }
            return listS;
        }


       

    }
}
