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

using System.Collections.Generic;

namespace Cliesta.Html.Header
{
    public class HtmlHeader : IHtmlElement
    {
        readonly List<IHtmlHeaderElement> _htmlHeaderElements;
        private readonly HtmlDocumentOptions _options;

        public HtmlHeader( HtmlDocumentOptions options, params IHtmlHeaderElement[] headerElements )
        {
            _options = options;
            _htmlHeaderElements = new List<IHtmlHeaderElement>( headerElements );
            _htmlHeaderElements.Add( new HtmlTitle( options.Title ) );

        }

        public void Build( HtmlBuilder builder )
        {
            builder.AppendLine( "<head>" );
            foreach ( var element in _htmlHeaderElements )
            {
                element.Build( builder.NextLevel() );
            }

            if ( _options.Theme != null && !_options.Theme.IsDefault )
            {
                new HtmlStyleTheme( _options ).Build( builder.NextLevel() );
            }
            builder.AppendLine( "</head>" );
        }
    }
}