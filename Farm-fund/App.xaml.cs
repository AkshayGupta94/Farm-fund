namespace Farm_fund
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCe0x0Qnxbf1x0ZFFMYFVbRX9PIiBoS35RckVnW3hfdnZTRWddVUZ2");
            MainPage = new AppShell();
        }
    }
}
