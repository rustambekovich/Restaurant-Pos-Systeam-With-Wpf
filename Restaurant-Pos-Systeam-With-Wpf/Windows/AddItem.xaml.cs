using Microsoft.Win32;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Helpers;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace Restaurant_Pos_Systeam_With_Wpf.Windows;

/// <summary>
/// Interaction logic for AddItem.xaml
/// </summary>
public partial class AddItem : Window
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryReposytory _categoryReposytory;
    public AddItem()
    {
        InitializeComponent();
        this._productRepository = new ProductRepository();
        this._categoryReposytory = new CategoryRepository();
    }

    private void btnImageSelector_Click(object sender, RoutedEventArgs e)
    {

    }
    PaginationParams paginationParams = new PaginationParams()
    {
        PageNumber = 1,
        PageSize = 20
    };

    public  async Task Put()
    {
        List<Category> items = new List<Category>();            
         var getctg = await _categoryReposytory.GetAllAsync(paginationParams);
            IEnumerable<Category> categorys = getctg;
        cmbCatogory.ItemsSource = categorys;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Task task = Put();
    }

    private void btnImgSelect_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = GetImageDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            string imgPath = openFileDialog.FileName;
            ImageItm.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
        }
    }
    private OpenFileDialog GetImageDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
        return openFileDialog;
    }

    private async Task<string> CopyImgAsync(string imgPath, string destinationDirectory)
    {
        if (!Directory.Exists(destinationDirectory))
            Directory.CreateDirectory(destinationDirectory);

        var imageName = ContentGenereteImagePaath.GeneretImagePath(imgPath);

        string path = System.IO.Path.Combine(destinationDirectory, imageName);

        byte[] image = await File.ReadAllBytesAsync(imgPath);

        await File.WriteAllBytesAsync(path, image);

        return path;
    }

    private async void ItemSave_Click(object sender, RoutedEventArgs e)
    {
        Products products = new Products();
        products.Name = ltbItm.Text;
        products.Description = new TextRange(rchDesc.Document.ContentStart, rchDesc.Document.ContentEnd).Text;
        products.Price = float.Parse(tbPrice.Text);
        string ImagePath = ImageItm.ImageSource.ToString();
        if (!String.IsNullOrEmpty(ImagePath))
            products.ImagePath = await CopyImageAsync(ImagePath, ContentConst.IMAGE_PATH);
        
        long selectedValue = Convert.ToInt64(cmbCatogory.SelectedValue);
        products.cotigory_id = selectedValue;
        await _productRepository.CreatedAtAsync(products);
    }

    private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
    {
        if (!Directory.Exists(destinationDirectory))
            Directory.CreateDirectory(destinationDirectory);

        var imageName = ContentGenereteImagePaath.GeneretImagePath(imgPath);

        string path = System.IO.Path.Combine(destinationDirectory, imageName);

        byte[] image = await File.ReadAllBytesAsync(imgPath);

        await File.WriteAllBytesAsync(path, image);

        return path;
    }
}
