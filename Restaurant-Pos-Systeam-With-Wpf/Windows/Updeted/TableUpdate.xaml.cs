using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Servise.ImageServises;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for TableUpdate.xaml
    /// </summary>
    public partial class TableUpdate : Window
    {
        private readonly ITebleRepository _tableRepository;
        private readonly SelectImage selectImage = new SelectImage();

        public long Id { get; set; }
        public TableRes TableRes{ get; set; }
        public TableUpdate()
        {
            _tableRepository = new TableRepository();
            InitializeComponent();
        }

        PaginationParams paginationParams = new PaginationParams()
        {
            PageNumber = 1,
            PageSize = 20
        };
        public void SetData(TableRes table)
        {
            this.TableRes = table;
            Id = table.Id;
            tbnameUp.Text = (table.TableNumber).ToString();
            tbCopstynameUP.Text = (table.SeatingCapasity).ToString();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //
        }

        private void CAPASTYTEXTINPUT(object sender, TextCompositionEventArgs e)
        {
            //
        }

        private async void Save_ClickUP(object sender, RoutedEventArgs e)
        {
            TableRes table = new TableRes();
            table.TableNumber = byte.Parse(tbnameUp.Text);
            table.SeatingCapasity = byte.Parse(tbCopstynameUP.Text);
            var res = await _tableRepository.UpdatedAtAsync(Id, table);

            if (res > 0) MessageBox.Show("UpdateDefaultStyle Table");
            else MessageBox.Show("Worning");
            this.Close();
            /*TableWindow tableWindow = new TableWindow();
            tableWindow.Show();*/
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
