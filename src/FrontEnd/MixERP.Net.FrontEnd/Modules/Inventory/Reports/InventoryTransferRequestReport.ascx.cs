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

using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MixERP.Net.Core.Modules.Inventory.Reports
{
    public partial class InventoryTransferRequestReport : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            Collection<KeyValuePair<string, object>> list = new Collection<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("@id", this.Page.Request["TranId"]));

            using (WebReport report = new WebReport())
            {
                report.AddParameterToCollection(list);
                report.AddParameterToCollection(list);
                report.AutoInitialize = true;
                report.Path = "~/Modules/Inventory/Reports/Source/Inventory.Transfer.Request.xml";

                this.Controls.Add(report);
            }
        }
    }
}