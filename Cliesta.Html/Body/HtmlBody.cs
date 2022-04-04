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

namespace Cliesta.Html
{
    public class HtmlBody : HtmlBodyElement, IHtmlElement
    {
        private readonly List<IHtmlBodyElement> _contents;

        public HtmlBody( string styleClass = "",
             params IHtmlBodyElement[] contents )
            : base( styleClass )
        {
            _contents = new List<IHtmlBodyElement>( contents );
        }

        public override void Build( HtmlBuilder builder )
        {
            builder.AppendLine( "<body>" );
            foreach ( var element in _contents )
            {
                element.Build( builder.NextLevel() );
            }
            builder.AppendLine( "</body>" );
        }
    }
}