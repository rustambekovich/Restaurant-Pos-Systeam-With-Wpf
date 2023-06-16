using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Commons
{
    public class Auditable : BaseEntitiy
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
