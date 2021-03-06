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

using System.Collections.Generic;
using MixERP.Net.Entities.Core;
using PetaPoco;

namespace MixERP.Net.Core.Modules.Sales.Data.Helpers
{
    public static class Currencies
    {
        public static IEnumerable<Currency> GetCurrencies(string catalog)
        {
            const string sql = "SELECT * FROM core.currencies ORDER BY currency_code;";
            return Factory.Get<Currency>(catalog, sql);
        }

        public static string GetHomeCurrency(string catalog, int officeId)
        {
            const string sql = "SELECT core.get_currency_code_by_office_id(@0);";
            return Factory.Scalar<string>(catalog, sql, officeId);
        }
    }
}