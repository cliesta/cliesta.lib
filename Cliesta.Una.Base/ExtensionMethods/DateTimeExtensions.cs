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

namespace Cliesta.Una.Base
{
    public static class DateTimeExtensions
    {
        public static DateTime AddTenthsOfMicroSeconds( this DateTime datetime, int value )
        {
            return new( datetime.Ticks + value, datetime.Kind );
        }

        public static DateTime AddFractionOfSecond( this DateTime datetime, double fractionOfSecond )
        {
            Debug.Assert( fractionOfSecond >= 0 && fractionOfSecond < 1, "fractionOfSecond must be >= 0 and < 1" );
            var hundredsOfNanoSeconds = (long)( fractionOfSecond * 10000000 );

            return new DateTime( datetime.Ticks + hundredsOfNanoSeconds, datetime.Kind );
        }

        public static bool RoughlyEqual( this DateTime dateTime, DateTime other,
            int toleranceInTenthsOfMicroSeconds = 10 )
        {
            return Math.Abs( dateTime.Ticks - other.Ticks ) <= toleranceInTenthsOfMicroSeconds;
        }

        public static string TimeStampString( this DateTime dateTime )
        {
            return dateTime.ToString( "yyyy-MM-dd HH:mm:ss.fff" );
        }

    }
}
