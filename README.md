# How to export multiple datagrid in an Excel in MAUI DataGrid?

The [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) supports exporting multiple datagrids in a single Excel file.
#### XAML
We have a [Tab View](https://www.syncfusion.com/maui-controls/maui-tab-view); it has three tab items. Each item consists of one datagrid.We can export the datagrid using the button click.
```XML
<StackLayout>
    <Button Text="Export to Excel" Clicked="ExportToExcel_Clicked"/>
    <tabView:SfTabView x:Name="tabView">
    <tabView:SfTabView.Items>
        <tabView:SfTabItem Header="Employees">
            <tabView:SfTabItem.Content>
                <syncfusion:SfDataGrid x:Name="employeeDataGrid"
                                        ColumnWidthMode="Auto"
                                        GridLinesVisibility="Both"
                                        HeaderGridLinesVisibility="Both"
                                        x:DataType="viewModel:MainViewModel"
                                        ItemsSource="{Binding Employees}">                    
                </syncfusion:SfDataGrid>
            </tabView:SfTabItem.Content>
        </tabView:SfTabItem>

        <tabView:SfTabItem Header="Orders">
            <tabView:SfTabItem.Content>
                <syncfusion:SfDataGrid x:Name="ordersDataGrid"
                                        ColumnWidthMode="Auto"
                                        GridLinesVisibility="Both"
                                        HeaderGridLinesVisibility="Both"
                                        x:DataType="viewModel:MainViewModel"     
                                        ItemsSource="{Binding OrderInfoCollection}">                    
                </syncfusion:SfDataGrid>
            </tabView:SfTabItem.Content>
        </tabView:SfTabItem>

        <tabView:SfTabItem Header="New Employees">
            <tabView:SfTabItem.Content>
                <syncfusion:SfDataGrid x:Name="newEmployeeDataGrid"
                                        GridLinesVisibility="Both"
                                        HeaderGridLinesVisibility="Both"
                                        ColumnWidthMode="Auto"
                                        x:DataType="viewModel:MainViewModel"
                                        ItemsSource="{Binding EmployeeCollection}">  
                </syncfusion:SfDataGrid>
            </tabView:SfTabItem.Content>
        </tabView:SfTabItem>
    </tabView:SfTabView.Items>
</tabView:SfTabView>
</StackLayout>
```

#### C#
The [DataGridExcelExportingController](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.Exporting.DataGridExcelExportingController.html) is responsible for exporting the DataGrid content, and the [DataGridExcelExportingOption](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.Exporting.DataGridExcelExportingOption.html) allows for configuring the export behavior. ExcelEngine is initialized by exporting the employeeDataGrid. A new workbook with three worksheets has been created. Then we export the data from the three different DataGrids (employeeDataGrid, ordersDataGrid, and newEmployeeDataGrid) into the corresponding worksheets in the workbook using the exporting options. 
```C#
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
```



[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-export-multiple-datagrid-in-an-Excel-in-MAUI-DataGrid)

Take a moment to pursue this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples.
Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid(SfDataGrid).

### Conclusion
I hope you enjoyed learning about how to export multiple datagrid in an Excel in MAUI DataGrid.

You can refer to our [.NET MAUI DataGrid's feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to know about its other groundbreaking feature representations. You can also explore our .NET MAUI DataGrid Documentation to understand how to present and manipulate data.
For current customers, you can check out our .NET MAUI components from the [License and Downloads](https://www.syncfusion.com/account/downloads) page. If you are new to Syncfusion, you can try our 30-day free trial to check out our .NET MAUI DataGrid and other .NET MAUI components.
If you have any queries or require clarifications, please let us know in comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/account/login?ReturnUrl=%2Faccount%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dc54e52f3eb3cde0c3f20474f1bc179ed%26redirect_uri%3Dhttps%253A%252F%252Fsupport.syncfusion.com%252Fagent%252Flogincallback%26response_type%3Dcode%26scope%3Dopenid%2520profile%2520agent.api%2520integration.api%2520offline_access%2520kb.api%26state%3D8db41f98953a4d9ba40407b150ad4cf2%26code_challenge%3DvwHoT64z2h21eP_A9g7JWtr3vp3iPrvSjfh5hN5C7IE%26code_challenge_method%3DS256%26response_mode%3Dquery) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid). We are always happy to assist you!