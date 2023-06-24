using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Components.Items;
using Restaurant_Pos_Systeam_With_Wpf.Helpers;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
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
using System.Windows.Threading;

namespace Restaurant_Pos_Systeam_With_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICategoryReposytory _categoryReposytory;
        private readonly IProductRepository _productRepository;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer.Tick += Timer_Tick;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            timer.Start();
            this._categoryReposytory = new CategoryRepository();
            this._productRepository = new ProductRepository();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            var currentTime = TimeHelper.GetDateTime();
            dateTextBlock.Text = currentTime.ToString("dd MM yyyy");
            timeTextBlock.Text = currentTime.ToString("HH:mm:ss");
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        public void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

       public async Task Refresh()
       {
            wrpCatigory.Children.Clear();
            wrpProduct.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var categorys = await _categoryReposytory.GetAllAsync(paginationParams);

            foreach (var category in categorys)
            {
                CategoryViewUserControl categoryViewUserControl = new CategoryViewUserControl();
                categoryViewUserControl.SetData(category);
                wrpCatigory.Children.Add(categoryViewUserControl);
            }

            var products = await _productRepository.GetAllAsync(paginationParams);
            foreach (var product in products)
            {
                ItemsUserControl itemsUserControl = new ItemsUserControl();
                itemsUserControl.SetData(product);
                wrpProduct.Children.Add(itemsUserControl);
            }
        }
    }
}
