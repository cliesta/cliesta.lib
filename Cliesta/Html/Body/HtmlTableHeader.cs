﻿#region copyright

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


namespace Cliesta.Html.Body
{
    public class HtmlTableHeader : IHtmlTableCell
    {
        private readonly IHtmlBodyElement _contents;
        public string StyleClass { get; }

        public HtmlTableHeader( IHtmlBodyElement contents )
        {
            _contents = contents;
        }

        public HtmlTableHeader( string contents )
        {
            _contents = new HtmlLiteralString( contents );
        }

        public void Build( HtmlBuilder builder )
        {
            builder.AppendLine( "<th>" );

            _contents.Build( builder.NextLevel() );

            builder.AppendLine( "</th>" );
        }
    }
}