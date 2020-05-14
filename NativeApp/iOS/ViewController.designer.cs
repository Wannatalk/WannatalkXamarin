//		
// This file has been generated automatically by MonoDevelop to store outlets and		
// actions made in the Xcode designer. If it is removed, they will be lost.		
// Manual changes to this file may not be handled correctly.		
//		
using Foundation;

namespace WTNativeApp.iOS
{
    [Register("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton BtnLogin { get; set; }

        [Outlet]
        UIKit.UIButton BtnSilentLogin { get; set; }

        [Outlet]
        UIKit.UIButton BtnLogout { get; set; }


        [Outlet]
        UIKit.UIButton BtnOrgProfile { get; set; }

        [Outlet]
        UIKit.UIButton BtnUserList { get; set; }


        [Outlet]
        UIKit.UIButton BtnChatList { get; set; }


        void ReleaseDesignerOutlets()
        {
            if (BtnLogin != null)
            {
                BtnLogin.Dispose();
                BtnLogin = null;
            }

            if (BtnSilentLogin != null)
            {
                BtnSilentLogin.Dispose();
                BtnSilentLogin = null;
            }


            if (BtnLogout != null)
            {
                BtnLogout.Dispose();
                BtnLogout = null;
            }



            if (BtnOrgProfile != null)
            {
                BtnOrgProfile.Dispose();
                BtnOrgProfile = null;
            }



            if (BtnUserList != null)
            {
                BtnUserList.Dispose();
                BtnUserList = null;
            }

            if (BtnChatList != null)
            {
                BtnChatList.Dispose();
                BtnChatList = null;
            }
        }

    }
}
