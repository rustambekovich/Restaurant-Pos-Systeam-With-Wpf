using Restaurant_Pos_Systeam_With_Wpf.Domans.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Table
    {
        [MaxLength(50)]
        public byte TableNumber { get; set; }
        public byte SeatingCapasity { get; set; }
        public TableStatus status { get; set; }
    }
}
