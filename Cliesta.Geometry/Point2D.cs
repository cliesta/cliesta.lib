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
    [Serializable]
    public readonly struct Point2D
    {
        public Point2D( double x, double y )
        {
            X = x;
            Y = y;
        }

        public static Point2D Undefined { get; } = new Point2D( double.NaN, double.NaN );

        public double SquaredDistanceTo( Point2D other )
        {
            return Math.Pow( other.X - X, 2 ) + Math.Pow( other.Y - Y, 2 );
        }
        
        public double X { get; }
        public double Y { get; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public PointF ToPointF()
        {
            return new PointF( (float) X, (float) Y );
        }
    }
}