﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    //[KnownType(typeof(FullTimeEmployee))]
    //[KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace = "http://pragimtech.com/Employee")]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;
        private DateTime _dateOfBirth;
        private EmployeeType employeeType;

        [DataMember(Order = 0)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Order = 1)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(Order = 2)]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        [DataMember(Order = 3)]
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        [DataMember(Order = 4)]
        public EmployeeType EmployeeType
        {
            get => employeeType;
            set => employeeType = value;
        }
    }
}