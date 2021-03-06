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
    public static class Transaction
    {
        public static decimal GetExchangeRate(string catalog, int officeId, string sourceCurrencyCode, string destinationCurrencyCode)
        {
            const string sql = "SELECT transactions.get_exchange_rate(@OfficeId, @SourceCurrencyCode, @DestinationCurrencyCode);";

            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                command.Parameters.AddWithValue("@OfficeId", officeId);
                command.Parameters.AddWithValue("@SourceCurrencyCode", sourceCurrencyCode);
                command.Parameters.AddWithValue("@DestinationCurrencyCode", destinationCurrencyCode);

                return Conversion.TryCastDecimal(DbOperation.GetScalarValue(catalog, command));
            }
        }
    }
}