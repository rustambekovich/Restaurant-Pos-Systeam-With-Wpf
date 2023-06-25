using Restaurant_Pos_Systeam_With_Wpf.Domains.Commons;

namespace Restaurant_Pos_Systeam_With_Wpf.Domains.Entities
{
    public class Category : Auditable
    {
        public string Name { get; set; } = string.Empty;
    }
}
