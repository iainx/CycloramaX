// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using AVFoundation;

namespace Cyclorama
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
            MainView.LeftPlayer = performance.LeftChannel.Player;
            MainView.RightPlayer = performance.RightChannel.Player;
        }
	}
}