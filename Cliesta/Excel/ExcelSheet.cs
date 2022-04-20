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
using System.Globalization;
using ClosedXML.Excel;

namespace Cliesta.Excel
{
    public class ExcelSheet
    {
        private IXLWorksheet Worksheet { get; }

        public ExcelSheet( IXLWorksheet worksheet )
        {
            Worksheet = worksheet;
        }

        public void SetCellValue( int row, int column, string value )
        {
            Worksheet.Cell( row, column ).SetValue( value );
        }

        public void SetCellValue( int row, int column, DateTime time )
        {
            var dateString = time.ToOADate().ToString( CultureInfo.InvariantCulture );
            SetCellValue( row, column, dateString );
            Worksheet.Cell( row, column ).DataType = XLDataType.DateTime;

            Worksheet.Cell( row, column ).Style.DateFormat.Format = "yyyy/mm/dd hh:mm:ss.000";
        }

        public void SetCellValue( int row, int column, double value )
        {
            Worksheet.Cell( row, column ).SetValue( value );
        }


        public void SetCellFormulaA1( int row, int column, string value )
        {
            Worksheet.Cell( row, column ).SetFormulaA1( value );
        }

        public void ColumnsAutoFit()
        {
            Worksheet.Columns().AdjustToContents();
        }

    }
}