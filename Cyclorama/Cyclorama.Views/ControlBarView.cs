using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama.Views
{
    public partial class ControlBarView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public ControlBarView (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public ControlBarView (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        public override CoreGraphics.CGSize IntrinsicContentSize {
            get {
                return new CoreGraphics.CGSize (-1, 93);
            }
        }
    }
}
