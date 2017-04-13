using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4th_Year_BMS_Project.Models
{
    public class Users
    {
        public int ContactId { get; }
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