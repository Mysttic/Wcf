using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(TextBox1.Text));
            TextBox2.Text = employee.Name;
            TextBox3.Text = employee.Gender;
            TextBox4.Text = employee.DateOfBirth.ToShortDateString();
            Label5.Text = "employee retrieved";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.Id = Convert.ToInt32(TextBox1.Text);
            employee.Name = TextBox2.Text;
            employee.Gender = TextBox3.Text;
            employee.DateOfBirth = Convert.ToDateTime(TextBox4.Text);

            client.SaveEmployee(employee);
            Label5.Text = "employee saved";
        }
    }
}