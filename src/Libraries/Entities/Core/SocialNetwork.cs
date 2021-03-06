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
    [PrimaryKey("social_network_name", autoIncrement = false)]
    [TableName("core.social_networks")]
    [ExplicitColumns]
    public sealed class SocialNetwork : PetaPocoDB.Record<SocialNetwork>, IPoco
    {
        [Column("social_network_name")]
        [ColumnDbType("varchar", 128, false, "")]
        public string SocialNetworkName { get; set; }

        [Column("semantic_css_class")]
        [ColumnDbType("varchar", 128, true, "")]
        public string SemanticCssClass { get; set; }

        [Column("base_url")]
        [ColumnDbType("varchar", 128, true, "")]
        public string BaseUrl { get; set; }

        [Column("profile_url")]
        [ColumnDbType("varchar", 128, true, "")]
        public string ProfileUrl { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}