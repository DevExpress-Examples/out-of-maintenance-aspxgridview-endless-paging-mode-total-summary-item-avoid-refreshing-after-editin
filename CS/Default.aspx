<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function onEndCallback(s, e) {
            for (var labelID in s.cpSummaryTexts) {
                var label = ASPxClientControl.GetControlCollection().GetByName(labelID);
                if (label)
                    label.SetText(s.cpSummaryTexts[labelID])
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxGridView ID="Grid" runat="server" DataSourceID="SqlDataSource1" KeyFieldName="ProductID" Width="800" OnInit="Grid_Init" OnCustomJSProperties="Grid_CustomJSProperties" ClientIDMode="AutoID">
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" ShowDeleteButton="True" ShowNewButtonInHeader="True" />
                <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" EditFormSettings-Visible="False" />
                <dx:GridViewDataTextColumn FieldName="ProductName" />
                <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                <dx:GridViewDataTextColumn FieldName="UnitsInStock" />
            </Columns>
            <TotalSummary>
                <dx:ASPxSummaryItem FieldName="UnitPrice" ShowInColumn="ProductID" SummaryType="Max" Visible="false" />
                <dx:ASPxSummaryItem FieldName="UnitsInStock" ShowInColumn="UnitsInStock" SummaryType="Sum" Visible="false" />
                <dx:ASPxSummaryItem ShowInColumn="UnitsInStock" SummaryType="Count" Visible="false" />
            </TotalSummary>
            <Settings ShowFooter="True" />
            <SettingsBehavior AllowFocusedRow="True" />
            <SettingsPager Mode="EndlessPaging" />
            <ClientSideEvents EndCallback="onEndCallback" />
        </dx:ASPxGridView>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [UnitsInStock] FROM [Products]" ConnectionString="<%$ ConnectionStrings:ConnStr %>"
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID"
            InsertCommand="INSERT INTO [Products] ([ProductName], [UnitPrice], [UnitsInStock]) VALUES (@ProductName, @UnitPrice, @UnitsInStock)"
            UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [UnitPrice] = @UnitPrice, [UnitsInStock] = @UnitsInStock WHERE [ProductID] = @ProductID">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsInStock" Type="Int16" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
