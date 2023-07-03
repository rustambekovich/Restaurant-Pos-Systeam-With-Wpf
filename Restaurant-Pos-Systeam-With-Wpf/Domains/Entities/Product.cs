using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Pos_Systeam_With_Wpf.Domans.Entities
{
    public class Product : Auditable
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        [Range(2, 3)]
        public float Price { get; set; }
        public long cotigory_id { get; set; }
    }
}
