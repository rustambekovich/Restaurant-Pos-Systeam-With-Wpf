using Restaurant_Pos_Systeam_With_Wpf.Domans.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Products : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAviable { get; set; } = false;
        public Cotigory cotigory { get; set; }
    }
}
