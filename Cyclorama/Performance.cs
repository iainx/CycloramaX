using System;
using System.Collections.Generic;

using AppKit;
using AVFoundation;
using CoreImage;
using CoreMedia;
using Foundation;

using Cyclorama.Filters;

namespace Cyclorama
{
    public class Performance
    {
        public class Channel
        {
            string filePath;
            public string FilePath {
                get {
                    return filePath;
                }

                set {
                    filePath = value;
                    Asset = AVAsset.FromUrl (NSUrl.FromFilename (value));
                }
            }
            AVAsset asset;
            public AVAsset Asset {
                get {
                    return asset;
                }
                set {
                    asset = value;
                    Item = new FilterProcessingPlayerItem (value, this);
                }
            }

            readonly AVQueuePlayer queuePlayer;
            public AVPlayer Player { get { return queuePlayer; } }

#pragma warning disable 0414
            AVPlayerLooper looper;
#pragma warning restore 0414
            AVPlayerItem item;
            public AVPlayerItem Item {
                get {
                    return item;
                }
                set {
                    item = value;
                    if (looper == null) {
                        looper = new AVPlayerLooper (queuePlayer, value, CMTimeRange.InvalidRange);
                    } else {
                        queuePlayer.ReplaceCurrentItemWithPlayerItem (value);
                    }
                }
            }

            bool active;
            public bool Active {
                get {
                    return active;
                }
                set {
                    active = value;
                    ActiveChanged?.Invoke (this, EventArgs.Empty);
                }
            }
            public event EventHandler ActiveChanged;

            public CIFilter [] Filters { get; set; }

            public bool UseChromaKey { get; set; }
            CIColor keyColor;
            public CIColor KeyColor {
                get {
                    return keyColor;
                }
                set {
                    keyColor = value;
                    KeyColorChanged?.Invoke (this, EventArgs.Empty);
                }
            }
            public event EventHandler KeyColorChanged;

            public Channel ()
            {
                Filters = new CIFilter [2];
                UseChromaKey = false;
                KeyColor = CIColor.BlackColor;
                Active = true;

                queuePlayer = new AVQueuePlayer ();
                queuePlayer.Muted = true;
            }
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

        bool crossfaderActive;
        public bool CrossfaderActive {
            get {
                return crossfaderActive;
            }

            set {
                crossfaderActive = value;
                CrossfaderActiveChanged?.Invoke (this, EventArgs.Empty);
            }
        }
        public event EventHandler CrossfaderActiveChanged;

        float crossfaderValue = 0.5f;
        public float CrossfaderValue {
            get {
                return crossfaderValue;
            }
            set {
                crossfaderValue = value;
                CrossfaderChanged?.Invoke (this, EventArgs.Empty);
            }
        }
        public event EventHandler CrossfaderChanged;

        NSImage background;
        public NSImage Background {
            get {
                return background;
            }
            set{
                background = value;
                BackgroundChanged?.Invoke (this, EventArgs.Empty);
            }
        }
        public event EventHandler BackgroundChanged;
        public Performance ()
        {
            Channels = new List<Channel> ();

            Channels.Add (new Channel ());
            Channels.Add (new Channel ());

            LeftChannel.Asset = AVAsset.FromUrl (NSUrl.FromFilename ("/Users/iain/Downloads/matrix.mp4"));
            RightChannel.Asset = AVAsset.FromUrl (NSUrl.FromFilename ("/Users/iain/Downloads/AR_8BIT_5_512kb.mp4"));

            Background = new NSImage ("/Users/iain/Pictures/a3114763257_2.jpg");
        }
    }
}
