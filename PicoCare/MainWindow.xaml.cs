using System;
using System.Collections.Generic;
using System.Data;
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
using PicoCRM.Core.Modules.Contact;
using PicoCRM.Core.Modules.Deal;

namespace PicoCare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private async void TabDeals_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DealManager dealManager = new DealManager();

            DataTable dts = new DataTable();

            dts = await dealManager.GetDealList();
            MessageBox.Show(dts.Rows.Count.ToString());

            dtDeals.DataContext = dts.DefaultView;
        }

        private void TabItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void TabContacts_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContactManager.ListContact contactManager = new ContactManager.ListContact();

            DataTable dts = new DataTable();
            dts = await  contactManager.GetContactList();
          
            dts.Columns[1].ColumnName = "نام و نام خانادگی";
            dts.Columns[2].ColumnName = "شماره تلفن همراه";
            dts.Columns[3].ColumnName = "مجموع امتیازات";
            dts.Columns[4].ColumnName = "تاریخ عضویت";
            dtCustomers.DataContext = dts.DefaultView;
        }
    }
}
