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

using System.Collections.Generic;
using System.IO;

namespace Cliesta.RecentlyUsed
{
    public class PersistentRecentlyUsedList : IRecentlyUsedList
    {
        private readonly string _fileName;
        private readonly List<string> _list = new List<string>();

        public PersistentRecentlyUsedList( string fileName )
        {
            _fileName = fileName;
            ReadList();
        }

        public IEnumerable<string> Items => _list;

        private void ReadList()
        {
            if ( !File.Exists( _fileName ) ) return;
            using ( var sr = new StreamReader( _fileName ) )
            {
                while ( !sr.EndOfStream )
                {
                    var line = sr.ReadLine()?.Trim();
                    if ( line?.Length > 0 )
                    {
                        _list.Add( line );
                    }
                }
            }
        }

        public void Add( string s )
        {
            if ( _list.Contains( s ) )
            {
                _list.Remove( s );
            }

            _list.Insert( 0, s );
            WriteList();
        }

        public void Remove( string item )
        {
            if ( _list.Contains( item ) )
            {
                _list.Remove( item );
            }

            WriteList();
        }

        private void WriteList()
        {
            using ( var sw = new StreamWriter( _fileName ) )
            {
                foreach ( var s in _list )
                {
                    sw.WriteLine( s );
                }
            }
        }
    }
}