Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Grid_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim grid = DirectCast(sender, ASPxGridView)
        grid.Templates.FooterCell = New SummaryFooterCellTemplate()
    End Sub
    Protected Sub Grid_CustomJSProperties(ByVal sender As Object, ByVal e As ASPxGridViewClientJSPropertiesEventArgs)
        Dim grid = DirectCast(sender, ASPxGridView)
        Dim summaryTemplate = CType(grid.Templates.FooterCell, SummaryFooterCellTemplate)
        e.Properties("cpSummaryTexts") = summaryTemplate.SummaryTexts
    End Sub
End Class