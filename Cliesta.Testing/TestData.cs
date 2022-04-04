using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using NUnit.Framework;

namespace Cliesta.Testing
{
    [ExcludeFromCodeCoverage]
    public class TestData
    {
        private const string AnnikaRootMagicFileName = "annika-root-sdr8gj34p81j4ksd.magicfile";
        private const string TestDataMagicFileName = "test-data-dghoserhwv43q.magicfile";

        public static string GetPath( string subPath )
        {
            return Path.Combine( GetTestDataDir().FullName, subPath );
        }

        public static string GetPath()
        {
            return GetTestDataDir().FullName;
        }

        private static DirectoryInfo FindAnnika()
        {
            var path = new DirectoryInfo( TestContext.CurrentContext.TestDirectory );

            for ( ;; )
            {
                var magicFilePath = Path.Combine( path.FullName, AnnikaRootMagicFileName );
                if ( File.Exists( magicFilePath ) )
                {
                    return path;
                }

                path = path.Parent ?? throw new InvalidOperationException( "Failed to find annika root" );
            }
        }

        private static DirectoryInfo GetTestDataDir()
        {
            var annikaDir = FindAnnika();
            var testDataDir = Path.Combine( annikaDir.FullName, "test-data" );
            return new DirectoryInfo( testDataDir );
        }
        
        /*
        [Test]
        public void TestFindAnnika()
        {
            Assert.IsTrue( File.Exists( Path.Combine( FindAnnika().FullName, AnnikaRootMagicFileName ) ) );
        }
        
        [Test]
        public void TestGetTestDataDir()
        {
            Assert.IsTrue( File.Exists( Path.Combine( GetTestDataDir().FullName, TestDataMagicFileName ) ) );
        }
        */
    }
}