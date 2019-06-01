<%@ Page MaintainScrollPositionOnPostback="true" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PapaBobsMegaChallenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="Content/bootstrap.min.css" rel="stylesheet" /> 
	<title></title>
	<style type="text/css">
		.auto-style1 {
			display: block;
			width: 100%;
			height: calc(1.5em + .75rem + 2px);
			font-size: 1rem;
			font-weight: 400;
			line-height: 1.5;
			color: #495057;
			background-clip: padding-box;
			border-radius: .25rem;
			transition: none;
			border: 1px solid #ced4da;
			margin-bottom: 0;
			background-color: #fff;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="container">
			<div class="page-header">
				<h1>Papa Bob's Pizza</h1>
				<p class=" lead">Pizza to code By</p>
				<hr />
			</div>

			<div class="row">
				<div class="col-12">
					<div class="form-group">
						<label class="h6">Size:</label>
						<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="auto-style1" AutoPostBack="True">
							<asp:ListItem Value="12">Small(12 inch - 12$)</asp:ListItem>
						</asp:DropDownList>
					</div>


					
					<div class="form-group">
						<label class="h6">Crust:</label>
						<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True">
						</asp:DropDownList>
					</div>

					
					<div class="custom-checkbox table table-sm table-responsive container-fluid flex-fill"><asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
					</asp:CheckBoxList>

					</div>


					<h2>Deliver To:</h2>
					<div class="form-group">
						<label  class="h6">Name:</label>
						<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
						<asp:Label ID="Label1" runat="server" Text="" CssClass="alert-danger"></asp:Label>
					</div>
					<div class="form-group">
						<label class="h6">Address:</label>
						<asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
						<asp:Label ID="Label2" runat="server" Text="" CssClass="alert-danger"></asp:Label>

					</div>
					<div class="form-group">
						<label class="h6">Zip:</label>
						<asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
						<asp:Label ID="Label3" runat="server" Text="" CssClass="alert-danger"></asp:Label>
					</div>
						
					<div class="form-group">
						<label class="h6">Phone:</label>
						<asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
						<asp:Label ID="Label4" runat="server" Text="" CssClass="alert-danger"></asp:Label>
					</div>
					
					
					
					
					
					<h2>Payment:</h2>
					<div class="custom-radio"><label><asp:RadioButton ID="RadioButton1" runat="server" GroupName="paymentMethod" Checked="True" /> Cash</label></div>
					<div class="custom-radio"><label><asp:RadioButton ID="RadioButton2" runat="server" GroupName="paymentMethod" /> Credit</label></div>
					
					
					
					
					<asp:Button ID="Button1" runat="server" Text="Order" CssClass="btn btn-lg btn-primary" OnClick="Button1_Click" />
					<br />
					<div>
						<label class="h2">Total Cost:</label>
						<label class ="h3"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></label>
					</div>
					<br />
					
				</div>
			</div>
        </div>
	<script src="Scripts/jquery-3.0.0.min.js"></script>
	<script src="Scripts/bootstrap.min.js"></script>
		<br />
		<br />
    </form>
	</body>
</html>
