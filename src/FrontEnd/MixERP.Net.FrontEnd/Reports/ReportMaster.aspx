<%--
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses />.
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/BackendMaster.Master" AutoEventWireup="true" CodeBehind="ReportMaster.aspx.cs" Inherits="MixERP.Net.FrontEnd.Reports.ReportMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptContentPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheetContentPlaceholder" runat="server">
    <style type="text/css">
        #IFramePlaceholder {
            width: 800px;
        }

        iframe {
            min-height: 1000px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <asp:PlaceHolder runat="server" ID="ReportPlaceholder"/>
    <asp:PlaceHolder ID="IFramePlaceholder" runat="server"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BottomScriptContentPlaceholder" runat="server">
</asp:Content>

<script runat="server">
    protected void Page_Init(object sender, EventArgs e)
    {
        this.IsLandingPage = true;
        using (HtmlGenericControl iFrame = new HtmlGenericControl())
        {
            iFrame.TagName = "iframe";
            iFrame.Attributes.Add("src", this.ResolveUrl("~/Reports/ReportViewer.aspx?Id=" + this.RouteData.Values["path"]));
            iFrame.Attributes.Add("style", "width:100%;border:1px solid #C0C0C0;");
            this.IFramePlaceholder.Controls.Add(iFrame);
        }
    }
</script>