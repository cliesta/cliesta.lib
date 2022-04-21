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

using System;
using System.Diagnostics.CodeAnalysis;
using Cliesta.Lib2.Time;
using NUnit.Framework;

namespace Cliesta.Testing.Time
{
    [ExcludeFromCodeCoverage]
    internal class DateTimeWrapperTests
    {
        [Test]
        [TestCase( 599266080000000000, 1900, 1, 1, 0, 0, 0, 0 )]
        [TestCase( 622851589234567891, 1974, 9, 28, 1, 2, 3, 0.4567891 )]
        [TestCase( 630822816000000000, 2000, 1, 1, 0, 0, 0, 0 )]
        [TestCase( 637134336000000000, 2020, 1, 1, 0, 0, 0, 0 )]
        [TestCase( 637134336000000000L + 31L * DateTimeWrapper.TicksPerDay, 2020, 2, 1, 0, 0, 0, 0 )]
        [TestCase( 637134336000000000L + (31L + 29L) * DateTimeWrapper.TicksPerDay, 2020, 3, 1, 0, 0, 0, 0 )]
        [TestCase( 637134336000000000L + (31L + 29L + 31L) * DateTimeWrapper.TicksPerDay, 2020, 4, 1, 0, 0, 0, 0 )]
        [TestCase( 637134336000000000L + 13132800L * DateTimeWrapper.TicksPerSecond, 2020, 6, 1, 0, 0, 0, 0 )]
        public void TestConstructor(
            long ticks,
            int year, int month, int day,
            int hour, int minute, int second, double fraction )
        {
            var wrapper = new DateTimeWrapper( year, month, day, hour, minute, second, fraction );
            Assert.AreEqual( ticks, wrapper.Ticks );

            var wrapper2 = new DateTimeWrapper( ticks );
            Assert.AreEqual( ticks, wrapper2.DateTime.Ticks );

            var dateTime = new DateTime( ticks, DateTimeKind.Utc );
            Assert.AreEqual( ticks, dateTime.Ticks );

            var wrapper3 = new DateTimeWrapper( dateTime );
            Assert.AreEqual( ticks, wrapper3.Ticks );
        }

        [Test]
        public void DateTimeMustBeUtc()
        {
            var localDateTime = new DateTime( 1990, 1, 1, 0, 0, 0, DateTimeKind.Local );
            Assert.Throws<InvalidOperationException>( () => { _ = new DateTimeWrapper( localDateTime ); } );
        }

        [Test]
        public void TestRoughlyEqual()
        {
            var wrapper1 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567891 );
            var wrapper2 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567881 );
            var wrapper3 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567871 );

            Assert.IsTrue( wrapper1.RoughlyEqual( wrapper2 ) );
            Assert.IsTrue( wrapper2.RoughlyEqual( wrapper3 ) );
            Assert.IsFalse( wrapper1.RoughlyEqual( wrapper3 ) );
        }

        [Test]
        public void TestRoughlyEqualWithTolerance()
        {
            var wrapper1 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567891 );
            var wrapper2 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567881 );
            var wrapper3 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3 );

            Assert.IsFalse( wrapper1.RoughlyEqual( wrapper2, TimeSpan.Zero ) );
            Assert.IsFalse( wrapper1.RoughlyEqual( wrapper2, TimeSpan.FromTicks( 9 ) ) );
            Assert.IsTrue( wrapper1.RoughlyEqual( wrapper2, TimeSpan.FromTicks( 10 ) ) );
            Assert.IsTrue( wrapper1.RoughlyEqual( wrapper3, TimeSpan.FromSeconds( 1 ) ) );

        }

        [Test]
        public void TestRoughlyEqualDateTime()
        {
            var wrapper1 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567891 );
            var wrapper2 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567881 );
            //var wrapper3 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567871 );

            var dt1 = new DateTime( 1974, 9, 28, 1, 2, 3, DateTimeKind.Utc ).AddFractionOfSecond( 0.4567891 );
            var dt2 = new DateTime( 1974, 9, 28, 1, 2, 3, DateTimeKind.Utc ).AddFractionOfSecond( 0.4567881 );
            var dt3 = new DateTime( 1974, 9, 28, 1, 2, 3, DateTimeKind.Utc ).AddFractionOfSecond( 0.4567871 );

            Assert.IsTrue( wrapper1.RoughlyEqual( dt1 ) );
            Assert.IsTrue( wrapper2.RoughlyEqual( dt2 ) );
            Assert.IsFalse( wrapper1.RoughlyEqual( dt3 ) );
        }

        [Test]
        public void TestAddition()
        {
            var wrapper1 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567891 );
            var wrapper2 = wrapper1 + new TimeSpan( 1, 0, 0, 0 );
            var wrapper3 = new DateTimeWrapper( 1974, 9, 29, 1, 2, 3, 0.4567891 );

            Assert.IsTrue( wrapper2.RoughlyEqual( wrapper3 ) );

        }

        [Test]
        public void TestGetters()
        {
            var wrapper1 = new DateTimeWrapper( 1974, 9, 28, 1, 2, 3, 0.4567891 );
            Assert.AreEqual( 1974, wrapper1.Year );
            Assert.AreEqual( 9, wrapper1.Month );
            Assert.AreEqual( 28, wrapper1.Day );
        }


    }
}
