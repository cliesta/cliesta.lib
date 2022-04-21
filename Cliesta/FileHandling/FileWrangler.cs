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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Cliesta.FileHandling
{
    public static class FileWrangler
    {
        public static string[] GetFiles( string path, string pattern, SearchOption searchOption )
        {
            var files = new List<string>();
            GetFilesInternal( files, path, pattern, searchOption );
            return files.ToArray();
        }

        [ExcludeFromCodeCoverage]
        private static void GetFilesInternal( List<string> allFiles, string path, string pattern,
            SearchOption searchOption )
        {
            var files = Directory.GetFiles( path, pattern, SearchOption.TopDirectoryOnly );
            allFiles.AddRange( files );
            if ( searchOption != SearchOption.AllDirectories ) return;

            var dirs = Directory.GetDirectories( path );
            foreach ( var dir in dirs )
            {
                GetFilesInternal( allFiles, dir, pattern, searchOption );
            }
        }

        public static int FolderDepth( string fileOrFolderPath )
        {
            var parts = PathSplit( fileOrFolderPath );
            return parts.Length;
        }

        private static string[] PathSplit( string fileOrFolderPath )
        {
            Debug.Assert( fileOrFolderPath.Length > 0 );
            var path = fileOrFolderPath.Replace( '\\', '/' );
            while ( path.EndsWith( "/" ) )
            {
                path = path.Substring( 0, path.Length - 1 );
            }

            var parts = path.Split( '/' );
            return parts;
        }

        public static string CommonRoot( string path1, string path2 )
        {
            StringBuilder root = new StringBuilder();
            var parts1 = PathSplit( path1 );
            var parts2 = PathSplit( path2 );
            var maxIndex = Math.Min( parts1.Length, parts2.Length );
            for ( int i = 0; i < maxIndex; i++ )
            {
                if ( parts1[ i ] == parts2[ i ] )
                {
                    root.Append( parts1[ i ] );
                    root.Append( "/" );
                }
            }

            return root.ToString();
        }

        public static void TransformLinesInFile( string fileName, Func<string, string> mapFunc )
        {
            var tempFileName = fileName + "~";
            var changed = false;
            using ( var sr = new StreamReader( fileName ) )
            {
                using ( var sw = new StreamWriter( tempFileName ) )
                {
                    while ( !sr.EndOfStream )
                    {
                        var line = sr.ReadLine();
                        var newLine = mapFunc( line );
                        sw.WriteLine( newLine );
                        if ( newLine != line )
                        {
                            changed = true;
                        }
                    }
                }
            }

            if ( changed )
            {
                File.Delete( fileName );
                File.Move( tempFileName, fileName );
            }
            else
            {
                File.Delete( tempFileName );
            }
        }

        public static void DoForEachLineIn( string fileName, Action<string> action )
        {
            using ( var sr = new StreamReader( fileName ) )
            {
                while ( !sr.EndOfStream )
                {
                    var line = sr.ReadLine();
                    action( line );
                }
            }
        }

        public static int CountForEachLineIn( string fileName, Func<string, int> action )
        {
            var count = 0;
            DoForEachLineIn( fileName, line => count += action( line ) );
            return count;
        }

        public static int CountLines( string fileName )
        {
            var count = 0;
            DoForEachLineIn( fileName, _ => count++ );
            return count;
        }

        public static bool FileContentsAreEqual( string fileName1, string fileName2 )
        {
            using ( var sr1 = new FileStream( fileName1, FileMode.Open, FileAccess.Read ) )
            {
                using ( var sr2 = new FileStream( fileName2, FileMode.Open, FileAccess.Read ) )
                {
                    if ( sr1.Length != sr2.Length )
                    {
                        return false;
                    }

                    const int bufferLength = 1000;
                    var buf1 = new byte[ bufferLength ];
                    var buf2 = new byte[ bufferLength ];
                    int count1;
                    while ( (count1 = sr1.Read( buf1, 0, bufferLength )) > 0 )
                    {
                        sr2.Read( buf2, 0, bufferLength );
                        for ( var i = 0; i < count1; i++ )
                        {
                            if ( buf1[ i ] != buf2[ i ] )
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static long GetFileSize( string fileName )
        {
            var fi = new FileInfo( fileName );
            return fi.Length;
        }

        public static string CreateContainingDirectory( string filePath )
        {
            var fileInfo = new FileInfo( filePath );
            // ReSharper disable once PossibleNullReferenceException
            if ( !Directory.Exists( fileInfo.Directory.FullName ) )
            {
                Directory.CreateDirectory( fileInfo.Directory.FullName );
            }

            return filePath;
        }

        public static void OpenFileDiffIfDifferent( string left, string right )
        {
            if ( !FileContentsAreEqual( left, right ) )
            {
                OpenFileDiff( left, right );
            }
        }

        public static void OpenFileDiff( string left, string right )
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Program Files\Beyond Compare 4\BCompare.exe",
                    UseShellExecute = false,
                    Arguments = $"\"{left}\" \"{right}\""
                }
            };

            process.Start();
        }


        public static bool FileContentsAreEqual( FileInfo fileName1, FileInfo fileName2 )
        {
            return FileContentsAreEqual( fileName1.FullName, fileName2.FullName );
        }

        public static void OpenInTextEditor( string filePath )
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = "\"" + filePath + "\"",
                FileName = ""
            };

            const string exePath1 = @"C:\Program Files\Notepad++\notepad++.exe";
            if ( File.Exists( exePath1 ) )
            {
                startInfo.FileName = exePath1;
            }
            else
            {
                throw new InvalidOperationException( "No text editor found" );
            }

            var process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
        }

        public static void OpenInWebBrowser( string filePath )
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = filePath,
                FileName = ""
            };

            const string exePath1 = @"C:\Program Files\Mozilla Firefox\firefox.exeee";
            const string exePath2 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            if ( File.Exists( exePath1 ) )
            {
                startInfo.FileName = exePath1;
            }
            else if ( File.Exists( exePath2 ) )
            {
                startInfo.FileName = exePath2;
            }
            else
            {
                throw new InvalidOperationException( "No web browser found" );
            }

            var process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
        }

        public static void OpenInWebBrowser( IEnumerable<string> htmlFileList )
        {
            var htmlFiles = htmlFileList.Aggregate( "", ( joined, next ) => joined + "\"" + next + "\"" + " " );
            OpenInWebBrowser( htmlFiles );
        }

        public static void CopyFiles( string previousDir, string outputDir, bool recursive )
        {
            if ( recursive )
            {
                throw new NotImplementedException();
            }

            var files = Directory.GetFiles( previousDir );
            foreach ( var file in files )
            {
                var srcFileInfo = new FileInfo( file );
                var dstFileInfo = new FileInfo( Path.Combine( outputDir, srcFileInfo.Name ) );
                File.Copy( srcFileInfo.FullName, dstFileInfo.FullName );
            }
        }
    }
}