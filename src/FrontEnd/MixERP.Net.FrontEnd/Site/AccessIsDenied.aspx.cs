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

using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Base;
using MixERP.Net.i18n.Resources;
using System;
using System.Web.UI.HtmlControls;

namespace MixERP.Net.FrontEnd.Site
{
    public partial class AccessIsDenied : MixERPWebpage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            using (HtmlGenericControl header = new HtmlGenericControl("h1"))
            {
                header.InnerText = Warnings.AccessIsDenied;
                this.Placeholder1.Controls.Add(header);
            }

            using (HtmlGenericControl divider = HtmlControlHelper.GetDivider())
            {
                this.Placeholder1.Controls.Add(divider);
            }

            using (HtmlGenericControl p = new HtmlGenericControl("p"))
            {
                p.InnerText = Warnings.NotAuthorized;
                this.Placeholder1.Controls.Add(p);
            }
        }
    }
}