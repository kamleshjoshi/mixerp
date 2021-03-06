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
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomFields.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.CustomFields" %>
<%@ Import Namespace="MixERP.Net.i18n.Resources" %>
<div>
    <div class="ui purple large header"><%=Titles.CustomFields %></div>
    <div class="ui divider"></div>

    <div class="ui form">
        <div class="fields">
            <div class="three wide field">
                <label for="FormSelect"><%=Titles.SelectForm %></label>
                <select id="FormSelect" class="ui dropdown"></select>
            </div>

            <div class="field">
                <label>&nbsp;</label>
                <a class="ui purple button" href="javascript:show();"><%=Titles.Show %></a>
            </div>

        </div>

    </div>
    <div class="ui divider"></div>

    <div class="ui form">
        <div id="CustomFieldContainer">
        </div>
        <div class="vpad8">
            <a class="ui pink button" href="javascript:window.addField();">
                <%=Titles.AddNew %>
            </a>
            <a class="ui positive button" onclick="save()"><%=Titles.Save %></a>
        </div>
    </div>
</div>


<script src="Scripts/CustomFields.ascx.js"></script>
