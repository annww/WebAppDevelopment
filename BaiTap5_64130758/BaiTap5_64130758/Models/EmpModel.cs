using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap5_64130758.Models
{
    public class EmpModel
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Avatar { get; set; }
    }
}