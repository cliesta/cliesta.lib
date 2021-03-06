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
using Cliesta.Lib2.Geometry;
using NUnit.Framework;

namespace Cliesta.Lib2.Tests
{
    [ExcludeFromCodeCoverage]
    public class CircleTests
    {
        [TestCase( 0, 0, 0, 0, 0, 0, true )]
        [TestCase( 0, 0, 1, 0, 0, 1, true )]
        [TestCase( 1, 0, 1, 1, 0, 1, true )]
        [TestCase( 1, 1, 1, 1, 1, 1, true )]

        [TestCase( 0, 0, 0, 0, 0, 1, false )]
        [TestCase( 1, 0, 1, 0, 0, 1, false )]
        [TestCase( 1, 0, 1, 1, 1, 1, false )]
        [TestCase( 1, 1, 1, 0, 1, 1, false )]

        public void CircleEquality(
            double x1, double y1, double r1, double x2, double y2, double r2, bool shouldBeEqual )
        {
            var circle1 = new Circle( x1, y1, r1 );
            var circle2 = new Circle( x2, y2, r2 );

            if ( shouldBeEqual )
            {
                Assert.AreEqual( circle1, circle2 );
            }
            else
            {
                Assert.AreNotEqual( circle1, circle2 );
            }
        }
    }
}