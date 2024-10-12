using Expense_Tracker.Abstractions;
using Expense_Tracker.Services;
using OfficeOpenXml;

namespace Expense_Tracker.Exporter;

public class ExcelExporter : AExporter
{
    public override void DoExport(string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var expenses = ExpenseManager.Instance.GetAll();
        using var package = new ExcelPackage();

        // Add a new worksheet to the Excel package
        var worksheet = package.Workbook.Worksheets.Add("Expenses");

        // Add headers
        worksheet.Cells[1, 1].Value = "Id";
        worksheet.Cells[1, 2].Value = "Date";
        worksheet.Cells[1, 3].Value = "Description";
        worksheet.Cells[1, 4].Value = "Amount";

        // Add data rows
        for (int i = 0; i < expenses.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = expenses[i].Id;
            worksheet.Cells[i + 2, 2].Value = expenses[i].Date.ToString("yyyy-MM-dd");
            worksheet.Cells[i + 2, 3].Value = expenses[i].Description;
            worksheet.Cells[i + 2, 4].Value = expenses[i].Amount;
        }

        // Auto-fit columns for better visibility
        worksheet.Cells.AutoFitColumns();

        // Save the Excel file to the specified path
        package.SaveAs(new FileInfo(filePath));
    }
}
