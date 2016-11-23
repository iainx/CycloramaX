using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama.FilterSelector
{
    public partial class FilterSelectorViewHeader : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public FilterSelectorViewHeader (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public FilterSelectorViewHeader (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        public string CategoryName {
            get { return categoryNameLabel.StringValue; }
            set { categoryNameLabel.StringValue = value; }
        }
    }
}
