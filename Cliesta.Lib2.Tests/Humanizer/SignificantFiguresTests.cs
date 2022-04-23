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

using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Cliesta.Lib2.Humanizer;

namespace Cliesta.Lib2.Tests.Humanizer
{
    [ExcludeFromCodeCoverage]
    public class SignificantFiguresTests
    {
        [TestCase( 0.07, 1, "0.07" )]
        [TestCase( 0.07, 3, "0.07" )]
        [TestCase( 0.0721, 1, "0.07" )]
        [TestCase( 0.0721, 3, "0.0721" )]

        [TestCase( 0, 1, "0" )]
        [TestCase( 0, 2, "0" )]
        [TestCase( 0, 5, "0" )]
        [TestCase( 1, 1, "1" )]
        [TestCase( 1, 2, "1" )]
        [TestCase( 1, 5, "1" )]
        [TestCase( 12, 1, "12" )]
        [TestCase( 12, 2, "12" )]
        [TestCase( 12, 5, "12" )]
        [TestCase( 123, 1, "123" )]
        [TestCase( 123, 2, "123" )]
        [TestCase( 123, 5, "123" )]
        [TestCase( 1234, 1, "1234" )]
        [TestCase( 1234, 2, "1234" )]
        [TestCase( 1234, 5, "1234" )]
        [TestCase( 12345, 1, "12345" )]
        [TestCase( 12345, 2, "12345" )]
        [TestCase( 12345, 5, "12345" )]

        [TestCase( 123.45, 3, "123" )]
        [TestCase( 123.45, 4, "123.4" )]
        [TestCase( 123.45, 5, "123.45" )]
        [TestCase( 123.45, 6, "123.45" )]

        [TestCase( -123.45, 3, "-123" )]
        [TestCase( -123.45, 4, "-123.4" )]
        [TestCase( -123.45, 5, "-123.45" )]
        [TestCase( -123.45, 6, "-123.45" )]

        [TestCase( 1.23456789, 11, "1.23456789" )]
        [TestCase( 1.23456789, 10, "1.23456789" )]
        [TestCase( 1.23456789, 9, "1.23456789" )]
        [TestCase( 1.23456789, 8, "1.2345679" )]
        [TestCase( 1.23456789, 7, "1.234568" )]
        [TestCase( 1.23456789, 6, "1.23457" )]
        [TestCase( 1.23456789, 5, "1.2346" )]
        [TestCase( 1.23456789, 4, "1.235" )]
        [TestCase( 1.23456789, 3, "1.23" )]
        [TestCase( 1.23456789, 2, "1.2" )]
        [TestCase( 1.23456789, 1, "1" )]

        [TestCase( 12345.6789, 11, "12345.6789" )]
        [TestCase( 12345.6789, 10, "12345.6789" )]
        [TestCase( 12345.6789, 9, "12345.6789" )]
        [TestCase( 12345.6789, 8, "12345.679" )]
        [TestCase( 12345.6789, 7, "12345.68" )]
        [TestCase( 12345.6789, 6, "12345.7" )]
        [TestCase( 12345.6789, 5, "12346" )]
        [TestCase( 12345.6789, 4, "12346" )]
        [TestCase( 12345.6789, 3, "12346" )]
        [TestCase( 12345.6789, 2, "12346" )]
        [TestCase( 12345.6789, 1, "12346" )]

        [TestCase( 1e3, 1, "1000" )]
        [TestCase( 593543, 1, "593543" )]
        [TestCase( 12345678.9, 1, "12345679" )]
        [TestCase( 1.23456789e-7, 1, "1.0E-007" )]

        [TestCase( 0.000148, 3, "0.000148" )]
        [TestCase( 0.0000148, 3, "0.0000148" )]
        [TestCase( 0.00000148, 3, "0.00000148" )]
        [TestCase( 0.000000148, 3, "1.480E-007" )]
        [TestCase( 0.000000000148, 3, "1.480E-010" )]
        [TestCase( 0.000000000000148, 3, "1.480E-013" )]
        [TestCase( 0.000000000000000148, 3, "1.480E-016" )]
        [TestCase( 0.000000000000000000148, 3, "1.480E-019" )]

        public void DecimalsToSignificantFigures( decimal value, int significantFigures, string expectedString )
        {
            Assert.AreEqual( expectedString, value.ToSignificantFigures( significantFigures ) );
        }
    }
}