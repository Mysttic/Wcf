using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee(int Id)
        {
            Employee employee = null;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = Id;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((EmployeeType)reader["EmployeeType"] == EmployeeType.FullTimeEmployee)
                    {
                        employee = new FullTimeEmployee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            AnnualSalary = Convert.ToInt32(reader["AnnualSalary"]),
                            EmployeeType = EmployeeType.FullTimeEmployee
                        };
                    }
                    else
                    {
                        employee = new PartTimeEmployee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            HourlyPay = Convert.ToInt32(reader["HourlyPay"]),
                            HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                            EmployeeType = EmployeeType.PartTimeEmployee
                        };
                    }
                }
            }
            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = employee.Id;
                cmd.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@Name";
                parameterName.Value = employee.Name;
                cmd.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter();
                parameterGender.ParameterName = "@Gender";
                parameterGender.Value = employee.Gender;
                cmd.Parameters.Add(parameterGender);

                SqlParameter parameterDateOfBirth = new SqlParameter();
                parameterDateOfBirth.ParameterName = "@DateOfBirth";
                parameterDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterEmployeeType = new SqlParameter();
                parameterEmployeeType.ParameterName = "@EmployeeType";
                parameterEmployeeType.Value = employee.EmployeeType;
                cmd.Parameters.Add(parameterEmployeeType);

                if (employee.GetType() == typeof(FullTimeEmployee))
                {
                    SqlParameter parameterAnnualSalary = new SqlParameter();
                    parameterAnnualSalary.ParameterName = "@AnnualSalary";
                    parameterAnnualSalary.Value = ((FullTimeEmployee)employee).AnnualSalary;
                    cmd.Parameters.Add(parameterAnnualSalary);
                }
                else if (employee.GetType() == typeof(PartTimeEmployee))
                {
                    SqlParameter parameterHourlyPay = new SqlParameter();
                    parameterHourlyPay.ParameterName = "@HourlyPay";
                    parameterHourlyPay.Value = ((PartTimeEmployee)employee).HourlyPay;
                    cmd.Parameters.Add(parameterHourlyPay);

                    SqlParameter parameterHoursWorked = new SqlParameter();
                    parameterHoursWorked.ParameterName = "@HoursWorked";
                    parameterHoursWorked.Value = ((PartTimeEmployee)employee).HoursWorked;
                    cmd.Parameters.Add(parameterHoursWorked);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int Id)
        {
            throw new NotImplementedException();
        }
    }
}