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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Cliesta.Geometry;
using Cliesta.Maths;
using Cliesta.Themes;
using Rectangle = Cliesta.Geometry.Rectangle;


namespace Cliesta.Images
{
    public class Visualiser : IVisualiser
    {
        private double _pixelsPerUnit;
        private readonly Colour _backgroundColour;
        private readonly List<Action<Graphics>> _drawOperations = new List<Action<Graphics>>();

        private Interval _xRange = new Interval();
        private Interval _yRange = new Interval();

        public Visualiser( double pixelsPerUnit, Colour backgroundColour )
        {
            _pixelsPerUnit = pixelsPerUnit;
            _backgroundColour = backgroundColour;
        }

        public void DrawCircles( IEnumerable<Circle> circles, Colour colour )
        {
            foreach(var circle in circles)
            {
                DrawCircle( circle, colour );
            }
        }

        public void EnsureVisible( params Point2D[] points )
        {
            foreach(var point in points)
            {
                _xRange = _xRange.Include( point.X );
                _yRange = _yRange.Include( point.Y );
            }
        }

        public void DrawRectangle( Rectangle rectangle, Colour colour )
        {
            var pen = new Pen( colour.ToColor() );
            _xRange = _xRange.Include( rectangle.Corner.X, rectangle.Corner.X + rectangle.Width );
            _yRange = _yRange.Include( rectangle.Corner.Y, rectangle.Corner.Y + rectangle.Height );
            _drawOperations.Add( graphics =>
            {
                var r = ScaleRectangle( rectangle );
                graphics.DrawRectangle(
                    pen, (float) r.Corner.X, (float) r.Corner.Y, (float) r.Width, (float) r.Height );
            } );
        }

        public void DrawAxes( double tickInterval, double scale, Colour colour )
        {
            var pen = new Pen( colour.ToColor() );
            _drawOperations.Add( graphics =>
            {
                graphics.DrawLine( pen,
                    ScalePoint( new Point2D( 0, _yRange.Min ) ).ToPointF(),
                    ScalePoint( new Point2D( 0, _yRange.Max ) ).ToPointF() );

                graphics.DrawLine( pen,
                    ScalePoint( new Point2D( _xRange.Min, 0 ) ).ToPointF(),
                    ScalePoint( new Point2D( _xRange.Max, 0 ) ).ToPointF() );

                var xTickMin = (int) (_xRange.Min / tickInterval);
                var xTickMax = (int) (_xRange.Max / tickInterval);
                for( var i = xTickMin; i <= xTickMax; i++ )
                {
                    var x = i * tickInterval;
                    var p1 = ScalePoint( new Point2D( x, 0 ) ).ToPointF();
                    var p2 = ScalePoint( new Point2D( x, 0 ) ).ToPointF();
                    p1.Y += (float) (scale * ((i % 10 == 0) ? 9 : (i % 5 == 0) ? 6 : 3));
                    graphics.DrawLine( pen,
                        p1,
                        p2 );
                }

                var yTickMin = (int) (_yRange.Min / tickInterval);
                var yTickMax = (int) (_yRange.Max / tickInterval);
                for( var i = yTickMin; i <= yTickMax; i++ )
                {
                    var y = i * tickInterval;
                    var p1 = ScalePoint( new Point2D( 0, y ) ).ToPointF();
                    var p2 = ScalePoint( new Point2D( 0, y ) ).ToPointF();
                    p1.X -= (float) (scale * ((i % 10 == 0) ? 9 : (i % 5 == 0) ? 6 : 3));
                    graphics.DrawLine( pen,
                        p1,
                        p2 );
                }
            } );
        }

        public void DrawAxes( double tickInterval, Colour colour )
        {
            DrawAxes( tickInterval, 1, colour );
        }

        private Rectangle ScaleRectangle( Rectangle rect )
        {
            var y2 = _yRange.Max - rect.Corner.Y;

            return new Rectangle(
                (float) ((rect.Corner.X - _xRange.Min) * _pixelsPerUnit),
                (float) (y2 * _pixelsPerUnit),
                (float) (rect.Width * _pixelsPerUnit),
                (float) (-rect.Height * _pixelsPerUnit) );
        }

        public void DrawCircle( Circle circle, Colour colour )
        {
            var x1 = circle.Centre.X - circle.Radius;
            var y1 = circle.Centre.Y - circle.Radius;
            var diameter = 2 * circle.Radius;
            _xRange = _xRange.Include( x1, x1 + diameter );
            _yRange = _yRange.Include( y1, y1 + diameter );

            var rect = new Rectangle( x1, y1, diameter, diameter );
            var pen = new Pen( colour.ToColor() );
            var operation = new Action<Graphics>( graphics =>
            {
                graphics.DrawEllipse( pen, ScaleRectangle( rect ).ToRectangleF() );
            } );
            _drawOperations.Add( operation );
        }

        public void DrawLine( LineSegment lineSegment, Colour colour )
        {
            var pen = new Pen( colour.ToColor() );
            _drawOperations.Add( graphics =>
            {
                var p1 = ScalePoint( lineSegment.Point1 ).ToPointF();
                var p2 = ScalePoint( lineSegment.Point2 ).ToPointF();
                graphics.DrawLine( pen, p1, p2 );
            } );
        }

        private Point2D ScalePoint( Point2D point )
        {
            return new Point2D( 
                (point.X - _xRange.Min) * _pixelsPerUnit, 
                (_yRange.Max - point.Y) * _pixelsPerUnit );
        }

        public Bitmap Visualise()
        {
            var width = (int) (_xRange.Range * _pixelsPerUnit);
            var height = (int) (_yRange.Range * _pixelsPerUnit);
            var bitmap = new Bitmap( width, height );

            using ( var graphics = Graphics.FromImage( bitmap ) )
            {

                Visualise( graphics );

                return bitmap;
            }
        }

        public void Visualise( Graphics graphics )
        {
            var pixelsPerUnitX = (double)graphics.VisibleClipBounds.Width / _xRange.Range;
            var pixelsPerUnitY = (double)graphics.VisibleClipBounds.Height / _yRange.Range;
            _pixelsPerUnit = Math.Min( pixelsPerUnitX, pixelsPerUnitY );

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle( 
                new SolidBrush( _backgroundColour.ToColor() ), 
                0, 0, graphics.VisibleClipBounds.Width, graphics.VisibleClipBounds.Height );
            foreach ( var drawOperation in _drawOperations )
            {
                drawOperation( graphics );
            }
        }

        public void ScaleBounds( double scaleFactor )
        {
            _xRange = _xRange.ScaleBy( scaleFactor );
            _yRange = _yRange.ScaleBy( scaleFactor);
        }
    }
}