using System;

using AppKit;
using Foundation;

using AVFoundation;
using CoreImage;

namespace Cyclorama
{
    public partial class ViewController : NSViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        Performance performance;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            performance = ((AppDelegate)NSApplication.SharedApplication.Delegate).Performance;

            LeftChannelView.Channel = performance.LeftChannel;
            RightChannelView.Channel = performance.RightChannel;
        }

        public override void ViewDidAppear ()
        {
            base.ViewDidAppear ();

            performance.LeftChannel.Player.Play ();
            performance.RightChannel.Player.Play ();
        }

        public override NSObject RepresentedObject {
            get {
                return base.RepresentedObject;
            }
            set {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
