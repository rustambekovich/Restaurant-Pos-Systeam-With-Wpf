using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
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
        
        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        public void SetData(Products item)
        {
            itemImage.ImageSource =new BitmapImage(new Uri(item.ImagePath, UriKind.Relative));
            List<Products> products = new List<Products>();
            foreach (var product in _productRepository.GetAllAsync())
            {

            }
            /*lbItemName.Content = .;
            lbitemPrise.Content = .Price.ToString();*/

        }
    }
}
