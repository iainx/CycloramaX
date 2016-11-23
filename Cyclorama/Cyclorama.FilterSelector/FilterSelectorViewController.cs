using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CoreGraphics;

namespace Cyclorama.FilterSelector
{
    public partial class FilterSelectorViewController : AppKit.NSViewController, INSCollectionViewDataSource, INSCollectionViewDelegateFlowLayout
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
                flowLayout.ItemSize = new CoreGraphics.CGSize (64.0f, 72.0f);
                flowLayout.SectionInset = new NSEdgeInsets (30.0f, 20.0f, 30.0f, 20.0f);
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

        #region INSCollectionViewDataSource
        [Export ("numberOfSectionsInCollectionView:")]
        public nint GetNumberOfSections (NSCollectionView collectionView)
        {
            Console.WriteLine ($"Sections {FilterModel.Categories.Count}");
            return FilterModel.Categories.Count;
        }

        public nint GetNumberofItems (NSCollectionView collectionView, nint section)
        {
            Console.WriteLine ($"Items: {FilterModel.Categories [(int)section].Filters.Count}");
            return FilterModel.Categories [(int)section].Filters.Count;
        }

        public NSCollectionViewItem GetItem (NSCollectionView collectionView, NSIndexPath indexPath)
        {
            var itemView = (FilterSelectorViewItem)collectionView.MakeItem ("FilterSelectorViewItem", indexPath);
            var item = FilterModel.Categories [(int)indexPath.Section].Filters [(int)indexPath.Item];
            itemView.Item = item;
            return itemView;
        }

        [Export ("collectionView:viewForSupplementaryElementOfKind:atIndexPath:")]
        public NSView MakeSupplementaryView (NSCollectionView collectionView, NSString kind, NSIndexPath path)
        {
            var itemView = (FilterSelectorViewHeader)collectionView.MakeSupplementaryView (kind, "FilterSelectorViewHeader", path);
            var item = FilterModel.Categories [(int)path.Section];
            itemView.CategoryName = item.Name;

            return itemView;
        }
        #endregion

        #region INSCollectionViewDelegateFlowLayout

        [Export ("collectionView:layout:referenceSizeForHeaderInSection:")]
        public CGSize ReferenceSizeForHeader (NSCollectionView collectionView, NSCollectionViewLayout layout, nint section)
        {
            return new CGSize (1000, 40);
        }

        #endregion

        #region INSCollectionViewDelegate
        [Export ("collectionView:didSelectItemsAtIndexPaths:")]
        public void ItemsSelected (NSCollectionView collectionView, NSSet items)
        {
            var itemPath = (NSIndexPath)items.AnyObject;
            var item = FilterModel.Categories [(int)itemPath.Section].Filters [(int)itemPath.Item];
            OnFilterSelected (item);
        }
        #endregion

        public event EventHandler<FilterSelectedArgs> FilterSelected;
        void OnFilterSelected (FilterModel.Item item)
        {
            FilterSelected?.Invoke (this, new FilterSelectedArgs (item));
        }
    }

    public class FilterSelectedArgs : EventArgs
    {
        public FilterModel.Item FilterItem { get; private set; }
        internal FilterSelectedArgs (FilterModel.Item item)
        {
            FilterItem = item;
        }
    }
}
