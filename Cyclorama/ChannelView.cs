using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama
{
    public partial class ChannelView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public ChannelView (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public ChannelView (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        partial void SelectFirstFilter (NSObject sender)
        {
            var popover = new FilterSelectorPopover ();
            popover.Show (CoreGraphics.CGRect.Empty, FilterSelector1, NSRectEdge.MinYEdge);
        }

        partial void SelectSecondFilter (NSObject sender)
        {
            var popover = new FilterSelectorPopover ();
            popover.Show (CoreGraphics.CGRect.Empty, FilterSelector2, NSRectEdge.MinYEdge);
        }
    }
}
