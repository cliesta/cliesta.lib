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

using System;

namespace Cliesta.Lib2.Themes
{
    public class DefaultTheme : Theme
    {
        public override bool IsDefault => true;

        protected override Colour AccentBackground => throw new NotImplementedException();
        public override Colour PageBackground => throw new NotImplementedException();
        protected override Colour ContentBackground => throw new NotImplementedException();
        protected override Colour ContentBackgroundContrast => throw new NotImplementedException();
        public override Colour Text => throw new NotImplementedException();
        public override Colour AccentForeground => throw new NotImplementedException();
        protected override Colour Comment => throw new NotImplementedException();
        public override Colour ErrorText => throw new NotImplementedException();
    }
}