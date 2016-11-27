using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama
{
    public partial class ChannelViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public ChannelViewController (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public ChannelViewController (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Call to load from the XIB/NIB file
        public ChannelViewController () : base ("ChannelView", NSBundle.MainBundle)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        //strongly typed view accessor
        public new ChannelView View {
            get {
                return (ChannelView)base.View;
            }
        }
    }
}
