using System;
using System.Diagnostics.CodeAnalysis;
using Cliesta.Time;
using NUnit.Framework;

namespace Cliesta.Time.Tests
{
    [ExcludeFromCodeCoverage]
    public class CloseOfBusinessDateTests
    {
        [TestCase( 2020, 11, 33, false )]
        [TestCase( 2020, 11, 3, true )]
        public void BadDatesThrowException( int year, int month, int day, bool good )
        {
            var exceptionThrown = false;
            try
            {
                _ = new CloseOfBusinessDate( year, month, day );
            }
            catch ( ArgumentOutOfRangeException )
            {
                exceptionThrown = true;
            }

            Assert.AreEqual( !good, exceptionThrown );
        }

        [TestCase( 2000, 1, 2, "2000-01-02" )]
        [TestCase( 1974, 9, 28, "1974-09-28" )]
        [TestCase( 2020, 11, 12, "2020-11-12" )]
        public void TestToString( int year, int month, int day, string str )
        {
            var date = new CloseOfBusinessDate( year, month, day );
            Assert.AreEqual( str, date.ToString() );
        }

        [TestCase( 2000, 1, 2, "2000/01/02" )]
        [TestCase( 1974, 9, 28, "1974/09/28" )]
        [TestCase( 2020, 11, 12, "2020/11/12" )]
        public void TestFromString( int year, int month, int day, string str )
        {
            var date = new CloseOfBusinessDate( str );
            Assert.AreEqual( date.Year, year );
            Assert.AreEqual( date.Month, month );
            Assert.AreEqual( date.Day, day );
        }

        [Test]
        public void TestEmptyConstructor()
        {
            var date = new CloseOfBusinessDate();
            Assert.AreEqual( 1, date.Year );
            Assert.AreEqual( 1, date.Month );
            Assert.AreEqual( 1, date.Day );
        }

        [TestCase( "2000/01/02", "1974/09/28", 1 )]
        [TestCase( "1974/09/28", "2000/01/02", -1 )]
        [TestCase( "1974/09/28", "1974/09/28", 0 )]
        public void TestCompareTo( string dateA, string dateB, int expectedComparisonResult )
        {
            Assert.AreEqual( expectedComparisonResult,
                new CloseOfBusinessDate( dateA ).CompareTo( new CloseOfBusinessDate( dateB ) ) );
        }

        [TestCase( "2000/01/02", "1974/09/28", false, false, true, true, false )]
        [TestCase( "1974/09/28", "2000/01/02", true, true, false, false, false )]
        [TestCase( "1974/09/28", "1974/09/28", false, true, false, true, true )]
        public void TestInequality(
            string dateAStr, string dateBStr,
            bool lessThan, bool lessThanOrEqual,
            bool greaterThan, bool greaterThanOrEqual,
            bool equal )
        {
            var dateA = new CloseOfBusinessDate( dateAStr );
            var dateB = new CloseOfBusinessDate( dateBStr );
            Assert.AreEqual( lessThan, dateA < dateB );
            Assert.AreEqual( lessThanOrEqual, dateA <= dateB );
            Assert.AreEqual( greaterThan, dateA > dateB );
            Assert.AreEqual( greaterThanOrEqual, dateA >= dateB );
            Assert.AreEqual( equal, dateA == dateB );
            Assert.AreEqual( !equal, dateA != dateB );
            var hashA = dateA.GetHashCode();
            var hashB = dateB.GetHashCode();
            Assert.AreEqual( equal, hashA == hashB );
        }

        [Test]
        public void TestNullEquals()
        {
            var dateA = new CloseOfBusinessDate( "1974/09/28" );
            Assert.AreNotSame( dateA, null );
            Assert.AreNotSame( null, dateA );
            Assert.AreNotEqual( dateA, null );
            Assert.AreNotEqual( null, dateA );
            Assert.IsFalse( dateA.Equals( null ) );
            Assert.IsFalse( dateA!.Equals( null as object ) );
            Assert.IsFalse( dateA.Equals( new object() ) );
            Assert.IsTrue( dateA.Equals( (object)dateA ) );

            CloseOfBusinessDate nullDate = null!;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.AreNotEqual( dateA, nullDate );

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.AreNotEqual( nullDate, dateA );
        }

        [Test]
        public void TestReferenceEquals()
        {
            var dateA = new CloseOfBusinessDate( "1974/09/28" );
            var dateA1 = dateA;
            var dateB = new CloseOfBusinessDate( "1974/09/28" );
            Assert.AreEqual( dateA, dateB );
            Assert.AreEqual( dateA, dateA1 );
            Assert.AreSame( dateA, dateA1 );
            Assert.AreNotSame( dateA, dateB );

            Assert.IsTrue( dateA.Equals( dateA1 ) );
        }
    }
}