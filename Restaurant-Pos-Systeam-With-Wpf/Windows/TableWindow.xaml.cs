using Restaurant_Pos_Systeam_With_Wpf.Components.Categoryes;
using Restaurant_Pos_Systeam_With_Wpf.Components.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
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
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        ITebleRepository _tableRepository;
        public TableWindow()
        {
            _tableRepository  = new TableRepository();
            InitializeComponent();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            TableRes table = new TableRes();

            table.TableNumber = byte.Parse(tbname.Text);
            table.SeatingCapasity = byte.Parse(tbCopstyname.Text);
            table.status = TableStatus.empty;
            var result = await _tableRepository.CreatedAtAsync(table);
            if (result != 0) MessageBox.Show("Susccsesfuly created");
            else MessageBox.Show("Not created");
            await Refresh();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
            tbname.Text = string.Empty;
            wrpTableSet.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var tables = await _tableRepository.GetAllAsync(paginationParams);
            byte count = 0;
            foreach (var table in tables)
            {
                TableUserControl tableUserControl = new TableUserControl();
                tableUserControl.SetData(table);
                wrpTableSet.Children.Add(tableUserControl);
                count++;
                CatrgoryItemCount.Content = (count).ToString();
            }
        } 

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
