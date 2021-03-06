// ReSharper disable All
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
// ReSharper disable All
using PetaPoco;
using System;

namespace MixERP.Net.Entities.Core
{
    [PrimaryKey("", autoIncrement = false)]
    [TableName("core.item_cost_price_scrud_view")]
    [ExplicitColumns]
    public sealed class ItemCostPriceScrudView : PetaPocoDB.Record<ItemCostPriceScrudView>, IPoco
    {
        [Column("item_cost_price_id")]
        [ColumnDbType("int8", 0, true, "")]
        public long? ItemCostPriceId { get; set; }

        [Column("item_code")]
        [ColumnDbType("varchar", 12, true, "")]
        public string ItemCode { get; set; }

        [Column("item_name")]
        [ColumnDbType("varchar", 150, true, "")]
        public string ItemName { get; set; }

        [Column("party_code")]
        [ColumnDbType("varchar", 12, true, "")]
        public string PartyCode { get; set; }

        [Column("party_name")]
        [ColumnDbType("text", 0, true, "")]
        public string PartyName { get; set; }

        [Column("unit")]
        [ColumnDbType("text", 0, true, "")]
        public string Unit { get; set; }

        [Column("price")]
        [ColumnDbType("money_strict", 0, true, "")]
        public decimal? Price { get; set; }
    }
}