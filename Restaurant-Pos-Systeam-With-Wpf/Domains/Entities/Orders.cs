using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Order : Auditable
    {
        public long CostumerID { get; set; }
        public long EmployeID { get; set; }
        public float TotalAmount { get; set; }
        public OrderStatus Ordertatus { get; set; }
        public long TableID { get; set; }
    }
}
