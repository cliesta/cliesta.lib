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
using System.Diagnostics;
using System.IO;

namespace Cliesta.Una.Base
{
    public static class SpecialFolders
    {
        public static string GetTemporaryFolder()
        {
            return AppDataDir( "temp" );
        }

        public static string MakeTemporaryFolder()
        {
            return MakeTemporaryFolder( Guid.NewGuid().ToString().Substring( 0, 8 ) );
        }

        public static string MakeTemporaryFolder( string subPath )
        {
            var path = Path.Combine( AppDataDir( "temp" ), subPath );
            Directory.CreateDirectory( path );
            return path;
        }

        public static string GetAppDataDir()
        {
            return AppDataDir( "config" );
        }

        public static string GetAppDataDir( string subItem )
        {
            return Path.Combine( GetAppDataDir(), subItem );
        }

        public static string GetLogDir()
        {
            return AppDataDir( "log" );
        }

        private static string AppDataDir( string subDir )
        {
            var appDataDir = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
            Debug.Assert( Directory.Exists( appDataDir ), $"{appDataDir} must exist" );
            var dir = Path.Combine( appDataDir, "com.cliesta", subDir );
            Directory.CreateDirectory( dir );
            Debug.Assert( Directory.Exists( dir ), $"Could not create {dir}" );
            return dir;
        }
    }
}