

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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3NzI5QDMxMzkyZTM0MmUzMGFiUDZTT0ZVMkY2QXlhZURyWHcyWW8vUVVxWE1MZTRMK1hoQ1A3YmVYY1k9");
            SfSkinManager.SetTheme(this, new Theme("FluentDark"));
            SfSkinManager.ApplyStylesOnApplication = true;
            FluentDarkThemeSettings themeSettings = new FluentDarkThemeSettings();
            themeSettings.FontFamily = new FontFamily("B Yekan");
            SfSkinManager.RegisterThemeSettings("FluentDark", themeSettings);
            ViewQuickTransaction viewQuickTransaction = new ViewQuickTransaction();
            NavDrawer.ContentView = viewQuickTransaction.PlaceHolder;

        }

        private void TabConfigurationSetting_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ViewConfigurationSetting viewConfigurationSettingPage = new ViewConfigurationSetting();
            NavDrawer.ContentView = viewConfigurationSettingPage;


        }

     

        private void TabContacts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewListContacts viewListContacts = new ViewListContacts();
            NavDrawer.ContentView = viewListContacts.MainView;

        }

        private void TabDashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewQuickTransaction viewQuickTransaction = new ViewQuickTransaction();

            NavDrawer.ContentView = viewQuickTransaction.PlaceHolder;
              
              
        }
    }
}
