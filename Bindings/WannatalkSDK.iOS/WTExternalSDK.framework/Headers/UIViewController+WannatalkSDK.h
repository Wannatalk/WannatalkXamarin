//
//  UIViewController+WannatalkSDK.h
//  WannaTalk
//
//  Created by Srikanth Ganji on 06/03/18.
//  Copyright © 2018 Wanna Talk. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol WTSDKManagerDelegate;

@interface UIViewController (WannatalkSDK)


- (void) presentOrgProfileVCWithAutoOpenChat:(BOOL) autoOpenChat delegate:(id <WTSDKManagerDelegate>) delegate animated:(BOOL) animated completion:(void (^)(void))completion;
- (void) presentChatListVCWithDelegate:(id <WTSDKManagerDelegate>) delegate animated:(BOOL) animated completion:(void (^)(void))completion;
- (void) presentUsersVCWithDelegate:(id <WTSDKManagerDelegate>) delegate animated:(BOOL) animated completion:(void (^)(void))completion;

@end
