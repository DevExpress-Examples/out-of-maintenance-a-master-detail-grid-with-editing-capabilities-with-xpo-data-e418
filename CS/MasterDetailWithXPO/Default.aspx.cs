using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;
using DevExpress.Web;

namespace MasterDetailWithXPO {
    // TODO: hide service columns (Oid, Customer!Key) from the grids, so that an end-user cannot see them

    public partial class _Default : System.Web.UI.Page {
        Session xpoSession; 

        protected void Page_Init(object sender, EventArgs e) {
            xpoSession = XpoHelper.GetNewSession();
            XpoDataSource1.Session = xpoSession;
            XpoDataSource2.Session = xpoSession;
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e) {
            Session["CustomerKey"] = ((ASPxGridView)sender).GetMasterRowKeyValue(); ;
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
}
