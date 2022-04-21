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


namespace Cliesta.Lib2.Themes
{
    public abstract class Theme
    {

        public abstract bool IsDefault { get; }

        protected abstract Colour AccentBackground { get; }
        public abstract Colour PageBackground { get; }
        protected abstract Colour ContentBackground { get; }
        protected abstract Colour ContentBackgroundContrast { get; }
        public abstract Colour Text { get; }
        public abstract Colour ErrorText { get; }
        protected abstract Colour Comment { get; }
        public abstract Colour AccentForeground { get; }

        public Colour TableHeaderBackground => AccentBackground;
        public Colour TableBackgroundColourEvenRows => ContentBackground;
        public Colour TableBackgroundColourOddRows => ContentBackgroundContrast;
        public Colour ChartBackgroundColour => ContentBackground;
        public Colour ChartLegendBackgroundColour => ContentBackground;
        public Colour ChartGridColour => Comment;
        public Colour MenuBackgroundColour => PageBackground;
        public Colour HighlightColour => AccentBackground;
        public Colour HighlightTextColour => AccentForeground;
        public Colour EditBackgroundColour => ContentBackground;
    }
}