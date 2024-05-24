using Client.EmployeeService;
using System;
using System.Xml.Linq;

namespace Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IEmployeeService client = new EmployeeServiceClient();
            EmployeeRequest request = new EmployeeRequest("AXG120ABC", Convert.ToInt32(TextBox1.Text));
            EmployeeInfo employee = client.GetEmployee(request);

            if (employee.EmployeeType == EmployeeType.FullTimeEmployee)
            {
                trAnnualSalary.Visible = true;
                trHourlyPay.Visible = false;
                trHoursWorked.Visible = false;
                TextBox5.Text = employee.AnnualSalary.ToString();
            }
            else if (employee.EmployeeType == EmployeeType.PartTimeEmployee)
            {
                trAnnualSalary.Visible = false;
                trHourlyPay.Visible = true;
                trHoursWorked.Visible = true;
                TextBox6.Text = employee.HourlyPay.ToString();
                TextBox7.Text = employee.HoursWorked.ToString();
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
            TextBox4.Text = employee.DOB.ToShortDateString();
            Label5.Text = "employee retrieved";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            IEmployeeService client = new EmployeeServiceClient();
            EmployeeInfo employee = new EmployeeInfo();

            if (DropDownList1.SelectedValue == "-1")
            {
                Label5.Text = "Please select Employee Type";
                return;
            }
            else if ((EmployeeType)Convert.ToInt32(DropDownList1.SelectedValue) == EmployeeType.FullTimeEmployee)
            {
                employee.EmployeeType = EmployeeType.FullTimeEmployee;
                employee.AnnualSalary = Convert.ToInt32(TextBox5.Text);
            }
            else
            {
                employee.EmployeeType = EmployeeType.PartTimeEmployee;
                employee.HourlyPay = Convert.ToInt32(TextBox6.Text);
                employee.HoursWorked = Convert.ToInt32(TextBox7.Text);
            }

            employee.Id = Convert.ToInt32(TextBox1.Text);
            employee.Name = TextBox2.Text;
            employee.Gender = TextBox3.Text;
            employee.DOB = Convert.ToDateTime(TextBox4.Text);
            client.SaveEmployee(employee);
            Label5.Text = "Employee saved";
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