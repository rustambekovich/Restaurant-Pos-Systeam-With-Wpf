using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Category : Auditable
    {
        public string Name { get; set; } = string.Empty;
    }
}
