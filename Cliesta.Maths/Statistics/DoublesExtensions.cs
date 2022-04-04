using System;
using System.Collections.Generic;
using System.Linq;

namespace Cliesta.Maths
{
    public static class DoublesExtensions
    {
        public static double Kurtosis( this IEnumerable<double> values )
        {
            return MathNet.Numerics.Statistics.Statistics.Kurtosis( values );
        }

        public static double ExcessKurtosis( this IEnumerable<double> values )
        {
            return values.Kurtosis() - 3;
        }

        public static double Skewness( this IEnumerable<double> values )
        {
            return MathNet.Numerics.Statistics.Statistics.Skewness( values );
        }

        public static bool IsSkewed( this IEnumerable<double> values )
        {
            return Math.Abs( values.Skewness() ) > 1;
        }

        public static bool IsSkinny( this IEnumerable<double> values )
        {
            return values.Kurtosis() > 5;
        }

        public static bool IsFat( this IEnumerable<double> values )
        {
            return values.Kurtosis() < 1;
        }

        public static double JarqueBera( this IEnumerable<double> values )
        {
            var S = values.Skewness();
            var K = values.Kurtosis();

            return (values.Count() / 6.0) * (Math.Pow( S, 2 ) + 0.25 * Math.Pow( K - 3, 2 ));
        }

    }
}
