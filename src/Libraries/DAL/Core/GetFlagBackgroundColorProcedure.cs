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
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using PetaPoco;
using MixERP.Net.Entities.Core;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Core.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "core.get_flag_background_color(flag_type_id_ integer)" on the database.
    /// </summary>
    public class GetFlagBackgroundColorProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "core";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_flag_background_color";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "flag_type_id_" argument of the function "core.get_flag_background_color".
        /// </summary>
        public int FlagTypeId { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "core.get_flag_background_color(flag_type_id_ integer)" on the database.
        /// </summary>
        public GetFlagBackgroundColorProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "core.get_flag_background_color(flag_type_id_ integer)" on the database.
        /// </summary>
        /// <param name="flagTypeId">Enter argument value for "flag_type_id_" parameter of the function "core.get_flag_background_color".</param>
        public GetFlagBackgroundColorProcedure(int flagTypeId)
        {
            this.FlagTypeId = flagTypeId;
        }
        /// <summary>
        /// Prepares and executes the function "core.get_flag_background_color".
        /// </summary>
        public string Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetFlagBackgroundColorProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM core.get_flag_background_color(@0::integer);";
            return Factory.Scalar<string>(this._Catalog, query, this.FlagTypeId);
        }
    }
}