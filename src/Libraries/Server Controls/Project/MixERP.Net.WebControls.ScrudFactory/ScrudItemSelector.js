/********************************************************************************
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
***********************************************************************************/
function sisGetQueryStringByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
};

function sisUpdateValue(val) {
    var ctl = sisGetQueryStringByName('AssociatedControlId');
    $('#' + ctl, parent.document.body).val(val);
    closeWindow();
};

function closeWindow() {
    parent.jQuery.colorbox.close();
    parent.closeItemSelector();
};

document.onkeydown = function (evt) {
    evt = evt || window.event;
    if (evt.keyCode === 27) {
        top.close();
    }
};