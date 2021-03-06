/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using System.Collections.Generic;
using MixERP.Net.Entities.Office;
using PetaPoco;

namespace MixERP.Net.Core.Modules.Inventory.Data.Helpers
{
    public static class Stores
    {
        public static IEnumerable<Store> GetStores(string catalog, int officeId)
        {
            const string sql = "SELECT * FROM office.stores WHERE office_id IN (SELECT office.get_office_ids(@0));";
            return Factory.Get<Store>(catalog, sql, officeId);
        }

        public static IEnumerable<Store> GetStores(string catalog, int officeId, int userId)
        {
            const string sql = "SELECT * FROM office.get_stores(@0, @1)";
            return Factory.Get<Store>(catalog, sql, officeId, userId);
        }
    }
}