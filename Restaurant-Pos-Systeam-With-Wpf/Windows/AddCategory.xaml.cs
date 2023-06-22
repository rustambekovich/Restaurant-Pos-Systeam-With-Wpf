using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
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
using System.Windows.Shapes;

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
            this._categoryReposytory= new CategoryRepository();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            category.Name = tbname.Text;
            var result = await _categoryReposytory.CreatedAtAsync(category);
            if (result > 0)
                MessageBox.Show("Succselfull");
            else MessageBox.Show("wrong");
        }
    }
}
