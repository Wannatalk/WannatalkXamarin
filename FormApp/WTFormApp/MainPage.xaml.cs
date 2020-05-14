using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Wannatalk.Shared;

namespace WTFormApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            App.wannatalkSDK.ShowGuideButton(false);
            App.wannatalkSDK.ShowProfileInfoPage(false);
            App.wannatalkSDK.AllowAddParticipants(false);
            App.wannatalkSDK.AllowSendAudioMessage(false);
            App.wannatalkSDK.EnableAutoTickets(true);

            App.wannatalkSDK.ShowExitButton(true);
            App.wannatalkSDK.EnableChatProfile(false);

            //App.wannatalkSDK.RequestAllPermissions();
            App.wannatalkSDK.SetLoginHandler(new LoginHandler(this));


            UpdateButtons();
        }

        async void OnLoginButtonClicked(object sender, EventArgs args)
        {
            App.wannatalkSDK.LoadLogin();
        }


        void OnSilentLoginButtonClicked(object sender, EventArgs args)
        {
            Dictionary<String, String> bundle = new Dictionary<String, String>();

            bundle.Add("displayname", "Srikanth");
            bundle.Add("key1", "value1");
            bundle.Add("key2", "value2");

            App.wannatalkSDK.LoadSilentLogin("<user_identifier>", bundle);
        }

        async void OnLogoutButtonClicked(object sender, EventArgs args)
        {
            App.wannatalkSDK.Logout();
        }


        async void OnOrgProfileButtonClicked(object sender, EventArgs args)
        {
            App.wannatalkSDK.LoadOrganizationProfile(true, new IOrgHandler());
        }

        async void OnUserListButtonClicked(object sender, EventArgs args)
        {
            App.wannatalkSDK.LoadChatList(new IUsersListHandler());
        }

        async void OnChatListButtonClicked(object sender, EventArgs args)
        {
            App.wannatalkSDK.LoadUserList(new IChatListListHandler());
        }

        internal void UpdateButtons()
        {

            bool isUserLoggedIn = App.wannatalkSDK.IsUserLoggedIn();
            btnLogin.IsVisible = !isUserLoggedIn;
            btnSilentLogin.IsVisible = !isUserLoggedIn;

            btnLogout.IsVisible = isUserLoggedIn;
            btnOrgProfile.IsVisible = isUserLoggedIn;
            btnUserList.IsVisible = isUserLoggedIn;
            btnChatList.IsVisible = isUserLoggedIn;

        }
    }

    public class LoginHandler : IWannatalkLoginCompletion
    {
        MainPage mainPage;
        public LoginHandler(MainPage mainPage)
        {
            this.mainPage = mainPage;
        }

        public void UserLoggedIn()
        {
            mainPage.UpdateButtons();
        }

        public void UserLoggedOut()
        {
            mainPage.UpdateButtons();
        }

        public void UserLoginFailed(string errorMessage)
        {
            Console.WriteLine("UserLoginFailed: " + errorMessage);
            mainPage.UpdateButtons();
        }

        public void UserLogoutFailed(string errorMessage)
        {
            Console.WriteLine("UserLogoutFailed: " + errorMessage);
            mainPage.UpdateButtons();
        }

    }

    public class IOrgHandler : IWannatalkCompletion
    {
        public void OnCompletion(bool success, string error)
        {
            Console.WriteLine("IOrgHandler->OnCompletion: " + success + " Error: " + error);
        }
    }

    public class IUsersListHandler : IWannatalkCompletion
    {
        public void OnCompletion(bool success, string error)
        {
            Console.WriteLine("IUsersListHandler->OnCompletion: " + success + " Error: " + error);
        }
    }

    public class IChatListListHandler : IWannatalkCompletion
    {
        public void OnCompletion(bool success, string error)
        {
            Console.WriteLine("IChatListListHandler->OnCompletion: " + success + " Error: " + error);
        }
    }


}
