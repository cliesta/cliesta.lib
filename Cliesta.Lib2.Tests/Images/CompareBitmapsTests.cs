#region copyright

// Copyright 2021-2022 Cliesta Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Drawing;
using NUnit.Framework;
using Cliesta.Lib2.Images;
using System.Drawing.Imaging;

namespace Cliesta.Lib2.Tests.Images
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

        /*
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
        */
    }
}