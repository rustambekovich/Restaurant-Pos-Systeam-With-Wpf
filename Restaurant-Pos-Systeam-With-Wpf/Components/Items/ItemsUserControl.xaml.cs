using Restaurant_Pos_Systeam_With_Wpf.Components.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Items
{
    /// <summary>
    /// Interaction logic for ItemsUserControl.xaml
    /// </summary>
    public partial class ItemsUserControl : UserControl
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderIteam _orderIteam;
        public Func<long, Task> RefreshOrderIteam { get; set; }
        public long id { get; set; }
        private Product Product { get; set; }
        public ItemsUserControl()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
            _orderIteam = new OrderIteamRepository();
            Product = new Product();
        }

        PaginationParams paginationParams = new PaginationParams()
        {
            PageNumber = 1,
            PageSize = 20
        };
        public  void SetData(Product item)
        {
            itemImage.ImageSource = new BitmapImage(new Uri(item.ImagePath, UriKind.Relative));
            lbItemName.Content = item.Name;
            lbitemPrise.Content = item.Price;
            Product = item;
        }

        private async void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrderIteam orderIteam = new OrderIteam();
            orderIteam.ProductID = Product.Id;
            orderIteam.Quantity = 1;
            orderIteam.Price = Product.Price;
            var idOrder =  TableSelectUserControl.Box.Text;
            if(idOrder != "")
            {
                orderIteam.OrderId = long.Parse(idOrder);
                orderIteam.OrderId = long.Parse(idOrder);
                var  res  = await _orderIteam.CreatedAtAsync(orderIteam);
                var result = long.Parse(idOrder);
                var total = await _orderIteam.TootalPriceAllAsync(result);
                ((MainWindow)Application.Current.MainWindow).totalPrice = total;
                await ((MainWindow)System.Windows.Application.Current.MainWindow).RefreshOrderIteam(result);
            }
            else
            {
                MessageBox.Show("Tabl tanlanmagan, Table tanlang!! ", "Information");
            }

        }
    }
}
