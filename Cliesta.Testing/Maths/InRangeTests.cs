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

using Cliesta.Maths;
using NUnit.Framework;

namespace Cliesta.Testing.Maths
{
    public class InRangeTests
    {
        [TestCase( 0, 1, 0, true, false, true )]
        [TestCase( 0, 1, 0.5, true, false, true )]
        [TestCase( 0, 1, 1, true, false, false )]
        [TestCase( 0, 1, -1, true, false, false )]
        [TestCase( 0, 1, 2, true, false, false )]

        [TestCase( 0, 1, 0, true, true, true )]
        [TestCase( 0, 1, 0.5, true, true, true )]
        [TestCase( 0, 1, 1, true, true, true )]
        [TestCase( 0, 1, -1, true, true, false )]
        [TestCase( 0, 1, 2, true, true, false )]

        [TestCase( 0, 1, 0, false, false, false )]
        [TestCase( 0, 1, 0.5, false, false, true )]
        [TestCase( 0, 1, 1, false, false, false )]
        [TestCase( 0, 1, -1, false, false, false )]
        [TestCase( 0, 1, 2, false, false, false )]

        [TestCase( 0, 1, 0, false, true, false )]
        [TestCase( 0, 1, 0.5, false, true, true )]
        [TestCase( 0, 1, 1, false, true, true )]
        [TestCase( 0, 1, -1, false, true, false )]
        [TestCase( 0, 1, 2, false, true, false )]

        public void TestInRange( double min, double max, double value, bool includeMin, bool includeMax, bool expectedResult )
        {
            Assert.AreEqual( expectedResult, value.InRange( min, max, includeMin, includeMax ) );
        }
    }
}