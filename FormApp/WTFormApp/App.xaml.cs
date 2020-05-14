using Xamarin.Forms;

using Wannatalk.Shared;

namespace WTFormApp
{
    public partial class App : Application
    {
        public static IWannatalkSDK wannatalkSDK = DependencyService.Get<IWannatalkSDK>();

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
