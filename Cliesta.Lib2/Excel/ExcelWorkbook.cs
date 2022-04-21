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

using ClosedXML.Excel;


namespace Cliesta.Lib2.Excel
{
    public class ExcelWorkbook
    {
        private readonly XLWorkbook _workbook;

        public ExcelWorkbook()
        {
            _workbook = new XLWorkbook
            {
                CalculationOnSave = true
            };
        }

        public ExcelSheet AddSheet( string name )
        {
            var sheet = _workbook.Worksheets.Add();
            sheet.Name = name
                .Replace( ":", "-" )
                .Replace( "/", "-" );
            return new ExcelSheet( sheet );
        }

        public void Save( string filePath )
        {
            _workbook.RecalculateAllFormulas();
            _workbook.SaveAs( filePath, true, true );
        }
    }
}