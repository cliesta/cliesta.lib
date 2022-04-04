using System;
using System.Diagnostics;


namespace Cliesta.Maths
{
    public class Interval
    {
        
        public double Min { get; } = double.MaxValue;
        public double Max { get; } = double.MinValue;
        public double Range => Max - Min;

        public Interval()
        {
        }

        public Interval( double min, double max )
        {
            Debug.Assert( min <= max );
            Min = min;
            Max = max;
        }

        public Interval( NormalDistribution distribution, double stdDevs )
        {
            Min = distribution.Mean - stdDevs * distribution.StdDev;
            Max = distribution.Mean + stdDevs * distribution.StdDev;
        }

        public Interval Include( params double[] values )
        {
            var min = Min;
            var max = Max;
            foreach ( var value in values )
            {
                min = Math.Min( min, value );
                max = Math.Max( max, value );
            }
            return new Interval( min, max );
        }

        public Interval ScaleBy( double scale )
        {
            var mean = (Min + Max) / 2.0;
            var halfRange = (Max - Min) / 2.0;
            return new Interval()
            .Include( mean - halfRange * scale )
            .Include( mean + halfRange * scale );
        }

        public Interval WithMin( double newMin )
        {
            return new Interval( newMin, Max );
        }

        public Interval WithMax( double newMax )
        {
            return new Interval( Min, newMax );
        }
    }
}