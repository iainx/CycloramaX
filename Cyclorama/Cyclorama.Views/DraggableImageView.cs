using System;

using AppKit;
using Foundation;

namespace Cyclorama.Views
{
    public class DraggableImageView : NSImageView
    {
        public DraggableImageView ()
        {
            RegisterForDraggedTypes (NSImage.ImageTypes);
        }

        public override NSDragOperation DraggingEntered (NSDraggingInfo sender)
        {
            var pboard = sender.DraggingPasteboard;
            if (NSImage.CanInitWithPasteboard (pboard)) {
                var array = new NSMutableArray ();
                sender.EnumerateDraggingItems (NSDraggingItemEnumerationOptions.Concurrent, this,
                                               array, new NSDictionary (),
                                               (NSDraggingItem item, nint idx, ref bool stop) => {
                                                   item.SetDraggingFrame (this.Bounds, item.ImageComponents [0].Contents);
                });
                return NSDragOperation.Copy;
            }

            return NSDragOperation.None;
        }

        public override void DraggingExited (NSDraggingInfo sender)
        {
        }

        public override bool PrepareForDragOperation (NSDraggingInfo sender)
        {
            return NSImage.CanInitWithPasteboard (sender.DraggingPasteboard);
        }

        public override bool PerformDragOperation (NSDraggingInfo sender)
        {
            if (sender.DraggingSource == this) {
                return true;
            }

            if (NSImage.CanInitWithPasteboard (sender.DraggingPasteboard)) {
                var newImage = new NSImage (sender.DraggingPasteboard);
                Image = newImage;
                ImageChanged?.Invoke (this, EventArgs.Empty);
            }

            return true;
        }

        public event EventHandler ImageChanged;
    }
}
