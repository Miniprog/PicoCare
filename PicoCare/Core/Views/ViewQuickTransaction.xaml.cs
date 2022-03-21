

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
    }
}
