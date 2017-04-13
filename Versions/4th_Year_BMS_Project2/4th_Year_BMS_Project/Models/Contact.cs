using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4th_Year_BMS_Project.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordIn { get; set; }
        public int electrical_Circuit_1 { get; set; }
        public int electrical_Circuit_2 { get; set; }
        public int electrical_Circuit_3 { get; set; }
        public int electrical_Circuit_4 { get; set; }
        public int heating_Circuit_1 { get; set; }
        public int heating_Circuit_2 { get; set; }
        public int heating_Circuit_3 { get; set; }
        public int heating_Circuit_4 { get; set; }
        public int door_access { get; set; }


    }
}

