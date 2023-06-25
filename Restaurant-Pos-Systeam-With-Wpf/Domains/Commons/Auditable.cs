using System;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Commons
{
    public class Auditable : BaseEntitiy
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
