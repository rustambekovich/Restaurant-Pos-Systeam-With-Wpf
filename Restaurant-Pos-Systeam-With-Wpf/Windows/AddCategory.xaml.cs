using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant_Pos_Systeam_With_Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private readonly ICategoryReposytory _categoryReposytory;
        public AddCategory()
        {
            InitializeComponent();
            this._categoryReposytory = new CategoryRepository();
        }
        public string CategoryName
        {
            get { return tbname.Text; }
            set { tbname.Text = value; }
        }
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {

            Category category = new Category();
            if (tbname.Text.Length > 0)
            {

                category.Name = tbname.Text;
               await _categoryReposytory.DeletedBynameAtAsync(tbname.Text); 
            }
            else
            {
                MessageBox.Show("Complate Category");

            }
            Refresh();
        }
        public long Id { get; set; }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            if (tbname.Text.Length > 0)
            {

                category.Name = tbname.Text;
                var result = await _categoryReposytory.CreatedAtAsync(category);
                if (result > 0)
                    MessageBox.Show("Succselfull"); 
                else MessageBox.Show("wrong");
            }
            else
            {
                MessageBox.Show("Complate Category");

            }
           await Refresh();
        }

        public async Task Refresh()
        {

            tbname.Text = string.Empty;
            wrpCatigory.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var categorys = await _categoryReposytory.GetAllAsync(paginationParams);
            byte count = 0;
            foreach (var category in categorys)
            {
                AllCotegoryUserControl allCotegoryUserControl = new AllCotegoryUserControl();
                allCotegoryUserControl.SetData(category);
                wrpCatigory.Children.Add(allCotegoryUserControl);
                count++;
                CatrgoryItemCount.Content = (count).ToString();
            }
            lbcharectr.Content = (50).ToString();
        }
        public  async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           await Refresh();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            lbcharectr.Content = (50 - text.Length).ToString();
            if (text.Length > 50)
            {

                textBox.Text = text.Substring(50, 0);
                textBox.CaretIndex = 50;
            }
        }

        public  void setTb(string text)
        {
            tbname.Text = text;
        }

        public void ClosePage()
        {
            this.Hide();
        }
    }
}
