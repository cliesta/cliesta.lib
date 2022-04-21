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

using Cliesta.Geometry;
using Cliesta.Html;
using Cliesta.Html.Body;
using Cliesta.Maths;
using Cliesta.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using XPlot.Plotly;

namespace Cliesta.HtmlPlots
{
    public class HtmlPlot : IHtmlBodyElement
    {
        private readonly string _title;
        private readonly Theme _theme;
        private readonly Size2D _size;
        private readonly IEnumerable<Trace> _traces;
        private readonly Interval _xRange;
        private readonly Interval _yRange;
        public string StyleClass { get; }

        public HtmlPlot(
            string title, 
            Theme theme, 
            Size2D size,
            IEnumerable<Trace> traces,
            Interval xRange, 
            Interval yRange )
        {
            _title = title;
            _theme = theme;
            _size = size;
            _traces = traces;
            _xRange = xRange;
            _yRange = yRange;
        }

        public void Build( HtmlBuilder builder )
        {
            var chart = PlotChart();
            builder.AppendLine( chart.GetInlineHtml() );
        }

        private PlotlyChart PlotChart()
        {
            var fgColor = _theme.Text;
            var bgColor = _theme.ChartBackgroundColour;
            var legendBgColor = _theme.ChartLegendBackgroundColour;
            var gridColour = _theme.ChartGridColour;

            var traces = _traces.Select( t => t.InnerTrace );
            if( !traces.Any())
            {
                throw new InvalidOperationException( "No traces given to plot" );
            }
            
            var chart = Chart.Plot( traces, new Layout.Layout
            {
                title = _title,
                margin = GetTightMargin(),
                xaxis = GetXAxis( _xRange.Min, _xRange.Max, fgColor, gridColour ),
                yaxis = GetYAxis( fgColor, gridColour ),
                legend = GetLegend( legendBgColor, fgColor ),
                showlegend = _traces.Any( trace => trace.Name.Length > 0 ),
                titlefont = GetTitlefont(),
                font = GetFont( fgColor ),

                paper_bgcolor = bgColor.ToHtmlValue(),
                plot_bgcolor = bgColor.ToHtmlValue()
                
            } );
            chart.Width = (int)_size.Width;
            chart.Height = (int)_size.Height;
            return chart;
        }



        Margin GetMargin()
        {
            return new Margin()
            {
                t = _title.Length > 0 ? 60 : 30,
                b = 30,
                r = 30,
                l = 50
            };
        }

        static Margin GetTightMargin()
        {
            return new Margin()
            {
                t = 1,
                b = 30,
                r = 1,
                l = 1
            };
        }

        static Xaxis GetXAxis( double min, double max, Colour fgColor, Colour gridColour )
        {
            return new Xaxis()
            {
                linecolor = fgColor.ToHtmlValue(),
                mirror = true,
                zeroline = false,
                gridcolor = gridColour.ToHtmlValue(),
                range = new List<double> { min, max }
            };
        }

        static Legend GetLegend( Colour legendBgColor, Colour fgColor )
        {
            return new Legend()
            {
                x = 0.025,
                y = 0.975,
                bgcolor = legendBgColor.ToHtmlValue(),
                bordercolor = fgColor.ToHtmlValue(),
                borderwidth = 1,
            };
        }

        Yaxis GetYAxis( Colour fgColor, Colour gridColour )
        {
            return new Yaxis
            {
                linecolor = fgColor.ToHtmlValue(),
                mirror = true,
                zeroline = false,
                gridcolor = gridColour.ToHtmlValue(),
                showticklabels = false,
                range = _yRange == null ? null : new List<double> { (double)_yRange.Min, (double)_yRange.Max }
            };
        }

        static Font GetTitlefont()
        {
            return new Font
            {
                size = 16
            };
        }

        static Font GetFont( Colour fgColor )
        {
            return new Font
            {
                family = "verdana",
                size = 12,
                color = fgColor.ToHtmlValue(),
            };
        }

    }
}
