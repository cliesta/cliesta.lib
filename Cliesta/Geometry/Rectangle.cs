#region copyright

// Copyright 2021 Cliesta Software
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

using System;
using System.Drawing;

namespace Cliesta.Geometry
{
    public readonly struct Rectangle
    {
        public Rectangle( Point2D corner, double width, double height )
        {
            Corner = corner;
            if ( width < 0 )
            {
                Corner = new Point2D( Corner.X + width, Corner.Y );
            }

            if ( height < 0 )
            {
                Corner = new Point2D( Corner.X, Corner.Y + height );
            }
            
            Width = Math.Abs( width );
            Height = Math.Abs( height );
        }

        public Rectangle( double cornerX, double cornerY, double width, double height )
        : this( new Point2D( cornerX, cornerY ), width, height )
        {
        }

        public Point2D Corner { get; }
        public double Width { get; }
        public double Height { get; }

        public RectangleF ToRectangleF()
        {
            return new RectangleF( (float) Corner.X, (float) Corner.Y, (float) Width, (float) Height );
        }
    }
}