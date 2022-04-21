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

using System.Collections.Generic;
using System.Drawing;
using Cliesta.Lib2.Geometry;
using Cliesta.Lib2.Themes;
using Rectangle = Cliesta.Lib2.Geometry.Rectangle;


namespace Cliesta.Lib2.Images
{
    public interface IVisualiser
    {
        void DrawAxes( double tickInterval, Colour colour );
        void DrawCircle( Circle circle, Colour colour );
        void DrawCircles( IEnumerable<Circle> circles, Colour colour );
        void DrawRectangle( Rectangle rectangle, Colour colour );
        Bitmap Visualise();
        void ScaleBounds( double scaleFactor );
    }
}