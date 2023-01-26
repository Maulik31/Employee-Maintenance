using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;
using Lab1_ASPNetConnectedMode.VALIDATION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Add("Id");
                DropDownList1.Items.Add("First Name");
                DropDownList1.Items.Add("Last Name");
                
            }
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtEmployeeId.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtEmployeeId.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
            if (!(Validator.IsValidId(id,4))){
                MessageBox.Show("Employee id Must be 4-Digit number.","Invalid Id",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }
            if (!(EmployeeDB.IsDuplicateId(Convert.ToInt32(id))))
            {
                MessageBox.Show("Id Must be Unique.", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }
            if (!(Validator.IsValidName(firstName)))
            {
                MessageBox.Show("Firstname contains only letters.", "Invalid FirstName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Text = "";
                txtFirstName.Focus();
                return;
            }        
            if (!(Validator.IsValidName(lastName)))
            {
                MessageBox.Show("Lastname contains only letters.", "Invalid LastName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Text = "";
                txtLastName.Focus();
                return;
            }
            if (!(Validator.IsValidName(jobTitle)))
            {
                MessageBox.Show("Jobtitle contains only letters.", "Invalid LastName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJobTitle.Text = "";
                txtJobTitle.Focus();
                return;
            }
            Employee employee= new Employee();
            employee.EmployeeId = Convert.ToInt32(id);
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.JobTitle = jobTitle;
            employee.SaveEmployee(employee);
            MessageBox.Show("Employee Data Saved","Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            GridView1.DataSource = employee.GetAllEmployee();
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {   

            Employee employee = new Employee();
            if (DropDownList1.SelectedValue == "Id")
            {
                int id = Convert.ToInt32(txtSearch.Text.Trim());
                if (!(Validator.IsValidId(id.ToString(), 4)))
                {
                    MessageBox.Show("Employee id Must be 4-Digit number.", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeId.Text = "";
                    txtEmployeeId.Focus();
                    return;
                }
                employee = employee.SearchById(id);
                if(employee != null) { 
                txtEmployeeId.Text = employee.EmployeeId.ToString();
                txtFirstName.Text = employee.FirstName.ToString();
                txtLastName.Text = employee.LastName.ToString();
                txtJobTitle.Text = employee.JobTitle.ToString();
                txtEmployeeId.ReadOnly = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No Data Found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if(DropDownList1.SelectedValue == "First Name")
            {
                String Input = txtSearch.Text;
                if (!(Validator.IsValidName(Input)))
                {
                    MessageBox.Show("Firstname contains only letters.", "Invalid FirstName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }
                List<Employee> listOfEmployees = new List<Employee>();
                listOfEmployees = employee.SearchByFirstName(Input);
                
                if(listOfEmployees.Count != 0)
                {
                    GridView1.DataSource = listOfEmployees;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    MessageBox.Show("No Data Found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (DropDownList1.SelectedValue == "Last Name")
            {
                String Input = txtSearch.Text;
                if (!(Validator.IsValidName(Input)))
                {
                    MessageBox.Show("Lastname contains only letters.", "Invalid Last Name", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    return;
                }
                List<Employee> listOfEmployees = new List<Employee>();
                listOfEmployees = employee.SearchByLastName(Input);
                if (listOfEmployees.Count != 0)
                {
                    GridView1.DataSource = listOfEmployees;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    MessageBox.Show("No Data Found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            GridView1.DataSource=null;
            GridView1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtEmployeeId.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string jobTitle = txtJobTitle.Text.Trim();
 
            if (!(Validator.IsValidName(firstName)))
            {
                MessageBox.Show("Firstname contains only letters.", "Invalid FirstName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Text = "";
                txtFirstName.Focus();
                return;
            }
            if (!(Validator.IsValidName(lastName)))
            {
                MessageBox.Show("Lastname contains only letters.", "Invalid LastName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Text = "";
                txtLastName.Focus();
                return;
            }
            if (!(Validator.IsValidName(jobTitle)))
            {
                MessageBox.Show("Jobtitle contains only letters.", "Invalid LastName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJobTitle.Text = "";
                txtJobTitle.Focus();
                return;
            }
            Employee employee = new Employee();
            employee.EmployeeId = Convert.ToInt32(id);
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.JobTitle = jobTitle;
            employee.UpdateEmployee(employee);
            MessageBox.Show("Employee " + id + " Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEmployeeId.ReadOnly = false;
            txtEmployeeId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtJobTitle.Text = "";

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {   
            Employee employee = new Employee();
            int id = Convert.ToInt32(txtEmployeeId.Text);
            DialogResult dialogResult = MessageBox.Show("Are you want To delete ID: " + id , "Conformation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                employee.DeleteEmployee(id);
                MessageBox.Show("Employee :"+ id +"has been Deleted","Done",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeId.ReadOnly = false;
                txtEmployeeId.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtJobTitle.Text = "";
            }
            else
            {
                return;
            }
           

        }

     }
}
