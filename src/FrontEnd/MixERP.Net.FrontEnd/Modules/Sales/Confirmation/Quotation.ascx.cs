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
using MixERP.Net.Common;
using MixERP.Net.Common.Extensions;
using MixERP.Net.Entities;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.FrontEnd.Controls;
using MixERP.Net.i18n.Resources;
using System;
using System.Web.Hosting;

namespace MixERP.Net.Core.Modules.Sales.Confirmation
{
    public partial class Quotation : TransactionCheckListControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            long transactionMasterId = Conversion.TryCastLong(this.Request["TranId"]);

            using (Checklist checklist = new Checklist())
            {
                checklist.ViewReportButtonText = Titles.ViewThisQuotation;
                checklist.EmailReportButtonText = Titles.EmailThisQuotation;
                checklist.Text = Titles.SalesQuotation;

                checklist.AttachmentFileName = HostingEnvironment.MapPath("/Resource/Documents/" + checklist.Text + "-#" + transactionMasterId + ".pdf");
                checklist.PartyEmailAddress = Data.Helpers.Parties.GetEmailAddress(AppUsers.GetCurrentUserDB(),
                    TranBook.Sales, SubTranBook.Quotation, transactionMasterId);


                checklist.AttachmentBookName = "non-gl-transaction";
                checklist.OverridePath = "/Modules/Sales/Quotation.mix";
                checklist.DisplayViewReportButton = true;
                checklist.DisplayEmailReportButton = true;
                checklist.DisplayAttachmentButton = true;
                checklist.IsNonGlTransaction = true;
                checklist.ReportPath = "~/Modules/Sales/Reports/SalesQuotationReport.mix";
                checklist.ViewPath = "/Modules/Sales/Quotation.mix";
                checklist.AddNewPath = "/Modules/Sales/Entry/Quotation.mix";
                checklist.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
                checklist.RestrictedTransactionMode = this.IsRestrictedMode;

                this.Placeholder1.Controls.Add(checklist);
            }
        }
    }
}