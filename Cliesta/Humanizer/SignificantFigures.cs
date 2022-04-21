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
using System;
using System.Diagnostics;
using System.Globalization;

namespace Cliesta.Humanizer
{
    public static class SignificantFigures
    {
        public static string ToSignificantFigures( this double value, int significantFigures )
        {
            if ( double.IsNaN( value ) )
            {
                return "NaN";
            }
            var decimalValue = Convert.ToDecimal( value );
            return decimalValue.ToSignificantFigures( significantFigures );
        }

        public static string ToSignificantFigures( this decimal value, int significantFigures )
        {
            Debug.Assert( significantFigures > 0, "significantFigures must be > 0" );

            if ( value == 0 ) return "0";
            var valueAsString = value.ToString( CultureInfo.InvariantCulture );
            if ( valueAsString.Contains( "E+" ) )
            {
                return valueAsString;
            }

            var schmid = new SchmidNumber( value );
            if ( significantFigures <= schmid.Exponent )
            {
                return Math.Round( schmid.Value ).ToString( CultureInfo.InvariantCulture );
            }

            var rounded = new SchmidNumber( Math.Round( schmid.Mantissa, significantFigures ), schmid.Exponent );
            var roundedStr = rounded.Value.ToString( CultureInfo.InvariantCulture ).TrimEnd( '0' ).TrimEnd( '.' );
            var sciStr = rounded.Value.ToString( $"E{significantFigures}" );
            if ( sciStr.Length < roundedStr.Length )
            {
                return sciStr;
            }
            return roundedStr;

        }

    }
}
