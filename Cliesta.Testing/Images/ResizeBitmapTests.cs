using System.Drawing;
using Cliesta.Images;
using NUnit.Framework;

namespace Cliesta.Images.Tests
{
    public class ResizeBitmapTests
    {
        [Test]
        public void TestResize()
        {
            var bitmap = new Bitmap( 1000, 500 );
            var resized = bitmap.Resize( 100, 50 );
            Assert.AreEqual( 100, resized.Width );
            Assert.AreEqual( 50, resized.Height );
        }
    }
}