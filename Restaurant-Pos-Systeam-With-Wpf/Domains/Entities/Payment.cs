using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Payment : Auditable
    {
        public long OrderID { get; set; }
        public float Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
