using System;
using System.Collections.Generic;

namespace WTNativeApp.Shared
{
    public interface IWannatalkLoginCompletion
    {
        void UserLoggedIn();

        void UserLoggedOut();

        void UserLoginFailed(string errorMessage);

        void UserLogoutFailed(string errorMessage);
    }


    public interface IWannatalkCompletion
    {
        void OnCompletion(Boolean success, String error);
    }

    public interface IWannatalkSDK
    {
        void SetLoginHandler(IWannatalkLoginCompletion wannatalkLoginCompletion);

        void LoadLogin();
        void LoadSilentLogin(String identifier, Dictionary<String, String> userInfo);
        void Logout();
        void LoadOrganizationProfile(Boolean autoOpenChat, IWannatalkCompletion wannatalkCompletion);
        void LoadChatList(IWannatalkCompletion wannatalkCompletion);
        void LoadUserList(IWannatalkCompletion wannatalkCompletion);
        bool IsUserLoggedIn();
        void RequestAllPermissions();


        void ClearTempFiles();
        void ShowGuideButton(bool show);
        void ShowProfileInfoPage(bool show);
        void AllowSendAudioMessage(bool allow);
        void AllowAddParticipants(bool allow);
        void AllowRemoveParticipants(bool allow);
        void ShowWelcomeMessage(bool show);
        void EnableAutoTickets(bool enable);
        void ShowExitButton(bool show);

        void ShowChatParticipants(bool show);
        void EnableChatProfile(bool enable);
        void AllowModifyChatProfile(bool allow);
        void SetInactiveChatTimeoutInterval(long timeoutInSeconds);

    }

    public class WannatalkSDK
    {
        public static IWannatalkSDK Manager { get; private set; }

        public static void Init(IWannatalkSDK wannatalkSDK)
        {
            WannatalkSDK.Manager = wannatalkSDK;
        }

        public WannatalkSDK() { }

    }
}



