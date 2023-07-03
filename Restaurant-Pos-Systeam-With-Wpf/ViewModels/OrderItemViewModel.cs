using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.ViewModels
{
    public class OrderItemViewModel
    {
        public long Quantity { get; set; }
        [Range(18, 2)]
        public decimal Price { get; set; }
        [Range(18, 2)]
        public decimal UnitPrice { get; set; }
        public long Product_id { get; set; }
        //public int OrderId { get; set; } = 0;
        public string ProductName { get; set; } = string.Empty;
        public long OrderId { get; set; }
    }
}
