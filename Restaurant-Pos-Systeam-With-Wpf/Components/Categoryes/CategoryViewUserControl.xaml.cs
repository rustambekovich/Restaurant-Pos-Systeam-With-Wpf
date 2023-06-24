using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
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

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes
{
    /// <summary>
    /// Interaction logic for CategoryViewUserControl.xaml
    /// </summary>
    public partial class CategoryViewUserControl : UserControl
    {
        AddCategory addCategory = new AddCategory();
        public long Id { get; private set; }
        public CategoryViewUserControl()
        {
            InitializeComponent();
        }

        public void SetData(Category categoryes)
        {
            lbname.Content  = categoryes.Name.ToString();
             Id = categoryes.Id;
        }

        private void ctgComponents_Click(object sender, RoutedEventArgs e)
        { 
        }
    }
}
