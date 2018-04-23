Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo
Imports DevExpress.Web

Namespace MasterDetailWithXPO
    ' TODO: hide service columns (Oid, Customer!Key) from the grids, so that an end-user cannot see them

    Partial Public Class _Default
        Inherits System.Web.UI.Page

        Private xpoSession As Session

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            xpoSession = XpoHelper.GetNewSession()
            XpoDataSource1.Session = xpoSession
            XpoDataSource2.Session = xpoSession
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub ASPxGridView2_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
            Session("CustomerKey") = DirectCast(sender, ASPxGridView).GetMasterRowKeyValue()

        End Sub

        Protected Sub ASPxGridView2_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
            ' Do not use this event to init values of a new row!
            ' It can be only used to initialize visible editors on the EditForm.
            ' To assign data row values, use the RowInserting event
        End Sub

        Protected Sub ASPxGridView2_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
            e.NewValues("Customer!Key") = DirectCast(sender, ASPxGridView).GetMasterRowKeyValue()
        End Sub
    End Class
End Namespace
