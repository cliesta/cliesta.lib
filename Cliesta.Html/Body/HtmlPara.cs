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

namespace Cliesta.Html
{
    public class HtmlPara : IHtmlBodyElement
    {
        private readonly IHtmlBodyElement _para;
        private readonly StyleModifier _styleModifier;
        public string StyleClass { get; }

        public HtmlPara( string para, StyleModifier styleModifier = null )
        {
            _para = new HtmlLiteralString( para );
            _styleModifier = styleModifier;
        }

        public HtmlPara( IHtmlBodyElement text, StyleModifier styleModifier = null )
        {
            _para = text;
            _styleModifier = styleModifier;
        }

        public HtmlPara()
        {
            _para = new HtmlLiteralString( "" );
        }

        public void Build( HtmlBuilder builder )
        {
            if ( _styleModifier != null && _styleModifier.IsEnabled )
            {
                builder.AppendLine( $"<p style=\"{_styleModifier.Html}\">" );
            }
            else
            {
                builder.AppendLine( "<p>" );
            }
            _para.Build( builder );
            builder.AppendLine( "</p>" );

        }
    }
}
