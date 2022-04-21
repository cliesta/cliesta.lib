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
using System.Text;

namespace Cliesta.Strings
{
    public class BufferedText
    {
        private StringBuilder _stringBuilder = new StringBuilder();
        private readonly Action<string> _outputAction;

        public BufferedText( Action<string> outputAction )
        {
            _outputAction = outputAction;
        }

        public void WriteLine( string s )
        {
            lock ( this )
            {
                _stringBuilder.AppendLine( s );
            }
        }

        public void Flush()
        {
            string s;
            lock ( this )
            {
                s = _stringBuilder.ToString();
                _stringBuilder = new StringBuilder();
            }

            _outputAction( s );
        }

        public void Write( string s )
        {
            lock ( this )
            {
                _stringBuilder.Append( s );
            }
        }
    }
}