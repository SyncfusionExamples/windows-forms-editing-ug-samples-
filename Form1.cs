using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;
using Syncfusion.Data;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.DataSource = new OrderInfoCollection().OrdersListDetails;
            this.sfDataGrid1.ShowGroupDropArea = true;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
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
        }
    }
}
