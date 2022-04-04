using MathNet.Numerics.Distributions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Cliesta.Maths
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