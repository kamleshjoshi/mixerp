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
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountStatement.ascx.cs" Inherits="MixERP.Net.Core.Modules.Finance.Reports.AccountStatement" %>

<style type="text/css">
    #AccountOverViewGrid td:nth-child(1),
    #AccountOverViewGrid th:nth-child(1) { width: 200px; }
</style>

<asp:PlaceHolder runat="server" ID="Placeholder1"></asp:PlaceHolder>
<script src="/Modules/Finance/Scripts/Reports/AccountStatement.js"></script>