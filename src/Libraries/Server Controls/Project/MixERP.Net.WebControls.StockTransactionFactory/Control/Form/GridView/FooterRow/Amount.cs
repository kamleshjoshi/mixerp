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
        private static void CreateAmountField(TableRow row)
        {
            using (TableCell cell = new TableCell())
            {
                using (HtmlInputText amountInputText = new HtmlInputText())
                {
                    amountInputText.ID = "AmountInputText";
                    amountInputText.Attributes.Add("class", "currency text-right");
                    amountInputText.Attributes.Add("readonly", "readonly");

                    cell.Controls.Add(amountInputText);
                }

                row.Cells.Add(cell);
            }
        }
    }
}