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

using MathNet.Numerics.Distributions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Cliesta.Lib2.Statistics
{
    public class NormalDistributionWithValues : NormalDistribution
    {
        public IEnumerable<double> Values { get; }

        public NormalDistributionWithValues( IEnumerable<double> values )
        : this( "", values )
        {
        }

        public NormalDistributionWithValues( string name, IEnumerable<double> values )
        {
            Debug.Assert( values != null );

            Name = name;
            Values = new List<double>( values );

            if ( Values.Any() )
            {
                _distribution = Normal.Estimate( values );
            }
            else
            {
                _distribution = null;
            }
        }
    }
}