Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports System.Linq

Public Class SummaryFooterCellTemplate
    Implements ITemplate

    Public Sub New()
        SummaryTexts = New Dictionary(Of String, String)()
    End Sub

    Private privateSummaryTexts As Dictionary(Of String, String)
    Public Property SummaryTexts() As Dictionary(Of String, String)
        Get
            Return privateSummaryTexts
        End Get
        Private Set(ByVal value As Dictionary(Of String, String))
            privateSummaryTexts = value
        End Set
    End Property

    Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
        Dim templateContainer = CType(container, GridViewFooterCellTemplateContainer)
        Dim grid = templateContainer.Grid
        Dim column = templateContainer.Column

        Dim summaryItems = grid.TotalSummary.Where(Function(i) CanShowSummaryItem(i, column)).ToList()
        For Each item In summaryItems
            templateContainer.Controls.Add(CreateSummaryItemControl(item, grid))
            If summaryItems.ElementAt(summaryItems.Count - 1) IsNot item Then
                templateContainer.Controls.Add(New LiteralControl("<br />"))
            End If
        Next item
    End Sub

    Protected Overridable Function CreateSummaryItemControl(ByVal item As ASPxSummaryItem, ByVal grid As ASPxGridView) As ASPxLabel
        Dim value = grid.GetTotalSummaryValue(item)
        Dim text = item.GetTotalFooterDisplayText(grid.DataColumns(item.FieldName), value)

        Dim label = New ASPxLabel()
        label.EnableClientSideAPI = True
        label.ID = String.Format("SummaryItemControl_{0}_{1}", item.FieldName, item.ShowInColumn)
        label.Text = text
        AddHandler label.Init, Sub(s, e) SummaryTexts(label.ClientID) = label.Text

        Return label
    End Function

    Protected Overridable Function CanShowSummaryItem(ByVal item As ASPxSummaryItem, ByVal column As GridViewColumn) As Boolean
        Dim dataColumn = TryCast(column, GridViewDataColumn)
        If Not String.IsNullOrEmpty(item.ShowInColumn) Then
            If item.ShowInColumn = column.Name OrElse item.ShowInColumn = column.Caption Then
                Return True
            End If
            Return dataColumn IsNot Nothing AndAlso item.ShowInColumn = dataColumn.FieldName
        End If
        Return dataColumn IsNot Nothing AndAlso item.FieldName = dataColumn.FieldName
    End Function
End Class