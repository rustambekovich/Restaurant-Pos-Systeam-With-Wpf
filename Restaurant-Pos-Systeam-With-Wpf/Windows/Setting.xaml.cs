using System.Windows;

namespace Restaurant_Pos_Systeam_With_Wpf.Windows
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void AddCatrgory_Click(object sender, RoutedEventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.ShowDialog();
        }

        private void Close_Setting(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AllItem allItem = new AllItem();
            allItem.ShowDialog();
            this.Close();
            
        }

        private void Table_setting(object sender, RoutedEventArgs e)
        {
            TableWindow tableWindow = new TableWindow();
            tableWindow.ShowDialog();
            this.Close();
        }
    }
}
