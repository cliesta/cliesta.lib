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
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Cliesta.Una.Base.Tests
{
    [ExcludeFromCodeCoverage]
    internal class DateTimeExtensionsTests
    {
        [Test]
        public void TestAddTenthsOfMicroSeconds()
        {
            var t = new DateTime( 1974, 9, 28, 19, 1, 2, 345 );
            Assert.AreEqual( 622852236623450000, t.Ticks );
            var t2 = t.AddTenthsOfMicroSeconds( 6789 );
            Assert.AreEqual( 622852236623456789, t2.Ticks );
        }

        [Test]
        public void TestAddTenthsOfMicroSecondsProperly()
        {
            var t = new DateTime( 1974, 9, 28, 19, 1, 2, 111 );
            var t2 = t.AddTenthsOfMicroSeconds( 10001 );

            Assert.AreEqual( 622852236621110000, t.Ticks );
            Assert.AreEqual( 622852236621120001, t2.Ticks );

        }

        [Test]
        public void TestTimeStampString()
        {
            Assert.AreEqual( "1974-09-28 08:09:07.123", new DateTime( 1974, 9, 28, 8, 9, 7, 123 ).TimeStampString() );
            Assert.AreEqual( "2020-12-28 18:09:07.000", new DateTime( 2020, 12, 28, 18, 9, 7, 0 ).TimeStampString() );
        }

        [Test]
        public void RoughlyEqualDateTimeAndDateTim()
        {
            var dt0 = new DateTime( 1974, 9, 28, 12, 31, 23, 123, DateTimeKind.Utc );
            var dt1 = new DateTime( 1974, 9, 28, 12, 31, 23, DateTimeKind.Utc ).AddMilliseconds( 123 );
            Assert.IsTrue( dt1.RoughlyEqual( dt0 ) );

            var dt2 = new DateTime( 1974, 9, 28, 12, 31, 23, DateTimeKind.Utc ).AddFractionOfSecond( 0.12301 );
            Assert.IsFalse( dt2.RoughlyEqual( dt0 ) );

            dt2 = new DateTime( 1974, 9, 28, 12, 31, 23, DateTimeKind.Utc ).AddFractionOfSecond( 0.12301 );
            Assert.IsTrue( dt2.RoughlyEqual( dt0, 100 ) );
        }


        [Test]
        public void TestAddFractionOfSecond()
        {
            var dt1 = new DateTime( 1974, 9, 28, 12, 31, 23, DateTimeKind.Utc );
            //var ticks1 = dt1.Ticks;
            var dt2 = dt1.AddFractionOfSecond( 0.1 );
            Assert.AreEqual( 100, ( dt2 - dt1 ).TotalMilliseconds );

            dt2 = dt1.AddFractionOfSecond( 0.01 );
            Assert.AreEqual( 10, ( dt2 - dt1 ).TotalMilliseconds );

            dt2 = dt1.AddFractionOfSecond( 0.001 );
            Assert.AreEqual( 1, ( dt2 - dt1 ).TotalMilliseconds );

            dt2 = dt1.AddFractionOfSecond( 0.0001 );
            Assert.AreEqual( 0.1, ( dt2 - dt1 ).TotalMilliseconds );

            dt2 = dt1.AddFractionOfSecond( 0.00001 );
            Assert.AreEqual( 0.01, ( dt2 - dt1 ).TotalMilliseconds );

            dt2 = dt1.AddFractionOfSecond( 0.000001 );
            Assert.AreEqual( 0.001, ( dt2 - dt1 ).TotalMilliseconds );

            dt2 = dt1.AddFractionOfSecond( 0.0000001 );
            Assert.AreEqual( 0.0001, ( dt2 - dt1 ).TotalMilliseconds );

            var dt3 = dt1.AddFractionOfSecond( 0.0000002 );
            Assert.AreEqual( 1, dt3.Ticks - dt2.Ticks );

        }

    }
}
