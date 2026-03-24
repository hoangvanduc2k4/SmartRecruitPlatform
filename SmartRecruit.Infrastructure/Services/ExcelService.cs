using ClosedXML.Excel;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace SmartRecruit.Infrastructure.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            // 1. Lấy thuộc tính của T để làm Header
            var properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
            }

            // 2. Chèn dữ liệu từ dòng 2
            worksheet.Cell(2, 1).InsertData(data);

            // 3. Định dạng Header (Dòng 1)
            var header = worksheet.Row(1);
            header.Style.Font.Bold = true;
            header.Style.Fill.BackgroundColor = XLColor.FromHtml("#4F46E5");
            header.Style.Font.FontColor = XLColor.White;
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // 4. Auto-fit và giới hạn độ rộng cho các cột quá dài
            worksheet.Columns().AdjustToContents();
            foreach (var col in worksheet.Columns())
            {
                if (col.Width > 50) // Nếu cột rộng hơn 50, giới hạn lại và cho xuống dòng
                {
                    col.Width = 50;
                    col.Style.Alignment.WrapText = true;
                    col.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                }
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
