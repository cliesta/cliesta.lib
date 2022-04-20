using Humanizer;

namespace Cliesta.Humanizer
{
    public static class StringExtensions
    {
        public static string Humanize( this string text )
        {
            return StringHumanizeExtensions.Humanize( text );
        }

    }
}
