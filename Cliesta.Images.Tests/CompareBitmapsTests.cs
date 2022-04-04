using System.Drawing;
using System.Drawing.Imaging;
using Cliesta.Images;
using Cliesta.Testing;
using NUnit.Framework;

namespace Cliesta.Una.Base.Tests
{
    public class CompareBitmapsTests
    {
        [Test]
        public void DifferentWidthBitmapsDontMatch()
        {
            var bmp1 = new Bitmap( 100, 100 );
            var bmp2 = new Bitmap( 101, 100 );
            Assert.IsFalse( bmp1.IsIdenticalTo( bmp2 ) );
        }

        [Test]
        public void DifferentHeightBitmapsDontMatch()
        {
            var bmp1 = new Bitmap( 100, 100 );
            var bmp2 = new Bitmap( 100, 101 );
            Assert.IsFalse( bmp1.IsIdenticalTo( bmp2 ) );
        }

        [Test]
        public void DifferentPixelFormatBitmapsDontMatch()
        {
            var bmp1 = new Bitmap( 100, 100, PixelFormat.Format24bppRgb );
            var bmp2 = new Bitmap( 100, 100, PixelFormat.Format32bppRgb );
            Assert.IsFalse( bmp1.IsIdenticalTo( bmp2 ) );
        }

        [Test]
        public void TwoBlankImagesAreIdentical()
        {
            Assert.IsTrue( new Bitmap( 100, 100 ).IsIdenticalTo( new Bitmap( 100, 100 ) ) );
        }

        [Test]
        public void ImagesWithDifferentPixelsAreNotIdentical()
        {
            var bmp1 = new Bitmap( 100, 100 );
            var bmp2 = new Bitmap( 100, 100 );

            bmp1.SetPixel( 43, 45, Color.Aqua );
            Assert.IsFalse( bmp1.IsIdenticalTo( bmp2 ) );
        }

        [Test]
        public void TwoHorsesAreIdentical()
        {
            var bmp1 = new Bitmap( TestData.GetPath( @"test-files\set3\photos\2020\IMG_20200111_154534.jpg" ) );
            var bmp2 = new Bitmap( TestData.GetPath( @"test-files\set3\photos\2020\IMG_20200111_154534 - Copy.jpg" ) );
            
            Assert.IsTrue( bmp1.IsIdenticalTo( bmp2 ) );
        }

        [Test]
        public void TwoOtherHorsesAreNotIdentical()
        {
            var bmp1 = new Bitmap( TestData.GetPath( @"test-files\set3\photos\2020\IMG_20200111_154534.jpg" ) );
            var bmp2 = new Bitmap( TestData.GetPath( @"test-files\set3\photos\2020\IMG_20200111_154534d.jpg" ) );
            
            Assert.IsFalse( bmp1.IsIdenticalTo( bmp2 ) );
        }
    }
}