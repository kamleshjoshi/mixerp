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
    [TableName("core.bank_accounts_scrud_view")]
    [ExplicitColumns]
    public sealed class BankAccountsScrudView : PetaPocoDB.Record<BankAccountsScrudView>, IPoco
    {
        [Column("account_id")]
        [ColumnDbType("int8", 0, true, "")]
        public long? AccountId { get; set; }

        [Column("user_name")]
        [ColumnDbType("varchar", 50, true, "")]
        public string UserName { get; set; }

        [Column("office_name")]
        [ColumnDbType("text", 0, true, "")]
        public string OfficeName { get; set; }

        [Column("bank_name")]
        [ColumnDbType("varchar", 128, true, "")]
        public string BankName { get; set; }

        [Column("bank_branch")]
        [ColumnDbType("varchar", 128, true, "")]
        public string BankBranch { get; set; }

        [Column("bank_contact_number")]
        [ColumnDbType("varchar", 128, true, "")]
        public string BankContactNumber { get; set; }

        [Column("bank_address")]
        [ColumnDbType("text", 0, true, "")]
        public string BankAddress { get; set; }

        [Column("bank_account_number")]
        [ColumnDbType("varchar", 128, true, "")]
        public string BankAccountNumber { get; set; }

        [Column("bank_account_type")]
        [ColumnDbType("varchar", 128, true, "")]
        public string BankAccountType { get; set; }

        [Column("relationship_officer_name")]
        [ColumnDbType("varchar", 128, true, "")]
        public string RelationshipOfficerName { get; set; }
    }
}