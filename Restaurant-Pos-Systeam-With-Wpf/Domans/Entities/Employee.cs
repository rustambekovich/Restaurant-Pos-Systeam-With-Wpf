using Restaurant_Pos_Systeam_With_Wpf.Domans.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Employee : Auditable
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DataOfBithday { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(15)]
        public string FamilyPhoneNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public Position position { get; set; }

        public string Address { get; set; } = string.Empty;

        public float Salary { get; set; }

    }
}