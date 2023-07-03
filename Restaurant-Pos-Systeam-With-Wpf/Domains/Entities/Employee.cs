using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
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
        public string image_path { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public Position position { get; set; }

        public string Address { get; set; } = string.Empty;
        [Range(2, 3)]
        public decimal Salary { get; set; }

    }
}