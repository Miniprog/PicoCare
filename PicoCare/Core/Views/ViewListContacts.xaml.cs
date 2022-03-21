

namespace PicoCare.Core.Views
{
    /// <summary>
    /// Interaction logic for ViewListContacts.xaml
    /// </summary>
    public partial class ViewListContacts : Window
    {
       
        public ViewListContacts()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3NzI5QDMxMzkyZTM0MmUzMGFiUDZTT0ZVMkY2QXlhZURyWHcyWW8vUVVxWE1MZTRMK1hoQ1A3YmVYY1k9");
            SfSkinManager.SetTheme(this, new Theme("FluentDark"));
            SfSkinManager.ApplyStylesOnApplication = true;
            FluentDarkThemeSettings themeSettings = new FluentDarkThemeSettings();
            themeSettings.FontFamily = new FontFamily("B Yekan");
            SfSkinManager.RegisterThemeSettings("FluentDark", themeSettings);

         

        }


        public DataTable? Contacts { get; set; }

        private async void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            ContactManager.ListContact listContact = new ContactManager.ListContact();

            Contacts = await listContact.GetContactList();
            Contacts.Columns[0].ColumnName = "شماره مشتری";
            Contacts.Columns[1].ColumnName = " نام و نام خانوادگی";
            dtContacts.DataContext = Contacts;
        }
    }
}
