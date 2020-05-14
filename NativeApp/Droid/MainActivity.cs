using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using WTNativeApp.Shared;

namespace WTNativeApp.Droid
{
    [Activity(Label = "WTNativeApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        //
        int count = 1;
        Button btn_login;
        Button btn_silentlogin;
        Button btn_logout;
        Button btn_load_org;
        Button btn_load_users;
        Button btn_load_chats;


        public class LoginHandler : Java.Lang.Object, IWannatalkLoginCompletion
        {
            MainActivity mainActivity;
            public LoginHandler(MainActivity mainActivity)
            {
                this.mainActivity = mainActivity;
            }

            public void UserLoggedIn()
            {
                mainActivity.updateButtons();
            }

            public void UserLoggedOut()
            {
                mainActivity.updateButtons();
            }

            public void UserLoginFailed(string errorMessage)
            {
                Console.WriteLine("UserLoginFailed: " + errorMessage);
                mainActivity.updateButtons();
            }

            public void UserLogoutFailed(string errorMessage)
            {
                Console.WriteLine("UserLogoutFailed: " + errorMessage);
                mainActivity.updateButtons();
            }

        }

        public class IOrgHandler : Java.Lang.Object, IWannatalkCompletion
        {
            public void OnCompletion(bool success, string error)
            {
                Console.WriteLine("IOrgHandler->OnCompletion: " + success + " Error: " + error);
            }
        }

        public class IUsersListHandler : Java.Lang.Object, IWannatalkCompletion
        {
            public void OnCompletion(bool success, string error)
            {
                Console.WriteLine("IUsersListHandler->OnCompletion: " + success + " Error: " + error);
            }
        }

        public class IChatListListHandler : Java.Lang.Object, IWannatalkCompletion
        {
            public void OnCompletion(bool success, string error)
            {
                Console.WriteLine("IChatListListHandler->OnCompletion: " + success + " Error: " + error);
            }
        }



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            SDKManager.Init();

            btn_login = FindViewById<Button>(Resource.Id.btn_login);
            btn_silentlogin = FindViewById<Button>(Resource.Id.btn_silentlogin);
            btn_logout = FindViewById<Button>(Resource.Id.btn_logout);
            btn_load_org = FindViewById<Button>(Resource.Id.btn_load_org);
            btn_load_users = FindViewById<Button>(Resource.Id.btn_load_users);
            btn_load_chats = FindViewById<Button>(Resource.Id.btn_load_chats);


            WannatalkSDK.Manager.ShowGuideButton(false);
            WannatalkSDK.Manager.ShowProfileInfoPage(false);
            WannatalkSDK.Manager.AllowAddParticipants(false);
            WannatalkSDK.Manager.AllowSendAudioMessage(false);
            WannatalkSDK.Manager.EnableAutoTickets(true);

            WannatalkSDK.Manager.ShowExitButton(true);
            WannatalkSDK.Manager.EnableChatProfile(false);

            //WannatalkSDK.Manager.RequestAllPermissions();
            WannatalkSDK.Manager.SetLoginHandler(new LoginHandler(this));

            btn_login.Click += delegate
            {
                loadLogin();
            };



            btn_silentlogin.Click += delegate
            {
                loadSilentLogin();
            };

            btn_logout.Click += delegate
            {
                logout();
            };


            btn_load_org.Click += delegate
            {
                loadOrgProfile();
            };

            btn_load_users.Click += delegate
            {
                loadUsersList();
            };


            btn_load_chats.Click += delegate
            {
                loadChatList();
            };

            updateButtons();

        }


        public void loadLogin()
        {
            WannatalkSDK.Manager.LoadLogin();
        }

        public void loadSilentLogin()
        {

            Dictionary<String, String> bundle = new Dictionary<String, String>();

            bundle.Add("displayname", "Srikanth");
            bundle.Add("key1", "value1");
            bundle.Add("key2", "value2");

            WannatalkSDK.Manager.LoadSilentLogin("<user_identifier>", bundle);
        }

        public void logout()
        {
            WannatalkSDK.Manager.Logout();
        }


        public void loadOrgProfile()
        {
            WannatalkSDK.Manager.LoadOrganizationProfile(true, new IOrgHandler());
        }


        public void loadUsersList()
        {
            WannatalkSDK.Manager.LoadChatList(new IUsersListHandler());
        }


        public void loadChatList()
        {

            WannatalkSDK.Manager.LoadUserList(new IChatListListHandler());
        }

        public void updateButtons()
        {
            bool isUserLoggedIn = WannatalkSDK.Manager.IsUserLoggedIn();

            if (isUserLoggedIn)
            {
                btn_login.Visibility = Android.Views.ViewStates.Gone;
                btn_silentlogin.Visibility = Android.Views.ViewStates.Gone;

                btn_logout.Visibility = Android.Views.ViewStates.Visible;
                btn_load_org.Visibility = Android.Views.ViewStates.Visible;
                btn_load_users.Visibility = Android.Views.ViewStates.Visible;
                btn_load_chats.Visibility = Android.Views.ViewStates.Visible;

            }
            else
            {
                btn_login.Visibility = Android.Views.ViewStates.Visible;
                btn_silentlogin.Visibility = Android.Views.ViewStates.Visible;

                btn_logout.Visibility = Android.Views.ViewStates.Gone;
                btn_load_org.Visibility = Android.Views.ViewStates.Gone;
                btn_load_users.Visibility = Android.Views.ViewStates.Gone;
                btn_load_chats.Visibility = Android.Views.ViewStates.Gone;
            }
        }
    }
}

