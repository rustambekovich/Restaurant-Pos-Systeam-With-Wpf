using PdfSharp.Drawing;
using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Components.Items;
using Restaurant_Pos_Systeam_With_Wpf.Components.Orders;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Helpers;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.ViewModeles;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.ViewModeles;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using static System.Net.Mime.MediaTypeNames;
using PdfSharp.Drawing.Layout;
using Restaurant_Pos_Systeam_With_Wpf.Components.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Orderes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Orderes;

namespace Restaurant_Pos_Systeam_With_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly ICategoryReposytory _categoryReposytory;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemView _orderItemView;
        private readonly IOrderIteam _orderIteam;
        private readonly ITebleRepository _tebleRepository;
        private readonly IOrder _order1;
        public long orderId { get;  set; }

        public MainWindow()
        {
            InitializeComponent();
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            // Repositories
            this._tebleRepository = new TableRepository();
            this._orderItemView = new ViewModelRepository();
            this._categoryReposytory = new CategoryRepository();
            this._productRepository = new ProductRepository();
            this._order1 = new OrderRepository();
            this._orderIteam = new OrderIteamRepository();
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
            //Application.Current.Shutdown();
            this.Close();
        }

        // Open settings window
        public void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
        //string a = TableSelectUserControl.Box.Text;
        
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
           // await RefreshOrderIteam(0);
        }

        public async Task RefreshTablechangeAsync(long id)
        {
            orderItem.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };

            if (id !=0)
            {
                var getitem = await _orderItemView.GetByIdAllAsync(id);
                foreach (var item in getitem)
                {
                    OrderUserControl orderUserControl = new OrderUserControl();
                    orderUserControl.SetData(item);
                    orderUserControl.RefreshOrderIteam = RefreshOrderIteam;

                    orderItem.Children.Add(orderUserControl);
                }
            }
           
        }

        //long dt = long.Parse(TableSelectUserControl.Box.Text);
        public  async Task RefreshOrderIteam(long id)
        {
            //Task<List<OrderIteam>> orderviews = new List<OrderIteam>();
            orderItem.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };

            if (id == 0)
            {
                //MessageBox.Show("va vav va");
            }
            else if (id > 0)
            {
                // var tableres = await _tebleRepository.GetAllAsync(paginationParams);
                var getitem = await _orderItemView.GetByIdAllAsync(id);
                foreach (var item in getitem)
                {
                    OrderUserControl orderUserControl = new OrderUserControl();
                    orderUserControl.SetData(item);
                    orderUserControl.RefreshOrderIteam = RefreshOrderIteam;

                    orderItem.Children.Add(orderUserControl);
                }
            }

            /*orderItem.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };

            if (id != 0)
            {
                var getitem = await _orderItemView.GetByIdAllAsync(id);
                foreach (var item in getitem)
                {
                    OrderUserControl orderUserControl = new OrderUserControl();
                    orderUserControl.SetData(item);
                    orderUserControl.RefreshOrderIteam = RefreshOrderIteam;

                    orderItem.Children.Add(orderUserControl);
                }
            }*/
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
                itemsUserControl.RefreshOrderIteam = RefreshOrderIteam;
                itemsUserControl.SetData(product);
                itemsUserControl.RefreshOrderIteam = RefreshOrderIteam;
                wrpProduct.Children.Add(itemsUserControl);
            }
            //
            
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
            TablewindowView tablewindowView = new TablewindowView();
            tablewindowView.Show();



        }

        private async void deleteAllItem(object sender, RoutedEventArgs e)
        {
            var res = await _orderIteam.DeletedAtALlItemAsync();
            await RefreshOrderIteam(0);
        }

        private async void Progress(object sender, RoutedEventArgs e)
        {
            var idOrder = long.Parse(TableSelectUserControl.Box.Text);
            orderItem.Children.Clear();
            Order order = new Order();
            order.Ordertatus = OrderStatus.InProgress;
            await _order1.UpdatedAtAsync(idOrder, order);

        }

        private async void PayentOrder(object sender, RoutedEventArgs e)
        {
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var orderviews = await _orderItemView.GetAllAsync(paginationParams);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

            XFont font = new("Arial", 20);

            /*XTextFormatter tf = new XTextFormatter(gfx);
            XRect rect = new XRect(40, 100, 400, 220);

            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.DrawString($"{dateTextBlock.Text} {timeTextBlock.Text}\n", font, XBrushes.Black, rect);
*/
            //------------------------------

            string[] data =
            {

            };

            string[] foodItems = {
            "Burger",
            "Pizza",
            "Salad",
            "Pasta",
            "Steak"
             };

            // Set the starting position
            double x = 50;
            double y = 50;

            // Draw the food items on the page
            gfx.DrawString($"-------------------------------------------------------------", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            gfx.DrawString($"Able Dev", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 15;
            x += 90;
            gfx.DrawString($"post sisteam", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            x -= 90;
            gfx.DrawString($"-------------------------------------------------------------", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            gfx.DrawString($"{dateTextBlock.Text} {timeTextBlock.Text}", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            gfx.DrawString($"Items", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            x += 200;
            gfx.DrawString($"Qty", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            x += 100;
            gfx.DrawString($"Price", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            x -= 300;
            gfx.DrawString($"=============================================================", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;

            decimal total = 0;

            foreach (var foodItem in orderviews)
            {
                gfx.DrawString($"{foodItem.ProductName}", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);

                // y += 25;  // Increase the y-coordinate for the next line            gfx.DrawString($"{dateTextBlock.Text} {timeTextBlock.Text}\n", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
                x += 200;
                gfx.DrawString($"{foodItem.Quantity}", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
                x += 100;
                gfx.DrawString($"{foodItem.Price}", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
                x -= 300;
                y += 25;
                total += foodItem.Price;
            }
            y += 25;
            gfx.DrawString($"Total:", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            x+= 300;
            gfx.DrawString($"${total}", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            x -= 300;
            y += 25;
            gfx.DrawString($"-------------------------------------------------------------", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            gfx.DrawString($"Thank you", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopCenter);
            y += 25;
            gfx.DrawString($"-------------------------------------------------------------", font, XBrushes.Black, new XRect(x, y, page.Width, page.Height), XStringFormats.TopLeft);
            y += 25;
            /*//tf.DrawString("Firstlusdvcd \nline\nSecond \nline", font, XBrushes.Black, rect);

            */
            /*float allprice = 0;



            foreach (var item in orderviews)
            {
                allprice += item.Price;
                tf.DrawString($"{item.ProductName}/t/t{item.Quantity}/t/t{item.UnitPrice}", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.TopLeft);
            }
            tf.DrawString($"All price:{allprice}", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.TopLeft);

            tf.DrawString($"{dateTextBlock.Text}/t{timeTextBlock.Text}/n------------------------------------------", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.TopLeft);

            string filename = "FirstPdf.pdf";

            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);
            string text = "Asssalomu alaykum/r/nVa alaykum assalom";
            XRect rect = new XRect(40, 100, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.Default);*/
            document.Save($"D:\\test\\test_{Guid.NewGuid().ToString()}.pdf");

            

        }

        
    }
}
