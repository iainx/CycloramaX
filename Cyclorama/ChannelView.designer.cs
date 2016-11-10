// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Cyclorama
{
	[Register ("ChannelView")]
	partial class ChannelView
	{
		[Outlet]
		AppKit.NSButton FilterSelector1 { get; set; }

		[Outlet]
		AppKit.NSButton FilterSelector2 { get; set; }

		[Outlet]
		Cyclorama.PlaybackPreviewView PreviewView { get; set; }

		[Action ("SelectFirstFilter:")]
		partial void SelectFirstFilter (Foundation.NSObject sender);

		[Action ("SelectSecondFilter:")]
		partial void SelectSecondFilter (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (PreviewView != null) {
				PreviewView.Dispose ();
				PreviewView = null;
			}

			if (FilterSelector1 != null) {
				FilterSelector1.Dispose ();
				FilterSelector1 = null;
			}

			if (FilterSelector2 != null) {
				FilterSelector2.Dispose ();
				FilterSelector2 = null;
			}
		}
	}
}
