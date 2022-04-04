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

using System.Text;

namespace Cliesta.Html
{
    public class HtmlBuilder
    {
        int _indentLevel;
        StringBuilder _stringBuilder;
        bool _newLine = true;

        private HtmlBuilder( int indentLevel, StringBuilder stringBuilder )
        {
            _indentLevel = indentLevel;
            _stringBuilder = stringBuilder;
        }

        public HtmlBuilder()
        {
            _stringBuilder = new StringBuilder();
            _indentLevel = 0;
        }

        /*
        internal void Append( params string[] text )
        {
            if ( _newLine )
            {
                Indent( _indentLevel, _stringBuilder );
            }
            _stringBuilder.Append( text );
            _newLine = false;
        }
        */

        public void AppendLine( params string[] text )
        {
            if ( _newLine )
            {
                Indent( _indentLevel, _stringBuilder );
            }
            foreach ( string textItem in text )
            {
                _stringBuilder.Append( textItem );               
            }
            _stringBuilder.AppendLine();
            _newLine = true;
        }

        internal void Add( string tag, IHtmlBodyElement element, string styleClass, bool indent )
        {
            var tagOpen = GetStyledElementOpener();
            var tagClose = $"</{tag}>";

            AppendLine( tagOpen );
            element.Build( indent ? this : NextLevel() );
            AppendLine( tagClose );


            string GetStyledElementOpener()
            {
                if ( styleClass != null && styleClass.Length > 0 )
                {
                    return $"<{tag} class=\"{styleClass}\">";
                }
                return $"<{tag}>";
            }
        }

        internal HtmlBuilder NextLevel()
        {
            return new HtmlBuilder( _indentLevel + 1, _stringBuilder );
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }

        public static void Indent( 
            int indent, StringBuilder stringBuilder )
        {
            for ( int i = 0; i < indent; i++ )
            {
                stringBuilder.Append( "    " );
            }

        }

    }
}
