//
//  WTLoginManagerDelegate.h
//  Wannatalk
//
//  Created by Srikanth Ganji on 04/03/17.
//  Copyright © 2017 Wannatalk. All rights reserved.
//

#import <UIKit/UIKit.h>

// A protocol implemented by the delegate of WTLoginManager to receive a login status.
@protocol WTLoginManagerDelegate <NSObject>

// This method will be invoked when user sign in successfully
- (void) wtAccountDidLoginSuccessfully;
// This method will be invoked when user sign out successfully
- (void) wtAccountDidLogOutSuccessfully;
@optional
// If implemented, this method will be invoked when login fails
- (void) wtAccountDidLoginFailWithError:(NSString *) error;
// If implemented, this method will be invoked when logout fails
- (void) wtAccountDidLogOutFailedWithError:(NSString *) error;


@end
