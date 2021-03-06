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
    [PrimaryKey("bonus_slab_id", autoIncrement = true)]
    [TableName("core.bonus_slabs")]
    [ExplicitColumns]
    public sealed class BonusSlab : PetaPocoDB.Record<BonusSlab>, IPoco
    {
        [Column("bonus_slab_id")]
        [ColumnDbType("int4", 0, false, "nextval('core.bonus_slabs_bonus_slab_id_seq'::regclass)")]
        public int BonusSlabId { get; set; }

        [Column("bonus_slab_code")]
        [ColumnDbType("varchar", 12, false, "")]
        public string BonusSlabCode { get; set; }

        [Column("bonus_slab_name")]
        [ColumnDbType("varchar", 50, false, "")]
        public string BonusSlabName { get; set; }

        [Column("effective_from")]
        [ColumnDbType("date", 0, false, "")]
        public DateTime EffectiveFrom { get; set; }

        [Column("ends_on")]
        [ColumnDbType("date", 0, false, "")]
        public DateTime EndsOn { get; set; }

        [Column("checking_frequency_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int CheckingFrequencyId { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }

        [Column("account_id")]
        [ColumnDbType("int8", 0, false, "")]
        public long AccountId { get; set; }

        [Column("statement_reference")]
        [ColumnDbType("varchar", 100, false, "")]
        public string StatementReference { get; set; }
    }
}