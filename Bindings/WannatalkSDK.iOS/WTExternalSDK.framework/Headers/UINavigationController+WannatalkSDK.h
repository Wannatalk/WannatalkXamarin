//
//  UINavigationController+WannatalkSDK.h
//  WannaTalk
//
//  Created by Srikanth Ganji on 06/03/18.
//  Copyright © 2018 Wanna Talk. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol WTSDKManagerDelegate;

@interface UINavigationController (WannatalkSDK)


- (void) pushOrgProfileVCWithAutoOpenChat:(BOOL) autoOpenChat delegate:(id <WTSDKManagerDelegate>) delegate animated:(BOOL) animated;

- (void) pushChatListVCWithDelegate:(id <WTSDKManagerDelegate>) delegate animated:(BOOL) animated;

- (void) pushUsersVCWithDelegate:(id <WTSDKManagerDelegate>) delegate animated:(BOOL) animated;

@end
