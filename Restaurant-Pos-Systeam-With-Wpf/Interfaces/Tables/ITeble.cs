using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables
{
    public interface ITebleRepository : IRepository<TableRes, TableRes>
    {
        public  Task<int> UpdatedAtStatusAsync(long id, TableRes entity);

    }
}
