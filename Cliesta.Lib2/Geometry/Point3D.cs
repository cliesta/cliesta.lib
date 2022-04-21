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


namespace Cliesta.Lib2.Geometry
{
    public readonly struct Point3D
    {
        public Point3D( double x, double y, double z )
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D( Point2D xy, double z )
        {
            X = xy.X;
            Y = xy.Y;
            Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Point2D Xy => new Point2D( X, Y );

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}