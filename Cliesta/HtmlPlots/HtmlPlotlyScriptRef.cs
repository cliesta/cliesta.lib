using Cliesta.Html;

namespace Cliesta.HtmlPlots
{
    public class HtmlPlotlyScriptRef : IHtmlHeaderElement
    {
        public void Build( HtmlBuilder builder )
        {
            builder.AppendLine( "<script src=\"https://cdn.plot.ly/plotly-latest.min.js\"></script>" );
        }
    }
}
