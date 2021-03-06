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

namespace MixERP.Net.Entities.Transactions
{
    [PrimaryKey("", autoIncrement = false)]
    [TableName("transactions.verified_stock_details_view")]
    [ExplicitColumns]
    public sealed class VerifiedStockDetailsView : PetaPocoDB.Record<VerifiedStockDetailsView>, IPoco
    {
        [Column("stock_detail_id")]
        [ColumnDbType("int8", 0, true, "")]
        public long? StockDetailId { get; set; }

        [Column("value_date")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? ValueDate { get; set; }

        [Column("stock_master_id")]
        [ColumnDbType("int8", 0, true, "")]
        public long? StockMasterId { get; set; }

        [Column("tran_type")]
        [ColumnDbType("transaction_type", 0, true, "")]
        public string TranType { get; set; }

        [Column("store_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? StoreId { get; set; }

        [Column("item_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? ItemId { get; set; }

        [Column("quantity")]
        [ColumnDbType("int4", 0, true, "")]
        public int? Quantity { get; set; }

        [Column("unit_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? UnitId { get; set; }

        [Column("base_quantity")]
        [ColumnDbType("numeric", 0, true, "")]
        public decimal? BaseQuantity { get; set; }

        [Column("base_unit_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? BaseUnitId { get; set; }

        [Column("price")]
        [ColumnDbType("money_strict", 0, true, "")]
        public decimal? Price { get; set; }

        [Column("cost_of_goods_sold")]
        [ColumnDbType("money_strict2", 0, true, "")]
        public decimal? CostOfGoodsSold { get; set; }

        [Column("discount")]
        [ColumnDbType("money_strict2", 0, true, "")]
        public decimal? Discount { get; set; }

        [Column("shipping_charge")]
        [ColumnDbType("money_strict2", 0, true, "")]
        public decimal? ShippingCharge { get; set; }

        [Column("sales_tax_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? SalesTaxId { get; set; }

        [Column("tax")]
        [ColumnDbType("money_strict2", 0, true, "")]
        public decimal? Tax { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}