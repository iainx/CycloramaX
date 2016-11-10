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

        AVAsset leftAsset, rightAsset;
        AVPlayerItem leftItem, rightItem;
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            performance = ((AppDelegate)NSApplication.SharedApplication.Delegate).Performance;

            LeftPreview.Player = performance.LeftChannel.Player;
            RightPreview.Player = performance.RightChannel.Player;
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
