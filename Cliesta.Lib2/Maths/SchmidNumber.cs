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
using System.Diagnostics;

namespace Cliesta.Lib2.Maths
{
    public class SchmidNumber
    {
        public decimal Mantissa { get; }
        public int Exponent { get; }
        public decimal Value => Mantissa * (decimal)Math.Pow( 10, Exponent );

        public SchmidNumber( decimal mantissa, int exponent )
        {
            Debug.Assert( Math.Abs( mantissa ).InRange( 0, 1, includeMax: false ) );
            Mantissa = mantissa;
            Exponent = exponent;
        }

        public SchmidNumber( double value )
        {
            (Mantissa, Exponent) = GetMantissaAndExponent( (decimal)value );
            Debug.Assert( Value == (decimal)value );
        }

        public SchmidNumber( decimal value )
        {
            (Mantissa, Exponent) = GetMantissaAndExponent( value );
            Debug.Assert( Math.Abs( value - Value ) < 1e-20m );
        }

        private (decimal Mantissa, int Exponent) GetMantissaAndExponent( decimal value )
        {
            decimal mantissa;
            int exponent;
            if ( value == 0 )
            {
                exponent = 0;
                mantissa = 0;
            }
            else
            {
                var abs = Math.Abs( value );
                var log = Math.Log10( (double)abs );
                exponent = (int)Math.Floor( log ) + 1;
                var powerOf10 = (decimal)Math.Pow( 10, exponent );
                mantissa = value / powerOf10;
            }
            return (mantissa, exponent);

        }
    }
}
