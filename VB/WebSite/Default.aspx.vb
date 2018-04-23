Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Data.PivotGrid

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private data As DataTable
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxPivotGrid1.DataSource = CreateTable()

	End Sub
	Private Function CreateTable() As DataTable
		data = New DataTable()
		data.Columns.Add("Name", GetType(String))
		data.Columns.Add("Group", GetType(String))
		data.Columns.Add("Value", GetType(Integer))

		data.Rows.Add(New Object() { "Aaa", "Group 1", 1 })
		data.Rows.Add(New Object() { "Aaa", "Group 1", 2 })
		data.Rows.Add(New Object() { "Bbb", "Group 1", 4 })

		data.Rows.Add(New Object() { "Ccc", "Group 2", 1 })
		Return data
	End Function
	Protected Sub ASPxPivotGrid1_CustomCellValue(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotCellValueEventArgs)
		If ReferenceEquals(e.RowCustomTotal, Nothing) Then
			Return
		End If

		If e.RowCustomTotal.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum Then
			Dim ds As PivotSummaryDataSource = e.CreateSummaryDataSource()
			Dim customSum As Decimal = 0
			For i As Integer = 0 To ds.RowCount - 1
				customSum += Convert.ToDecimal(ds.GetValue(i, e.DataField))
			Next i
			e.Value = customSum
		ElseIf e.RowCustomTotal.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average Then
			Dim ds As PivotSummaryDataSource = e.CreateSummaryDataSource()
			If ds.RowCount = 0 Then
				Return
			End If
			Dim customAverage As Decimal = 0
			For i As Integer = 0 To ds.RowCount - 1
				customAverage += Convert.ToDecimal(ds.GetValue(i, e.DataField))
			Next i
			e.Value = customAverage / ds.RowCount
		End If
	End Sub
End Class
