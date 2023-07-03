using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Windows.Updeted;
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
using System.Xml.Linq;
using WPFCustomMessageBox;

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Tables
{
    /// <summary>
    /// Interaction logic for TableUserControl.xaml
    /// </summary>
    public partial class TableUserControl : UserControl
    {
        public TableRes Tableres = new TableRes();
        private readonly ITebleRepository _tableRepository;
        public long Id { get; set; }

        public Func<long, Task> Refresh { get; set; }
        public TableUserControl()
        {
            _tableRepository = new TableRepository();
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TableUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }
        public void SetData(TableRes tableRes)
        {
            tablenum.Content = tableRes.TableNumber;
            Id = tableRes.Id;
            tablCapasty.Content = tableRes.SeatingCapasity;
            Tableres = tableRes;
        }


        private void tableSet(object sender, RoutedEventArgs e)
        {
           // var result = CustomMessageBox.ShowYesNoCancel("Are you sure you want to eject the nuclear fuel rods?", "Confirm Fuel Ejection", "Deleted", "Update", "Canel");
            /*switch (0)
            {
                case MessageBoxResult.Yes:
                    delet();
                    break;
                case MessageBoxResult.No:
                    Update();

                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("bekor");

                    break;
                default:
                    MessageBox.Show("ishlamadi");
                    break;
            }*/
        }

        public void Update()
        {
            TableUpdate tableUpdate = new TableUpdate();
            tableUpdate.SetData(Tableres);
            tableUpdate.Show();
        }

        public async void delet()
        {
            MessageBoxResult result = MessageBox.Show($"Are you shure Delete  {tablenum.Content} Table?", "Worning!!", MessageBoxButton.YesNo);
            bool answer = (result == MessageBoxResult.Yes);
            if (answer)
            {
                var res = await _tableRepository.DeletedAtAsync(Id);
                if (res != 0)
                {

                    MessageBox.Show($"Succsefuly {tablenum.Content} Deleted.");



                }
                else MessageBox.Show("Don't deleted");
            }
        }

        private void editTable(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteTable(object sender, RoutedEventArgs e)
        {
            delet();
        }
    }
}
