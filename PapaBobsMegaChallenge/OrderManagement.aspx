<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobsMegaChallenge.OrderManagement" %>

<%@ Register assembly="Microsoft.AspNet.EntityDataSource" namespace="Microsoft.AspNet.EntityDataSource" tagprefix="ef" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:GridView ShowHeaderWhenEmpty="true" ID="GridView1" runat="server"  OnRowCommand="GridView1_OnRowCommand" OnRowDataBound="GridView_RowDataBound">
				<Columns>
					<asp:ButtonField CommandName="FinishOrder" Text="Button" />
				</Columns>
				<EmptyDataTemplate>
					No Orders Available
				</EmptyDataTemplate>
			</asp:GridView>
        </div>
    </form>
</body>
</html>
