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