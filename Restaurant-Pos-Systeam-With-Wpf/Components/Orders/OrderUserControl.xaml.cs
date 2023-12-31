﻿using Restaurant_Pos_Systeam_With_Wpf.Components.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
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
using System.Security.Cryptography;
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
        public long orderId { get; set; }
        public decimal priceU { get; set; }
        public decimal price { get; set; }
        public Func<long, Task> RefreshOrderIteam { get; set; }

        private OrderItemViewModel Product  = new OrderItemViewModel();

        public OrderUserControl()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
            this._orderIteam = new OrderIteamRepository();
            Product = new OrderItemViewModel();
        }
        public  void SetData(OrderItemViewModel item)
        {
            this.Product = item;
            nameOrder.Content = item.ProductName;
            UntPrice.Content = item.UnitPrice;
            priceU = item.UnitPrice;
            qtyCount.Content = item.Quantity;
            Price.Content = item.Price;
            id = item.Product_id;
            Product = item;
            orderId = item.OrderId;
        }


        private async void itemDelete(object sender, RoutedEventArgs e)
        {
            var ordrid = await _orderIteam.GetByIdAsync(id);
            var res = await _orderIteam.DeletedAtAsync(id);
            var total = await _orderIteam.TootalPriceAllAsync(ordrid.OrderId);
            ((MainWindow)Application.Current.MainWindow).totalPrice = total;
            await ((MainWindow)System.Windows.Application.Current.MainWindow).RefreshOrderIteam(ordrid.OrderId);

            //await RefreshOrderIteam(Product.Product_id);
        }
    }
}
