using System;
using AVFoundation;
using AVKit;
using Foundation;
using UIKit;
using GoogleIMA;

namespace GoogleIMAQs
{
    public partial class ViewController : UIViewController
    {
        public AVPlayer ContentPlayer { get; set; }
        public IMAAdsLoader AdsLoader { get; set; }
        public IMAAVPlayerContentPlayhead ContentPlayhead { get; set; }
        public IMAAdsManager AdsManager { get; set; }
        public const string TestContentUrl_MP4 = "https://0.s3.envato.com/h264-video-previews/80fad324-9db4-11e3-bf3d-0050569255a8/490527.mp4";
        public const string TestAdTagUrl = "https://test.bopodastaging.top/vmap/70.xml";

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.SetupAdsLoader();
            this.SetupContentPlayer();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        /// <summary>
        /// Setups the content player.
        /// </summary>
        private void SetupContentPlayer()
        {
            NSUrl contentUrl = NSUrl.FromString(TestContentUrl_MP4);

            this.ContentPlayer = AVPlayer.FromUrl(contentUrl);

            AVPlayerViewController controller = new AVPlayerViewController();
            controller.Player = this.ContentPlayer;

            AddChildViewController(controller);
            View.AddSubview(controller.View);
            controller.View.Frame = View.Frame;

            this.ContentPlayhead = new IMAAVPlayerContentPlayhead(this.ContentPlayer);
            NSNotificationCenter.DefaultCenter.AddObserver(observer:this, 
                                                           aSelector: new ObjCRuntime.Selector("contentDidFinishPlaying:"), 
                                                           aName: AVPlayerItem.DidPlayToEndTimeNotification, 
                                                           anObject: this.ContentPlayer.CurrentItem);

            this.RequestAds();
        }

        /// <summary>
        /// Setups the ads loader.
        /// </summary>
        private void SetupAdsLoader()
        {
            IMASettings settings = new IMASettings()
            {
                Language = "zh-CN"
            };
            this.AdsLoader = new IMAAdsLoader(settings);
            this.AdsLoader.Delegate = new MYPlayerAdsLoaderDelegate(new WeakReference<ViewController>(this));
        }

        /// <summary>
        /// Requests the ads.
        /// </summary>
        private void RequestAds()
        {
            IMAAdDisplayContainer adDisplayContainer = new IMAAdDisplayContainer(this.View, null);
            IMAAdsRequest request = new IMAAdsRequest(TestAdTagUrl, adDisplayContainer, this.ContentPlayhead, null);

            this.AdsLoader.RequestAdsWithRequest(request);
        }

        /// <summary>
        /// Contents the did finish playing.
        /// </summary>
        /// <param name="notification">Notification.</param>
        [Export("contentDidFinishPlaying:")]
        private void ContentDidFinishPlaying(NSNotification notification)
        {
            if(notification.Object == this.ContentPlayer?.CurrentItem)
            {
                this.AdsLoader.ContentComplete();
            }
        }
    }

    /// <summary>
    /// Player ads loader delegate.
    /// </summary>
    public class MYPlayerAdsLoaderDelegate : IMAAdsLoaderDelegate
    {
        private ViewController weakSelf;

        public MYPlayerAdsLoaderDelegate(WeakReference<ViewController> parent)
        {
            if (parent.TryGetTarget(out ViewController controller))
            {
                weakSelf = controller;
            }
        }

