

namespace PicoCare.Core.Views
{
    /// <summary>
    /// Interaction logic for ViewQuickTransaction.xaml
    /// </summary>
    public partial class ViewQuickTransaction : Window
    {
        public ViewQuickTransaction()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3NzI5QDMxMzkyZTM0MmUzMGFiUDZTT0ZVMkY2QXlhZURyWHcyWW8vUVVxWE1MZTRMK1hoQ1A3YmVYY1k9");
            SfSkinManager.SetTheme(this, new Theme("FluentDark"));
            SfSkinManager.ApplyStylesOnApplication = true;
            FluentDarkThemeSettings themeSettings = new FluentDarkThemeSettings();
            themeSettings.FontFamily = new FontFamily("B Yekan");
            SfSkinManager.RegisterThemeSettings("FluentDark", themeSettings);
        }

        private async void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ContactManager.CreateContact contactManager = new ContactManager.CreateContact();
           
            ContactManager.AssociateContact associateContact = new ContactManager.AssociateContact();
           
            ContactManager.GetContact getContact = new ContactManager.GetContact();
           
            DealManager dealManager = new DealManager();
           
            PicoCRM.Core.Modules.SMS.Handler.Send Sms = new PicoCRM.Core.Modules.SMS.Handler.Send();
          

            ContactManager.UpdateContact updateContact = new ContactManager.UpdateContact();
         
              
            string contactid =   await contactManager.Create(cName.Text, cPhoneNumber.Text, cNatCode.Text);

            string DayID = await contactManager.Create("DayReport:" + ToPersianDate(DateTime.Now, false), ToPersianDate(DateTime.Now, false), ToPersianDate(DateTime.Now, false));


            string DealId = await dealManager.CreateDeal(cDealTitle.Text, cDealPrice.Text, "", "closedwon", cDealIPG.Text);
            
            associateContact.ToDeal(contactid, DealId);
            
            associateContact.ToDeal(DayID, DealId);


         
            bool status =   await  updateContact.UpdateWallet(contactid,long.Parse(cDealPrice.Text) /100*15 , true);
          
            MessageBox.Show(status.ToString());
            
            string DayRevenue = await getContact.GetRevenue(ToPersianDate(DateTime.Now , false));

        

           await Sms.SendReportToAdmin(cName.Text, "09109740017", cDealPrice.Text, cDealTitle.Text,DayRevenue, "", DealId);
                         
                
           
            await Sms.SendReportToAdmin(cName.Text, "09150089472", cDealPrice.Text, cDealTitle.Text, DayRevenue, "", DealId);

            ContactManager.GetContact GetWallet = new ContactManager.GetContact();
         
            long wb = await  GetWallet.GetWalletBalance(contactid);
            await Sms.SendTranaction(cPhoneNumber.Text,cName.Text, cDealTitle.Text, (long.Parse(cDealPrice.Text) / 100 * 15).ToString(), wb.ToString(), DealId.ToString());

        }
        public string ToPersianDate(DateTime thisDate , bool Timeincluded)
        {
            if (Timeincluded)
            {
                PersianCalendar pc = new PersianCalendar();
                string PersianDateConverter = "" + pc.GetYear(thisDate) + "/"
                    + pc.GetMonth(thisDate) + 

                    + pc.GetDayOfMonth(thisDate) + " /" + pc.GetHour(thisDate) + ":" + pc.GetMinute(thisDate);
                return PersianDateConverter;
            }
            else
            {
                PersianCalendar pc = new PersianCalendar();
                string PersianDateConverter = "" + pc.GetYear(thisDate) 
                    + pc.GetMonth(thisDate) 

                    + pc.GetDayOfMonth(thisDate) ;
                return PersianDateConverter;
            }
           
        }

        private void cNatCode_LostFocus(object sender, RoutedEventArgs e)
        {
        
        }

        private async void cPhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            ContactManager.GetContact contactManager = new ContactManager.GetContact();
          
            string ContactId =  await contactManager.GetId(cPhoneNumber.Text);

            var ContactData = await contactManager.GetContactProp(ContactId);
            if (ContactData.id != "0" )
            {
                try
                {
                    cNatCode.Text = new String(ContactData.properties.email.Where(Char.IsDigit).ToArray());
                    cName.Text = ContactData.properties.firstname;
                    WalletBalance.Content = $"{ContactData.properties.fax}:موجودی کیف پول  ";
                   
                }
                catch (Exception ex)
                {
                    WalletBalance.Content = $"0:موجودی کیف پول  ";
                    OnlinePayment.Visibility = Visibility.Hidden;
                }

            }
            else
            {

            }
            OnlinePayment.Visibility = Visibility.Hidden;

        }

        private async void OnlinePayment_Click(object sender, RoutedEventArgs e)
        {
            ContactManager.GetContact contactManager = new ContactManager.GetContact();
            ContactManager.UpdateContact updateContact = new ContactManager.UpdateContact();
            string ContactId = await contactManager.GetId(cPhoneNumber.Text);

            var ContactData = await contactManager.GetContactProp(ContactId);

            bool UpdateWallet = await updateContact.UpdateWallet(ContactId, long.Parse(cDealPrice.Text), false);

            if (UpdateWallet)
            {
            
                long WalletBalanceAmount = await   contactManager.GetWalletBalance(ContactId);
                MessageBox.Show($"پرداخت اعتباری با موفقیت انجام گردید اعتبار فعلی :{WalletBalanceAmount}");
            }
            else
            {
                MessageBox.Show("پرداخت اعبتاری با خطا مواجه شد");
            }
           
        }

        private async void cDealPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            ContactManager.GetContact contactManager = new ContactManager.GetContact();
            ContactManager.UpdateContact updateContact = new ContactManager.UpdateContact();
            string ContactId = await contactManager.GetId(cPhoneNumber.Text);

            var ContactData = await contactManager.GetContactProp(ContactId);
            if (cDealPrice.Text == ContactData.properties.fax)
            {
                OnlinePayment.Visibility = Visibility.Visible;
            }
            else
            {
                OnlinePayment.Visibility = Visibility.Hidden;
            }
        }
    }
}
