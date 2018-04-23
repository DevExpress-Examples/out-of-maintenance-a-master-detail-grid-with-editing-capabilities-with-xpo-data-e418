<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MasterDetailWithXPO._Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Xpo.v15.1, Version=15.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Xpo" TagPrefix="dxxpo" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>A master-detail grid with editing capabilities with XPO data</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
			DataSourceID="XpoDataSource1" KeyFieldName="Oid">
			<Templates>
				<DetailRow>
					<dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
						DataSourceID="XpoDataSource2" KeyFieldName="Oid" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect"
						OnInitNewRow="ASPxGridView2_InitNewRow" OnRowInserting="ASPxGridView2_RowInserting">
						<Columns>
							<dxwgv:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true" ShowNewButton="true" ShowDeleteButton="true">
							</dxwgv:GridViewCommandColumn>
							<dxwgv:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1">
							</dxwgv:GridViewDataTextColumn>
							<dxwgv:GridViewDataTextColumn FieldName="Customer!Key" VisibleIndex="2">
							</dxwgv:GridViewDataTextColumn>
							<dxwgv:GridViewDataDateColumn FieldName="Date" VisibleIndex="3">
							</dxwgv:GridViewDataDateColumn>
							<dxwgv:GridViewDataTextColumn FieldName="Totals" VisibleIndex="4">
							</dxwgv:GridViewDataTextColumn>
						</Columns>
					</dxwgv:ASPxGridView>
				</DetailRow>
			</Templates>
			<Columns>
				<dxwgv:GridViewCommandColumn VisibleIndex="0"  ShowEditButton="true" ShowNewButton="true" ShowDeleteButton="true">
				</dxwgv:GridViewCommandColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
				</dxwgv:GridViewDataTextColumn>
			</Columns>
			<SettingsDetail ShowDetailRow="True" />
		</dxwgv:ASPxGridView>
		<dxxpo:XpoDataSource ID="XpoDataSource1" runat="server" TypeName="MasterDetailWithXPO.Customer">
		</dxxpo:XpoDataSource>
		<dxxpo:XpoDataSource ID="XpoDataSource2" runat="server" TypeName="MasterDetailWithXPO.Order"
			Criteria="[Customer!Key] = ?">
			<CriteriaParameters>
				<asp:SessionParameter DefaultValue="-1" Name="unnamedParam0" SessionField="CustomerKey" />
			</CriteriaParameters>
		</dxxpo:XpoDataSource>
	</div>
	</form>
</body>
</html>
