using Microsoft.Win32;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Servise.ImageServises;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml.Linq;

namespace Restaurant_Pos_Systeam_With_Wpf.Windows.Updeted
{
    /// <summary>
    /// Interaction logic for ProductItemUpdate.xaml
    /// </summary>
    public partial class ProductItemUpdate : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryReposytory _categoryReposytory;
        private readonly SelectImage selectImage = new SelectImage();

        public long Id { get; set; }
        public Product Product { get; set; }
        public ProductItemUpdate()
        {
            InitializeComponent();
            this._productRepository = new ProductRepository();
            this._categoryReposytory = new CategoryRepository();
        }
        PaginationParams paginationParams = new PaginationParams()
        {
            PageNumber = 1,
            PageSize = 20
        };
        public void SetData(Product product)
        {
            this.Product = product;
            Id= product.Id;
            ltbItm.Text = product.Name;
            string imgPath = product.ImagePath;
            ItmUp.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            // qara
            ItemUpCatogory.ItemsSource = product.cotigory_id.ToString();
            tbPrice.Text = product.Price.ToString();
            rchDesc.Document.Blocks.Clear();
            rchDesc.Document.Blocks.Add(new Paragraph(new Run(product.Description)));
        }
        public async Task Put()
        {
            List<Category> items = new List<Category>();
            var getctg = await _categoryReposytory.GetAllAsync();
            IEnumerable<Category> categorys = getctg;
            ItemUpCatogory.ItemsSource = categorys;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task task = Put();
        }

        private async void saveItem(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = ltbItm.Text;
            product.Description = new TextRange(rchDesc.Document.ContentStart, rchDesc.Document.ContentEnd).Text; ;
            product.Price = float.Parse(tbPrice.Text, CultureInfo.InvariantCulture.NumberFormat);
            string imgPath  = ItmUp.ImageSource.ToString();
            if(!String.IsNullOrEmpty(imgPath))
                product.ImagePath = await CopyImage.CopyImageAsync(imgPath, ContentConst.IMAGE_PATH);
            long selectedValue = Convert.ToInt64(ItemUpCatogory.SelectedValue);
            product.cotigory_id = selectedValue;
            await _productRepository.UpdatedAtAsync(Id,product);
            this.Close();
            AllItem allItem = new AllItem();
            allItem.Show();
        }



        public void btnselectImage(object sender, RoutedEventArgs e)
        {
            var openfileDiolog = selectImage.GetImagrDialog();
            if (openfileDiolog.ShowDialog() == true)
            {
                string imgPath = openfileDiolog.FileName;
                ItmUp.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private void cmbCatogory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
