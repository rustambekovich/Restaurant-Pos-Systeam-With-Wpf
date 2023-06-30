using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class OrderIteam : Auditable
    {
        public long OrderId { get; set; }
        public long ProductID { get; set; }
        public byte Quantity { get; set; }
        public float Price { get; set; }
    }
}
