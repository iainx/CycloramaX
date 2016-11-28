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
	[Register ("ChannelView")]
	partial class ChannelView
	{
		[Outlet]
		AppKit.NSColorWell ChromaKeyColor { get; set; }

		[Outlet]
		AppKit.NSButton FilterSelector1 { get; set; }

		[Outlet]
		AppKit.NSButton FilterSelector2 { get; set; }

		[Outlet]
		Cyclorama.Views.PlaybackPreviewView PreviewView { get; set; }

		[Outlet]
		AppKit.NSSlider SpeedControl { get; set; }

		[Outlet]
		AppKit.NSButton UseChromaKey { get; set; }

		[Action ("KeyColorChanged:")]
		partial void KeyColorChanged (Foundation.NSObject sender);

		[Action ("SelectFirstFilter:")]
		partial void SelectFirstFilter (Foundation.NSObject sender);

		[Action ("SelectSecondFilter:")]
		partial void SelectSecondFilter (Foundation.NSObject sender);

		[Action ("SpeedChanged:")]
		partial void SpeedChanged (Foundation.NSObject sender);

		[Action ("UseChromaKeyToggled:")]
		partial void UseChromaKeyToggled (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ChromaKeyColor != null) {
				ChromaKeyColor.Dispose ();
				ChromaKeyColor = null;
			}

			if (FilterSelector1 != null) {
				FilterSelector1.Dispose ();
				FilterSelector1 = null;
			}

			if (FilterSelector2 != null) {
				FilterSelector2.Dispose ();
				FilterSelector2 = null;
			}

			if (PreviewView != null) {
				PreviewView.Dispose ();
				PreviewView = null;
			}

			if (UseChromaKey != null) {
				UseChromaKey.Dispose ();
				UseChromaKey = null;
			}

			if (SpeedControl != null) {
				SpeedControl.Dispose ();
				SpeedControl = null;
			}
		}
	}
}
