using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using Restaurant_Pos_Systeam_With_Wpf.Windows.Updeted;
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
using System.Xml.Linq;
using WPFCustomMessageBox;

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Items
{
    /// <summary>
    /// Interaction logic for SetItemUserControl.xaml
    /// </summary>
    public partial class SetItemUserControl : UserControl
    {
        public Func<long, Task> Refresh { get; set; }
        private readonly IProductRepository _ItemproductRepository;
        private Product Product { get; set; }
        public long id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SetItemUserControl()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            this._ItemproductRepository= new ProductRepository();
            Product = new Product();
        }
       

        
        public void SetData(Product item)
        {
            itemImage.ImageSource = new BitmapImage(new Uri(item.ImagePath, UriKind.Relative));
           // IList<Product> Products = new List<Product>();
            lbItemName.Content = item.Name;
            lbitemPrise.Content = item.Price;
           
            id = item.Id;
            Product = item;

        }
        private void SetUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = CustomMessageBox.ShowYesNoCancel("Are you sure you want to eject the nuclear fuel rods?", "Confirm Fuel Ejection", "Deleted", "Update", "Canel");
            switch (result)
            {
                case MessageBoxResult.Yes:
                    delet();
                    break;
                case MessageBoxResult.No:
                    Update();

                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("bekor");

                    break;
                default:
                    MessageBox.Show("ishlamadi");
                    break;
            }

        }
        public void Update()
        {
            ProductItemUpdate productItemUpdate = new();
            productItemUpdate.SetData(Product);
            productItemUpdate.Show();
        }

        public async void delet()
        {
            MessageBoxResult result = MessageBox.Show($"Are you shure Delete {lbItemName.Content} category?", "Worning!!", MessageBoxButton.YesNo);
            bool answer = (result == MessageBoxResult.Yes);
            if (answer)
            {
                var res = await _ItemproductRepository.DeletedAtAsync(id);
                if (res != 0)
                {

                    MessageBox.Show($"Succsefuly {lbItemName.Content} Deleted.");



                }
                else MessageBox.Show("Don't deleted");
            }
        }
    }
}
