using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Components.Items;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Helpers;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
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

            // Timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            // Repositories
            this._categoryReposytory = new CategoryRepository();
            this._productRepository = new ProductRepository();
        }

        // Update current date and time
        private void Timer_Tick(object sender, EventArgs e)
        {
            var currentTime = TimeHelper.GetDateTime();
            dateTextBlock.Text = currentTime.ToString("dd MM yyyy");
            timeTextBlock.Text = currentTime.ToString("HH:mm:ss");
        }

        // Close the application
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Open settings window
        public void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        // Load main window
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wrpCatigory.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };

            var categories = await _categoryReposytory.GetAllAsync(paginationParams);

            foreach (var category in categories)
            {
                CategoryViewUserControl categoryViewUserControl = new CategoryViewUserControl();
                categoryViewUserControl.Refresh = RefreshAsync;
                categoryViewUserControl.SetData(category);
                categoryViewUserControl.Refresh = RefreshAsync;
                wrpCatigory.Children.Add(categoryViewUserControl);
            }

            await RefreshAsync(0);
        }

        // Refresh products based on category
        public async Task RefreshAsync(long categoryId)
        {
            wrpProduct.Children.Clear();
            IList<Product> products;
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };

            if (categoryId == 0)
            {
                products = await _productRepository.GetAllAsync(paginationParams);
            }
            else
            {
                products = await _productRepository.GetAllByCategoryIdAsync(categoryId);
            }

            foreach (var product in products)
            {
                ItemsUserControl itemsUserControl = new ItemsUserControl();
                itemsUserControl.SetData(product);
                wrpProduct.Children.Add(itemsUserControl);
            }
            /*//
            orderItem.Children.Clear();
           
            foreach (var item in products)
            {
                ItemsUserControl itemsUserControl = new ItemsUserControl();
                itemsUserControl.SetData(item);
                orderItem.Children.Add(itemsUserControl);
            }*/
        }

        // Show all categories
        private async void allCtg(object sender, RoutedEventArgs e)
        {
            await RefreshAsync(0);
        }

        /// <summary>
        /// Handles the selection changed event of the DataGrid.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Add your logic here
        }

        /// <summary>
        /// Handles the selection changed event of the DtgMaxsulot.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void DtgMaxsulot_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Add your logic here
        }

        /// <summary>
        /// Handles the click event of the Button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic here
        }
    }
}
