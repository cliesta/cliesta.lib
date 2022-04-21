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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;


namespace Cliesta.Lib2.Time
{
    public class DateTimeWrapper
    {
        public DateTime DateTime { get; }
        public const long TicksPerSecond = 10000000L;
        public const long TicksPerMinute = 60 * TicksPerSecond;
        public const long TicksPerHour = 60 * TicksPerMinute;
        public const long TicksPerDay = 24 * TicksPerHour;

        public DateTimeWrapper(
            int year, int month, int day, int hour = 0, int minute = 0, int second = 0, double fractionOfSecond = 0 )
        {
            Debug.Assert( fractionOfSecond >= 0 && fractionOfSecond < 1, "fractionOfSecond must be >= 0 and < 1" );
            var hundredsOfNanoSeconds = (int)(fractionOfSecond * 10000000);
            var d = new DateTime( year, month, day, hour, minute, second, DateTimeKind.Utc );
            DateTime = new DateTime( d.Ticks + hundredsOfNanoSeconds, DateTimeKind.Utc );
        }

        public bool RoughlyEqual( DateTimeWrapper other )
        {
            return Math.Abs( Ticks - other.Ticks ) <= 10;
        }

        public bool RoughlyEqual( DateTime other )
        {
            Debug.Assert( other.Kind == DateTimeKind.Utc, "DateTime must be UTC" );
            return Math.Abs( Ticks - other.Ticks ) <= 10;
        }

        public bool RoughlyEqual( DateTimeWrapper other, TimeSpan tolerance )
        {
            return Math.Abs( Ticks - other.Ticks ) <= tolerance.Ticks;
        }

        public DateTimeWrapper( long ticks )
        {
            DateTime = new DateTime( ticks, DateTimeKind.Utc );
        }

        public DateTimeWrapper( DateTime dateTime )
        {
            if ( dateTime.Kind != DateTimeKind.Utc )
            {
                throw new InvalidOperationException( "DateTime must be UTC" );
            }
            DateTime = dateTime;
        }

        public static DateTimeWrapper operator +( DateTimeWrapper dateTime, TimeSpan timeSpan )
        {
            return new DateTimeWrapper( dateTime.Ticks + timeSpan.Ticks );
        }

        public long Ticks => DateTime.Ticks;
        public int Year => DateTime.Year;
        public int Month => DateTime.Month;
        public int Day => DateTime.Day;

        [ExcludeFromCodeCoverage]
        public override string ToString() => DateTime.ToString( CultureInfo.InvariantCulture );

        [ExcludeFromCodeCoverage]
        public string ToString( string format ) => DateTime.ToString( format );

        /*
        public static DateTimeWrapper ParseDateDD_MMM_YYYY( string dateStr )
        {
            var dateBits = dateStr.Trim().Split( ' ' );
            if ( dateBits.Length == 3 )
            {
                var day = int.Parse( dateBits[ 0 ] );
                var year = int.Parse( dateBits[ 2 ] );
                if ( year < 50 )
                {
                    year += 2000;
                }
                else if ( year < 100 )
                {
                    year += 1900;
                }

                var month = dateBits[ 1 ].ToLowerInvariant() switch
                {
                    "jan" => 1,
                    "feb" => 2,
                    "mar" => 3,
                    "apr" => 4,
                    "may" => 5,
                    "jun" => 6,
                    "jul" => 7,
                    "aug" => 8,
                    "sep" => 9,
                    "oct" => 10,
                    "nov" => 11,
                    "dec" => 12,
                    _ => throw new InvalidDataException()
                };

                if ( day < 1 || day > 31 || year < -10000 || year > 10000 )
                {
                    throw new InvalidDataException( $"Invalid date \"{dateStr}\"" );
                }

                return new DateTimeWrapper( year, month, day );
            }

            throw new InvalidDataException( $"Failed to parse date \"{dateStr}\"" );
        }
        */

    }
}