        /// <summary>
        /// Adses the loaded with data.
        /// </summary>
        /// <param name="loader">Loader.</param>
        /// <param name="adsLoadedData">Ads loaded data.</param>
        public override void AdsLoadedWithData(IMAAdsLoader loader, IMAAdsLoadedData adsLoadedData)
        {
            if (weakSelf == null)
                return;
            // Grab the instance of the IMAAdsManager and set ourselves as the delegate.
            weakSelf.AdsManager = adsLoadedData.AdsManager;
            weakSelf.AdsManager.Delegate = new MYPlayerAdsManagerDelegate(new WeakReference<ViewController>(weakSelf));
            // Create ads rendering settings to tell the SDK to use the in-app browser.
            IMAAdsRenderingSettings adsRenderingSettings = new IMAAdsRenderingSettings();
            adsRenderingSettings.WebOpenerDelegate = new MYPlayerWebOpenerDelegate(new WeakReference<ViewController>(weakSelf));
            adsRenderingSettings.WebOpenerPresentingController = weakSelf;
            weakSelf.AdsManager.InitializeWithAdsRenderingSettings(adsRenderingSettings);
        }

        /// <summary>
        /// Faileds the with error data.
        /// </summary>
        /// <param name="loader">Loader.</param>
        /// <param name="adErrorData">Ad error data.</param>
        public override void FailedWithErrorData(IMAAdsLoader loader, IMAAdLoadingErrorData adErrorData)
        {
            if (weakSelf == null)
                return;
            System.Diagnostics.Debug.WriteLine(adErrorData.AdError.Message);
            weakSelf.ContentPlayer?.Play();
        }
    }

    /// <summary>
    /// Player ads manager delegate.
    /// </summary>
    public class MYPlayerAdsManagerDelegate : IMAAdsManagerDelegate
    {
        private ViewController weakSelf;
        public MYPlayerAdsManagerDelegate(WeakReference<ViewController> parent)
        {
            if (parent.TryGetTarget(out ViewController controller))
            {
                weakSelf = controller;
            }
        }

        /// <summary>
        /// Adses the manager.
        /// </summary>
        /// <param name="adsManager">Ads manager.</param>
        /// <param name="event">Event.</param>
        public override void AdsManager(IMAAdsManager adsManager, IMAAdEvent @event)
        {
            if (@event.Type == IMAAdEventType.Loaded)
            {
                adsManager.Start();
            }
            else if(@event.Type == IMAAdEventType.Clicked)
            {
                adsManager.Pause();
            }
        }

        /// <summary>
        /// Adses the manager failed with error data.
        /// </summary>
        /// <param name="adsManager">Ads manager.</param>
        /// <param name="error">Error.</param>
        public override void AdsManager(IMAAdsManager adsManager, IMAAdError error)
        {
            if (weakSelf == null)
                return;
            System.Diagnostics.Debug.WriteLine(error.Message);
            weakSelf.ContentPlayer?.Play();
        }

        /// <summary>
        /// Adses the manager did request content pause.
        /// </summary>
        /// <param name="adsManager">Ads manager.</param>
        public override void AdsManagerDidRequestContentPause(IMAAdsManager adsManager)
        {
            if (weakSelf == null)
                return;
            // The SDK is going to play ads, so pause the content.
            weakSelf.ContentPlayer?.Pause();
        }

        /// <summary>
        /// Adses the manager did request content resume.
        /// </summary>
        /// <param name="adsManager">Ads manager.</param>
        public override void AdsManagerDidRequestContentResume(IMAAdsManager adsManager)
        {
            if (weakSelf == null)
                return;
            // The SDK is done playing ads (at least for now), so resume the content.
            weakSelf.ContentPlayer?.Play();
        }
    }

    /// <summary>
    /// Player web opener delegate.
    /// </summary>
    public class MYPlayerWebOpenerDelegate : IMAWebOpenerDelegate
    {
        private ViewController weakSelf;
        public MYPlayerWebOpenerDelegate(WeakReference<ViewController> parent)
        {
            if (parent.TryGetTarget(out ViewController controller))
            {
                weakSelf = controller;
            }
        }

        /// <summary>
        /// Webs the opener did close in app browser.
        /// </summary>
        /// <param name="webOpener">Web opener.</param>
        public override void WebOpenerDidCloseInAppBrowser(NSObject webOpener)
        {
            System.Diagnostics.Debug.WriteLine("WebOpenerDidCloseInAppBrowser");
            weakSelf.AdsManager?.Resume();
        }
    }
}
