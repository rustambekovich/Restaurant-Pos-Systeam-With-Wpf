using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
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
        public long id { get; set; }
        public ItemsUserControl()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
        }

        private async void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
        PaginationParams paginationParams = new PaginationParams()
        {
            PageNumber = 1,
            PageSize = 20
        };
        public async void SetData(Product item)
        {
            itemImage.ImageSource = new BitmapImage(new Uri(item.ImagePath, UriKind.Relative));
            IList<Product> Products = new List<Product>();
            Products = await _productRepository.GetAllAsync(paginationParams);
            foreach (var product in Products)
            {
                lbItemName.Content = product.Name;
                lbitemPrise.Content = product.Price;
            }
            /*lbItemName.Content = .;
            lbitemPrise.Content = .Price.ToString();*/

        }
    }
}
