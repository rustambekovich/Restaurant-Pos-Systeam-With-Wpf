using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Orders : Auditable
    {
        public long CostumerID { get; set; }
        public float TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Table TableID { get; set; }
        public DateTime OerderTime { get; set; }
    }
}
