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

using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MixERP.Net.WebControls.StockTransactionFactory
{
    public partial class StockTransactionForm
    {
        private static void CreateTaxFormField(TableRow row)
        {
            using (TableCell cell = new TableCell())
            {
                using (HtmlSelect taxSelect = new HtmlSelect())
                {
                    taxSelect.ID = "TaxSelect";
                    taxSelect.Attributes.Add("title", "Ctrl + T");
                    cell.Controls.Add(taxSelect);
                }

                row.Cells.Add(cell);
            }
        }

        private static void CreateTaxtField(TableRow row)
        {
            using (TableCell cell = new TableCell())
            {
                using (HtmlInputText taxInputText = new HtmlInputText())
                {
                    taxInputText.ID = "TaxInputText";
                    taxInputText.Attributes.Add("class", "currency text-right");
                    taxInputText.Attributes.Add("readonly", "readonly");

                    cell.Controls.Add(taxInputText);
                }

                row.Cells.Add(cell);
            }
        }
    }
}