using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes
{
    /// <summary>
    /// Interaction logic for CategoryViewUserControl.xaml
    /// </summary> 
    public partial class CategoryViewUserControl : UserControl
    {
        public Func<long, Task> Refresh { get; set; } 
        private  Category category = new Category();
        public long Id { get; private set; }
        public CategoryViewUserControl()
        {
            InitializeComponent();
        }

        public void SetData(Category categoryes)
        {
            this.category  = categoryes;
            lbname.Content = categoryes.Name.ToString();
            Id = categoryes.Id;
        }
 

        private async void ctgComponents_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Refresh(category.Id);
        }
    }
}
