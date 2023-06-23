using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            Category category = new Category();

            _categoryReposytory.DeletedAtAsync(tbname.Text);
            Refresh();
        }
        public long Id { get; set; }
        public async void put(string lbname, long id)
        {
            tbname.Text = Name;
            Id = id;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            if(tbname.Text.Length > 0 ) 
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
            Refresh();
        }

        private async void Refresh()
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
                CategoryViewUserControl categoryViewUserControl = new CategoryViewUserControl();
                categoryViewUserControl.SetData(category);
                wrpCatigory.Children.Add(categoryViewUserControl);
                count++;
                CatrgoryItemCount.Content = (count).ToString();
            }
            lbcharectr.Content = (50).ToString();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           Refresh();
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

    }
}
