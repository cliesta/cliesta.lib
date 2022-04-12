using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Cliesta.Una.Base;

namespace Cliesta.Images
{
    public static class ImageHash
    {
        public static ulong GetDHash( string bitmapFilePath, int size = 8 )
        {
            var file = new FileInfo( bitmapFilePath );

            if ( !file.Exists )
            {
                throw new IOException( $"File not found {bitmapFilePath}" );
            }

            using var bmp = new Bitmap( bitmapFilePath );
            return GetDHash( bmp, size, file.Name );
        }

        public static ulong GetDHash( Bitmap bitmap, int size = 8, string diagnosticFileNameRoot = "" )
        {
            Console.WriteLine( diagnosticFileNameRoot );
            var tempFolder = SpecialFolders.GetTemporaryFolder();

            if ( diagnosticFileNameRoot.Length > 0 )
            {
                bitmap.Save( Path.Combine( tempFolder, diagnosticFileNameRoot + ".original.png" ), ImageFormat.Png );
            }

            Debug.Assert( size <= 8 && size > 1 );
            ulong hash = 0;

            int i = 0;
            using ( var resized = bitmap.Resize( size + 1, size ) )
            {
                if ( diagnosticFileNameRoot.Length > 0 )
                {
                    var resizedFileName = Path.Combine( tempFolder, diagnosticFileNameRoot + ".resized.png" );
                    resized.Save( resizedFileName, ImageFormat.Png );
                }

                using ( var diffImage = new Bitmap( size, size ) )
                {
                    for ( int y = 0; y < resized.Height; y++ )
                    {
                        for ( int x = 1; x < resized.Width; x++ )
                        {
                            bool lighter = resized.GetPixel( x, y ).GetBrightness() >
                                resized.GetPixel( x - 1, y ).GetBrightness();
                            hash |= (lighter ? 1ul : 0) << i++;
                            diffImage.SetPixel( x - 1, y, lighter ? Color.White : Color.Black );
                        }
                    }

                    if ( diagnosticFileNameRoot.Length > 0 )
                    {
                        diffImage.Save( Path.Combine( tempFolder, diagnosticFileNameRoot + ".diffImage.png" ), ImageFormat.Png );
                    }
                }
            }
            return hash;
        }



    }
}
