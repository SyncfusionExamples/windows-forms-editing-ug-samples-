# Windows Forms Editing UG samples 

This sample illustrates how to change a cell value in [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid) programmatically

The value exists in a particular cell can be changed programmatically by using the row column index of the cell. 

```c#

// Modify the cell value for RowIndex = 5 and ColumnIndex = 2
int rowIndex = 5;
int columnIndex = sfDataGrid1.TableControl.ResolveToGridVisibleColumnIndex(2);
if (columnIndex < 0)
    return;
var mappingName = sfDataGrid1.Columns[columnIndex].MappingName;
var recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(rowIndex);
if (recordIndex < 0)
    return;
object data;
if (sfDataGrid1.View.TopLevelGroup != null)
{
    var record = sfDataGrid1.View.TopLevelGroup.DisplayElements[recordIndex];
    if (!record.IsRecords)
        return;
    data = (record as Syncfusion.Data.RecordEntry).Data;
}
else
    data = sfDataGrid1.View.Records.GetItemAt(recordIndex);

this.sfDataGrid1.View.GetPropertyAccessProvider().SetValue(data, mappingName, "Modified Value");

```

``` vb

' Modify the cell value for RowIndex = 5 and ColumnIndex = 2
Dim rowIndex As Integer = 5
Dim columnIndex As Integer = sfDataGrid1.TableControl.ResolveToGridVisibleColumnIndex(2)
If columnIndex < 0 Then
    Return
End If
Dim mappingName = sfDataGrid1.Columns(columnIndex).MappingName
Dim recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(rowIndex)
If recordIndex < 0 Then
    Return
End If
Dim data As Object
If sfDataGrid1.View.TopLevelGroup IsNot Nothing Then
    Dim record = sfDataGrid1.View.TopLevelGroup.DisplayElements(recordIndex)
    If Not record.IsRecords Then
        Return
    End If
    data = (TryCast(record, Syncfusion.Data.RecordEntry)).Data
Else
    data = sfDataGrid1.View.Records.GetItemAt(recordIndex)
End If

Me.sfDataGrid1.View.GetPropertyAccessProvider().SetValue(data, mappingName, "Modified Value")

```

