using System;
using System.Collections.Generic;
using UIKit;
using WTNativeApp.Shared;

namespace WTNativeApp.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public class LoginHandler : IWannatalkLoginCompletion
        {
            ViewController viewController;
            public LoginHandler(ViewController viewController)
            {
                this.viewController = viewController;
            }

            public void UserLoggedIn()
            {
                viewController.updateButtons();
            }

            public void UserLoggedOut()
            {
                viewController.updateButtons();
            }

            public void UserLoginFailed(string errorMessage)
            {
                Console.WriteLine("UserLoginFailed: " + errorMessage);
                viewController.updateButtons();
            }

            public void UserLogoutFailed(string errorMessage)
            {
                Console.WriteLine("UserLogoutFailed: " + errorMessage);
                viewController.updateButtons();
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




        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            WannatalkSDK.Manager.SetLoginHandler(new LoginHandler(this));

            BtnLogin.TouchUpInside += delegate
            {
                loadLogin();
            };

            BtnSilentLogin.TouchUpInside += delegate
            {
                loadSilentLogin();
            };

            BtnLogout.TouchUpInside += delegate
            {
                logout();
            };


            BtnOrgProfile.TouchUpInside += delegate
            {
                loadOrgProfile();
            };

            BtnChatList.TouchUpInside += delegate
            {
                loadChatList();
            };


            BtnUserList.TouchUpInside += delegate
            {
                loadUsersList();
            };

            updateButtons();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
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

            BtnLogin.Hidden = isUserLoggedIn;
            BtnSilentLogin.Hidden = isUserLoggedIn;
            BtnLogout.Hidden = !isUserLoggedIn;
            BtnOrgProfile.Hidden = !isUserLoggedIn;
            BtnUserList.Hidden = !isUserLoggedIn;
            BtnChatList.Hidden = !isUserLoggedIn;
        }
    }
}