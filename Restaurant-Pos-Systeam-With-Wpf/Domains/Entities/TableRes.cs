using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class TableRes : Auditable
    {
        [MaxLength(50)]
        public byte TableNumber { get; set; }
        public byte SeatingCapasity { get; set; }
        public TableStatus status { get; set; }
    }
}
