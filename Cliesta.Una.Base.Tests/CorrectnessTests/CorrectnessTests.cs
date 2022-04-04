using System.Diagnostics.CodeAnalysis;
using Cliesta.Diagnostics;
using NUnit.Framework;

namespace Cliesta.Base.Tests
{
    [ExcludeFromCodeCoverage]
    internal class CorrectnessTests
    {
        [Test]
        public void TestRequire()
        {
            Require.IsTrue( true );
            Require.IsTrue( true, "This requirement is satisfied" );

            Assert.Throws<RequirementFailureException>(
                () => Require.IsTrue( false ) );

            Assert.Throws<RequirementFailureException>(
                () => Require.IsTrue( false, "This requirement is NOT satisfied" ) );

            var o = new object();
            Require.NotNull(o);

            Assert.Throws<RequirementFailureException>(
                () => Require.NotNull( null! ) );
        }

    }
}
