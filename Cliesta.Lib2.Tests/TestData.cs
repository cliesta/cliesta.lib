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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using NUnit.Framework;

namespace Cliesta.Lib2.Tests
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

            for (; ; )
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