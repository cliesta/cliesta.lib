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
using System.IO;


namespace Cliesta.Lib2.Time
{
    public class CloseOfBusinessDate : IComparable<CloseOfBusinessDate>, IEquatable<CloseOfBusinessDate>
    {
        public DateTime DateTime { get; }

        public CloseOfBusinessDate()
        {
            DateTime = new DateTime();
        }

        public CloseOfBusinessDate( int year, int month, int day )
        {
            DateTime = new DateTime( year, month, day, 20, 0, 0, DateTimeKind.Unspecified );
        }

        public static CloseOfBusinessDate Today
        {
            get
            {
                var today = DateTime.Today;
                return new CloseOfBusinessDate( today.Year, today.Month, today.Day );
            }
        }

        public static bool operator >( CloseOfBusinessDate d1, CloseOfBusinessDate d2 )
        {
            return d1.DateTime > d2.DateTime;
        }

        public static bool operator >=( CloseOfBusinessDate d1, CloseOfBusinessDate d2 )
        {
            return d1.DateTime >= d2.DateTime;
        }

        public static bool operator <=( CloseOfBusinessDate d1, CloseOfBusinessDate d2 )
        {
            return d1.DateTime <= d2.DateTime;
        }

        public static bool operator <( CloseOfBusinessDate d1, CloseOfBusinessDate d2 )
        {
            return d1.DateTime < d2.DateTime;
        }

        public int Year => DateTime.Year;
        public int Month => DateTime.Month;
        public int Day => DateTime.Day;
        public static readonly CloseOfBusinessDate MaxValue = new CloseOfBusinessDate( 3000, 1, 1 );
        public static readonly CloseOfBusinessDate MinValue = new CloseOfBusinessDate( 1000, 1, 1 );

        public CloseOfBusinessDate( string dateStr )
        {
            var yearStr = dateStr.Substring( 0, 4 );
            var monthStr = dateStr.Substring( 5, 2 );
            var dayStr = dateStr.Substring( 8, 2 );

            var year = int.Parse( yearStr );
            var month = int.Parse( monthStr );
            var day = int.Parse( dayStr );
            DateTime = new DateTime( year, month, day, 20, 0, 0, DateTimeKind.Unspecified );
        }

        public static CloseOfBusinessDate ParseDate( string dateStr )
        {
            var separator1 = dateStr[ 4 ] == '-' || dateStr[ 4 ] == '/';
            var separator2 = dateStr[ 7 ] == '-' || dateStr[ 7 ] == '/';
            Debug.Assert( !(!separator1 || !separator2) );

            var yearStr = dateStr.Substring( 0, 4 );
            var monthStr = dateStr.Substring( 5, 2 );
            var dayStr = dateStr.Substring( 8, 2 );

            try
            {
                var year = int.Parse( yearStr );
                var month = int.Parse( monthStr );
                var day = int.Parse( dayStr );

                return new CloseOfBusinessDate( year, month, day );
            }
            catch ( ArgumentOutOfRangeException e )
            {
                throw new InvalidDataException( "Bad date", e );
            }
        }

        public int CompareTo( CloseOfBusinessDate other )
        {
            return DateTime.CompareTo( other.DateTime );
        }

        public override string ToString()
        {
            return $"{Year}-{Month:D2}-{Day:D2}";
        }

        public bool Equals( CloseOfBusinessDate other )
        {
            if ( ReferenceEquals( null, other ) ) return false;
            if ( ReferenceEquals( this, other ) ) return true;
            return DateTime.Equals( other.DateTime );
        }

        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) ) return false;
            if ( ReferenceEquals( this, obj ) ) return true;
            if ( obj.GetType() != GetType() ) return false;
            return Equals( (CloseOfBusinessDate)obj );
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }

        public static bool operator ==( CloseOfBusinessDate left, CloseOfBusinessDate right )
        {
            return Equals( left, right );
        }

        public static bool operator !=( CloseOfBusinessDate left, CloseOfBusinessDate right )
        {
            return !Equals( left, right );
        }

        public static int operator -( CloseOfBusinessDate date1, CloseOfBusinessDate date2 )
        {
            var span = date1.DateTime - date2.DateTime;
            return (int)Math.Round( span.TotalDays, 0 );
        }

        public static CloseOfBusinessDate operator -( CloseOfBusinessDate date1, int days )
        {
            return date1.AddDays( -days );
        }

        public static CloseOfBusinessDate operator +( CloseOfBusinessDate date1, int days )
        {
            return date1.AddDays( days );
        }

        public CloseOfBusinessDate AddDays( int days )
        {
            var newDateTime = DateTime.AddDays( days );
            return new CloseOfBusinessDate( newDateTime.Year, newDateTime.Month, newDateTime.Day );
        }

        public CloseOfBusinessDate AddMonths( int months )
        {
            var newDateTime = DateTime.AddMonths( months );
            return new CloseOfBusinessDate( newDateTime.Year, newDateTime.Month, newDateTime.Day );
        }
    }
}