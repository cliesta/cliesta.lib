using NUnit.Framework;
using System;

namespace Cliesta.Maths.Tests
{

    [TestFixtureSource( nameof( FixtureArgs ) )]
    internal class Schmid_number_created_from_decimal
    {
        static object[] FixtureArgs =
        {
        new object[] { 0m },
        new object[] { 43.3456345622348757264592734659723657982364957629784569237845E-40m },
        new object[] { 0.0002452546546679851m },
        new object[] { 0.1m },
        new object[] { 1m },
        new object[] { 42m },
        new object[] { 43.345634562m },
        new object[] { 43.3456345622348757264592734659723657982364957629784569237845m },
        new object[] { 433456345622373465629784m},
        new object[] { -0m },
        new object[] { -43.3456345622348757264592734659723657982364957629784569237845E-40m },
        new object[] { -0.0002452546546679851m },
        new object[] { -0.1m },
        new object[] { -1m },
        new object[] { -42m },
        new object[] { -43.345634562m },
        new object[] { -43.3456345622348757264592734659723657982364957629784569237845m },
        new object[] { -43345648757264237845.0m }
    };
        private readonly decimal _value;
        private readonly SchmidNumber _schmid;

        public Schmid_number_created_from_decimal( decimal value )
        {
            _schmid = new SchmidNumber( value );
            _value = value;
        }

        [Test]
        public void Has_correct_value()
        {
            Assert.IsTrue( (_value - _schmid.Value) < 1e-20m );
        }

        [Test]
        public void Mantissa_size_is_less_than_one()
        {
            Assert.Greater( 1, Math.Abs( _schmid.Mantissa ) );
        }
    }
}