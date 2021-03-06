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

namespace MixERP.Net.Entities.Office
{
    [PrimaryKey("configuration_id", autoIncrement = true)]
    [TableName("office.configuration")]
    [ExplicitColumns]
    public sealed class Configuration : PetaPocoDB.Record<Configuration>, IPoco
    {
        [Column("configuration_id")]
        [ColumnDbType("int4", 0, false, "nextval('office.configuration_configuration_id_seq'::regclass)")]
        public int ConfigurationId { get; set; }

        [Column("config_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? ConfigId { get; set; }

        [Column("office_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int OfficeId { get; set; }

        [Column("value")]
        [ColumnDbType("text", 0, false, "")]
        public string Value { get; set; }

        [Column("configuration_details")]
        [ColumnDbType("text", 0, false, "")]
        public string ConfigurationDetails { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}