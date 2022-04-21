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
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using Image = SixLabors.ImageSharp.Image;

namespace Cliesta.Lib2.Images
{
    public static class ImageSharpExtensions
    {

        public static Bitmap ToBitmap<TPixel>( this Image<TPixel> image )
        where TPixel : unmanaged, IPixel<TPixel>
        {
            using ( var memoryStream = new MemoryStream() )
            {
                var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder( PngFormat.Instance );
                image.Save( memoryStream, imageEncoder );

                memoryStream.Seek( 0, SeekOrigin.Begin );

                return new Bitmap( memoryStream );
            }
        }

        public static Image<TPixel> ToImageSharpImage<TPixel>( this Bitmap bitmap )
        where TPixel : unmanaged, IPixel<TPixel>
        {
            using ( var memoryStream = new MemoryStream() )
            {
                bitmap.Save( memoryStream, System.Drawing.Imaging.ImageFormat.Png );

                memoryStream.Seek( 0, SeekOrigin.Begin );

                return Image.Load<TPixel>( memoryStream );
            }
        }

    }
}