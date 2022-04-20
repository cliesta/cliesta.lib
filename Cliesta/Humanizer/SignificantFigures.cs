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
