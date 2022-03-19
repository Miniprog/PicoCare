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
using Syncfusion.SfSkinManager;

using Syncfusion.Licensing;
namespace PicoCRM.Core.Pages.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardIndex.xaml
    /// </summary>
    public partial class DashboardIndex : Window
    {
        public DashboardIndex()
        {
            InitializeComponent();
           
            SyncfusionLicenseProvider.RegisterLicense("MTcwOUAzMTM5MmUzNDJlMzBXZjgrSERrT2MyRDRlZlpqRjQ4bWZYMEtLaXJDYXFGSzN1U3Q2TlFuUHVrPQ==");


        }
    }
}
