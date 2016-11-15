﻿using System;

using AVFoundation;
using CoreImage;
using Foundation;

namespace Cyclorama
{
    public class FilterProcessingPlayerItem : AVPlayerItem
    {
        static readonly NSString inputImageString = new NSString ("inputImage");
        static readonly NSString outputImageString = new NSString ("outputImage");

        // Share the context between all the instances
        static CIContext context = new CIContext (new CIContextOptions ());

        Performance.Channel channel;

        public FilterProcessingPlayerItem (AVAsset asset, Performance.Channel channel) : base (asset)
        {
            this.channel = channel;
            VideoComposition = AVVideoComposition.CreateVideoComposition (asset, ProcessImage);
        }

        void ProcessImage (AVAsynchronousCIImageFilteringRequest obj)
        {
            var sourceImage = obj.SourceImage;

            if (channel.Filters == null) {
                obj.Finish (sourceImage, context);
                return;
            }

            foreach (var filter in channel.Filters) {
                if (filter == null) {
                    continue;
                }
                filter.SetValueForKey (sourceImage, inputImageString);
                sourceImage = (CIImage)filter.ValueForKey (outputImageString);
            }

            obj.Finish (sourceImage, context);
        }
    }
}
