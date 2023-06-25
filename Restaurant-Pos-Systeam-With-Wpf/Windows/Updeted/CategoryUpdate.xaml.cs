using DevExpress.XtraPrinting;
using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
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
        public Category Category { get; set; }
        public  CategoryUpdate()
        {
            InitializeComponent();
            this._categoryReposytory = new CategoryRepository();
        }
        public string CategoryName
        {
            get { return tbname.Text; }
            set { tbname.Text = value; }
        }
        

        

       
        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var courses = await _categoryReposytory.GetAllAsync(new Utils.PaginationParams()
            {
                PageNumber = 1,
                PageSize = 100
            });
        }

        public void SetData(Category catgory)
        {
            this.Category = catgory;
            tbname.Text = Category.Name;
            //Id = catgory.Id;
        }

        private async void Updated_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            category.Name = tbname.Text;
            category.Id = Category.Id; ;
            var res = await _categoryReposytory.UpdatedAtAsync(Category.Id, category);

            if (res > 0)
            {
                MessageBox.Show("Updated");
            }
            else MessageBox.Show("Wrong");
        }
    }
}
