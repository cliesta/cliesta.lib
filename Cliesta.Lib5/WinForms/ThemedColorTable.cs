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

using Cliesta.Lib2.Themes;
using System.Drawing;
using System.Windows.Forms;

namespace Cliesta.Lib5.WinForms
{
    public class ThemedColorTable : ProfessionalColorTable
    {
        private readonly Color _background;
        private readonly Color _border;
        private readonly Color _selection;
        private readonly Color _highlight;

        public ThemedColorTable( Theme theme )
        {
            _background = theme.MenuBackgroundColour.ToColor();
            _border = theme.HighlightColour.ToColor();
            _selection = theme.HighlightColour.ToColor();
            _highlight = theme.HighlightColour.ToColor();
        }

        public override Color ToolStripDropDownBackground => _background;
        public override Color ImageMarginGradientBegin => _background;
        public override Color ImageMarginGradientMiddle => _background;
        public override Color ImageMarginGradientEnd => _background;
        public override Color MenuBorder => _border;
        public override Color MenuItemBorder => _border;
        public override Color MenuItemSelected => _selection;
        public override Color MenuStripGradientBegin => _background;
        public override Color MenuStripGradientEnd => _background;
        public override Color MenuItemSelectedGradientBegin => _selection;
        public override Color MenuItemSelectedGradientEnd => _selection;
        public override Color MenuItemPressedGradientBegin => _highlight;
        public override Color MenuItemPressedGradientEnd => _highlight;
        public override Color SeparatorDark => _highlight;
        public override Color SeparatorLight => _highlight;
    }
}