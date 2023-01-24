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



    }
}