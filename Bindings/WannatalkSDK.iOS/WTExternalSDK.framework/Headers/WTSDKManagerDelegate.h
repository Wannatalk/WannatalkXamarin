//
//  WTSDKManagerDelegate.h
//  Wannatalk
//
//  Created by Srikanth Ganji on 31/05/17.
//  Copyright © 2017 Wannatalk. All rights reserved.
//

#import <Foundation/Foundation.h>

// A protocol implemented by the delegate of WTSDKManager to receive a sdk updates.
@protocol WTSDKManagerDelegate <NSObject>



@optional

- (UINavigationController *) prepareViewHierachiesToLoadChatRoom:(BOOL) aiTopic;

// If implemented, this method will be invoked when organization profile loads successfully
- (void) wtsdkOrgProfileDidLoadSuccesfully;

// If implemented, this method will be invoked when organization profile fails to load
- (void) wtsdkOrgProfileDidLoadFailWithError:(NSString *) error;

// If implemented, this method will be invoked when chat list page loads successfully
- (void) wtsdkChatListDidLoadSuccesfully;

// If implemented, this method will be invoked when chat list page fails to load
- (void) wtsdkChatListDidLoadFailWithError:(NSString *) error;

// If implemented, this method will be invoked when user list page loads successfully
- (void) wtsdkUsersDidLoadSuccesfully;

// If implemented, this method will be invoked when user list page fails to load
- (void) wtsdkUsersDidLoadFailWithError:(NSString *) error;

@end
