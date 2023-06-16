using Restaurant_Pos_Systeam_With_Wpf.Domans.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Employee : Auditable
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime DataOfBithday { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string FamilyPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Position WherePosition { get; set; }
        public float Salary { get; set; }

    }
}