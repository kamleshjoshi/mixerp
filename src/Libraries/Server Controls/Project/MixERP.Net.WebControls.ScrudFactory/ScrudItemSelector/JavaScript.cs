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
using System.Security.Permissions;
using System.Web;
using System.Web.UI;

[assembly: WebResource("MixERP.Net.WebControls.ScrudFactory.ScrudItemSelector.js", "application/x-javascript", PerformSubstitution = true)]

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudItemSelector
    {
        [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
        private void AddJavascript()
        {
            JSUtility.AddJSReference(this.Page, "MixERP.Net.WebControls.ScrudFactory.ScrudItemSelector.js", "ScrudItemSelector", typeof(ScrudItemSelector));
        }
    }
}