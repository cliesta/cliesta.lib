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

using System.Diagnostics.CodeAnalysis;

namespace Cliesta.Testing.Images
{
    [ExcludeFromCodeCoverage]
    public class VisualiserTests
    {
        /*
        [Test]
        public void DrawShapes()
        {
            var visualiser = new Visualiser( 100, Colours.Black );
            visualiser.DrawAxes( 0.1, Colours.Grey );
            visualiser.DrawCircle( new Circle( new Point2D(), 0.01 ), Colours.White );
            visualiser.DrawCircle( new Circle( new Point2D( 1, 1 ), 1 ), Colours.White );
            visualiser.DrawCircle( new Circle( new Point2D( -1, 1 ), 1 ), Colours.Grey );
            visualiser.DrawCircle( new Circle( new Point2D( -1, -1 ), 1 ), Colours.Tomato );
            visualiser.DrawCircle( new Circle( new Point2D( 1, -1 ), 1 ), Colours.LightBlue );
            visualiser.DrawCircle( new Circle( new Point2D( 3, -1 ), 1 ), Colours.LightGreen );
            visualiser.DrawCircle( new Circle( new Point2D( 3, -3 ), 1 ), Colours.Magenta );
            visualiser.DrawLine( new LineSegment( new Point2D( 1, 1 ), new Point2D( 3, 2 ) ), Colours.LightGreen );
            visualiser.DrawLine( new LineSegment( new Point2D( -1, -2 ), new Point2D( 3, 2 ) ), Colours.LightGreen );

            visualiser.DrawRectangle( new Geometry.Rectangle( new Point2D( 0, 0 ), 1, 1 ), Colours.Yellow );
            visualiser.DrawRectangle( new Geometry.Rectangle( new Point2D( -3, -1 ), 2.5, 2 ), Colours.Red );
            visualiser.ScaleBounds( 1.1 );

            var bmp = visualiser.Visualise();
            var referenceBmp = new Bitmap( TestData.GetPath( "VisualiserTests.DrawShapes.png" ) );
            Assert.IsTrue( bmp.IsIdenticalTo( referenceBmp ) );

            //Assert.IsTrue(bmp.);
        }
        */
    }
}