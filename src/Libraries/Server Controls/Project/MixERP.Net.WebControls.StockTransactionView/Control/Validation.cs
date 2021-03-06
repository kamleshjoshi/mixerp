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

using MixERP.Net.Entities;
using MixERP.Net.i18n.Resources;
using MixERP.Net.WebControls.StockTransactionViewFactory.Data.Helpers;
using System.Collections.ObjectModel;

namespace MixERP.Net.WebControls.StockTransactionViewFactory
{
    public partial class StockTransactionView
    {
        private bool AreAlreadyMerged(string catalog, Collection<long> values)
        {
            if (this.AreSalesQuotationsAlreadyMerged(catalog, values))
            {
                return true;
            }
            if (this.AreOrdersAlreadyMerged(catalog, values))
            {
                return true;
            }

            return false;
        }

        private bool AreOrdersAlreadyMerged(string catalog, Collection<long> values)
        {
            bool merged = false;

            if (this.SubBook == SubTranBook.Order)
            {
                if (this.Book == TranBook.Sales)
                {
                    merged = NonGlStockTransaction.AreSalesOrdersAlreadyMerged(catalog, values);
                }

                if (this.Book == TranBook.Purchase)
                {
                    merged = NonGlStockTransaction.ArePurchaseOrdersAlreadyMerged(catalog, values);
                }
            }

            if (merged)
            {
                this.errorLabel.InnerText = Warnings.CannotMergeAlreadyMerged;
            }

            return merged;
        }

        private bool AreSalesQuotationsAlreadyMerged(string catalog, Collection<long> values)
        {
            if (this.Book == TranBook.Sales && this.SubBook == SubTranBook.Quotation)
            {
                if (NonGlStockTransaction.AreSalesQuotationsAlreadyMerged(catalog, values))
                {
                    this.errorLabel.InnerText = Warnings.CannotMergeAlreadyMerged;
                    return true;
                }
            }

            return false;
        }

        private bool IsValid(string catalog)
        {
            Collection<long> values = this.GetSelectedValues();

            if (values.Count.Equals(0))
            {
                this.errorLabel.InnerText = Warnings.NothingSelected;
                return false;
            }

            if (!this.BelongToSameParty(catalog, values))
            {
                return false;
            }
            if (this.AreAlreadyMerged(catalog, values))
            {
                return false;
            }
            if (this.ContainsIncompatibleTaxes(catalog, values))
            {
                return false;
            }

            return true;
        }

        private bool BelongToSameParty(string catalog, Collection<long> values)
        {
            bool belongToSameParty = NonGlStockTransaction.TransactionIdsBelongToSameParty(catalog, values);

            if (!belongToSameParty)
            {
                this.errorLabel.InnerText = Warnings.CannotMergeDifferentPartyTransaction;
                return false;
            }

            return true;
        }

        private bool ContainsIncompatibleTaxes(string catalog, Collection<long> values)
        {
            if (this.Book == TranBook.Sales)
            {
                if (NonGlStockTransaction.ContainsIncompatibleTaxes(catalog, values))
                {
                    this.errorLabel.InnerText = Warnings.CannotMergeIncompatibleTax;
                    return true;
                }
            }

            return false;
        }
    }
}