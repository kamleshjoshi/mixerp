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

using MixERP.Net.WebControls.StockTransactionViewFactory.Data;
using MixERP.Net.WebControls.StockTransactionViewFactory.Data.Models;
using System.Collections.ObjectModel;
using System.Web;

namespace MixERP.Net.WebControls.StockTransactionViewFactory
{
    public partial class StockTransactionView
    {
        private void Merge(Collection<long> ids, string link)
        {
            MergeModel model = ModelFactory.GetMergeModel(this.Catalog, ids, this.Book, this.SubBook);

            if (model.View == null)
            {
                return;
            }

            if (model.View.Count.Equals(0))
            {
                return;
            }

            HttpContext.Current.Session["Product"] = model;
            HttpContext.Current.Response.Redirect(link);
        }
    }
}