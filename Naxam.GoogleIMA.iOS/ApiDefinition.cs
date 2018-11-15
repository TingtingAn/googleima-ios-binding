﻿using System;
using AVFoundation;
using AVKit;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace GoogleIMA
{
    partial interface IIMAContentPlayhead {}
	// @protocol IMAContentPlayhead
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAContentPlayhead
	{
		// @required @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Abstract]
		[Export ("currentTime")]
		double CurrentTime { get; }
	}

	// @interface IMAAVPlayerContentPlayhead : NSObject <IMAContentPlayhead>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAVPlayerContentPlayhead : IMAContentPlayhead
	{
		// @property (readonly, nonatomic, strong) AVPlayer * player;
		[Export ("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// -(instancetype)initWithAVPlayer:(AVPlayer *)player;
		[Export ("initWithAVPlayer:")]
		IntPtr Constructor (AVPlayer player);
	}

	//partial interface IIMAAdPlaybackInfo { }
	// @protocol IMAAdPlaybackInfo <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IMAAdPlaybackInfo
	{
		// @required @property (readonly, nonatomic) NSTimeInterval currentMediaTime;
		[Abstract]
		[Export ("currentMediaTime")]
		double CurrentMediaTime { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval totalMediaTime;
		[Abstract]
		[Export ("totalMediaTime")]
		double TotalMediaTime { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval bufferedMediaTime;
		[Abstract]
		[Export ("bufferedMediaTime")]
		double BufferedMediaTime { get; }

		// @required @property (readonly, getter = isPlaying, nonatomic) BOOL playing;
		[Abstract]
		[Export ("playing")]
		bool Playing { [Bind ("isPlaying")] get; }
	}

    //partial interface IIMAVideoDisplayDelegate {}
	// @protocol IMAVideoDisplayDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IMAVideoDisplayDelegate
	{
		// @required -(void)videoDisplayDidPlay:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidPlay:")]
		void VideoDisplayDidPlay (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidPause:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidPause:")]
		void VideoDisplayDidPause (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidResume:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidResume:")]
		void VideoDisplayDidResume (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidStart:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidStart:")]
		void VideoDisplayDidStart (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidComplete:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidComplete:")]
		void VideoDisplayDidComplete (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidClick:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidClick:")]
		void VideoDisplayDidClick (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidReceiveError:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidReceiveError:")]
		void VideoDisplayDidReceiveError (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidSkip:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidSkip:")]
		void VideoDisplayDidSkip (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidShowSkip:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidShowSkip:")]
		void VideoDisplayDidShowSkip (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidLoad:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export ("videoDisplayDidLoad:")]
		void VideoDisplayDidLoad (IMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay volumeChangedTo:(NSNumber *)volume;
		[Abstract]
		[Export ("videoDisplay:volumeChangedTo:")]
		void VideoDisplay (IMAVideoDisplay videoDisplay, NSNumber volume);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didProgressWithMediaTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)duration;
		[Abstract]
		[Export ("videoDisplay:didProgressWithMediaTime:totalTime:")]
		void VideoDisplay (IMAVideoDisplay videoDisplay, double mediaTime, double duration);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didReceiveTimedMetadata:(NSDictionary *)metadata;
		[Abstract]
		[Export ("videoDisplay:didReceiveTimedMetadata:")]
		void VideoDisplay (IMAVideoDisplay videoDisplay, NSDictionary metadata);

		// @optional -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didBufferToMediaTime:(NSTimeInterval)mediaTime;
		[Export ("videoDisplay:didBufferToMediaTime:")]
		void VideoDisplay (IMAVideoDisplay videoDisplay, double mediaTime);

		// @optional -(void)videoDisplayIsPlaybackReady:(id<IMAVideoDisplay>)videoDisplay;
		[Export ("videoDisplayIsPlaybackReady:")]
		void VideoDisplayIsPlaybackReady (IMAVideoDisplay videoDisplay);

		// @optional -(void)videoDisplayDidStartBuffering:(id<IMAVideoDisplay>)videoDisplay;
		[Export ("videoDisplayDidStartBuffering:")]
		void VideoDisplayDidStartBuffering (IMAVideoDisplay videoDisplay);
	}

    //partial interface IIMAVideoDisplay {}
	// @protocol IMAVideoDisplay <IMAAdPlaybackInfo>
	[Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface IMAVideoDisplay : IMAAdPlaybackInfo
	{
        [Wrap("WeakDelegate")]
        IMAVideoDisplayDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<IMAVideoDisplayDelegate> delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

		// @required @property (assign, nonatomic) float volume;
		[Abstract]
		[Export ("volume")]
		float Volume { get; set; }

		// @required -(void)loadStream:(NSURL *)streamURL withSubtitles:(NSArray *)subtitles;
		[Abstract]
		[Export ("loadStream:withSubtitles:")]
		void LoadStream (NSUrl streamURL, NSObject[] subtitles);

		// @required -(void)loadUrl:(NSURL *)url;
		[Abstract]
		[Export ("loadUrl:")]
		void LoadUrl (NSUrl url);

		// @required -(void)play;
		[Abstract]
		[Export ("play")]
		void Play ();

		// @required -(void)pause;
		[Abstract]
		[Export ("pause")]
		void Pause ();

		// @required -(void)reset;
		[Abstract]
		[Export ("reset")]
		void Reset ();
	}

	[Static]
	partial interface kIMASubtitle
    {
		// extern NSString *const kIMASubtitleLanguage;
		[Field ("kIMASubtitleLanguage", "__Internal")]
		NSString Language { get; }

		// extern NSString *const kIMASubtitleWebVTT;
		[Field ("kIMASubtitleWebVTT", "__Internal")]
		NSString WebVtt { get; }

		// extern NSString *const kIMASubtitleTTML;
		[Field ("kIMASubtitleTTML", "__Internal")]
		NSString Ttml { get; }
	}

    // @protocol IMAAVPlayerVideoDisplayDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMAAVPlayerVideoDisplayDelegate
    {
        // @optional -(void)avPlayerVideoDisplay:(IMAAVPlayerVideoDisplay *)avPlayerVideoDisplay willLoadStreamAsset:(AVURLAsset *)avUrlAsset;
        [Export("avPlayerVideoDisplay:willLoadStreamAsset:")]
        void WillLoadStreamAsset(IMAAVPlayerVideoDisplay avPlayerVideoDisplay, AVUrlAsset avUrlAsset);
    }

    // @interface IMAAVPlayerVideoDisplay : NSObject <IMAVideoDisplay>
    [BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAVPlayerVideoDisplay : IMAVideoDisplay
	{
		// @property (readonly, nonatomic, strong) AVPlayer * player;
		[Export ("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// @property (readonly, nonatomic, strong) AVPlayerItem * playerItem;
		[Export ("playerItem", ArgumentSemantic.Strong)]
		AVPlayerItem PlayerItem { get; }

        [Wrap("WeakAvPlayerVideoDisplayDelegate")]
        IMAAVPlayerVideoDisplayDelegate AvPlayerVideoDisplayDelegate { get; set; }

        // @property (nonatomic, weak) id<IMAAVPlayerVideoDisplayDelegate> avPlayerVideoDisplayDelegate;
        [NullAllowed, Export("avPlayerVideoDisplayDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAvPlayerVideoDisplayDelegate { get; set; }

        // @property (readonly, nonatomic, strong) NSArray * subtitles;
        [Export ("subtitles", ArgumentSemantic.Strong)]
		NSObject[] Subtitles { get; }

		// -(instancetype)initWithAVPlayer:(AVPlayer *)player;
		[Export ("initWithAVPlayer:")]
		IntPtr Constructor (AVPlayer player);
	}

	// @interface IMAAdPodInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdPodInfo
	{
		// @property (readonly, nonatomic) int totalAds;
		[Export ("totalAds")]
		int TotalAds { get; }

		// @property (readonly, nonatomic) int adPosition;
		[Export ("adPosition")]
		int AdPosition { get; }

		// @property (readonly, nonatomic) BOOL isBumper;
		[Export ("isBumper")]
		bool IsBumper { get; }

		// @property (readonly, nonatomic) int podIndex;
		[Export ("podIndex")]
		int PodIndex { get; }

		// @property (readonly, nonatomic) NSTimeInterval timeOffset;
		[Export ("timeOffset")]
		double TimeOffset { get; }

		// @property (readonly, nonatomic) NSTimeInterval maxDuration;
		[Export ("maxDuration")]
		double MaxDuration { get; }
	}

	// @interface IMAAd : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAd
	{
		// @property (readonly, copy, nonatomic) NSString * adId;
		[Export ("adId")]
		string AdId { get; }

		// @property (readonly, copy, nonatomic) NSString * adTitle;
		[Export ("adTitle")]
		string AdTitle { get; }

		// @property (readonly, copy, nonatomic) NSString * adDescription;
		[Export ("adDescription")]
		string AdDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * adSystem;
		[Export ("adSystem")]
		string AdSystem { get; }

		// @property (readonly, copy, nonatomic) NSString * contentType;
		[Export ("contentType")]
		string ContentType { get; }

		// @property (readonly, nonatomic) NSTimeInterval duration;
		[Export ("duration")]
		double Duration { get; }

		// @property (readonly, copy, nonatomic) NSArray * uiElements;
		[Export ("uiElements", ArgumentSemantic.Copy)]
		NSObject[] UiElements { get; }

		// @property (readonly, nonatomic) int width;
		[Export ("width")]
		int Width { get; }

		// @property (readonly, nonatomic) int height;
		[Export ("height")]
		int Height { get; }

		// @property (readonly, getter = isLinear, nonatomic) BOOL linear;
		[Export ("linear")]
		bool Linear { [Bind ("isLinear")] get; }

		// @property (readonly, getter = isSkippable, nonatomic) BOOL skippable;
		[Export ("skippable")]
		bool Skippable { [Bind ("isSkippable")] get; }

		// @property (readonly, nonatomic, strong) IMAAdPodInfo * adPodInfo;
		[Export ("adPodInfo", ArgumentSemantic.Strong)]
		IMAAdPodInfo AdPodInfo { get; }

		// @property (readonly, copy, nonatomic) NSString * traffickingParameters;
		[Export ("traffickingParameters")]
		string TraffickingParameters { get; }

		// @property (readonly, copy, nonatomic) NSString * creativeID;
		[Export ("creativeID")]
		string CreativeID { get; }

		// @property (readonly, copy, nonatomic) NSString * creativeAdID;
		[Export ("creativeAdID")]
		string CreativeAdID { get; }

		// @property (readonly, copy, nonatomic) NSString * universalAdIdValue;
		[Export ("universalAdIdValue")]
		string UniversalAdIdValue { get; }

		// @property (readonly, copy, nonatomic) NSString * universalAdIdRegistry;
		[Export ("universalAdIdRegistry")]
		string UniversalAdIdRegistry { get; }

		// @property (readonly, copy, nonatomic) NSString * advertiserName;
		[Export ("advertiserName")]
		string AdvertiserName { get; }

		// @property (readonly, copy, nonatomic) NSString * surveyURL;
		[Export ("surveyURL")]
		string SurveyURL { get; }

		// @property (readonly, copy, nonatomic) NSString * dealID;
		[Export ("dealID")]
		string DealID { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * wrapperAdIDs;
        [Export("wrapperAdIDs", ArgumentSemantic.Copy)]
        string[] WrapperAdIDs { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * wrapperCreativeIDs;
        [Export ("wrapperCreativeIDs", ArgumentSemantic.Copy)]
		string[] WrapperCreativeIDs { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * wrapperSystems;
		[Export ("wrapperSystems", ArgumentSemantic.Copy)]
		string[] WrapperSystems { get; }
	}

	// @interface IMAAdDisplayContainer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdDisplayContainer
	{
		// @property (readonly, nonatomic, strong) UIView * adContainer;
		[Export ("adContainer", ArgumentSemantic.Strong)]
		UIView AdContainer { get; }

		// @property (readonly, copy, nonatomic) NSArray * companionSlots;
		[Export ("companionSlots", ArgumentSemantic.Copy)]
		NSObject[] CompanionSlots { get; }

		// -(instancetype)initWithAdContainer:(UIView *)adContainer companionSlots:(NSArray *)companionSlots __attribute__((objc_designated_initializer));
		[Export ("initWithAdContainer:companionSlots:")]
		[DesignatedInitializer]
        IntPtr Constructor (UIView adContainer, [NullAllowed] NSObject[] companionSlots);
	}

	// @interface IMAAdError : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdError
	{
		// @property (readonly, nonatomic) IMAErrorType type;
		[Export ("type")]
		IMAErrorType Type { get; }

		// @property (readonly, nonatomic) IMAErrorCode code;
		[Export ("code")]
		IMAErrorCode Code { get; }

		// @property (readonly, copy, nonatomic) NSString * message;
		[Export ("message")]
		string Message { get; }
	}

	// @interface IMAAdEvent : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdEvent
	{
		// @property (readonly, nonatomic) IMAAdEventType type;
		[Export ("type")]
		IMAAdEventType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * typeString;
		[Export ("typeString")]
		string TypeString { get; }

		// @property (readonly, nonatomic, strong) IMAAd * ad;
		[Export ("ad", ArgumentSemantic.Strong)]
		IMAAd Ad { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * adData;
		[Export ("adData", ArgumentSemantic.Copy)]
		NSDictionary AdData { get; }
	}

	// @interface IMAAdsLoadedData : NSObject
	[BaseType (typeof(NSObject))]
	interface IMAAdsLoadedData
	{
		// @property (readonly, nonatomic, strong) IMAAdsManager * adsManager;
		[Export ("adsManager", ArgumentSemantic.Strong)]
		IMAAdsManager AdsManager { get; }

		// @property (readonly, nonatomic, strong) IMAStreamManager * streamManager;
		[Export ("streamManager", ArgumentSemantic.Strong)]
		IMAStreamManager StreamManager { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export ("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }
	}

	// @interface IMAAdLoadingErrorData : NSObject
	[BaseType (typeof(NSObject))]
	interface IMAAdLoadingErrorData
	{
		// @property (readonly, nonatomic, strong) IMAAdError * adError;
		[Export ("adError", ArgumentSemantic.Strong)]
		IMAAdError AdError { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export ("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }
	}

    //partial interface IIMAAdsLoaderDelegate {}
	// @protocol IMAAdsLoaderDelegate
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAdsLoaderDelegate
	{
		// @required -(void)adsLoader:(IMAAdsLoader *)loader adsLoadedWithData:(IMAAdsLoadedData *)adsLoadedData;
		[Abstract]
		[Export ("adsLoader:adsLoadedWithData:")]
		void AdsLoadedWithData (IMAAdsLoader loader, IMAAdsLoadedData adsLoadedData);

		// @required -(void)adsLoader:(IMAAdsLoader *)loader failedWithErrorData:(IMAAdLoadingErrorData *)adErrorData;
		[Abstract]
		[Export ("adsLoader:failedWithErrorData:")]
		void FailedWithErrorData (IMAAdsLoader loader, IMAAdLoadingErrorData adErrorData);
	}

	// @interface IMAAdsLoader : NSObject
	[BaseType (typeof(NSObject))]
	interface IMAAdsLoader
	{
		// @property (readonly, copy, nonatomic) IMASettings * settings;
		[Export ("settings", ArgumentSemantic.Copy)]
		IMASettings Settings { get; }

		[Wrap ("WeakDelegate")]
		IMAAdsLoaderDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IMAAdsLoaderDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(NSString *)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// -(instancetype)initWithSettings:(IMASettings *)settings;
		[Export ("initWithSettings:")]
		IntPtr Constructor (IMASettings settings);

		// -(void)requestAdsWithRequest:(IMAAdsRequest *)request;
		[Export ("requestAdsWithRequest:")]
		void RequestAdsWithRequest (IMAAdsRequest request);

		// -(void)requestStreamWithRequest:(IMAStreamRequest *)request;
		[Export ("requestStreamWithRequest:")]
		void RequestStreamWithRequest (IMAStreamRequest request);

		// -(void)contentComplete;
		[Export ("contentComplete")]
		void ContentComplete ();
	}

    //partial interface IIMAAdsManagerDelegate {}
	// @protocol IMAAdsManagerDelegate
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAdsManagerDelegate
	{
		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdEvent:(IMAAdEvent *)event;
		[Abstract]
		[Export ("adsManager:didReceiveAdEvent:")]
		void AdsManager (IMAAdsManager adsManager, IMAAdEvent @event);

		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdError:(IMAAdError *)error;
		[Abstract]
		[Export ("adsManager:didReceiveAdError:")]
		void AdsManager (IMAAdsManager adsManager, IMAAdError error);

		// @required -(void)adsManagerDidRequestContentPause:(IMAAdsManager *)adsManager;
		[Abstract]
		[Export ("adsManagerDidRequestContentPause:")]
		void AdsManagerDidRequestContentPause (IMAAdsManager adsManager);

		// @required -(void)adsManagerDidRequestContentResume:(IMAAdsManager *)adsManager;
		[Abstract]
		[Export ("adsManagerDidRequestContentResume:")]
		void AdsManagerDidRequestContentResume (IMAAdsManager adsManager);

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidProgressToTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime;
		[Export ("adsManager:adDidProgressToTime:totalTime:")]
		void AdsManager (IMAAdsManager adsManager, double mediaTime, double totalTime);

		// @optional -(void)adsManagerAdPlaybackReady:(IMAAdsManager *)adsManager;
		[Export ("adsManagerAdPlaybackReady:")]
		void AdsManagerAdPlaybackReady (IMAAdsManager adsManager);

		// @optional -(void)adsManagerAdDidStartBuffering:(IMAAdsManager *)adsManager;
		[Export ("adsManagerAdDidStartBuffering:")]
		void AdsManagerAdDidStartBuffering (IMAAdsManager adsManager);

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidBufferToMediaTime:(NSTimeInterval)mediaTime;
		[Export ("adsManager:adDidBufferToMediaTime:")]
		void AdsManager (IMAAdsManager adsManager, double mediaTime);
	}

	// @interface IMAAdsManager : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdsManager
	{
		[Wrap ("WeakDelegate")]
		IMAAdsManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<IMAAdsManagerDelegate> * delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray * adCuePoints;
		[Export ("adCuePoints", ArgumentSemantic.Copy)]
		NSObject[] AdCuePoints { get; }

		// @property (readonly, nonatomic, strong) id<IMAAdPlaybackInfo> adPlaybackInfo;
		[Export ("adPlaybackInfo", ArgumentSemantic.Strong)]
		IMAAdPlaybackInfo AdPlaybackInfo { get; }

		// @property (assign, nonatomic) float volume;
		[Export ("volume")]
		float Volume { get; set; }

		// -(void)initializeWithAdsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings;
		[Export ("initializeWithAdsRenderingSettings:")]
		void InitializeWithAdsRenderingSettings (IMAAdsRenderingSettings adsRenderingSettings);

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)pause;
		[Export ("pause")]
		void Pause ();

		// -(void)resume;
		[Export ("resume")]
		void Resume ();

		// -(void)skip;
		[Export ("skip")]
		void Skip ();

        // -(void)clicked;
        [Export("clicked")]
        void Clicked();

        // -(void)destroy;
        [Export ("destroy")]
		void Destroy ();

		// -(void)discardAdBreak;
		[Export ("discardAdBreak")]
		void DiscardAdBreak ();
	}

	[Static]
	partial interface kIMAAutodetect
    {
		// extern const int kIMAAutodetectBitrate;
		[Field ("kIMAAutodetectBitrate", "__Internal")]
		int Bitrate { get; }
	}

    //partial interface IIMAWebOpenerDelegate {}
	// @protocol IMAWebOpenerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IMAWebOpenerDelegate
	{
		// @optional -(void)webOpenerWillOpenExternalBrowser:(NSObject *)webOpener;
		[Export ("webOpenerWillOpenExternalBrowser:")]
		void WebOpenerWillOpenExternalBrowser (NSObject webOpener);

		// @optional -(void)webOpenerWillOpenInAppBrowser:(NSObject *)webOpener;
		[Export ("webOpenerWillOpenInAppBrowser:")]
		void WebOpenerWillOpenInAppBrowser (NSObject webOpener);

		// @optional -(void)webOpenerDidOpenInAppBrowser:(NSObject *)webOpener;
		[Export ("webOpenerDidOpenInAppBrowser:")]
		void WebOpenerDidOpenInAppBrowser (NSObject webOpener);

		// @optional -(void)webOpenerWillCloseInAppBrowser:(NSObject *)webOpener;
		[Export ("webOpenerWillCloseInAppBrowser:")]
		void WebOpenerWillCloseInAppBrowser (NSObject webOpener);

		// @optional -(void)webOpenerDidCloseInAppBrowser:(NSObject *)webOpener;
		[Export ("webOpenerDidCloseInAppBrowser:")]
		void WebOpenerDidCloseInAppBrowser (NSObject webOpener);
	}

	// @interface IMAAdsRenderingSettings : NSObject
	[BaseType (typeof(NSObject))]
	interface IMAAdsRenderingSettings
	{
		// @property (copy, nonatomic) NSArray * mimeTypes;
		[Export ("mimeTypes", ArgumentSemantic.Copy)]
		NSObject[] MimeTypes { get; set; }

		// @property (nonatomic) int bitrate;
		[Export ("bitrate")]
		int Bitrate { get; set; }

		// @property (nonatomic) NSTimeInterval playAdsAfterTime;
		[Export ("playAdsAfterTime")]
		double PlayAdsAfterTime { get; set; }

		// @property (copy, nonatomic) NSArray * uiElements;
		[Export ("uiElements", ArgumentSemantic.Copy)]
		NSObject[] UiElements { get; set; }

        // @property (nonatomic) BOOL disableUi;
        [Export("disableUi")]
        bool DisableUi { get; set; }

        // @property (nonatomic, weak) UIViewController * webOpenerPresentingController;
        [Export ("webOpenerPresentingController", ArgumentSemantic.Weak)]
		UIViewController WebOpenerPresentingController { get; set; }

		[Wrap ("WeakWebOpenerDelegate")]
		IMAWebOpenerDelegate WebOpenerDelegate { get; set; }

		// @property (nonatomic, weak) id<IMAWebOpenerDelegate> webOpenerDelegate;
		[NullAllowed, Export ("webOpenerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakWebOpenerDelegate { get; set; }
	}

	// @interface IMAAdsRequest : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdsRequest
	{
		// @property (readonly, copy, nonatomic) NSString * adTagUrl;
		[Export ("adTagUrl")]
		string AdTagUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * adsResponse;
		[Export ("adsResponse")]
		string AdsResponse { get; }

		// @property (readonly, nonatomic, strong) IMAAdDisplayContainer * adDisplayContainer;
		[Export ("adDisplayContainer", ArgumentSemantic.Strong)]
		IMAAdDisplayContainer AdDisplayContainer { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export ("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }

		// @property (nonatomic) BOOL adWillAutoPlay;
		[Export ("adWillAutoPlay")]
		bool AdWillAutoPlay { get; set; }

        // @property (nonatomic) BOOL adWillPlayMuted;
        [Export("adWillPlayMuted")]
        bool AdWillPlayMuted { get; set; }

        // @property (nonatomic) float contentDuration;
        [Export ("contentDuration")]
		float ContentDuration { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * contentKeywords;
		[Export ("contentKeywords", ArgumentSemantic.Copy)]
		string[] ContentKeywords { get; set; }

		// @property (copy, nonatomic) NSString * contentTitle;
		[Export ("contentTitle")]
		string ContentTitle { get; set; }

        // @property (nonatomic) float vastLoadTimeout;
        [Export("vastLoadTimeout")]
        float VastLoadTimeout { get; set; }

        // @property (nonatomic) float liveStreamPrefetchSeconds;
        [Export("liveStreamPrefetchSeconds")]
        float LiveStreamPrefetchSeconds { get; set; }

        // -(instancetype)initWithAdsResponse:(NSString *)adsResponse adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer avPlayerVideoDisplay:(IMAAVPlayerVideoDisplay *)avPlayerVideoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy userContext:(id)userContext;
        //[Export ("initWithAdsResponse:adDisplayContainer:avPlayerVideoDisplay:pictureInPictureProxy:userContext:")]
        //IntPtr Constructor (string adsResponse, IMAAdDisplayContainer adDisplayContainer, IMAAVPlayerVideoDisplay avPlayerVideoDisplay, IMAPictureInPictureProxy pictureInPictureProxy, NSObject userContext);

        // -(instancetype)initWithAdsResponse:(NSString *)adsResponse adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer contentPlayhead:(NSObject<IMAContentPlayhead> *)contentPlayhead userContext:(id)userContext __attribute__((objc_designated_initializer));
        //[Export ("initWithAdsResponse:adDisplayContainer:contentPlayhead:userContext:")]
        //[DesignatedInitializer]
        //IntPtr Constructor (string adsResponse, IMAAdDisplayContainer adDisplayContainer, IIMAContentPlayhead contentPlayhead, NSObject userContext);

        //// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer avPlayerVideoDisplay:(IMAAVPlayerVideoDisplay *)avPlayerVideoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy userContext:(id)userContext;
        [Export ("initWithAdTagUrl:adDisplayContainer:avPlayerVideoDisplay:pictureInPictureProxy:userContext:")]
		IntPtr Constructor (string adTagUrl, IMAAdDisplayContainer adDisplayContainer, IMAAVPlayerVideoDisplay avPlayerVideoDisplay, IMAPictureInPictureProxy pictureInPictureProxy, [NullAllowed]NSObject userContext);

		//// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer contentPlayhead:(NSObject<IMAContentPlayhead> *)contentPlayhead userContext:(id)userContext __attribute__((objc_designated_initializer));
		[Export ("initWithAdTagUrl:adDisplayContainer:contentPlayhead:userContext:")]
		[DesignatedInitializer]
        IntPtr Constructor (string adTagUrl, IMAAdDisplayContainer adDisplayContainer, IIMAContentPlayhead contentPlayhead, [NullAllowed]NSObject userContext);
	}

    //partial interface IIMACompanionDelegate {}
	// @protocol IMACompanionDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IMACompanionDelegate
	{
		// @optional -(void)companionSlot:(IMACompanionAdSlot *)slot filled:(BOOL)filled;
		[Export ("companionSlot:filled:")]
		void CompanionSlot (IMACompanionAdSlot slot, bool filled);

		// @optional -(void)companionSlotWasClicked:(IMACompanionAdSlot *)slot;
		[Export ("companionSlotWasClicked:")]
		void CompanionSlotWasClicked (IMACompanionAdSlot slot);
	}

	// @interface IMACompanionAdSlot : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMACompanionAdSlot
	{
		// @property (readonly, nonatomic, strong) UIView * view;
		[Export ("view", ArgumentSemantic.Strong)]
		UIView View { get; }

		// @property (readonly, nonatomic) int width;
		[Export ("width")]
		int Width { get; }

		// @property (readonly, nonatomic) int height;
		[Export ("height")]
		int Height { get; }

		[Wrap ("WeakDelegate")]
		IMACompanionDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IMACompanionDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype)initWithView:(UIView *)view width:(int)width height:(int)height;
		[Export ("initWithView:width:height:")]
		IntPtr Constructor (UIView view, int width, int height);
	}

	// @interface IMACuepoint : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMACuepoint
	{
		// @property (readonly, nonatomic) NSTimeInterval startTime;
		[Export ("startTime")]
		double StartTime { get; }

		// @property (readonly, nonatomic) NSTimeInterval endTime;
		[Export ("endTime")]
		double EndTime { get; }

		// @property (readonly, getter = isPlayed, nonatomic) BOOL played;
		[Export ("played")]
		bool Played { [Bind ("isPlayed")] get; }
	}

	//[Static]
	//partial interface IMAStreamParamConstants
	//{
	//	// extern NSString *const kIMAStreamParamIU;
	//	[Field ("kIMAStreamParamIU", "__Internal")]
	//	NSString IU { get; }

	//	// extern NSString *const kIMAStreamParamDescriptionURL;
	//	[Field ("kIMAStreamParamDescriptionURL", "__Internal")]
	//	NSString DescriptionURL { get; }

	//	// extern NSString *const kIMAStreamParamCustomParameters;
	//	[Field ("kIMAStreamParamCustomParameters", "__Internal")]
	//	NSString CustomParameters { get; }

	//	// extern NSString *const kIMAStreamParamTFCD;
	//	[Field ("kIMAStreamParamTFCD", "__Internal")]
	//	NSString Tfcd { get; }

	//	// extern NSString *const kIMAStreamParamOrderVariant;
	//	[Field ("kIMAStreamParamOrderVariant", "__Internal")]
	//	NSString OrderVariant { get; }

	//	// extern NSString *const kIMAStreamParamOrderType;
	//	[Field ("kIMAStreamParamOrderType", "__Internal")]
	//	NSString OrderType { get; }
	//}

	// @interface IMAStreamRequest : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAStreamRequest
	{
		// @property (readonly, nonatomic, strong) IMAAdDisplayContainer * adDisplayContainer;
		[Export ("adDisplayContainer", ArgumentSemantic.Strong)]
		IMAAdDisplayContainer AdDisplayContainer { get; }

		// @property (readonly, nonatomic, strong) id<IMAVideoDisplay> videoDisplay;
		[Export ("videoDisplay", ArgumentSemantic.Strong)]
		IMAVideoDisplay VideoDisplay { get; }

		// @property (copy, nonatomic) NSString * apiKey;
		[Export ("apiKey")]
		string ApiKey { get; set; }

		// @property (copy, nonatomic) NSString * authToken;
		[Export ("authToken")]
		string AuthToken { get; set; }

		// @property (copy, nonatomic) NSString * streamActivityMonitorID;
		[Export ("streamActivityMonitorID")]
		string StreamActivityMonitorID { get; set; }

		// @property (copy, nonatomic) NSDictionary * adTagParameters;
		[Export ("adTagParameters", ArgumentSemantic.Copy)]
		NSDictionary AdTagParameters { get; set; }

		// @property (copy, nonatomic) NSString * manifestURLSuffix;
		[Export ("manifestURLSuffix")]
		string ManifestURLSuffix { get; set; }
	}

	// @interface IMALiveStreamRequest : IMAStreamRequest
	[BaseType (typeof(IMAStreamRequest))]
	[DisableDefaultCtor]
	interface IMALiveStreamRequest
	{
		// @property (readonly, copy, nonatomic) NSString * assetKey;
		[Export ("assetKey")]
		string AssetKey { get; }

		// @property (nonatomic) BOOL attemptPreroll;
		//[Export ("attemptPreroll")]
		//bool AttemptPreroll { get; set; }

		// -(instancetype)initWithAssetKey:(NSString *)assetKey adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay;
		[Export ("initWithAssetKey:adDisplayContainer:videoDisplay:")]
		IntPtr Constructor (string assetKey, IMAAdDisplayContainer adDisplayContainer, IMAVideoDisplay videoDisplay);

		// -(instancetype)initWithAssetKey:(NSString *)assetKey adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy;
		[Export ("initWithAssetKey:adDisplayContainer:videoDisplay:pictureInPictureProxy:")]
		IntPtr Constructor (string assetKey, IMAAdDisplayContainer adDisplayContainer, IMAVideoDisplay videoDisplay, IMAPictureInPictureProxy pictureInPictureProxy);
	}

	// @interface IMAPictureInPictureProxy : NSProxy <AVPictureInPictureControllerDelegate, AVPlayerViewControllerDelegate>
    [BaseType (typeof(NSObject))]
	interface IMAPictureInPictureProxy : IAVPictureInPictureControllerDelegate, IAVPlayerViewControllerDelegate
	{
		// @property (readonly, getter = isPictureInPictureActive, nonatomic) BOOL pictureInPictureActive;
		[Export ("pictureInPictureActive")]
		bool PictureInPictureActive { [Bind ("isPictureInPictureActive")] get; }

		// +(BOOL)isPictureInPictureSupported;
		[Static]
		[Export ("isPictureInPictureSupported")]
		bool IsPictureInPictureSupported { get; }

		// -(instancetype)initWithAVPictureInPictureControllerDelegate:(id<AVPictureInPictureControllerDelegate>)delegate;
		[Export ("initWithAVPictureInPictureControllerDelegate:")]
		IntPtr Constructor (IAVPictureInPictureControllerDelegate @delegate);

		// -(instancetype)initWithAVPlayerViewControllerDelegate:(id<AVPlayerViewControllerDelegate>)delegate;
		[Export ("initWithAVPlayerViewControllerDelegate:")]
		IntPtr Constructor (IAVPlayerViewControllerDelegate @delegate);
	}

	// @interface IMASettings : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface IMASettings : INSCopying
	{
		// @property (copy, nonatomic) NSString * ppid;
		[Export ("ppid")]
		string Ppid { get; set; }

		// @property (copy, nonatomic) NSString * language;
		[Export ("language")]
		string Language { get; set; }

		// @property (nonatomic) NSUInteger maxRedirects;
		[Export ("maxRedirects")]
		nuint MaxRedirects { get; set; }

		// @property (nonatomic) BOOL enableBackgroundPlayback;
		[Export ("enableBackgroundPlayback")]
		bool EnableBackgroundPlayback { get; set; }

		// @property (nonatomic) BOOL autoPlayAdBreaks;
		[Export ("autoPlayAdBreaks")]
		bool AutoPlayAdBreaks { get; set; }

		// @property (nonatomic) BOOL disableNowPlayingInfo;
		[Export ("disableNowPlayingInfo")]
		bool DisableNowPlayingInfo { get; set; }

		// @property (copy, nonatomic) NSString * playerType;
		[Export ("playerType")]
		string PlayerType { get; set; }

		// @property (copy, nonatomic) NSString * playerVersion;
		[Export ("playerVersion")]
		string PlayerVersion { get; set; }

		// @property (nonatomic) BOOL enableDebugMode;
		[Export ("enableDebugMode")]
		bool EnableDebugMode { get; set; }
	}

    //partial interface IIMAStreamManagerDelegate {}

	// @protocol IMAStreamManagerDelegate
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAStreamManagerDelegate
	{
		// @required -(void)streamManager:(IMAStreamManager *)streamManager didReceiveAdEvent:(IMAAdEvent *)event;
		[Abstract]
		[Export ("streamManager:didReceiveAdEvent:")]
		void DidReceiveAdEvent (IMAStreamManager streamManager, IMAAdEvent @event);

		// @required -(void)streamManager:(IMAStreamManager *)streamManager didReceiveAdError:(IMAAdError *)error;
		[Abstract]
		[Export ("streamManager:didReceiveAdError:")]
		void DidReceiveAdError (IMAStreamManager streamManager, IMAAdError error);

		// @required -(void)streamManager:(IMAStreamManager *)streamManager adDidProgressToTime:(NSTimeInterval)time adDuration:(NSTimeInterval)adDuration adPosition:(NSInteger)adPosition totalAds:(NSInteger)totalAds adBreakDuration:(NSTimeInterval)adBreakDuration;
		[Abstract]
		[Export ("streamManager:adDidProgressToTime:adDuration:adPosition:totalAds:adBreakDuration:")]
		void AdDidProgressToTime (IMAStreamManager streamManager, double time, double adDuration, nint adPosition, nint totalAds, double adBreakDuration);
	}

	// @interface IMAStreamManager : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAStreamManager
	{
		[Wrap ("WeakDelegate")]
		IMAStreamManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<IMAStreamManagerDelegate> * delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * streamId;
		[Export ("streamId")]
		string StreamId { get; }

		// -(void)initializeWithAdsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings;
		[Export ("initializeWithAdsRenderingSettings:")]
		void InitializeWithAdsRenderingSettings (IMAAdsRenderingSettings adsRenderingSettings);

		// -(NSTimeInterval)streamTimeForContentTime:(NSTimeInterval)contentTime;
		[Export ("streamTimeForContentTime:")]
		double StreamTimeForContentTime (double contentTime);

		// -(NSTimeInterval)contentTimeForStreamTime:(NSTimeInterval)streamTime;
		[Export ("contentTimeForStreamTime:")]
		double ContentTimeForStreamTime (double streamTime);

		// -(IMACuepoint *)previousCuepointForStreamTime:(NSTimeInterval)streamTime;
		[Export ("previousCuepointForStreamTime:")]
		IMACuepoint PreviousCuepointForStreamTime (double streamTime);

		// -(void)destroy;
		[Export ("destroy")]
		void Destroy ();
	}

	// @interface IMAVODStreamRequest : IMAStreamRequest
	[BaseType (typeof(IMAStreamRequest))]
	[DisableDefaultCtor]
	interface IMAVODStreamRequest
	{
		// @property (readonly, copy, nonatomic) NSString * contentSourceID;
		[Export ("contentSourceID")]
		string ContentSourceID { get; }

		// @property (readonly, copy, nonatomic) NSString * videoID;
		[Export ("videoID")]
		string VideoID { get; }

		// -(instancetype)initWithContentSourceID:(NSString *)contentSourceID videoID:(NSString *)videoID adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay;
		[Export ("initWithContentSourceID:videoID:adDisplayContainer:videoDisplay:")]
		IntPtr Constructor (string contentSourceID, string videoID, IMAAdDisplayContainer adDisplayContainer, IMAVideoDisplay videoDisplay);

		// -(instancetype)initWithContentSourceID:(NSString *)contentSourceID videoID:(NSString *)videoID adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy;
		[Export ("initWithContentSourceID:videoID:adDisplayContainer:videoDisplay:pictureInPictureProxy:")]
		IntPtr Constructor (string contentSourceID, string videoID, IMAAdDisplayContainer adDisplayContainer, IMAVideoDisplay videoDisplay, IMAPictureInPictureProxy pictureInPictureProxy);
	}
}
