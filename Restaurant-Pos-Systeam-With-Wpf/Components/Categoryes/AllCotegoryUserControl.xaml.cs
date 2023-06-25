using DevExpress.XtraEditors.DXErrorProvider;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            MessageBoxResult result = MessageBox.Show("Are you shure Delete this category?", "Worning!!", MessageBoxButton.YesNo);
            bool answer = (result == MessageBoxResult.Yes);
            if (answer)
            {
                var res = await _categoryReposytory.DeletedAtAsync(Id);
                if (res != 0)
                {

                    MessageBox.Show("Succsefuly Deleted.");// Boshqa Windowdan AddCategory oynasini yaratish
                    AddCategory addCategoryWindow = new AddCategory();

                    // AddCategory oynasidagi Refresh metodini chaqirish
                    await addCategoryWindow.Refresh();
                    addCategory.Window_Loaded(sender, e);
                    //  addCategory.ClosePage();
                    //   Setting setting   = new Setting();
                    //  setting.AddCatrgory_Click(sender, e);
                }
                else MessageBox.Show(ErrorType.Information.ToString());
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
    }
}
