using System;

using AppKit;
using CoreImage;
using Foundation;

using Cyclorama.FilterSelector;

namespace Cyclorama
{
    public partial class ChannelView : NSView
    {
        #region Constructors

        FilterSelectorPopover popover;

        Performance.Channel channel;
        public Performance.Channel Channel { 
            get {
                return channel;
            } 
            set {
                channel = value;
                PreviewView.Player = channel.Player;
            }
        }

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

        public override void AwakeFromNib ()
        {
            PreviewView.FilePathDropped += (sender, e) => {
                channel.FilePath = e.FilePath;
            };
        }

        public override CoreGraphics.CGSize IntrinsicContentSize
        {
            get {
                return new CoreGraphics.CGSize (320, 314);
            }
        }

        partial void SelectFirstFilter (NSObject sender)
        {
            popover = new FilterSelectorPopover ();
            var vc = (FilterSelectorViewController)popover.ContentViewController;
            vc.FilterSelected += (s, e) => {
                var item = e.FilterItem;
                FilterSelector1.Title = item.Name;
                Channel.Filters [0] = CIFilter.FromName (item.FilterName);
                popover.Close ();
                popover = null;
            };
            popover.Show (CoreGraphics.CGRect.Empty, FilterSelector1, NSRectEdge.MinYEdge);
        }

        partial void SelectSecondFilter (NSObject sender)
        {
            var popover = new FilterSelectorPopover ();
            var vc = (FilterSelectorViewController)popover.ContentViewController;
            vc.FilterSelected += (s, e) => {
                var item = e.FilterItem;
                FilterSelector2.Title = item.Name;
                Channel.Filters [1] = CIFilter.FromName (item.FilterName);
                popover.Close ();
                popover = null;
            };
            popover.Show (CoreGraphics.CGRect.Empty, FilterSelector2, NSRectEdge.MinYEdge);
        }

        partial void KeyColorChanged (Foundation.NSObject sender)
        {
            var color = ChromaKeyColor.Color;
            channel.KeyColor = new CIColor (color);
        }

        partial void UseChromaKeyToggled (Foundation.NSObject sender)
        {
            channel.UseChromaKey = (UseChromaKey.State == NSCellStateValue.On);
        }
    }
}
