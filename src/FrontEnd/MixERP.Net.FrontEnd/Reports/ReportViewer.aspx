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

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MixERPReportMaster.Master" 
    CodeBehind="ReportViewer.aspx.cs" Inherits="MixERP.Net.FrontEnd.Reports.ReportViewer" ValidateRequest="false"
    IsLandingPage="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">

    <asp:Panel runat="server" ID="ReportParameterPanel" class="report-parameter hide">
        <asp:Table ID="ReportParameterTable" runat="server"/>
        <a href="#" onclick=" $('.report-parameter').toggle(500); " class="ui red button" style="float: right; padding: 4px;">Close This Form</a>
    </asp:Panel>

    <div style="padding: 12px">
        <asp:PlaceHolder runat="server" ID="Placeholder1"></asp:PlaceHolder>
    </div>

</asp:Content>