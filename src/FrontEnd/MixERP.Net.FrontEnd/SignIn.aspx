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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="MixERP.Net.FrontEnd.SignIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body id="SignInBody">
    <form id="form1" runat="server">
        <asp:Literal ID="TestLiteral" runat="server" />

        <asp:PlaceHolder runat="server" ID="Placeholder1"></asp:PlaceHolder>
        <script type="text/javascript" src="/bundles/libraries.js"></script>
        <script type="text/javascript" src="/Scripts/jssha1.5/src/sha.js"></script>
        <script type="text/javascript" src="/Scripts/Pages/SignIn.aspx.js"></script>
    </form>
</body>
</html>
