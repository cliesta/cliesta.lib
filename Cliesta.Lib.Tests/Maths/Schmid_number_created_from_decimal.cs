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

using Cliesta.Lib2.Maths;
using NUnit.Framework;
using System;

namespace Cliesta.Testing.Maths
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
            Assert.IsTrue( _value - _schmid.Value < 1e-20m );
        }

        [Test]
        public void Mantissa_size_is_less_than_one()
        {
            Assert.Greater( 1, Math.Abs( _schmid.Mantissa ) );
        }
    }
}