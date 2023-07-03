using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Costumer : Auditable
    {
        public string name { get; set; } = "Guest";
        //public int count { get; set; }
        public long TableId { get; set; }
    }
}
