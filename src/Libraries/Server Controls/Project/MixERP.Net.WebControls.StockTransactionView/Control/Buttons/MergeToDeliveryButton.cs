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

using MixERP.Net.i18n.Resources;
using System;
using System.Collections.ObjectModel;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MixERP.Net.Framework;

namespace MixERP.Net.WebControls.StockTransactionViewFactory
{
    public partial class StockTransactionView
    {
        private void CreateMergeToDeliveryButton(HtmlGenericControl container)
        {
            if (this.ShowMergeToDeliveryButton)
            {
                this.mergeToDeliveryButton = new Button();
                this.mergeToDeliveryButton.ID = "MergeToDeliveryButton";
                this.mergeToDeliveryButton.CssClass = "ui button";
                this.mergeToDeliveryButton.Text = Titles.MergeBatchToSalesDelivery;
                this.mergeToDeliveryButton.OnClientClick = "if(!getSelectedItems()){return false;};";

                this.mergeToDeliveryButton.Click += this.MergeToDeliveryButton_Click;

                container.Controls.Add(this.mergeToDeliveryButton);
            }
        }

        private void MergeToDeliveryButton_Click(object sender, EventArgs e)
        {
            Collection<long> values = this.GetSelectedValues();

            if (this.IsValid(this.Catalog))
            {
                if (string.IsNullOrWhiteSpace(this.MergeToDeliveryButtonUrl))
                {
                    throw new MixERPException(Warnings.CannotMergeUrlNull);
                }

                this.Merge(values, this.MergeToDeliveryButtonUrl);
            }
        }
    }
}