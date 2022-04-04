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
    public class HtmlDocument : IHtmlElement
    {
        private readonly HtmlDocType _docType  = new HtmlDocType();
        private readonly HtmlLanguage _language = new HtmlLanguage( "en" );
        private readonly HtmlHeader _header;
        private readonly HtmlBody _body;

        public HtmlDocument(
            HtmlHeader header,
            HtmlBody body )
        {
            _header = header;
            _body = body;
        }

        public void Build( HtmlBuilder builder )
        {
            _docType.Build( builder);
            _language.Build( builder);
            _header.Build( builder);
            _body.Build( builder);
        }

        public override string ToString()
        {
            var builder = new HtmlBuilder();
            Build( builder );
            return builder.ToString();
        }
    }

}