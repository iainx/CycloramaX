using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Cyclorama
{
    public partial class FilterSelectorViewController : AppKit.NSViewController, INSCollectionViewDataSource
    {
        #region Constructors

        // Called when created from unmanaged code
        public FilterSelectorViewController (IntPtr handle) : base (handle)
        {
            Initialize ();
        }

        // Called when created directly from a XIB file
        [Export ("initWithCoder:")]
        public FilterSelectorViewController (NSCoder coder) : base (coder)
        {
            Initialize ();
        }

        // Call to load from the XIB/NIB file
        public FilterSelectorViewController () : base ("FilterSelectorViewController", NSBundle.MainBundle)
        {
            Initialize ();
        }

        // Shared initialization code
        void Initialize ()
        {
        }

        #endregion

        //strongly typed view accessor
        /*
        public new FilterSelectorView View {
            get {
                return (FilterSelectorView)base.View;
            }
        }
*/

        public override void ViewDidLoad ()
        {
            try {
                var flowLayout = new NSCollectionViewFlowLayout ();
                flowLayout.ItemSize = new CoreGraphics.CGSize (128.0f, 96.0f);
                flowLayout.SectionInset = new NSEdgeInsets (10.0f, 20.0f, 10.0f, 20.0f);
                flowLayout.MinimumInteritemSpacing = 20.0f;
                flowLayout.MinimumLineSpacing = 20.0f;

                FilterCollectionView.CollectionViewLayout = flowLayout;
                View.WantsLayer = true;

                FilterCollectionView.Layer.BackgroundColor = NSColor.Black.CGColor;
            } catch (Exception ex) {
                Console.WriteLine ($"{ex}");
            }
            base.ViewDidLoad ();
        }

        [Export ("numberOfSectionsInCollectionView:")]
        public nint GetNumberOfSections (NSCollectionView collectionView)
        {
            Console.WriteLine ($"Sections {FilterModel.Categories.Count}");
            return FilterModel.Categories.Count;
        }

        public nint GetNumberofItems (NSCollectionView collectionView, nint section)
        {
            Console.WriteLine ($"Items: {FilterModel.Categories[(int)section].Filters.Count}");
            return FilterModel.Categories [(int)section].Filters.Count;
        }

        public NSCollectionViewItem GetItem (NSCollectionView collectionView, NSIndexPath indexPath)
        {
            var itemView = (FilterSelectorViewItem)collectionView.MakeItem ("FilterSelectorViewItem", indexPath);
            var item = FilterModel.Categories [(int)indexPath.Section].Filters [(int)indexPath.Item];
            itemView.Item = item;
            return itemView;
        }
    }
}
