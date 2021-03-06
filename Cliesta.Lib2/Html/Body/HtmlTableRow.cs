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
using System.Linq;

namespace Cliesta.Lib2.Html.Body
{
    public class HtmlTableRow : IHtmlBodyElement
    {
        private readonly List<IHtmlTableCell> _cells;
        public string StyleClass { get; }

        public HtmlTableRow()
        {
            _cells = new List<IHtmlTableCell>();
        }

        public HtmlTableRow( params IHtmlTableCell[] cells )
        {
            _cells = new List<IHtmlTableCell>( cells );
        }

        public HtmlTableRow( params string[] cells )
        {
            _cells = cells.Select( c => (IHtmlTableCell)new HtmlTableCell( c ) ).ToList();
        }

        public void Build( HtmlBuilder builder )
        {
            builder.AppendLine( "<tr>" );

            foreach ( var cell in _cells )
            {
                cell.Build( builder.NextLevel() );
            }

            builder.AppendLine( "</tr>" );
        }

        public void Add( HtmlTableCell cell )
        {
            _cells.Add( cell );
        }
    }
}