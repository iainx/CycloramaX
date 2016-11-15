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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		Cyclorama.ChannelView LeftChannelView { get; set; }

		[Outlet]
		Cyclorama.PlaybackPreviewView LeftPreview { get; set; }

		[Outlet]
		AppKit.NSLayoutConstraint LeftPreviewHeightConstraint { get; set; }

		[Outlet]
		AppKit.NSLayoutConstraint LeftPreviewWidthConstraint { get; set; }

		[Outlet]
		Cyclorama.ChannelView RightChannelView { get; set; }

		[Outlet]
		Cyclorama.PlaybackPreviewView RightPreview { get; set; }

		[Outlet]
		AppKit.NSLayoutConstraint RightPreviewHeightConstraint { get; set; }

		[Outlet]
		AppKit.NSLayoutConstraint RightPreviewWidthConstraint { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LeftPreview != null) {
				LeftPreview.Dispose ();
				LeftPreview = null;
			}

			if (LeftPreviewHeightConstraint != null) {
				LeftPreviewHeightConstraint.Dispose ();
				LeftPreviewHeightConstraint = null;
			}

			if (LeftPreviewWidthConstraint != null) {
				LeftPreviewWidthConstraint.Dispose ();
				LeftPreviewWidthConstraint = null;
			}

			if (RightPreview != null) {
				RightPreview.Dispose ();
				RightPreview = null;
			}

			if (RightPreviewHeightConstraint != null) {
				RightPreviewHeightConstraint.Dispose ();
				RightPreviewHeightConstraint = null;
			}

			if (RightPreviewWidthConstraint != null) {
				RightPreviewWidthConstraint.Dispose ();
				RightPreviewWidthConstraint = null;
			}

			if (LeftChannelView != null) {
				LeftChannelView.Dispose ();
				LeftChannelView = null;
			}

			if (RightChannelView != null) {
				RightChannelView.Dispose ();
				RightChannelView = null;
			}
		}
	}
}
