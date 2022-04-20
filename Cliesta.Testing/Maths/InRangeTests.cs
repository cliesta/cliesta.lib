using NUnit.Framework;

namespace Cliesta.Maths.Tests
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

        public void TestInRange(double min, double max, double value, bool includeMin, bool includeMax, bool expectedResult)
        {
            Assert.AreEqual( expectedResult, value.InRange( min, max, includeMin, includeMax ) );
        }
    }
}