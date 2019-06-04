<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" 
            oncustomcellvalue="ASPxPivotGrid1_CustomCellValue">
            <Fields>
                <dxwpg:PivotGridField ID="fieldGroup" Area="RowArea" AreaIndex="0" FieldName="Group"
                    TotalsVisibility="CustomTotals">
                    <CustomTotals>
                        <dxwpg:PivotGridCustomTotal />
                        <dxwpg:PivotGridCustomTotal SummaryType="Count" />
                        <dxwpg:PivotGridCustomTotal SummaryType="Average" />
                    </CustomTotals>
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldName" Area="RowArea" AreaIndex="1" FieldName="Name">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldSum" Area="DataArea" AreaIndex="0" FieldName="Value"
                    Caption="Sum" CellFormat-FormatType="Numeric" CellFormat-FormatString="N2">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldCount" Area="DataArea" AreaIndex="1" FieldName="Value"
                    SummaryType="Count" Caption="Count" CellFormat-FormatType="Numeric" CellFormat-FormatString="N2">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldAverage" Area="DataArea" AreaIndex="2" FieldName="Value"
                    SummaryType="Average" Caption="Average" CellFormat-FormatType="Numeric" CellFormat-FormatString="N2">
                </dxwpg:PivotGridField>
            </Fields>
        </dxwpg:ASPxPivotGrid>
    </div>
    </form>
</body>
</html>