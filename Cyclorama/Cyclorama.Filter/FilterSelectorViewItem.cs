using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama.Filter
{
    public partial class FilterSelectorViewItem : NSCollectionViewItem
    {
        #region Constructors

        // Called when created from unmanaged code
        public FilterSelectorViewItem (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public FilterSelectorViewItem (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        FilterModel.Item item;
        public FilterModel.Item Item {
            get {
                return item;
            }

            set {
                item = value;
                Image.Image = item.ImageThumbnail;
                FilterName.StringValue = item.Name;

                Console.WriteLine ($"{item.FilterName} - {item.Name}");
            }
        }
    }
}
