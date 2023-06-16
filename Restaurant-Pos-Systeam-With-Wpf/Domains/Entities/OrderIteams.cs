using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class OrderIteams : Auditable
    {
        public long OrderId { get; set; }
        public long ProductID { get; set; }
        public byte Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
