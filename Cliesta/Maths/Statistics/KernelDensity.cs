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
using System.Collections.Generic;
using System.Linq;

namespace Cliesta.Maths.Statistics
{
    public class KernelDensity
    {


        public static Func<double, double> EstimatePdf( IEnumerable<double> samples )
        {
            var allSamplesDistribution = new NormalDistributionWithValues( samples );

            var stdDev = allSamplesDistribution.StdDev;
            if ( samples.IsFat() || samples.IsSkinny() )
            {
                stdDev /= 2;
            }
            if ( samples.IsSkewed() )
            {
                stdDev /= 2;
            }

            var distributions = samples.Select( sample => new NormalDistribution( sample, stdDev ) );
            var func = new Func<double, double>( x => SumDistributions( x, distributions ) );

            return func;
        }

        private static double SumDistributions( double x, IEnumerable<NormalDistribution> distributions )
        {
            var y = 0d;
            foreach ( var distribution in distributions )
            {
                var p = distribution.StdDev * distribution.ProbabilityDensity( x );
                y += p;
                if ( p > 1 )
                {
                    throw new InvalidOperationException( "p>1" );
                }
            }
            var r = y / distributions.Count();
            if ( r > 1 )
            {
                throw new InvalidOperationException( "r>1" );
            }
            return r;
        }


    }

}