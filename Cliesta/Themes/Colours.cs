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

namespace Cliesta.Themes
{
    public static class Colours
    {
        public static Colour LightBlue { get; } = new Colour( 0, 150, 255 );
        public static Colour Tomato { get; } = new Colour( 255, 70, 70 );
        public static Colour LightGreen { get; } = new Colour( 70, 255, 70 );
        
        public static Colour Black { get; } = new Colour( 0, 0, 0 );
        public static Colour DarkestGrey { get; } = new Colour( 8, 8, 8 );
        public static Colour EvenDarkerGrey { get; } = new Colour( 16, 16, 16 );
        public static Colour DarkerGrey { get; } = new Colour( 32, 32, 32 );
        public static Colour DarkGrey { get; } = new Colour( 64, 64, 64 );
        public static Colour Grey { get; } = new Colour( 128, 128, 128 );
        public static Colour LightGrey { get; } = new Colour( 192, 192, 192 );
        public static Colour LighterGrey { get; } = new Colour( 220, 220, 220 );
        public static Colour EvenLighterGrey { get; } = new Colour( 232, 232, 232 );
        public static Colour LightestGrey { get; } = new Colour( 242, 242, 242 );
        public static Colour White { get; } = new Colour( 255, 255, 255 );
        
        public static Colour Magenta { get; } = new Colour( 255, 0, 255 );
        public static Colour Yellow { get; } = new Colour( 255, 255, 0 );
        public static Colour Cyan { get; } = new Colour( 0, 255, 255 );
        public static Colour Red { get;  } = new Colour( 255, 0, 0 );
        public static Colour Orange { get; } = new Colour( 255, 215, 0 );
    }
}