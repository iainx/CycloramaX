// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using AVFoundation;

namespace Cyclorama
{
    public partial class PerformanceWindowController : NSWindowController, INSTouchBarDelegate
	{
        /*
        public AVPlayer LeftPlayer { get; set; }
        public AVPlayer RightPlayer { get; set; }

        NSSlider slider;
*/
		public PerformanceWindowController (IntPtr handle) : base (handle)
		{
		}

        public override void WindowDidLoad ()
        {
            base.WindowDidLoad ();
        }

        /*
        public override NSTouchBar MakeTouchBar ()
        {
            var touchbar = new NSTouchBar ();
            touchbar.Delegate = this;

            touchbar.DefaultItemIdentifiers = new string [] { "crossfader" };
            return touchbar;
        }

        [Export ("touchBar:makeItemForIdentifier:")]
        public NSTouchBarItem MakeItem (NSTouchBar touchBar, string identifier)
        {
            var item = new NSSliderTouchBarItem ("crossfader");
            item.Label = "Crossfader";

            item.Activated += (sender, e) => {
                var pv = (PerformanceView)Window.ContentView.Subviews [0];
                pv.CrossfaderPosition = slider.FloatValue;
            };

            slider = item.Slider;

            return item;
        }

        [Export ("sliderAction:")]
        void SliderAction (NSObject sender)
        {
            var pv = (PerformanceView)Window.ContentView.Subviews [0];
            pv.CrossfaderPosition = slider.FloatValue;
        }
        */
	}
}
