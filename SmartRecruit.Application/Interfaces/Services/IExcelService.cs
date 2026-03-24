using SmartRecruit.Domain.Entities;
using System.Collections.Generic;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IExcelService
    {
        byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName);
    }
}
