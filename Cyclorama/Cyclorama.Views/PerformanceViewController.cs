// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using AVFoundation;

namespace Cyclorama.Views
{
    public partial class PerformanceViewController : NSViewController, INSTouchBarDelegate
	{
        public PerformanceView MainPerformanceView { get { return MainView; } }

        Performance performance;
		public PerformanceViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewWillAppear ()
        {
            base.ViewWillAppear ();
            View.Window.MakeFirstResponder (View);

            performance = ((AppDelegate)NSApplication.SharedApplication.Delegate).Performance;
            MainView.BackgroundLayer.Contents = performance.Background.CGImage;

            MainView.LeftPlayer = performance.LeftChannel.Player;
            MainView.RightPlayer = performance.RightChannel.Player;

            if (performance.CrossfaderActive) {
                MainView.LeftVideo.Opacity = 1.0f - performance.CrossfaderValue;
                MainView.RightVideo.Opacity = performance.CrossfaderValue;
            }

            performance.LeftChannel.ActiveChanged += (sender, e) => {
                MainView.LeftVideo.Hidden = !performance.LeftChannel.Active;
            };
            performance.RightChannel.ActiveChanged += (sender, e) => {
                MainView.RightVideo.Hidden = !performance.RightChannel.Active;
            };
            performance.CrossfaderActiveChanged += (sender, e) => {
                MainView.LeftVideo.Opacity = (performance.CrossfaderActive ? 1.0f - performance.CrossfaderValue : 1.0f);
                MainView.RightVideo.Opacity = (performance.CrossfaderActive ? performance.CrossfaderValue : 1.0f);
            };
            performance.CrossfaderChanged += (sender, e) => {
                if (performance.CrossfaderActive) {
                    MainView.LeftVideo.Opacity = 1.0f - performance.CrossfaderValue;
                    MainView.RightVideo.Opacity = performance.CrossfaderValue;
                }
            };

            performance.BackgroundChanged += (sender, e) => {
                MainView.BackgroundLayer.Contents = performance.Background.CGImage;
            };
        }
	}
}