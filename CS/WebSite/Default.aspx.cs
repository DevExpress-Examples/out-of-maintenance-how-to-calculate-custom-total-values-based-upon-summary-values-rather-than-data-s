using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;

public partial class _Default : System.Web.UI.Page 
{
    DataTable data;
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxPivotGrid1.DataSource = CreateTable();

    }
    private DataTable CreateTable()
    {
        data = new DataTable();
        data.Columns.Add("Name", typeof(string));
        data.Columns.Add("Group", typeof(string));
        data.Columns.Add("Value", typeof(int));

        data.Rows.Add(new object[] { "Aaa", "Group 1", 1 });
        data.Rows.Add(new object[] { "Aaa", "Group 1", 2 });
        data.Rows.Add(new object[] { "Bbb", "Group 1", 4 });

        data.Rows.Add(new object[] { "Ccc", "Group 2", 1 });
        return data;
    }
    protected void ASPxPivotGrid1_CustomCellValue(object sender, DevExpress.Web.ASPxPivotGrid.PivotCellValueEventArgs e)
    {
        if (ReferenceEquals(e.RowCustomTotal, null)) return;

        if (e.RowCustomTotal.SummaryType == DevExpress.Data.PivotGrid.PivotSummaryType.Sum)
        {
            PivotSummaryDataSource ds = e.CreateSummaryDataSource();
            decimal customSum = 0;
            for (int i = 0; i < ds.RowCount ; i++)
            {
                customSum += Convert.ToDecimal(ds.GetValue(i, e.DataField));
            }
            e.Value = customSum;
        }
        else if (e.RowCustomTotal.SummaryType == DevExpress.Data.PivotGrid.PivotSummaryType.Average )
        {
            PivotSummaryDataSource ds = e.CreateSummaryDataSource();
            if (ds.RowCount == 0) return;
            decimal customAverage = 0;
            for (int i = 0; i < ds.RowCount; i++)
            {
                customAverage += Convert.ToDecimal(ds.GetValue(i, e.DataField));
            }
            e.Value = customAverage / ds.RowCount ;
        }
    }
}
