using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using Restaurant_Pos_Systeam_With_Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Orders
{
    /// <summary>
    /// Interaction logic for OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderIteam _orderIteam;
        public long id { get; set; }
        public Func<long, Task> RefreshOrderIteam { get; set; }

        private OrderItemViewModel Product  = new OrderItemViewModel();

        public OrderUserControl()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
            this._orderIteam = new OrderIteamRepository();
            Product = new OrderItemViewModel();
        }


        PaginationParams paginationParams = new PaginationParams()
        {
            PageNumber = 1,
            PageSize = 20
        };
        public void SetData(OrderItemViewModel item)
        {
            this.Product = item;
            nameOrder.Content = item.ProductName;
            UntPrice.Content = item.UnitPrice;
            qtyCount.Content = item.Quantity;
            Price.Content = item.Price;
            id = item.Product_id;
            Product = item;
        }

        private async void itemDelete(object sender, RoutedEventArgs e)
        {
            var res = _orderIteam.DeletedAtAsync(id);

            await RefreshOrderIteam(Product.Product_id);
        }
    }
}
