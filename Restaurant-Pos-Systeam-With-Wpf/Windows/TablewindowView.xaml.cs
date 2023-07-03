using Restaurant_Pos_Systeam_With_Wpf.Components.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Tables;
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

namespace Restaurant_Pos_Systeam_With_Wpf.Windows
{
    /// <summary>
    /// Interaction logic for TablewindowView.xaml
    /// </summary>
    public partial class TablewindowView : Window
    {
        ITebleRepository _tableRepository;
        
            
        public TablewindowView()
        {
            InitializeComponent();
            _tableRepository = new TableRepository();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CAPASTYTEXTINPUT(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true; // Cancel the input event
                    break;
                }
            }
        }

        

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            await Refresh();
        }
        public async Task Refresh()
        {
            tbCopstyname.Text = string.Empty;
            //tbname.Text = string.Empty;
            wrpTable.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var tables = await _tableRepository.GetAllAsync(paginationParams);
            byte count = 0;
            foreach (var table in tables)
            {
                TableSelectUserControl tableUserControl = new TableSelectUserControl();
                tableUserControl.SetData(table);
                if(table.status.ToString() == "busy")
                    tableUserControl.tableBoreder.Background = new SolidColorBrush(Colors.Red);
                else if(table.status.ToString() == "empty")
                    tableUserControl.tableBoreder.Background= new SolidColorBrush(Colors.Green);
                wrpTable.Children.Add(tableUserControl);
                count++; 
                CatrgoryItemCount.Content = (count).ToString();
            }
        }
    }
}
