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

namespace Cliesta.Geometry
{
    public readonly struct Circle
    {
        public Circle( double radius )
        {
            Centre = new Point2D();
            Radius = radius;
        }
        
        public Circle( Point2D centre, double radius )
        {
            Centre = centre;
            Radius = radius;
        }

        public Circle( double centreX, double centreY, double radius )
        {
            Centre = new Point2D( centreX, centreY );
            Radius = radius;
        }

        public Point2D Centre { get; }
        public double Radius { get; }

        public override string ToString()
        {
            return $"Centre = {Centre.ToString()}, Radius = {Radius}";
        }
    }
}