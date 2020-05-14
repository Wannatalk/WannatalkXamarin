using System;
using System.Collections;
using System.Collections.Generic;
using Foundation;
using NativeLibrary;
using UIKit;
using WTNativeApp.Shared;

namespace WTNativeApp.iOS
{
    public class SDKManager: IWannatalkSDK
    {
        LoginHandler loginHandler;
        SDKHandler sdkHandler;


        public static void Init()
        {
            WannatalkSDK.Init(GetInstance());
        }

        private SDKManager()
        {

        }


        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static SDKManager _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static SDKManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SDKManager();
                _instance.initialize();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.

        public void initialize()
        {
            loginHandler = new LoginHandler();
            sdkHandler = new SDKHandler();
        }



        public class LoginHandler : WTLoginManagerDelegate
        {

            public override void LoggedInSuccessfully()
            {
                if (loginCompletion != null)
                {
                    loginCompletion.UserLoggedIn();
                }
            }

            public override void LoggedOutSuccessfully()
            {
                if (loginCompletion != null)
                {
                    loginCompletion.UserLoggedOut();
                }
            }

            public override void LoginFailWithError(string error)
            {
                if (loginCompletion != null)
                {
                    loginCompletion.UserLoginFailed(error);
                }
            }

            public override void LogOutFailedWithError(string error)
            {
                if (loginCompletion != null)
                {
                    loginCompletion.UserLogoutFailed(error);
                }
            }
        }

        public class SDKHandler : WTSDKManagerDelegate
        {

            public override UINavigationController PrepareViewHierachiesToLoadChatRoom(bool aiTopic)
            {
                return null;
            }

            public override void wtsdkChatListDidLoadFailWithError(string error)
            {
                if (chatlistCompletion != null)
                {
                    chatlistCompletion.OnCompletion(false, error);
                }
            }

            public override void wtsdkChatListDidLoadSuccesfully()
            {
                if (chatlistCompletion != null)
                {
                    chatlistCompletion.OnCompletion(true, null);
                }
            }

            public override void wtsdkOrgProfileDidLoadFailWithError(string error)
            {
                if (orgprofileCompletion != null)
                {
                    orgprofileCompletion.OnCompletion(false, error);
                }
            }

            public override void wtsdkOrgProfileDidLoadSuccesfully()
            {
                if (orgprofileCompletion != null)
                {
                    orgprofileCompletion.OnCompletion(true, null);
                }
            }

            public override void wtsdkUsersDidLoadFailWithError(string error)
            {
                if (userlistCompletion != null)
                {
                    userlistCompletion.OnCompletion(false, error);
                }
            }

            public override void wtsdkUsersDidLoadSuccesfully()
            {
                if (userlistCompletion != null)
                {
                    userlistCompletion.OnCompletion(true, null);
                }
            }
        }


        static IWannatalkLoginCompletion loginCompletion;
        static IWannatalkCompletion orgprofileCompletion;
        static IWannatalkCompletion userlistCompletion;
        static IWannatalkCompletion chatlistCompletion;

        private static UIViewController GetVisibleViewController()
        {
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            UIViewController presentedVC = window.RootViewController;
            while (presentedVC.PresentedViewController != null)
            {
                presentedVC = presentedVC.PresentedViewController;
            }

            return presentedVC;
        }

        public void SetLoginHandler(IWannatalkLoginCompletion wannatalkLoginCompletion)
        {
            loginCompletion = wannatalkLoginCompletion;
            WTLoginManager.SharedInstance().WeakDelegate = loginHandler;
        }
        public void LoadLogin()
        {
            UIViewController presentedVC = GetVisibleViewController();

            if (presentedVC != null)
            {
                WTLoginManager.SharedInstance().LoginFromVC(presentedVC);
            }

            
        }

        public void LoadSilentLogin(string identifier, Dictionary<string, string> userInfo)
        {
            UIViewController presentedVC = GetVisibleViewController();

            if (presentedVC != null)
            {
                NSMutableDictionary dctUserInfo = new NSMutableDictionary();

                IDictionaryEnumerator e = userInfo.GetEnumerator();
                foreach (String key in userInfo.Keys)
                {
                    String value = userInfo[key];
                    dctUserInfo.SetValueForKey((NSString)value, (NSString)key);
                }

                WTLoginManager.SharedInstance().SilentLogin(identifier, dctUserInfo, presentedVC);
            }

            

        }


        public void Logout()
        {
            WTLoginManager.SharedInstance().Logout();
        }

        public void LoadOrganizationProfile(bool autoOpenChat, IWannatalkCompletion wannatalkCompletion)
        {
            orgprofileCompletion = wannatalkCompletion;

            UIViewController presentedVC = GetVisibleViewController();

            if (presentedVC != null)
            {
                presentedVC.PresentOrgProfileVC(autoOpenChat, sdkHandler, true, null);
            }
        }

        public void LoadChatList(IWannatalkCompletion wannatalkCompletion)
        {
            chatlistCompletion = wannatalkCompletion;

            UIViewController presentedVC = GetVisibleViewController();

            if (presentedVC != null)
            {
                presentedVC.PresentChatListVC(sdkHandler, true, null);
            }
        }


        public void LoadUserList(IWannatalkCompletion wannatalkCompletion)
        {
            userlistCompletion = wannatalkCompletion;

            UIViewController presentedVC = GetVisibleViewController();

            if (presentedVC != null)
            {
                presentedVC.PresentUsersVC(sdkHandler, true, null);
            }
        }

        public bool IsUserLoggedIn()
        {
            return WTLoginManager.SharedInstance().IsUserLoggedIn;
        }

        public void RequestAllPermissions()
        {

            //Wannatalk.Wannatalksdk.WTCore.WTSDKManager.RequestAllPermissions(null, 10099);
        }


        #region 



        public void ClearTempFiles()
        {
            WTSDKManager.ClearTempFiles();
        }

        public void ShowGuideButton(bool show)
        {

            WTSDKManager.ShowGuideButton(show);
        }

        public void ShowProfileInfoPage(bool show)
        {
            WTSDKManager.ShowProfileInfoPage(show);
        }


        public void AllowSendAudioMessage(bool allow)
        {
            WTSDKManager.AllowSendAudioMessage(allow);
        }

        public void AllowAddParticipants(bool allow)
        {
            WTSDKManager.AllowAddParticipants(allow);
        }


        public void AllowRemoveParticipants(bool allow)
        {
            WTSDKManager.AllowRemoveParticipants(allow);
        }


        public void ShowWelcomeMessage(bool show)
        {
            WTSDKManager.ShowWelcomeMessage(show);
        }


        public void EnableAutoTickets(bool enable)
        {
            WTSDKManager.EnableAutoTickets(enable);
        }


        public void ShowExitButton(bool show)
        {
            WTSDKManager.ShowExitButton(show);
        }


        public void ShowChatParticipants(bool show)
        {
            WTSDKManager.ShowChatParticipants(show);
        }


        public void EnableChatProfile(bool enable)
        {
            WTSDKManager.EnableChatProfile(enable);
        }


        public void AllowModifyChatProfile(bool allow)
        {
            WTSDKManager.AllowModifyChatProfile(allow);
        }


        public void SetInactiveChatTimeoutInterval(long timeoutInSeconds)
        {
            WTSDKManager.SetInactiveChatTimeoutInterval(timeoutInSeconds);
        }

        #endregion




    }
}
