using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Linq;

public class SummaryFooterCellTemplate : ITemplate {
    public SummaryFooterCellTemplate() {
        SummaryTexts = new Dictionary<string, string>();
    }

    public Dictionary<string, string> SummaryTexts { get; private set; }

    public void InstantiateIn(Control container) {
        var templateContainer = (GridViewFooterCellTemplateContainer)container;
        var grid = templateContainer.Grid;
        var column = templateContainer.Column;

        var summaryItems = grid.TotalSummary.Where(i => CanShowSummaryItem(i, column)).ToList();
        foreach (var item in summaryItems) {
            templateContainer.Controls.Add(CreateSummaryItemControl(item, grid));
            if (summaryItems.ElementAt(summaryItems.Count - 1) != item)
                templateContainer.Controls.Add(new LiteralControl("<br />"));
        }
    }

    protected virtual ASPxLabel CreateSummaryItemControl(ASPxSummaryItem item, ASPxGridView grid) {
        var value = grid.GetTotalSummaryValue(item);
        var text = item.GetTotalFooterDisplayText(grid.DataColumns[item.FieldName], value);

        var label = new ASPxLabel();
        label.EnableClientSideAPI = true;
        label.ID = string.Format("SummaryItemControl_{0}_{1}", item.FieldName, item.ShowInColumn);
        label.Text = text;
        label.Init += (s, e) => { SummaryTexts[label.ClientID] = label.Text; };

        return label;
    }

    protected virtual bool CanShowSummaryItem(ASPxSummaryItem item, GridViewColumn column) {
        var dataColumn = column as GridViewDataColumn;
        if (!string.IsNullOrEmpty(item.ShowInColumn)) {
            if (item.ShowInColumn == column.Name || item.ShowInColumn == column.Caption)
                return true;
            return dataColumn != null && item.ShowInColumn == dataColumn.FieldName;
        }
        return dataColumn != null && item.FieldName == dataColumn.FieldName;
    }
}