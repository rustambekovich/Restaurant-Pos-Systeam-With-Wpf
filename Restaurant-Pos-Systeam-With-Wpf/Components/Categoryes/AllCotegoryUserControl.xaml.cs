using DevExpress.XtraEditors.DXErrorProvider;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCustomMessageBox;

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes
{
    /// <summary>
    /// Interaction logic for AllCotegoryUserControl.xaml
    /// </summary>
    public partial class AllCotegoryUserControl : UserControl
    {
        private readonly ICategoryReposytory _categoryReposytory;
        public long Id { get; private set; }
        public AllCotegoryUserControl()
        {
            InitializeComponent();
            this._categoryReposytory = new CategoryRepository();
        }
        AddCategory addCategory = new AddCategory();

        public void SetData(Category categoryes)
        {

            lbname.Content = categoryes.Name.ToString();
            Id = categoryes.Id;
        }

        private async void ctgComponents_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show($"Are you shure Delete {lbname.Content} category?", "Worning!!", MessageBoxButton.YesNo);
            bool answer = (result == MessageBoxResult.Yes);
            if (answer)
            {
                var res = await _categoryReposytory.DeletedAtAsync(Id);
                if (res != 0)
                {

                    MessageBox.Show($"Succsefuly {lbname.Content} Deleted.");
                }
                else MessageBox.Show("Don't deleted");
            }
        }

        private void CrudctgComponents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void get_catg(object sender, MouseButtonEventArgs e)
        {

        }

        private void edit_ctg(object sender, RoutedEventArgs e)
        {


        }


        private void AddCotegoryUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = CustomMessageBox.ShowYesNoCancel("Are you sure you want to eject the nuclear fuel rods?","Confirm Fuel Ejection","Update","Deleted","Canel");
            switch (result)
            {
                case MessageBoxResult.Yes:
                    delet();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Updated");

                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("bekor");

                    break;
                default:
                    MessageBox.Show("ishlamadi");
                    break;
            }

        }


        public async void delet()
        {
            MessageBoxResult result = MessageBox.Show($"Are you shure Delete {lbname.Content} category?", "Worning!!", MessageBoxButton.YesNo);
            bool answer = (result == MessageBoxResult.Yes);
            if (answer)
            {
                var res = await _categoryReposytory.DeletedAtAsync(Id);
                if (res != 0)
                {

                    MessageBox.Show($"Succsefuly {lbname.Content} Deleted.");


                }
                else MessageBox.Show("Don't deleted");
            }
        }
    }
}
