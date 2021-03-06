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

using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

[assembly: WebResource("MixERP.Net.WebControls.StockTransactionFactory.Includes.Style.StockTransactionFactory.css", "text/css", PerformSubstitution = true)]

namespace MixERP.Net.WebControls.StockTransactionFactory
{
    public partial class StockTransactionForm
    {
        private const string resource = "MixERP.Net.WebControls.StockTransactionFactory.Includes.Style.StockTransactionFactory.css";

        [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
        private void AddStylesheet()
        {
            string href = this.Page.Request.Url.GetLeftPart(UriPartial.Authority) + this.Page.ClientScript.GetWebResourceUrl(typeof(StockTransactionForm), resource);

            using (HtmlLink link = new HtmlLink())
            {
                link.Attributes.Add("rel", "stylesheet");
                link.Attributes.Add("type", "text/css");
                link.Href = href;

                this.Page.Header.Controls.Add(link);
            }
        }
    }
}