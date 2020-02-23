﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Model
{
    public class User
    {
        public enum SexOfPerson
        {
            Male = 1,
            Female = 2
        }

        private string _FirstName;

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Lengte >4 M 21")]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value.Length > 10)
                    Console.WriteLine("Error! FirstName must be less than 51 characters!");
                else
                    _FirstName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value.Length > 50)
                    Console.WriteLine("Error! LastName must be less than 51 characters!");
                else
                    _LastName = value;
            }
        }

        private string _ID;
        public string ID
        {
            get { return _ID; }
            set
            {
                if (value.Length > 9)
                    Console.WriteLine("Error! ID must be less than 10 characters!");
                else
                    _ID = value;
            }
        }

        private string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        private SexOfPerson _Sex;
        public SexOfPerson Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }


        public User(string id, string firstname, string lastname, string department, SexOfPerson sex)
        {
            FirstName = firstname;
            LastName = lastname;
            ID = id;
            Department = department;
            Sex = sex;
        }
    }
}
