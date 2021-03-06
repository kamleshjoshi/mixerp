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

using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace MixERP.Net.WebControls.ScrudFactory.Helpers
{
    internal sealed class AjaxProgressTemplate : ITemplate
    {
        private readonly string cssClass;
        private readonly string spinnerImageCssClass;
        private readonly string spinnerImagePath;

        public AjaxProgressTemplate(string cssClass, string spinnerImageCssClass, string spinnerImagePath)
        {
            this.cssClass = cssClass;
            this.spinnerImageCssClass = spinnerImageCssClass;
            this.spinnerImagePath = spinnerImagePath;
        }

        public void InstantiateIn(Control container)
        {
            using (HtmlGenericControl ajaxProgressDiv = new HtmlGenericControl("div"))
            {
                ajaxProgressDiv.Attributes.Add("class", this.cssClass);

                using (HtmlGenericControl ajaxImage = new HtmlGenericControl("img"))
                {
                    ajaxImage.Attributes.Add("src", this.spinnerImagePath);
                    ajaxImage.Attributes.Add("class", this.spinnerImageCssClass);

                    ajaxProgressDiv.Controls.Add(ajaxImage);

                    container.Controls.Add(ajaxProgressDiv);
                }
            }
        }
    }
}