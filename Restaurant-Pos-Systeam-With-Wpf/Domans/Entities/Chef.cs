using Restaurant_Pos_Systeam_With_Wpf.Domans.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Chef : Auditable
    {
        public long EmployeeID { get; set; }
        public long OrdersID { get; set; }
    }
}
