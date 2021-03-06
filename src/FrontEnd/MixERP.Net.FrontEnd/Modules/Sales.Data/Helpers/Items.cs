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

using MixERP.Net.Common;
using MixERP.Net.DbFactory;
using Npgsql;

namespace MixERP.Net.Core.Modules.Sales.Data.Helpers
{
    public static class Items
    {
        public static bool IsStockItem(string catalog, string itemCode)
        {
            const string sql = "SELECT core.is_stock_item(@ItemCode);";
            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                command.Parameters.AddWithValue("@ItemCode", itemCode);

                return Conversion.TryCastBoolean(DbOperation.GetScalarValue(catalog, command));
            }
        }

        public static decimal CountItemInStock(string catalog, string itemCode, string unitName, int storeId)
        {
            const string sql = "SELECT core.count_item_in_stock(core.get_item_id_by_item_code(@ItemCode), core.get_unit_id_by_unit_name(@UnitName), @StoreId);";
            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                command.Parameters.AddWithValue("@ItemCode", itemCode);
                command.Parameters.AddWithValue("@UnitName", unitName);
                command.Parameters.AddWithValue("@StoreId", storeId);
                return Conversion.TryCastDecimal(DbOperation.GetScalarValue(catalog, command));
            }
        }
    }
}