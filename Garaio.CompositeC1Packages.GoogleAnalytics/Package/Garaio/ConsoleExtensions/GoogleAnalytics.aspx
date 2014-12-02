<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleAnalytics.aspx.cs" Inherits="Garaio.CompositeC1Packages.GoogleAnalytics.Package.Garaio.ConsoleExtensions.GoogleAnalytics" %>

<%@ Import Namespace="Garaio.CompositeC1Packages.GoogleAnalytics" %>
<%@ Import Namespace="Garaio.CompositeC1Packages.GoogleAnalytics.Package.App_GlobalResources" %>

<%@ Register TagPrefix="control" TagName="httpheaders" Src="~/Composite/controls/HttpHeadersControl.ascx" %>
<%@ Register TagPrefix="control" TagName="scriptloader" Src="~/Composite/controls/ScriptLoaderControl.ascx" %>
<%@ Register TagPrefix="control" TagName="styleloader" Src="~/Composite/controls/StyleLoaderControl.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:ui="http://www.w3.org/1999/xhtml" xmlns:control="http://www.composite.net/ns/uicontrol">
	<control:httpheaders runat="server" />
	<head runat="server">
	<title>Google Analytics Settings</title>
	<control:styleloader runat="server" />
	<link rel="stylesheet" href="<%= ResolveUrl("~/Frontend/Garaio/Styles/Bootstrap/css/bootstrap.min.css") %>" />
	<script type="application/javascript" src="<%= ResolveUrl("~/Frontend/Garaio/Scripts/jquery-1.11.0.min.js") %>"></script>
	<script type="application/javascript" src="<%= ResolveUrl("~/Frontend/Garaio/Scripts/bootstrap.min.js") %>"></script>
	<script type="application/javascript" src="<%= ResolveUrl("~/Frontend/Garaio/Scripts/bootstrapValidator.min.js") %>"></script>

	<control:scriptloader runat="server" type="sub" />

	<script type="text/javascript">
		$(document).ready(function () {
			$('#manageForm').bootstrapValidator({
				feedbackIcons: {
					valid: 'glyphicon glyphicon-ok',
					invalid: 'glyphicon glyphicon-remove',
					validating: 'glyphicon glyphicon-refresh'
				}
			});
			$('#<%= TxtAccount.ClientID%>').on('keydown', function (e) {
				e.stopPropagation();
			});
		});
	</script>

	<style type="text/css">
		body {
			background: #F0F0F0;
		}

		div.container {
			margin-top: 100px;
		}

		h1.margin-base-vertical {
			padding-bottom: 30px;
		}
	</style>
</head>
<body>
	<ui:page>
		<div class="container">
			<div class="row">
				<div class="col-md-8 col-md-offset-2">

					<h1 class="margin-base-vertical"><%= Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Sesstings_Title_H1%></h1>

					<div ID="SuccessAlert" class="alert alert-success alert-dismissible" role="alert" runat="server">
						<button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&#215;</span><span class="sr-only">Close</span></button>
						<strong><%# Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Success_Alert_Text_Strong%></strong> <%# Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Success_Alert_Text%>
					</div>

					<form runat="server" ID="manageForm" role="form" class="form-horizontal">
						<div class="panel panel-default">
							<div class="panel-heading">
								<h3 class="panel-title"><%= Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Panel_Title%></h3>
							</div>
							<div class="panel-body">
								<div class="form-group">
									<label class="col-sm-4 control-label" for="TxtAccount">
										<%= Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Label_For_TxtAccount%>
									</label>
									<div class="col-sm-8">
										<asp:TextBox runat="server" ID="TxtAccount" autofocus="true" CssClass="form-control"
											data-bv-notempty="true"
											data-bv-notempty-message="<%# Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Validation_NotEmpty_Message%>"
											data-bv-regexp="true"
											data-bv-regexp-regexp="<%# ConfigurationConstants.AnalyticsIdRegexPattern%>"
											data-bv-regexp-message="<%# Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Validation_RegEx_Message%>" />
										<asp:RegularExpressionValidator EnableClientScript="false" Display="Dynamic" runat="server"
											ID="AccountIdValidator"
											controltovalidate="TxtAccount"
											validationexpression="<%# ConfigurationConstants.AnalyticsIdRegexPattern%>"
											errormessage="<%# Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Validation_RegEx_Message%>"
											ForeColor="#a94442" />
									</div>
								</div>
								<div class="form-group">
									<div class="col-sm-3 col-sm-offset-9">
										<asp:Button runat="server" ID="BtnSave" Text="<%# Garaio_CompositeC1Packages_GoogleAnalytics_Texte.Button_Save_Text%>" CssClass="btn btn-primary btn-block" OnCommand="SaveData" />
									</div>
								</div>
							</div>
						</div>
					</form>
				</div>
			</div>
			<div class="row">
				<p class="col-md-4 col-md-offset-2">
					powered by <a title="GARAIO AG" href="http://www.garaio.com" target="_blank">GARAIO AG</a>
				</p>
			</div>
		</div>
	</ui:page>
</body>
</html>
