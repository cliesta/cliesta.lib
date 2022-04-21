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
using System.Drawing;
using System.Windows.Forms;
using Cliesta.Strings;

namespace Cliesta.WinForms
{
    public partial class OutputWindow : UserControl
    {
        private readonly BufferedText _bufferedText;

        public OutputWindow()
        {
            InitializeComponent();

            timer1.Interval = 100;
            timer1.Start();

            _bufferedText = new BufferedText( text => richTextBox1.AppendText( text ) );
        }

        public Font OutputFont
        {
            get => richTextBox1.Font;
            set => richTextBox1.Font = value;
        }

        public void WriteLine( string text ) => _bufferedText.WriteLine( text );
        public void Write( string text ) => _bufferedText.Write( text );

        private void timer1_Tick( object sender, System.EventArgs e )
        {
            _bufferedText.Flush();
        }

        private void OutputWindow_Resize( object sender, System.EventArgs e )
        {
            richTextBox1.Location = new Point( -2, -2 );
            richTextBox1.Size = new Size( Width + 4, Height + 4 );
        }

        public void Invoke(Action action)
        {
            richTextBox1.Invoke( new MethodInvoker( action ) );
        }
        
        public void EraseLastLine()
        {
            Invoke( () =>
            {
                _bufferedText.Flush();
                EraseLastLineFromTextBox();
            } ) ;
        }

        public void Clear()
        {
            Invoke( () =>
            {
                _bufferedText.Flush();
                richTextBox1.ReadOnly = false;
                richTextBox1.Text = "";
                richTextBox1.ReadOnly = true;
            } );
        }
        
        public void Flush()
        {
            Invoke( _bufferedText.Flush );
        }

        private void EraseLastLineFromTextBox()
        {
            var text = richTextBox1.Text;
            richTextBox1.ReadOnly = false;
            var lastNewLine = text.LastIndexOf( '\n' );
            if ( lastNewLine == -1 )
            {
                richTextBox1.Select( 0, text.Length );
            }
            else if ( lastNewLine == text.Length - 1 )
            {
                lastNewLine = text.LastIndexOf( '\n', lastNewLine - 1 );
            }

            if ( lastNewLine == -1 )
            {
                richTextBox1.Select( 0, text.Length );
            }
            else
            {
                richTextBox1.Select( lastNewLine + 1, text.Length );
            }

            richTextBox1.SelectedText = "";
            richTextBox1.ReadOnly = true;
        }
    }
}