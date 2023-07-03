using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Costumeres;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Orderes;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.COstumeres;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Orderes;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Repositories.Tables;
using Restaurant_Pos_Systeam_With_Wpf.ViewModels;
using Restaurant_Pos_Systeam_With_Wpf.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Security.Cryptography;
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

namespace Restaurant_Pos_Systeam_With_Wpf.Components.Tables
{
    /// <summary>
    /// Interaction logic for TableSelectUserControl.xaml
    /// </summary>
    public partial class TableSelectUserControl : UserControl
    {
        public Func<long, Task> RefreshOrderIteam { get; set; }
        public Func<long, Task> RefreshTablechange { get; set; }
        public long orderId { get; set; }
        public TableRes Tableres = new TableRes();
        public Order order = new Order();
        private readonly ITebleRepository _tableRepository;
        private readonly ICostumer _costumer;
        private readonly IOrder _order;
        private readonly IOrderIteam _orderIteam;

        public static TextBox Box = new TextBox();

        public long Id { get; set; }

        public Func<long, Task> Refresh { get; set; }
        public Costumer Costumer { get; set; }
        private TableRes TableRes { get; set; }
        public TableSelectUserControl()
        {
            InitializeComponent();
            this._costumer = new CostumerRepository();
            this._tableRepository = new TableRepository();
            this._order = new OrderRepository();
            this._orderIteam = new OrderIteamRepository();
            TableRes= new TableRes();

        }
        public void SetData(TableRes tableRes)
        {
            tablenum.Content = tableRes.TableNumber;
            Id = tableRes.Id;
            tablCapasty.Content = tableRes.SeatingCapasity;
            TableRes = tableRes;
        }

        private async  void TableUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if(TableRes.status.ToString() != "busy")
            {
                Costumer costumer = new Costumer();
                costumer.TableId = TableRes.Id;
                this.tableBoreder.Background = new SolidColorBrush(Colors.Red);
                Tableres.TableNumber = TableRes.TableNumber;
                Tableres.SeatingCapasity = TableRes.SeatingCapasity;

                Tableres.status = TableStatus.busy;
                await _costumer.CreatedAtAsync(costumer);
                await _tableRepository.UpdatedAtAsync(Id, Tableres);
                var res = await _costumer.GetByIdAsync(TableRes.Id);
                Order order = new Order();
                order.TableID = TableRes.Id;
                order.CostumerID = res.Id;
                order.CreatedAt = DateTime.Now;
                order.EmployeID = 1;
                order.TotalAmount = 0;
                order.Ordertatus = OrderStatus.New;
                var jav = await _order.CreatedAtAsync(order);
                var result = await _order.GetByIdAsync(order.TableID);
                Box.Text = result.Id.ToString();
                orderId = result.Id;
                ((MainWindow)Application.Current.MainWindow).orderIdPay = orderId;
                //await ((TablewindowView)System.Windows.Application.Current.MainWindow).CloseedWin();


                //_ = ((MainWindow)System.Windows.Application.Current.MainWindow).RefreshOrderIteam(orderId);

            }
            else if(TableRes.status.ToString() == "busy")
            {
                var odid = await _order.GetById(TableRes.Id);
                MainWindow mainWindow = GetMainWindow();
                mainWindow.orderId = odid;
                Box.Text = odid.ToString();
                var total = await _orderIteam.TootalPriceAllAsync(odid);
                ((MainWindow)Application.Current.MainWindow).orderIdPay = odid;
                ((MainWindow)Application.Current.MainWindow).status = TableRes.status.ToString();
                ((MainWindow)Application.Current.MainWindow).tableid = TableRes.Id;
                ((MainWindow)Application.Current.MainWindow).totalPrice = total;
                await ((MainWindow)System.Windows.Application.Current.MainWindow).RefreshTablechangeAsync(odid);

                //await ((TablewindowView)System.Windows.Application.Current.MainWindow).CloseedWin();
                TablewindowView tablewindowView = new TablewindowView();
                await tablewindowView.CloseedWin();


                //await RefreshTablechange(odid);
            }
            //tablewindowView.Show();
            //tableSet(sender, e);;

            // await RefreshOrderIteam(orderId);
        }
        public static MainWindow GetMainWindow()
        {
            MainWindow mainWindow = null;

            foreach (Window window in Application.Current.Windows)
            {
                Type type = typeof(MainWindow);
                if (window != null && window.DependencyObjectType.Name == type.Name)
                {
                    mainWindow = (MainWindow)window;
                    if (mainWindow != null)
                    {
                        break;
                    }
                }
            }
            return mainWindow;

        }

        public async void empty(string status, long id)
        {
            if (status == "busy")
            {
                TableRes.status = TableStatus.empty;
                //TableRes.TableNumber = 
                this.tableBoreder.Background = new SolidColorBrush(Colors.Green);

                var red = await _tableRepository.UpdatedAtStatusAsync(id, TableRes);
            }
        }
        public async void tableSet(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
