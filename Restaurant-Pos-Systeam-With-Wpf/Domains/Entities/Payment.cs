using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Payment : Auditable
    {
        public long OrderID { get; set; }
        [Range(2, 3)]
        public float Amount { get; set; }
        public long CostumerId { get; set; }
        public long EmployeeId { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
