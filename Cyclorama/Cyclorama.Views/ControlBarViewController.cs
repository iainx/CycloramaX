using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama.Views
{
    public partial class ControlBarViewController : AppKit.NSViewController
    {
        #region Constructors

        Performance performance;
        public Performance Performance {
            get {
                return performance;
            }

            set {
                performance = value;
                Channel1Toggle.State = Performance.LeftChannel.Active ? NSCellStateValue.On : NSCellStateValue.Off;
                Channel2Toggle.State = Performance.RightChannel.Active ? NSCellStateValue.On : NSCellStateValue.Off;
                CrossFader.FloatValue = Performance.CrossfaderValue * 100;
                CrossfaderToggle.State = Performance.CrossfaderActive ? NSCellStateValue.On : NSCellStateValue.Off;
            }
        }

        // Called when created from unmanaged code
        public ControlBarViewController (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public ControlBarViewController (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Call to load from the XIB/NIB file
        public ControlBarViewController () : base ("ControlBarView", NSBundle.MainBundle)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
        }

        //strongly typed view accessor
        public new ControlBarView View {
            get {
                return (ControlBarView)base.View;
            }
        }

        partial void Channel1Activated (Foundation.NSObject sender)
        {
            Performance.LeftChannel.Active = (Channel1Toggle.State == NSCellStateValue.On);
        }

        partial void Channel2Activated (Foundation.NSObject sender)
        {
            Performance.RightChannel.Active = (Channel2Toggle.State == NSCellStateValue.On);
        }

        partial void CrossfaderActivated (Foundation.NSObject sender)
        {
            Performance.CrossfaderActive = (CrossfaderToggle.State == NSCellStateValue.On);
        }

        partial void CrossfaderMoved (NSObject sender)
        {
            Performance.CrossfaderValue = CrossFader.FloatValue / 100.0f;
        }
    }
}
