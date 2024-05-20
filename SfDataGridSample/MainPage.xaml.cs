using SfDataGridSample.Service;
using Syncfusion.Maui.DataGrid.Exporting;
using Syncfusion.XlsIO;
namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ExportToExcel_Clicked(object sender, EventArgs e)
        {

            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            DataGridExcelExportingOption employeeDataGridOption = new DataGridExcelExportingOption();
            DataGridExcelExportingOption ordersDataGridOption = new DataGridExcelExportingOption();
            DataGridExcelExportingOption newEmployeeDataGridOption = new DataGridExcelExportingOption();

            ExcelEngine newengine = excelExport.ExportToExcel(employeeDataGrid);
            var Newworkbook = newengine.Excel.Workbooks.Create(3);

            var Newworksheet1 = Newworkbook.Worksheets[0];
            var Newworksheet2 = Newworkbook.Worksheets[1];
            var Newworksheet3 = Newworkbook.Worksheets[2];
            Newworksheet1 = excelExport.ExportToExcel(employeeDataGrid, employeeDataGrid.View!, employeeDataGridOption, Newworksheet1);
            Newworksheet2 = excelExport.ExportToExcel(ordersDataGrid, ordersDataGrid.View!, ordersDataGridOption, Newworksheet2);
            Newworksheet3 = excelExport.ExportToExcel(newEmployeeDataGrid, newEmployeeDataGrid.View!, newEmployeeDataGridOption, Newworksheet3);


            MemoryStream stream = new MemoryStream();

            Newworkbook.SaveAs(stream);
            Newworkbook.Close();
            newengine.Dispose();

            string OutputFilename = "DataGrid.xlsx";
            SaveService saveService = new();
            saveService.SaveAndView(OutputFilename, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", stream);
        }
    }

}
