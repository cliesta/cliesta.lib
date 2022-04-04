﻿#region copyright

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
    public static class DirectoryInfoExtensions
    {
        public static void ShowInExplorer( this DirectoryInfo dirInfo )
        {
            if ( !dirInfo.Exists )
            {
                throw new NotImplementedException( "Can't yet handle files that don't exist" );
            }

            Process.Start( dirInfo.FullName );

        }
    }
}