using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Payment : Auditable
    {
        public long OrderID { get; set; }
        public float Amount { get; set; }
        public long CostumerId { get; set; }
        public long EmployeeId { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
