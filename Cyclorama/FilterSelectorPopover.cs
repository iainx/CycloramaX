using System;

using AppKit;

namespace Cyclorama
{
    public class FilterSelectorPopover : NSPopover
    {
        public FilterSelectorPopover ()
        {
            Behavior = NSPopoverBehavior.Transient;

            var storyboard = NSStoryboard.FromName ("Main", null);
            ContentViewController = (NSViewController)storyboard.InstantiateControllerWithIdentifier ("FilterSelectorViewController");
        }
    }
}
