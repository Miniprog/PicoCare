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
using PicoCRM.Core.Modules.Deal;
using PicoCRM.Core.Modules.Contact;
namespace PicoCRM.Core.Pages
{
    /// <summary>
    /// Interaction logic for Pages.xaml
    /// </summary>
    public partial class GetDealInfo : Window
    {
        public GetDealInfo()
        {
            InitializeComponent();
        }

        private async void UpDateDealBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string DealStage = "";
                switch (DealStatus.SelectedIndex)
                {
                    case 0:
                        DealStage = "appointmentscheduled";
                        break;
                    case 1:
                        DealStage = "8198221";
                        break;
                    case 2:
                        DealStage = "8198220";
                        break;
                    case 3:
                        DealStage = "8198223";
                        break;
                    case 4:
                        DealStage = "closedwon";
                        break;
                    case 5:
                        DealStage = "closedlost";
                        break;
                }
                DealManager dealManager = new DealManager();
                var UpdateResult = await dealManager.UpdateDeal(cDealId.Text, cDealTitle.Text, cDealTotalAmont.Text, cDealAbout.Text, DealStage, cDealIPG.Text);
                if (UpdateResult.message == null)
                {
                    MessageBox.Show("بروزرسانی با خطار موجه شد");
                }
                else
                {
                    MessageBox.Show("بروزرسانی با موفقیت انجام شد");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        private async void GetDealBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DealManager dealManager = new DealManager();
                ContactManager.GetContact contactManager = new ContactManager.GetContact();
                var DealInfo = await dealManager.GetDeal(cDealId.Text);
                var dealAssoc = await dealManager.GetDealAssoc(cDealId.Text);
                var ContactProp = await contactManager.GetContactProp(dealAssoc.ToString());
                cDealTitle.Text = DealInfo.properties.dealname;
                cDealTotalAmont.Text = DealInfo.properties.amount;
                cDealFullName.Text = ContactProp.properties.firstname;
                cDealPhone.Text = ContactProp.properties.phone;
                MessageBox.Show(DealInfo.properties.dealstage);
                switch (DealInfo.properties.dealstage)
                {
                    case "appointmentscheduled":
                        DealStatus.SelectedIndex = 0;
                        break;
                    case "8198221":

                        DealStatus.SelectedIndex = 1;

                        break;
                    case "8198220":
                        DealStatus.SelectedIndex = 2;
                        break;
                    case "8198223":
                        DealStatus.SelectedIndex = 3;
                        break;
                    case "closedwon":
                        DealStatus.SelectedIndex = 4;
                        break;
                    case "closedlost":
                        DealStatus.SelectedIndex = 5;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }
    }
}
