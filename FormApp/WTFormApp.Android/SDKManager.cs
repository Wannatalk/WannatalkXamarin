using System;
using Wannatalk.Wannatalksdk.WTCore;
using Wannatalk.Wannatalksdk.WTLogin;
using Wannatalk.Wannatalksdk.WTCore.Interface;

using Android.OS;
using System.Collections.Generic;
using System.Collections;
using Wannatalk.Shared;
using Wannatalk;

[assembly: Xamarin.Forms.Dependency(typeof(SDKManager))]
namespace Wannatalk
{

    public class SDKManager : Java.Lang.Object, IWannatalkSDK
    {
        LoginHandler loginHandler;
        OrgHandler orgHandler;
        UsersListHandler usersListHandler;
        ChatListListHandler chatListListHandler;

        public SDKManager()
        {
            initialize();
        }

        public void initialize()
        {
            loginHandler = new LoginHandler();
            orgHandler = new OrgHandler();
            usersListHandler = new UsersListHandler();
            chatListListHandler = new ChatListListHandler();
        }



        public class LoginHandler : Java.Lang.Object, IWTLoginManager
        {

            public LoginHandler()
            {

            }

            public void WtsdkUserLoggedIn()
            {
                if (loginCompletion != null)
                {
                    loginCompletion.UserLoggedIn();
                }
            }

            public void WtsdkUserLoggedOut()
            {
                if (loginCompletion != null)
                {
                    loginCompletion.UserLoggedOut();
                }
            }

            public void WtsdkUserLoginFailed(string p0)
            {
                //Console.WriteLine("WtsdkUserLoginFailed: " + p0);
                if (loginCompletion != null)
                {
                    loginCompletion.UserLoginFailed(p0);
                }
            }

            public void WtsdkUserLogoutFailed(string p0)
            {
                //Console.WriteLine("WtsdkUserLogoutFailed: " + p0);
                if (loginCompletion != null)
                {
                    loginCompletion.UserLogoutFailed(p0);
                }
            }

        }

        public class OrgHandler : Java.Lang.Object, IWTCompletion
        {
            public void OnCompletion(bool p0, string p1)
            {
                if (orgprofileCompletion != null)
                {
                    orgprofileCompletion.OnCompletion(p0, p1);
                }

            }
        }

        public class UsersListHandler : Java.Lang.Object, IWTCompletion
        {
            public void OnCompletion(bool p0, string p1)
            {
                if (userlistCompletion != null)
                {
                    userlistCompletion.OnCompletion(p0, p1);
                }

            }
        }

        public class ChatListListHandler : Java.Lang.Object, IWTCompletion
        {
            public void OnCompletion(bool p0, string p1)
            {
                if (chatlistCompletion != null)
                {
                    chatlistCompletion.OnCompletion(p0, p1);
                }
            }
        }



        static IWannatalkLoginCompletion loginCompletion;
        static IWannatalkCompletion orgprofileCompletion;
        static IWannatalkCompletion userlistCompletion;
        static IWannatalkCompletion chatlistCompletion;

        public void SetLoginHandler(IWannatalkLoginCompletion wannatalkLoginCompletion)
        {
            loginCompletion = wannatalkLoginCompletion;
            WTLoginManager.IwtLoginManager = loginHandler;
        }
        public void LoadLogin()
        {
            WTLoginManager.StartLoginActivity(null);
        }

        public void LoadSilentLogin(string identifier, Dictionary<string, string> userInfo)
        {
            Bundle bundle = new Bundle();

            IDictionaryEnumerator e = userInfo.GetEnumerator();
            foreach (String key in userInfo.Keys)
            {
                String value = userInfo[key];
                bundle.PutString(key, value);
            }

            WTLoginManager.SilentLoginActivity(identifier, bundle, null);

        }


        public void Logout()
        {
            WTLoginManager.Logout(null);
        }

        public void LoadOrganizationProfile(bool autoOpenChat, IWannatalkCompletion wannatalkCompletion)
        {
            orgprofileCompletion = wannatalkCompletion;
            Wannatalk.Wannatalksdk.WTCore.WTSDKManager.LoadOrganizationActivity(null, true, orgHandler);
        }

        public void LoadChatList(IWannatalkCompletion wannatalkCompletion)
        {
            chatlistCompletion = wannatalkCompletion;
            Wannatalk.Wannatalksdk.WTCore.WTSDKManager.LoadChatListActivity(null, chatListListHandler);
        }

        public void LoadUserList(IWannatalkCompletion wannatalkCompletion)
        {
            userlistCompletion = wannatalkCompletion;
            Wannatalk.Wannatalksdk.WTCore.WTSDKManager.LoadUsersActivity(null, usersListHandler);
        }

        public bool IsUserLoggedIn()
        {
            return (bool)WTLoginManager.IsUserLoggedIn();
        }

        public void RequestAllPermissions()
        {
            Wannatalk.Wannatalksdk.WTCore.WTSDKManager.RequestAllPermissions(null, 10099);
        }


        #region 



        public void ClearTempFiles()
        {
            WTSDKManager.ClearOldTempFiles();
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
