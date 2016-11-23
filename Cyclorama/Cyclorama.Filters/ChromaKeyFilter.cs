using System;
using System.IO;

using Foundation;
using CoreImage;

namespace Cyclorama.Filters
{
    public class ChromaKeyFilter : CIFilter
    {
        static CIKernel _GSChromaKeyFilterKernel;
        static ChromaKeyFilter ()
        {
            try {
                var bundle = NSBundle.MainBundle;
                var url = bundle.GetUrlForResource ("GSChromaKeyFilter", "cikernel");

                var code = File.ReadAllText (new Uri (url.AbsoluteString).AbsolutePath);

                _GSChromaKeyFilterKernel = CIKernel.FromProgramSingle (code);
            } catch (Exception e) {
                Console.WriteLine ($"{e}");
            }
        }

        public CIImage InputImage { get; set; }
        public override CIImage OutputImage {
            get {
                var src = new CISampler (InputImage);
                NSMutableArray args = new NSMutableArray ();
                NSMutableDictionary options = new NSMutableDictionary ();

                args.Add (src);
                args.Add (CIColor.BlackColor);

                options [CIFilterApply.OptionDefinition] = src.Definition;
                CIImage output = Apply (_GSChromaKeyFilterKernel, args, options);

                return output;
            }
        }
    }
}
