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
using MixERP.Net.WebControls.TransactionViewFactory;
using System;

namespace MixERP.Net.Core.Modules.Finance
{
    public partial class JournalVoucher : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (TransactionView view = new TransactionView())
            {
                view.DisplayAddButton = true;
                view.DisplayFlagButton = true;
                view.DisplayPrintButton = true;
                view.AddNewPath = "Entry/JournalVoucher.mix";
                view.GridViewCssClass = "ui table nowrap";
                view.Text = Titles.JournalVoucher;

                //Default Values
                view.DateFromFromFrequencyType = FrequencyType.FiscalYearStartDate;
                view.DateToFrequencyType = FrequencyType.FiscalYearEndDate;

                view.Book = "Journal";
                view.PostedBy = AppUsers.GetCurrent().View.UserName;
                view.OfficeName = AppUsers.GetCurrent().View.OfficeName;
                view.Status = "Approved";

                view.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
                view.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
                view.Catalog = AppUsers.GetCurrentUserDB();

                this.Controls.Add(view);
            }
        }
    }
}