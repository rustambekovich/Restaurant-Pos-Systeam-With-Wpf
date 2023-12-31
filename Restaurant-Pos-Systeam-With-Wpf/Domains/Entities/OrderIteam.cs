﻿using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class OrderIteam : Auditable
    {
        public long OrderId { get; set; }
        public long ProductID { get; set; }
        public byte Quantity { get; set; }
        //[Range(2, 3)]
        public double Price { get; set; }
    }
}
