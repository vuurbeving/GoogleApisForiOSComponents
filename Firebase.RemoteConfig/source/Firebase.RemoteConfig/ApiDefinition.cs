﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using System.Collections.Generic;

namespace Firebase.RemoteConfig
{
	// typedef void (^FIRRemoteConfigFetchCompletion)(FIRRemoteConfigFetchStatus, NSError * _Nullable);
	delegate void RemoteConfigFetchCompletionHandler (RemoteConfigFetchStatus status, [NullAllowed] NSError error);

	// @interface FIRRemoteConfigValue : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRRemoteConfigValue")]
	interface RemoteConfigValue : INSCopying
	{
		// @property (readonly, nonatomic) NSString * _Nullable stringValue;
		[NullAllowed]
		[Export ("stringValue")]
		NSString NSStringValue { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable numberValue;
		[NullAllowed]
		[Export ("numberValue")]
		NSNumber NumberValue { get; }

		// @property (readonly, nonatomic) NSData * _Nonnull dataValue;
		[Export ("dataValue")]
		NSData DataValue { get; }

		// @property (readonly, nonatomic) BOOL boolValue;
		[Export ("boolValue")]
		bool BoolValue { get; }

		// @property (readonly, nonatomic) FIRRemoteConfigSource source;
		[Export ("source")]
		RemoteConfigSource Source { get; }
	}

	// @interface FIRRemoteConfigSettings : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRRemoteConfigSettings")]
	interface RemoteConfigSettings
	{
		// @property (readonly, nonatomic) BOOL isDeveloperModeEnabled;
		[Export ("isDeveloperModeEnabled")]
		bool IsDeveloperModeEnabled { get; }

		// -(FIRRemoteConfigSettings * _Nullable)initWithDeveloperModeEnabled:(BOOL)developerModeEnabled __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithDeveloperModeEnabled:")]
		IntPtr Constructor (bool developerModeEnabled);
	}

	// @interface FIRRemoteConfig : NSObject <NSFastEnumeration>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRRemoteConfig")]
	interface RemoteConfig
	{
		// extern NSString *const _Nonnull FIRNamespaceGoogleMobilePlatform;
		[Field ("FIRNamespaceGoogleMobilePlatform", "__Internal")]
		NSString GoogleMobilePlatformNamespace { get; }

		// extern NSString *const _Nonnull FIRRemoteConfigThrottledEndTimeInSecondsKey;
		[Field ("FIRRemoteConfigThrottledEndTimeInSecondsKey", "__Internal")]
		NSString ThrottledEndTimeInSecondsKey { get; }

