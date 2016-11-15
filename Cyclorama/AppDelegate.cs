using System;

using AppKit;
using Foundation;

using Cyclorama.Filter;

namespace Cyclorama
{
    [Register ("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public NSWindowController PerformanceWindowController { get; private set; }

        public Performance Performance { get; private set; }

        public AppDelegate ()
        {
            Performance = new Performance ();
        }

        public override void DidFinishLaunching (NSNotification notification)
        {
            // Insert code here to initialize your application
            var storyboard = NSStoryboard.FromName ("Main", null);
            PerformanceWindowController = (NSWindowController)storyboard.InstantiateControllerWithIdentifier ("PerformanceWindowController");
            PerformanceWindowController.Window.OrderFront (null);

            Console.WriteLine ($"{FilterModel.Categories.Count}");
        }

        public override void WillTerminate (NSNotification notification)
        {
            // Insert code here to tear down your application

            foreach (var channel in Performance.Channels) {
                channel.Player.Pause ();
            }
        }
    }
}
