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
    [PrimaryKey("non_gl_stock_master_relation_id", autoIncrement = true)]
    [TableName("transactions.non_gl_stock_master_relations")]
    [ExplicitColumns]
    public sealed class NonGlStockMasterRelation : PetaPocoDB.Record<NonGlStockMasterRelation>, IPoco
    {
        [Column("non_gl_stock_master_relation_id")]
        [ColumnDbType("int8", 0, false, "nextval('transactions.non_gl_stock_master_relations_non_gl_stock_master_relation__seq'::regclass)")]
        public long NonGlStockMasterRelationId { get; set; }

        [Column("order_non_gl_stock_master_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long OrderNonGlStockMasterId { get; set; }

        [Column("quotation_non_gl_stock_master_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long QuotationNonGlStockMasterId { get; set; }
    }
}