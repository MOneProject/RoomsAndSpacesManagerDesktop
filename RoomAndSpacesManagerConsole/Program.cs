﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;

namespace RoomAndSpacesManagerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(@"C:\Users\ya.goreglyad\Desktop\Помещения.xlsx", false))
            {
                WorkbookPart bkPart = doc.WorkbookPart;
                DocumentFormat.OpenXml.Spreadsheet.Workbook workbook = bkPart.Workbook;
                DocumentFormat.OpenXml.Spreadsheet.Sheet s = workbook.Descendants<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Where(sht => sht.Name == "Категории").FirstOrDefault();
                WorksheetPart wsPart = (WorksheetPart)bkPart.GetPartById(s.Id);
                DocumentFormat.OpenXml.Spreadsheet.SheetData sheetdata = wsPart.Worksheet.Elements<DocumentFormat.OpenXml.Spreadsheet.SheetData>().FirstOrDefault();


                foreach (Row r in sheetdata.Elements<Row>())
                {
                    Cell[] arrayRow = r.Elements<Cell>().ToArray();


                    CategoryDto category = new CategoryDto()
                    {
                        Key = arrayRow[1].CellValue?.Text,
                        Name = arrayRow[0].CellValue?.Text

                    };
                    categoryList.Add(category);
                }
            }

        }
    }
}
