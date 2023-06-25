using DevExpress.XtraEditors.DXErrorProvider;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using Restaurant_Pos_Systeam_With_Wpf.Windows.Updeted;
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
        private Category Category { get; set; }
        public long Id { get; private set; }
        public AllCotegoryUserControl()
        {
            InitializeComponent();
            this._categoryReposytory = new CategoryRepository();
            Category = new Category(); 
        }
        AddCategory addCategory = new AddCategory();

        public void SetData(Category categoryes)
        { 
            //this.Category = categoryes;
            lbname.Content = categoryes.Name;
            Id = categoryes.Id;
            Category = categoryes;
        }
        /// <summary>
        /// Deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        private void AddCotegoryUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = CustomMessageBox.ShowYesNoCancel("Are you sure you want to eject the nuclear fuel rods?","Confirm Fuel Ejection","Deleted", "Update", "Canel");
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
        public  void  Update()
        {

            CategoryUpdate categoryUpdate = new CategoryUpdate();
            categoryUpdate.SetData(Category);
            CategoryUpdate updatecategoryUpdate = new CategoryUpdate();
            updatecategoryUpdate.Show();
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

        private void get_catg(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
