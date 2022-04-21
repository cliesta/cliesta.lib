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

using NUnit.Framework;
using System.Drawing;
using Cliesta.Lib2.Images;

namespace Cliesta.Lib2.Tests.Images
{
    public class ResizeBitmapTests
    {
        [Test]
        public void TestResize()
        {
            var bitmap = new Bitmap( 1000, 500 );
            var resized = bitmap.Resize( 100, 50 );
            Assert.AreEqual( 100, resized.Width );
            Assert.AreEqual( 50, resized.Height );
        }
    }
}