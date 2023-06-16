using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Enums
{
    public enum OrderStatus
    {
        New,  // Yangi buyruq
        InProgress,  // Ish jarayonida
        Completed,  // Yakunlangan
        Canceled  // Bekor qilingan
    }

}
