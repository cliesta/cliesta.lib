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

using Cliesta.Lib2.Statistics;
using System;
using System.Diagnostics;


namespace Cliesta.Lib2.Maths
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