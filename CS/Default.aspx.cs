using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Xpo;

public partial class _Default: System.Web.UI.Page {
    Session xpoSession;

    protected void Page_Init(object sender, EventArgs e) {
        xpoSession = XpoHelper.GetNewSession();
        XpoDataSource1.Session = xpoSession;
        XpoDataSource2.Session = xpoSession;
    }

    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e) {
        XpoDataSource2.CriteriaParameters["CustomerKey"].DefaultValue =  ((ASPxGridView)sender).GetMasterRowKeyValue().ToString();
    }

    protected void ASPxGridView2_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
        // Do not use this event to init values of a new row!
        // It can be only used to initialize visible editors on the EditForm.
        // To assign data row values, use the RowInserting event
    }

    protected void ASPxGridView2_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
        e.NewValues["Customer!Key"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }

}