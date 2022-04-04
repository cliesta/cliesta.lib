#region copyright

// Copyright 2021 Cliesta Software
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

using System.Diagnostics.CodeAnalysis;
using System.IO;
using NUnit.Framework;

namespace Cliesta.Una.Base.Tests
{
    [ExcludeFromCodeCoverage]
    public class SpecialFoldersTests
    {
        [Test]
        public void TestGetLogDir()
        {
            var dir = SpecialFolders.GetLogDir().Replace( "\\", "/" );
            Assert.IsTrue( dir.EndsWith( "/com.cliesta/log" ) );
            Assert.IsTrue( Directory.Exists( dir ) );
        }
        
        [Test]
        public void TestAppDataDir()
        {
            var dir = SpecialFolders.GetAppDataDir().Replace( "\\", "/" );
            Assert.IsTrue( dir.EndsWith( "/com.cliesta/config" ) );
            Assert.IsTrue( Directory.Exists( dir ) );
        }
        
        [Test]
        public void TestTempDir()
        {
            var dir = SpecialFolders.GetTemporaryFolder().Replace( "\\", "/" );
            Assert.IsTrue( dir.EndsWith( "/com.cliesta/temp" ) );
            Assert.IsTrue( Directory.Exists( dir ) );
        }
        
    }
}