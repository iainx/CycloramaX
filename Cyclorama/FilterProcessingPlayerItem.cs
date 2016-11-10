using System;

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

        public FilterProcessingPlayerItem (AVAsset asset) : base (asset)
        {
            VideoComposition = AVVideoComposition.CreateVideoComposition (asset, ProcessImage);
        }

        public CIFilter [] Filters { get; set; }

        void ProcessImage (AVAsynchronousCIImageFilteringRequest obj)
        {
            var sourceImage = obj.SourceImage;

            if (Filters == null) {
                obj.Finish (sourceImage, context);
                return;
            }

            foreach (var filter in Filters) {
                filter.SetValueForKey (sourceImage, inputImageString);
                sourceImage = (CIImage)filter.ValueForKey (outputImageString);
            }

            obj.Finish (sourceImage, context);
        }
    }
}
