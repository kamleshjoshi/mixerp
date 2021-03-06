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

using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.i18n.Resources;
using MixERP.Net.WebControls.StockAdjustmentFactory;
using System;
using MixERP.Net.Framework.Contracts;

namespace MixERP.Net.Core.Modules.Inventory.Entry
{
    public partial class TransferRequest : MixERPUserControl, ITransaction
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (FormView form = new FormView())
            {
                form.Text = Titles.StockTransferRequest;
                form.StoreServiceUrl = "/Modules/Inventory/Services/ItemData.asmx/GetStores";
                form.ItemServiceUrl = "/Modules/Inventory/Services/ItemData.asmx/GetItems";
                form.UnitServiceUrl = "/Modules/Inventory/Services/ItemData.asmx/GetUnits";
                form.ItemPopupUrl =
                    "/Modules/Inventory/Setup/ItemsPopup.mix?modal=1&CallBackFunctionName=loadItems&AssociatedControlId=ItemIdHidden";
                form.ItemIdQuerySericeUrl = "/Modules/Inventory/Services/ItemData.asmx/GetItemCodeByItemId";
                form.ValidateSides = false;
                form.HideSides = true;
                form.Catalog = AppUsers.GetCurrentUserDB();
                form.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();

                this.Placeholder1.Controls.Add(form);
            }
        }
    }
}