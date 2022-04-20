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

namespace Cliesta.Themes
{
    public class DarkTheme : Theme
    {
        public override bool IsDefault => false;

        public override Colour PageBackground => Colours.DarkerGrey;
        protected override Colour ContentBackground => Colours.DarkestGrey;
        protected override Colour ContentBackgroundContrast => Colours.EvenDarkerGrey;
        public override Colour Text => Colours.White;
        protected override Colour AccentBackground => new Colour( 80, 20, 20 );
        public override Colour AccentForeground => Colours.White;
        protected override Colour Comment => Colours.DarkerGrey;
        public override Colour ErrorText => Colours.Red;
    }
}