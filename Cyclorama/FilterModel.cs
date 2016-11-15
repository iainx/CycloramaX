using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using AppKit;
using CoreImage;
using Foundation;

namespace Cyclorama
{
    public static class FilterModel
    {
        public class Category
        {
            public string Name { get; set; }
            public List<Item> Filters { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public string FilterName { get; set; }
            public string Category { get; set; }
            NSImage imageThumbnail;
            public NSImage ImageThumbnail { 
                get {
                    if (imageThumbnail == null) {
                        if (CImage == null) {
                            return null;
                        }

                        var ciRep = NSCIImageRep.FromCIImage (CImage);
                        imageThumbnail = new NSImage (ciRep.Size);
                        imageThumbnail.AddRepresentation (ciRep);

                        CImage = null;
                    }

                    return imageThumbnail;
                }
            }
            internal CIImage CImage { get; set; }
        }

        public static List<Category> Categories { get; private set; }

        static BlockingCollection<Item> itemsForThumbnails;
        static CIImage baseImage;

        static FilterModel ()
        {
            var unaffectedImage = NSImage.ImageNamed ("demo-bird");
            baseImage = CIImage.FromCGImage (unaffectedImage.CGImage);

            itemsForThumbnails = new BlockingCollection<Item> ();

            Task.Run (() => {
                while (!itemsForThumbnails.IsCompleted) {
                    Item item = null;
                    try {
                        item = itemsForThumbnails.Take ();
                    } catch (InvalidOperationException ex) {
                        Console.WriteLine ($"{ex}");
                    }

                    GenerateThumbnailWithFilter (item);
                }
            });

            Categories = new List<Category> ();
            NSString [] cats = { 
                CIFilterCategory.Blur,
                CIFilterCategory.ColorAdjustment,
                CIFilterCategory.ColorEffect,
                CIFilterCategory.HalftoneEffect,
                CIFilterCategory.Sharpen,
                CIFilterCategory.Stylize
            };

            foreach (var catName in cats) {
                var filterNames = CIFilter.FilterNamesInCategory (catName);
                var filters = new List<Item> ();

                foreach (var filterName in filterNames) {
                    var item = new Item { FilterName = filterName, Name = CIFilter.FilterLocalizedName (filterName), Category = catName };
                    filters.Add (item);
                    itemsForThumbnails.Add (item);
                }

                var cat = new Category { Name = catName, Filters = filters };
                Categories.Add (cat);
            }

            itemsForThumbnails.CompleteAdding ();
        }

        static NSString inputName = new NSString ("inputImage");
        static NSString outputName = new NSString ("outputImage");

        static void GenerateThumbnailWithFilter (Item item)
        {
            var filter = CIFilter.FromName (item.FilterName);

            filter.SetDefaults ();
            filter.SetValueForKey (baseImage, inputName);

            item.CImage = (CIImage)filter.ValueForKey (outputName);
        }
    }
}
