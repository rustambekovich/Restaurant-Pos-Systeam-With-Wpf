using Restaurant_Pos_Systeam_With_Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces.ViewModeles
{
    public interface IOrderItemView : IRepository<OrderItemViewModel, OrderItemViewModel>
    {
        public Task<int> CountById(long id);
    }
}
