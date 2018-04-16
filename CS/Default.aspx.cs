using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Grid_Init(object sender, EventArgs e) {
        var grid = (ASPxGridView)sender;
        grid.Templates.FooterCell = new SummaryFooterCellTemplate();
    }
    protected void Grid_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e) {
        var grid = (ASPxGridView)sender;
        var summaryTemplate = (SummaryFooterCellTemplate)grid.Templates.FooterCell;
        e.Properties["cpSummaryTexts"] = summaryTemplate.SummaryTexts;
    }
}