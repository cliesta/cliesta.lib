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

namespace Cliesta.Maths.Statistics
{
    public class NormalDistribution
    {
        public double Mean => _distribution != null ? _distribution.Mean : double.NaN;
        public double StdDev => _distribution != null ? _distribution.StdDev : double.NaN;

        protected Normal _distribution;
        public string Name { get; protected set; }

        protected NormalDistribution()
        {
        }

        public NormalDistribution( double mean, double stdDev )
        {
            _distribution = new Normal( mean, stdDev );
        }

        public double ProbabilityDensity( double x )
        {
            return _distribution.Density( x );
        }

        public override string ToString()
        {
            return $"Normal distribution: mean = {Mean}, std dev = {StdDev}";
        }

    }
}