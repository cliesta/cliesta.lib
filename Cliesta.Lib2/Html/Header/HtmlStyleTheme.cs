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

namespace Cliesta.Lib2.Html.Header
{
    public class HtmlStyleTheme : HtmlStyle
    {
        public HtmlStyleTheme( HtmlDocumentOptions options )
        {
            var tableBackgroundColourOddRows = options.StripedTables ?
                options.Theme.TableBackgroundColourOddRows :
                options.Theme.TableBackgroundColourEvenRows;

            _styleElements = new List<IStyleElement>
            {
                new StyleElement(
                    ".tight",
                    "padding: 0px" ),
                new StyleElement(
                    "body",
                    $"background-color:{options.Theme.PageBackground}",
                    $"color:{options.Theme.Text}",
                    "font-family:verdana",
                    "font-size:12px" ),
                new StyleElement(
                    "table",
                    //$"border: 1px solid {theme.TextColour}",
                    "padding: 2px" ),
                new StyleElement(
                    "th, td",
                    //$"border: 1px solid {theme.TextColour}",
                    //"border-collapse: collapse",
                    "padding: 10px",
                    "vertical-align:top" ),
                new StyleElement(
                    "th",
                     $"background-color: {options.Theme.TableHeaderBackground}",
                     $"color: {options.Theme.AccentForeground}"),
                new StyleElement(
                    "tr:nth-child(even)",
                    $"background-color: {options.Theme.TableBackgroundColourEvenRows}" ),
                new StyleElement(
                    "tr:nth-child(odd)",
                    $"background-color: {tableBackgroundColourOddRows}" )


            };
        }
    }
}