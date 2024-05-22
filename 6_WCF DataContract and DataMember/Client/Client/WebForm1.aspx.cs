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

            if (employee.EmployeeType == EmployeeService.EmployeeType.FullTimeEmployee)
            {
                trAnnualSalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
                TextBox5.Text = ((EmployeeService.FullTimeEmployee)employee).AnnualSalary.ToString();
            }
            else if (employee.EmployeeType == EmployeeService.EmployeeType.PartTimeEmployee)
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
                TextBox6.Text = ((EmployeeService.PartTimeEmployee)employee).HourlyPay.ToString();
                TextBox7.Text = ((EmployeeService.PartTimeEmployee)employee).HoursWorked.ToString();
            }
            else
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            DropDownList1.SelectedValue = ((int)employee.EmployeeType).ToString();

            TextBox2.Text = employee.Name;
            TextBox3.Text = employee.Gender;
            TextBox4.Text = employee.DateOfBirth.ToShortDateString();
            Label5.Text = "employee retrieved";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            EmployeeService.Employee employee = null;

            if ((EmployeeService.EmployeeType)Convert.ToInt32(DropDownList1.SelectedValue) == EmployeeService.EmployeeType.FullTimeEmployee)
            {
                employee = new EmployeeService.FullTimeEmployee()
                {
                    Id = Convert.ToInt32(TextBox1.Text),
                    Name = TextBox2.Text,
                    Gender = TextBox3.Text,
                    DateOfBirth = Convert.ToDateTime(TextBox4.Text),
                    EmployeeType = EmployeeService.EmployeeType.FullTimeEmployee,
                    AnnualSalary = Convert.ToInt32(TextBox5.Text)
                };
                client.SaveEmployee(employee);
                Label5.Text = "FullTimeEmployee saved";
            }
            else if ((EmployeeService.EmployeeType)Convert.ToInt32(DropDownList1.SelectedValue) == EmployeeService.EmployeeType.PartTimeEmployee)
            {
                employee = new EmployeeService.PartTimeEmployee()
                {
                    Id = Convert.ToInt32(TextBox1.Text),
                    Name = TextBox2.Text,
                    Gender = TextBox3.Text,
                    DateOfBirth = Convert.ToDateTime(TextBox4.Text),
                    EmployeeType = EmployeeService.EmployeeType.PartTimeEmployee,
                    HourlyPay = Convert.ToInt32(TextBox6.Text),
                    HoursWorked = Convert.ToInt32(TextBox7.Text)
                };
                client.SaveEmployee(employee);
                Label5.Text = "PartTimeEmployee saved";
            }
            else
            {
                Label5.Text = "Please select Employee Type";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "-1")
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "1")
            {
                trAnnualSalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
            }
        }
    }
}