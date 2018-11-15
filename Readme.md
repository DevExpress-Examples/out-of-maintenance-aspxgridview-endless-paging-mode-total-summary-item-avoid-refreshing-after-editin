<!-- default file list -->
*Files to look at*:

* [SummaryFooterCell.cs](./CS/App_Code/SummaryFooterCell.cs) (VB: [SummaryFooterCell.vb](./VB/App_Code/SummaryFooterCell.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - Endless Paging Mode - Total summary item - Avoid refreshing after editing


<p>In this example, the following scenario is illustrated:<br>1) ASPxGridView operates in <a href="https://documentation.devexpress.com/#AspNet/CustomDocument15467">Endless paging mode</a>.<br>2) ASPxGridView contains the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument3757">total summary</a> item.<br>3) An ASPxGridView row is updated/deleted/inserted on the N page (for example, the AllowFocusedRow property is set to true and the edit row is focused).<br>4) After updating, ASPxGridView needs to update the total summary item and get completely refreshed.<br>5) Due to refreshing ASPxGridView in Endless mode, the control loses all uploaded pages and the edit row loses focus (the current page is reset to the first page and focus is set to the first row).<br>This example demonstrates how to avoid this scenario. Set the Visible property of the total summary item to <em>false -</em> in this case, ASPxGridView isn't refreshed after the update/delete/insert operation. Then, create a footer template, and use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridView_GetTotalSummaryValuetopic">GetTotalSummaryValue</a> and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxSummaryItem_GetTotalFooterDisplayTexttopic">GetTotalFooterDisplayText</a> methods to fill the template with a required value. </p>

<br/>


