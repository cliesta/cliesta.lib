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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cliesta.Lib5.WinForms
{
    public class WinFormsThemeVisitor : IWinFormsControlVisitor
    {
        private readonly Theme _theme;
        private readonly ToolStripProfessionalRenderer _toolStripRenderer;

        public WinFormsThemeVisitor( Theme theme )
        {
            _theme = theme;
            _toolStripRenderer = new ToolStripProfessionalRenderer( new ThemedColorTable( _theme ) );
        }

        public void Visit( Form form )
        {
            ThemeChildControls( form );

            form.BackColor = _theme.PageBackground.ToColor();
            form.ForeColor = _theme.Text.ToColor();
        }

        private void ThemeChildControls( Control control )
        {
            var childControls = new List<dynamic>();
            childControls.AddRange( control.Controls.Cast<Control>() );
            childControls.ForEach( c => Visit( c ) );
        }

        public void Visit( MenuStrip menuStrip )
        {
            menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            menuStrip.Renderer = _toolStripRenderer;

            foreach ( ToolStripItem toolStripItem in menuStrip.Items )
            {
                var menuItem = toolStripItem as ToolStripMenuItem;

                foreach ( ToolStripItem dropDownItem in menuItem.DropDownItems )
                {
                    dropDownItem.ForeColor = _theme.Text.ToColor();
                }

                toolStripItem.ForeColor = _theme.Text.ToColor();
            }
        }

        public void Visit( ToolStripDropDown control )
        {
            control.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            control.Renderer = _toolStripRenderer;
            //control.ForeColor = Color.Red;
            //control.BackColor = Color.Yellow;
        }

        public void Visit( RichTextBox richTextBox )
        {
            richTextBox.BackColor = _theme.EditBackgroundColour.ToColor();
            richTextBox.ForeColor = _theme.Text.ToColor();
        }

        public void Visit( Button button )
        {
            button.BackColor = _theme.ChartBackgroundColour.ToColor();
            button.ForeColor = _theme.Text.ToColor();
        }

        public void Visit( Panel control )
        {
            control.BackColor = _theme.PageBackground.ToColor();
            ThemeChildControls( control );
        }

        public void Visit( DataGridView control )
        {
            control.BackgroundColor = _theme.PageBackground.ToColor();
            control.GridColor = _theme.ChartGridColour.ToColor();
            control.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            control.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            control.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = _theme.PageBackground.ToColor(),
                ForeColor = _theme.Text.ToColor(),
                SelectionBackColor = _theme.HighlightColour.ToColor(),
                SelectionForeColor = _theme.HighlightTextColour.ToColor(),
            };

            control.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = _theme.TableHeaderBackground.ToColor(),
                ForeColor = _theme.Text.ToColor(),
                SelectionBackColor = _theme.TableHeaderBackground.ToColor(),
                SelectionForeColor = _theme.Text.ToColor(),
            };

            control.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = _theme.TableHeaderBackground.ToColor(),
                ForeColor = _theme.Text.ToColor(),
                SelectionBackColor = _theme.HighlightColour.ToColor(),
                SelectionForeColor = _theme.HighlightTextColour.ToColor(),
            };

            control.EnableHeadersVisualStyles = false;
        }

        public void Visit( ComboBox control )
        {
            control.BackColor = _theme.ChartBackgroundColour.ToColor();
            control.ForeColor = _theme.Text.ToColor();
        }

        public void Visit( Control control )
        {
            throw new InvalidOperationException( $"Don't know how to theme {control.GetType()}" );
        }

        public void Visit( TabControl control )
        {
            throw new InvalidOperationException( "Can't theme TabControls" );
        }

        public void Visit( Label control )
        {
            // do nothing, use parent's colours
        }

        public void Visit( SplitContainer control )
        {
            ThemeChildControls( control );
        }

        public void Visit( UserControl control )
        {
            ThemeChildControls( control );
        }
    }
}