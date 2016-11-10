using System;
using System.Collections.Generic;

using Foundation;
using AVFoundation;
using CoreImage;
using CoreMedia;

namespace Cyclorama
{
    public class Performance
    {
        public class Channel
        {
            AVAsset asset;
            public AVAsset Asset {
                get {
                    return asset;
                }
                set {
                    asset = value;
                    Item = new FilterProcessingPlayerItem (value);
                }
            }

            AVQueuePlayer queuePlayer = new AVQueuePlayer ();
            public AVPlayer Player { get { return queuePlayer; } }

            AVPlayerLooper looper;
            AVPlayerItem item;
            public AVPlayerItem Item {
                get {
                    return item;
                }
                set {
                    item = value;
                    looper = new AVPlayerLooper (queuePlayer, value, CMTimeRange.InvalidRange);
                }
            }

            public CIFilter [] Filters { get; set; }
        }

        // More than 2 channels in the future
        public List<Channel> Channels { get; private set; }
        public Channel LeftChannel {
            get {
                return Channels [0];
            }
        }
        public Channel RightChannel {
            get {
                return Channels [1];
            }
        }

        public Performance ()
        {
            Console.WriteLine ("Created performance");
            Channels = new List<Channel> ();

            Channels.Add (new Channel ());
            Channels.Add (new Channel ());

            LeftChannel.Asset = AVAsset.FromUrl (NSUrl.FromFilename ("/Users/iain/Downloads/matrix.mp4"));
            RightChannel.Asset = AVAsset.FromUrl (NSUrl.FromFilename ("/Users/iain/Downloads/AR_8BIT_5_512kb.mp4"));
        }
    }
}
