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
using MixERP.Net.FrontEnd.Base;
using System;
using MixERP.Net.Framework.Contracts;

namespace MixERP.Net.Core.Modules.Finance
{
    public partial class UpdateExchangeRates : MixERPUserControl, ITransaction
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            this.OfficeInputText.Value = AppUsers.GetCurrent().View.OfficeName;
            this.CurrencyInputText.Value = AppUsers.GetCurrent().View.CurrencyCode;
        }
    }
}