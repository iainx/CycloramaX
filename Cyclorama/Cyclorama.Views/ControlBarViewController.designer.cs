// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Cyclorama.Views
{
	[Register ("ControlBarViewController")]
	partial class ControlBarViewController
	{
		[Outlet]
		AppKit.NSButton Channel1Toggle { get; set; }

		[Outlet]
		AppKit.NSButton Channel2Toggle { get; set; }

		[Outlet]
		AppKit.NSSlider CrossFader { get; set; }

		[Outlet]
		AppKit.NSButton CrossfaderToggle { get; set; }

		[Action ("Channel1Activated:")]
		partial void Channel1Activated (Foundation.NSObject sender);

		[Action ("Channel2Activated:")]
		partial void Channel2Activated (Foundation.NSObject sender);

		[Action ("CrossfaderActivated:")]
		partial void CrossfaderActivated (Foundation.NSObject sender);

		[Action ("CrossfaderMoved:")]
		partial void CrossfaderMoved (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Channel1Toggle != null) {
				Channel1Toggle.Dispose ();
				Channel1Toggle = null;
			}

			if (Channel2Toggle != null) {
				Channel2Toggle.Dispose ();
				Channel2Toggle = null;
			}

			if (CrossFader != null) {
				CrossFader.Dispose ();
				CrossFader = null;
			}

			if (CrossfaderToggle != null) {
				CrossfaderToggle.Dispose ();
				CrossfaderToggle = null;
			}
		}
	}
}