		// extern NSString *const _Nonnull FIRRemoteConfigErrorDomain;
		[Field ("FIRRemoteConfigErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// @property (readonly, nonatomic, strong) NSDate * _Nullable lastFetchTime;
		[NullAllowed]
		[Export ("lastFetchTime", ArgumentSemantic.Strong)]
		NSDate LastFetchTime { get; }

		// @property (readonly, assign, nonatomic) FIRRemoteConfigFetchStatus lastFetchStatus;
		[Export ("lastFetchStatus", ArgumentSemantic.Assign)]
		RemoteConfigFetchStatus LastFetchStatus { get; }

		// @property (readwrite, nonatomic, strong) FIRRemoteConfigSettings * _Nonnull configSettings;
		[Export ("configSettings", ArgumentSemantic.Strong)]
		RemoteConfigSettings ConfigSettings { get; set; }

		// +(FIRRemoteConfig * _Nonnull)remoteConfig;
		[Static]
		[Export ("remoteConfig")]
		RemoteConfig SharedInstance { get; }

		// -(void)fetchWithCompletionHandler:(FIRRemoteConfigFetchCompletion _Nullable)completionHandler;
		[Async]
		[Export ("fetchWithCompletionHandler:")]
		void Fetch ([NullAllowed] RemoteConfigFetchCompletionHandler completionHandler);

		// -(void)fetchWithExpirationDuration:(NSTimeInterval)expirationDuration completionHandler:(FIRRemoteConfigFetchCompletion _Nullable)completionHandler;
		[Async]
		[Export ("fetchWithExpirationDuration:completionHandler:")]
		void Fetch (double expirationDuration, [NullAllowed] RemoteConfigFetchCompletionHandler completionHandler);

		// -(BOOL)activateFetched;
		[Export ("activateFetched")]
		bool ActivateFetched ();

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key;
		[Export ("configValueForKey:")]
		RemoteConfigValue GetConfigValue ([NullAllowed] string key);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key namespace:(NSString * _Nullable)aNamespace;
		[Export ("configValueForKey:namespace:")]
		RemoteConfigValue GetConfigValue ([NullAllowed] string key, [NullAllowed] string aNamespace);

		// -(FIRRemoteConfigValue * _Nonnull)configValueForKey:(NSString * _Nullable)key namespace:(NSString * _Nullable)aNamespace source:(FIRRemoteConfigSource)source;
		[Export ("configValueForKey:namespace:source:")]
		RemoteConfigValue GetConfigValue ([NullAllowed] string key, [NullAllowed] string aNamespace, RemoteConfigSource source);

		// -(NSArray<NSString *> * _Nonnull)allKeysFromSource:(FIRRemoteConfigSource)source namespace:(NSString * _Nullable)aNamespace;
		[Export ("allKeysFromSource:namespace:")]
		string [] GetAllKeys (RemoteConfigSource source, [NullAllowed] string aNamespace);

		// -(NSSet<NSString *> * _Nonnull)keysWithPrefix:(NSString * _Nullable)prefix;
		[Export ("keysWithPrefix:")]
		NSSet<NSString> GetKeys ([NullAllowed] string prefix);

		// -(NSSet<NSString *> * _Nonnull)keysWithPrefix:(NSString * _Nullable)prefix namespace:(NSString * _Nullable)aNamespace;
		[Export ("keysWithPrefix:namespace:")]
		NSSet<NSString> GetKeys ([NullAllowed] string prefix, [NullAllowed] string aNamespace);

		// -(void)setDefaults:(NSDictionary<NSString *,NSObject *> * _Nullable)defaults;
		[Export ("setDefaults:")]
		void SetDefaults ([NullAllowed] NSDictionary nsDefaults);

		[Wrap ("SetDefaults (defaults == null ? null : NSDictionary.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (defaults.Values), System.Linq.Enumerable.ToArray (defaults.Keys), defaults.Keys.Count))")]
		void SetDefaults (Dictionary<object, object> defaults);

		// -(void)setDefaults:(NSDictionary<NSString *,NSObject *> * _Nullable)defaultConfig namespace:(NSString * _Nullable)aNamespace;
		[Export ("setDefaults:namespace:")]
		void SetDefaults ([NullAllowed] NSDictionary nsDefaults, [NullAllowed] string aNamespace);

		[Wrap ("SetDefaults (defaults == null ? null : NSDictionary.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (defaults.Values), System.Linq.Enumerable.ToArray (defaults.Keys), defaults.Keys.Count), aNamespace)")]
		void SetDefaults (Dictionary<object, object> defaults, string aNamespace);

		// -(void)setDefaultsFromPlistFileName:(NSString * _Nullable)fileName;
		[Export ("setDefaultsFromPlistFileName:")]
		void SetDefaults ([NullAllowed] string plistFileName);

		// -(void)setDefaultsFromPlistFileName:(NSString * _Nullable)fileName namespace:(NSString * _Nullable)aNamespace;
		[Export ("setDefaultsFromPlistFileName:namespace:")]
		void SetDefaults ([NullAllowed] string plistFileName, [NullAllowed] string aNamespace);

		// -(FIRRemoteConfigValue * _Nullable)defaultValueForKey:(NSString * _Nullable)key namespace:(NSString * _Nullable)aNamespace;
		[return: NullAllowed]
		[Export ("defaultValueForKey:namespace:")]
		RemoteConfigValue GetDefaultValue ([NullAllowed] string key, [NullAllowed] string aNamespace);
	}
}
