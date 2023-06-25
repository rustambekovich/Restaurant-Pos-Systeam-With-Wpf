using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Components.Items;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
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
using System.Windows.Shapes;

namespace Restaurant_Pos_Systeam_With_Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AllItem.xaml
    /// </summary>
    public partial class AllItem : Window
    {
        private readonly ICategoryReposytory _categoryReposytory;
        private readonly IProductRepository _productRepository;
        public AllItem()
        {
            InitializeComponent();
            this._categoryReposytory = new CategoryRepository();
            this._productRepository = new ProductRepository();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wrpItem.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var categorys = await _categoryReposytory.GetAllAsync(paginationParams);

            foreach (var category in categorys)
            {
                CategoryViewUserControl categoryViewUserControl = new CategoryViewUserControl();
                categoryViewUserControl.Refresh = Refreshasync;
                categoryViewUserControl.SetData(category);/*
                categoryViewUserControl.Refresh = Refreshasync;*/
                wrpItem.Children.Add(categoryViewUserControl);
            }
            await Refreshasync(0);
        }
        public async Task Refreshasync(long categoryId)
        {
            wrpProduct.Children.Clear();
            IList<Product> prdt;
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            if (categoryId == 0)
            {
                prdt = await _productRepository.GetAllAsync(paginationParams);

            }
            else
            {
                prdt = await _productRepository.GetAllByCategoryIdAsync(categoryId);
            }
            foreach (var product in prdt)
            {
                ItemsUserControl itemsUserControl = new ItemsUserControl();
                itemsUserControl.SetData(product);
                wrpProduct.Children.Add(itemsUserControl);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Refreshasync(0);
        }

        private async void allCtg(object sender, RoutedEventArgs e)
        {
            await Refreshasync(0);
        }

        private void addItem(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
            this.Close();

        }
    }
}
