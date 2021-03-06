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
    [PrimaryKey("late_fee_id", autoIncrement = true)]
    [TableName("core.late_fee")]
    [ExplicitColumns]
    public sealed class LateFee : PetaPocoDB.Record<LateFee>, IPoco
    {
        [Column("late_fee_id")]
        [ColumnDbType("int4", 0, false, "nextval('core.late_fee_late_fee_id_seq'::regclass)")]
        public int LateFeeId { get; set; }

        [Column("late_fee_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string LateFeeCode { get; set; }

        [Column("late_fee_name")]
        [ColumnDbType("varchar", 50, false, "")]
        public string LateFeeName { get; set; }

        [Column("is_flat_amount")]
        [ColumnDbType("bool", 0, false, "false")]
        public bool IsFlatAmount { get; set; }

        [Column("rate")]
        [ColumnDbType("numeric", 1572868, false, "")]
        public decimal Rate { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }

        [Column("account_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long AccountId { get; set; }
    }
}