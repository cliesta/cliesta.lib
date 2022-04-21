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

namespace Cliesta.Lib2.Html.Body
{
    public class HtmlTable : IHtmlBodyElement
    {
        private List<HtmlTableRow> _rows;
        public string StyleClass { get; }

        public HtmlTable( params HtmlTableRow[] rows )
        {
            _rows = new List<HtmlTableRow>( rows );
        }

        public HtmlTable( IEnumerable<HtmlTableRow> rows )
        {
            _rows = new List<HtmlTableRow>( rows );
        }

        public void Build( HtmlBuilder builder )
        {
            builder.AppendLine( "<table>" );

            foreach ( var row in _rows )
            {
                row.Build( builder.NextLevel() );
            }

            builder.AppendLine( "</table>" );
        }
    }
}