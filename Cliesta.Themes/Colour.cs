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

// ReSharper disable InconsistentNaming

using Cliesta.Maths;
using System;
using System.Diagnostics;

namespace Cliesta.Themes
{
    public class Colour
    {
        private readonly int _value;
        public byte R => (byte) ((_value >> 24) & 0xff);
        public byte G => (byte) ((_value >> 16) & 0xff);
        public byte B => (byte) ((_value >> 8) & 0xff);
        public double A => ((byte) (_value & 0xff)) / 255.0;

        public Colour( byte r, byte g, byte b, double a = 1 )
        {
            Debug.Assert( a.InRange( 0, 1 ) );
            _value = RgbaToInt( r, g, b, (byte) Math.Round( a * 255 ) );
        }

        public Colour( double r, double g, double b, double a )
        {
            Debug.Assert( r.InRange( 0, 1 ) );
            Debug.Assert( g.InRange( 0, 1 ) );
            Debug.Assert( b.InRange( 0, 1 ) );
            Debug.Assert( a.InRange( 0, 1 ) );

            _value = RgbaToInt(
                Convert.ToByte( r * 255 ),
                Convert.ToByte( g * 255 ),
                Convert.ToByte( b * 255 ),
                Convert.ToByte( a * 255 )
            );
        }

        public static Colour FromLightness( double lightness )
        {
            return new Colour( lightness, lightness, lightness, 1 );
        }

        private static int RgbaToInt( byte r, byte g, byte b, byte a )
        {
            int value = r;
            value <<= 8;
            value |= g;
            value <<= 8;
            value |= b;
            value <<= 8;
            value |= a;
            return value;
        }

        public override string ToString()
        {
            return ToHtmlValue();
        }

        public string ToHtmlValue()
        {
            return $"rgba({R},{G},{B},{A})";
        }

        public Colour WithAlpha( double alpha )
        {
            return new Colour( R, G, B, alpha );
        }
    }
}