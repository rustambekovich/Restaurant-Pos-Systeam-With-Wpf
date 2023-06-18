using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Costumer : Auditable
    {
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
