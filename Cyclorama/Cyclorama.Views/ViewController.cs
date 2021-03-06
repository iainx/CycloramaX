﻿using System;

using AppKit;
using Foundation;

using AVFoundation;
using CoreImage;

namespace Cyclorama.Views
{
    public partial class ViewController : NSViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        Performance performance;

        ChannelViewController leftChannelViewController;
        ChannelViewController rightChannelViewController;
        ChannelView leftChannelView;
        ChannelView rightChannelView;
        DraggableImageView backgroundImageView;

        ControlBarViewController controlBarViewController;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            performance = ((AppDelegate)NSApplication.SharedApplication.Delegate).Performance;

            controlBarViewController = new ControlBarViewController ();
            controlBarViewController.View.TranslatesAutoresizingMaskIntoConstraints = false;

            leftChannelViewController = new ChannelViewController ();
            rightChannelViewController = new ChannelViewController ();

            leftChannelView = leftChannelViewController.View;
            leftChannelView.TranslatesAutoresizingMaskIntoConstraints = false;
            leftChannelView.Identifier = "LeftChannel";
            rightChannelView = rightChannelViewController.View;
            rightChannelView.TranslatesAutoresizingMaskIntoConstraints = false;
            rightChannelView.Identifier = "RightChannel";

            backgroundImageView = new DraggableImageView ();
            backgroundImageView.TranslatesAutoresizingMaskIntoConstraints = false;
            backgroundImageView.ImageChanged += (sender, obj) => {
                performance.Background = backgroundImageView.Image;
            };

            View.AddSubview (leftChannelView);
            View.AddSubview (rightChannelView);
            View.AddSubview (controlBarViewController.View);
            View.AddSubview (backgroundImageView);

            leftChannelView.Channel = performance.LeftChannel;
            rightChannelView.Channel = performance.RightChannel;

            backgroundImageView.Image = performance.Background;

            var viewsDict = new NSDictionary ("left", leftChannelView, "right", rightChannelView, "control", controlBarViewController.View,
                                              "background", backgroundImageView);
            var constraints = NSLayoutConstraint.FromVisualFormat ("|-20-[left]-40-[right]-20-|", NSLayoutFormatOptions.AlignAllBottom,
                                                                   null, viewsDict);
            View.AddConstraints (constraints);
            constraints = NSLayoutConstraint.FromVisualFormat ("|-20-[background]-20-[control]-20-|", NSLayoutFormatOptions.None, null, viewsDict);
            View.AddConstraints (constraints);
            constraints = NSLayoutConstraint.FromVisualFormat ("V:|[left][background]|", NSLayoutFormatOptions.None, null, viewsDict);
            View.AddConstraints (constraints);
            constraints = NSLayoutConstraint.FromVisualFormat ("V:|[right][control]|", NSLayoutFormatOptions.None, null, viewsDict);
            View.AddConstraints (constraints);

            var constraint = NSLayoutConstraint.Create (backgroundImageView, NSLayoutAttribute.Width, NSLayoutRelation.Equal,
                                                        backgroundImageView, NSLayoutAttribute.Height, 1.0f, 0.0f);
            backgroundImageView.AddConstraint (constraint);
        }

        public override void ViewDidAppear ()
        {
            base.ViewDidAppear ();

            performance.LeftChannel.Player.Play ();
            performance.RightChannel.Player.Play ();

            controlBarViewController.Performance = performance;
        }

        public override NSObject RepresentedObject {
            get {
                return base.RepresentedObject;
            }
            set {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
