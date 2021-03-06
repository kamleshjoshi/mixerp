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
using MixERP.Net.Entities;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.i18n.Resources;
using MixERP.Net.WebControls.StockTransactionFactory;
using System;
using MixERP.Net.Framework.Contracts;
using PetaPoco;

namespace MixERP.Net.Core.Modules.Purchase.Entry
{
    public partial class GRN : MixERPUserControl, ITransaction
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (StockTransactionForm product = new StockTransactionForm())
            {
                product.Book = TranBook.Purchase;
                product.SubBook = SubTranBook.Receipt;
                product.Text = Titles.GoodsReceiptNote;
                product.ShowStore = true;
                product.ShowCostCenter = true;
                product.Catalog = AppUsers.GetCurrentUserDB();
                product.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();

                this.Placeholder1.Controls.Add(product);
            }
        }
    }
}