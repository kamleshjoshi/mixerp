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
using MixERP.Net.i18n.Resources;
using MixERP.Net.WebControls.PartyControl;
using System;
using MixERP.Net.Framework.Contracts;
using PetaPoco;

namespace MixERP.Net.Core.Modules.Sales.Entry
{
    public partial class Receipt : MixERPUserControl, ITransaction
    {
        public string ExchangeRateLocalized()
        {
            return Titles.ExchangeRate;
        }

        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (PartyControl partyControl = new PartyControl())
            {
                this.Placeholder1.Controls.Add(partyControl);
            }

            this.InitializeResourceStrings();
        }

        private void InitializeResourceStrings()
        {
            this.TitleLiteral.Text = Titles.SalesReceipt;
            this.TotalDueAmountInBaseCurrencyLiteral.Text = Titles.TotalDueAmountInBaseCurrency;
            this.BaseCurrencyLiteral.Text = Titles.BaseCurrency;
            this.ReceivedCurrencyLiteral.Text = Titles.ReceivedCurrency;
            this.ReceivedAmountInaboveCurrencyLiteral.Text = Titles.ReceivedAmountInaboveCurrency;
            this.DebitExchangeRateLiteral.Text = Titles.ExchangeRate;
            this.ConvertedToHomeCurrencyLiteral.Text = Titles.ConvertedtoHomeCurrency;
            this.CreditExchangeRateLiteral.Text = Titles.ExchangeRate;
            this.ConvertedToBaseCurrencyLiteral.Text = Titles.ConvertedtoBaseCurrency;
            this.FinalDueAmountInBaseCurrencyLiteral.Text = Titles.FinalDueAmountinBaseCurrency;
            this.SaveLiteral.Text = Titles.Save;
            this.ReceiptTypeLiteral.Text = Titles.ReceiptType;
            this.CostCenterLiteral.Text = Titles.CostCenter;
            this.CashRepositoryLiteral.Text = Titles.CashRepository;
            this.WhichBankLiteral.Text = Titles.WhichBank;
            this.PostedDateLiteral.Text = Titles.PostedDate;

            this.PaymentCardLiteral.Text = Titles.SelectPaymentCard;
            this.MerchantFeeLiteral.Text = Titles.MerchantFeeInPercent;
            this.CustomerPaysFeesLiteral.Text = Titles.CustomerPaysFees;
            this.YesLiteral.Text = Titles.Yes;
            
            this.InstrumentCodeLiteral.Text = Titles.InstrumentCode;
            this.BankTransactionCodeLiteral.Text = Titles.BankTransactionCode;
            this.ReferenceNumberLiteral.Text = Titles.ReferenceNumber;
            this.StatementReferenceLiteral.Text = Titles.StatementReference;
        }
    }
}