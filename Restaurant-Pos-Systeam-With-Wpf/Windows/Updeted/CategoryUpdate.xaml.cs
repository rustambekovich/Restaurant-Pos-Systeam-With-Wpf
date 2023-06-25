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

namespace Restaurant_Pos_Systeam_With_Wpf.Windows.Updeted
{
    /// <summary>
    /// Interaction logic for CategoryUpdate.xaml
    /// </summary>
    public partial class CategoryUpdate : Window
    {
        private readonly ICategoryReposytory _categoryReposytory;
        
        public long Id { get; set; }
        public CategoryUpdate()
        {
            InitializeComponent();
            this._categoryReposytory = new CategoryRepository();
        }
        public void SetData(Category category)
        {

            tbname.Text = category.Name;
            Id = category.Id;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
