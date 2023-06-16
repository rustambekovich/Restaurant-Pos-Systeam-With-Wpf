﻿using Restaurant_Pos_Systeam_With_Wpf.Domans.Commons;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Products : Auditable
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAviable { get; set; } = false;
        public Cotigory cotigory { get; set; }
    }
}
