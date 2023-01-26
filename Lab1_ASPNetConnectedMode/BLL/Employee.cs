using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_ASPNetConnectedMode.BLL
{
    public class Employee
    {
        //private class variables

        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //Proprties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        
        public void SaveEmployee(Employee emp)
        {
           EmployeeDB.SaveRecord(emp);
        }
        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }
        public void DeleteEmployee(int id)
        {
            EmployeeDB.DeleteRecord(id);
        }
        public List<Employee> GetAllEmployee()
        {
            return EmployeeDB.ShowAll();
        }
        public Employee SearchById( int id)
        {
            return EmployeeDB.GetEmployee(id);
        }
        public List<Employee> SearchByFirstName(String Input)
        {
            return EmployeeDB.SearchRecordByFirstName(Input);
        }
        public List<Employee> SearchByLastName(String Input)
        {
            return EmployeeDB.SearchRecordByLastName(Input);
        }

    }
}