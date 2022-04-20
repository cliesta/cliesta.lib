using System.Drawing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;


namespace Cliesta.Images
{
    public static class BitmapExtensions
    {
        public static Bitmap Resize( this Bitmap bmp, int width, int height )
        {
            //return new Bitmap( width, height );
            var image = bmp.ToImageSharpImage<Argb32>();
            image.Mutate( s => s.Resize( width, height ) );
            return image.ToBitmap();
        }

        public static bool IsIdenticalTo( this Bitmap bmp1, Bitmap bmp2 )
        {
            if ( bmp1.Width != bmp2.Width ) return false;
            if ( bmp1.Height != bmp2.Height ) return false;
            if ( bmp1.PixelFormat != bmp2.PixelFormat ) return false;

            for ( var x = 0; x < bmp1.Width; x++ )
            {
                for ( var y = 0; y < bmp1.Height; y++ )
                {
                    if ( bmp1.GetPixel( x, y ) != bmp2.GetPixel( x, y ) )
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}