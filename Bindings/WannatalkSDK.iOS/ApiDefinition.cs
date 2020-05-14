using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace NativeLibrary
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //


    [BaseType(typeof(NSObject))]
    interface WTSDKManager
    {

        [Static, Export("sharedInstance")]
        public WTSDKManager SharedInstance();

        [Wrap("WeakDelegate")]
        WTSDKManagerDelegate Delegate { get; set; }

        [Export("delegate", ArgumentSemantic.Assign)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Static, Export("ClearTempDirectory")]
        public void ClearTempFiles();

        // To show or hide guide button // default = YES
        [Static, Export("ShowGuideButton:")]
        public void ShowGuideButton(Boolean show);

        //// To enable or disable sending audio message // default = YES
        [Static, Export("ShouldAllowSendAudioMessage:")]
        public void AllowSendAudioMessage(Boolean allow);


        //// To show or hide add participants option in new ticket page and chat item profile page // default = YES
        [Static, Export("ShouldAllowAddParticipant:")]
        public void AllowAddParticipants(Boolean allow);

        //// To show or hide remove participants option in chat item profile // default = NO
        [Static, Export("ShouldAllowRemoveParticipant:")]
        public void AllowRemoveParticipants(Boolean allow);

        //// To show or hide welcome message // default = NO
        [Static, Export("ShowWelcomeMessage:")]
        public void ShowWelcomeMessage(Boolean show);

        //// To show or hide Profile Info page // default = YES
        [Static, Export("ShowProfileInfoPage:")]
        public void ShowProfileInfoPage(Boolean show);


        //// To create auto tickets:
        ////Chat ticket will create automatically when auto tickets is enabled, otherwise default ticket creation page will popup
        //// default = NO
        [Static, Export("EnableAutoTickets:")]
        public void EnableAutoTickets(Boolean enable);

        //// To show or hide close chat button in chat page // default = NO
        [Static, Export("ShowExitButton:")]
        public void ShowExitButton(Boolean show);

        //// To show or hide participants in chat profile page // default = YES
        [Static, Export("ShowChatParticipants:")]
        public void ShowChatParticipants(Boolean show);

        //// To enable or disbale chat profile page // default = YES
        [Static, Export("EnableChatProfile:")]
        public void EnableChatProfile(Boolean enable);

        //// To allow modify  in chat profile page // default = YES
        [Static, Export("AllowModifyChatProfile:")]
        public void AllowModifyChatProfile(Boolean allow);

        //// To set Inactive chat timeout:
        ////Chat session will end if user is inactive for timeout interval duration. If timeout interval is 0, chat session will not end automatically. The default timout interval is 1800 seconds (30 minutes).
        //// default = 1800 seconds (30 minutes).
        [Static, Export("SetInactiveChatTimeoutInterval:")]
        public void SetInactiveChatTimeoutInterval(long timeoutInSeconds);


        [Static, Export("ShowDebugLogs:")]
        public void ShowDebugLogs(Boolean show);


    }

    public delegate void CompletionBlock();
    //public delegate void CompletionBlock(NSError error);


    [Category, BaseType(typeof(UIViewController))]
    interface UIViewController_WannatalkSDK
    {
        //[Abstract]
        [Export("presentOrgProfileVCWithAutoOpenChat:delegate:animated:completion:")]
        public void PresentOrgProfileVC(bool autoOpenChat, [NullAllowed] WTSDKManagerDelegate sdkManagerDelegate, bool animated, [NullAllowed] CompletionBlock completion);

        //[Abstract]
        [Export("presentChatListVCWithDelegate:animated:completion:")]
        public void PresentChatListVC([NullAllowed] WTSDKManagerDelegate sdkManagerDelegate, bool animated, [NullAllowed] CompletionBlock completion);


        //[Abstract]
        [Export("presentUsersVCWithDelegate:animated:completion:")]
        public void PresentUsersVC([NullAllowed] WTSDKManagerDelegate sdkManagerDelegate, bool animated, [NullAllowed] CompletionBlock completion);

    }

    [Category, BaseType(typeof(UINavigationController))]
    interface UINavigationController_WannatalkSDK
    {
        //[Abstract]
        [Export("pushOrgProfileVCWithAutoOpenChat:delegate:animated:")]
        public void PushOrgProfileVC(bool autoOpenChat, [NullAllowed] WTSDKManagerDelegate sdkManagerDelegate, bool animated);

        //[Abstract]
        [Export("pushChatListVCWithDelegate:animated:")]
        public void PushChatListVC([NullAllowed] WTSDKManagerDelegate sdkManagerDelegate, bool animated);


        //[Abstract]
        [Export("pushUsersVCWithDelegate:animated:")]
        public void PushUsersVC([NullAllowed] WTSDKManagerDelegate sdkManagerDelegate, bool animated);

    }



    [BaseType(typeof(NSObject))]
    [Model]
    [Protocol]
    interface WTLoginManagerDelegate
    {
        [Abstract]
        [Export("wtAccountDidLoginSuccessfully")]
        void LoggedInSuccessfully();

        [Abstract]
        [Export("wtAccountDidLogOutSuccessfully")]
        void LoggedOutSuccessfully();

        [Abstract]
        [Export("wtAccountDidLoginFailWithError:")]
        void LoginFailWithError(String error);

        [Abstract]
        [Export("wtAccountDidLogOutFailedWithError:")]
        void LogOutFailedWithError(String error);

    }


    [BaseType(typeof(NSObject))]
    interface WTLoginManager
    {

        [Static, Export("sharedInstance")]
        public WTLoginManager SharedInstance();


        [Wrap("WeakDelegate")]
        WTLoginManagerDelegate Delegate { get; set; }

        [Export("delegate", ArgumentSemantic.Assign)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }


        [Export("isUserLoggedIn")]
        bool IsUserLoggedIn { get; }

        //[Export("isConnected")]
        //bool IsConnected { get; }

        [Export("loginFromVC:")]
        void LoginFromVC(UIViewController fromVC);

        [Export("silentLoginWithIdentifier:userInfo:fromVC:")]
        void SilentLogin(String identifier, [NullAllowed] NSDictionary userInfo, UIViewController fromVC);

        [Export("logout")]
        void Logout();

    }


    [BaseType(typeof(NSObject))]
    [Model]
    [Protocol]
    interface WTSDKManagerDelegate
    {


        [Abstract]
        [Export("prepareViewHierachiesToLoadChatRoom:")]
        UINavigationController PrepareViewHierachiesToLoadChatRoom(bool aiTopic);

        //// If implemented, this method will be invoked when organization profile loads successfully
        [Abstract]
        [Export("wtsdkOrgProfileDidLoadSuccesfully")]
        void wtsdkOrgProfileDidLoadSuccesfully();

        //// If implemented, this method will be invoked when organization profile fails to load
        [Abstract]
        [Export("wtsdkOrgProfileDidLoadFailWithError:")]
        void wtsdkOrgProfileDidLoadFailWithError(String error);

        //// If implemented, this method will be invoked when chat list page loads successfully
        [Abstract]
        [Export("wtsdkChatListDidLoadSuccesfully")]
        void wtsdkChatListDidLoadSuccesfully();

        //// If implemented, this method will be invoked when chat list page fails to load
        ///
        [Abstract]
        [Export("wtsdkChatListDidLoadFailWithError:")]
        void wtsdkChatListDidLoadFailWithError(String error);

        //// If implemented, this method will be invoked when user list page loads successfully
        [Abstract]
        [Export("wtsdkUsersDidLoadSuccesfully")]
        void wtsdkUsersDidLoadSuccesfully();

        //// If implemented, this method will be invoked when user list page fails to load

        [Abstract]
        [Export("wtsdkUsersDidLoadFailWithError:")]
        void wtsdkUsersDidLoadFailWithError(String error);


    }



    [BaseType(typeof(NSObject))]
    interface WTSDKApplicationDelegate
    {
        [Static, Export("sharedInstance")]
        public WTSDKApplicationDelegate SharedInstance();

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, [NullAllowed] NSDictionary launchOptions);


        [Export("application:handleEventsForBackgroundURLSession:completionHandler:")]
        public void HandleEventsForBackgroundUrl(UIApplication application, string sessionIdentifier, System.Action completionHandler);


        [Export("application:openURL:options:")]
        public bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options);


        [Export("application:openURL:sourceApplication:annotation:")]
        public bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation);


        [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
        public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken);


        [Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
        public void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, System.Action<UIBackgroundFetchResult> completionHandler);


        [Export("application:handleActionWithIdentifier:forLocalNotification:withResponseInfo:completionHandler:")]
        public void HandleAction(UIApplication application, string actionIdentifier, UILocalNotification localNotification, NSDictionary responseInfo, System.Action completionHandler);

        [Export("application:handleActionWithIdentifier:forLocalNotification:completionHandler:")]
        public void HandleAction(UIApplication application, string actionIdentifier, UILocalNotification localNotification, System.Action completionHandler);

        [Export("application:continueUserActivity:restorationHandler:")]
        public bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler);

    }



}

