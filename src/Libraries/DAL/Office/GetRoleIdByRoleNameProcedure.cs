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
using MixERP.Net.Entities.Office;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Office.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "office.get_role_id_by_role_name(_role_name text)" on the database.
    /// </summary>
    public class GetRoleIdByRoleNameProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "office";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_role_id_by_role_name";
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
        /// Maps to "_role_name" argument of the function "office.get_role_id_by_role_name".
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "office.get_role_id_by_role_name(_role_name text)" on the database.
        /// </summary>
        public GetRoleIdByRoleNameProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "office.get_role_id_by_role_name(_role_name text)" on the database.
        /// </summary>
        /// <param name="roleName">Enter argument value for "_role_name" parameter of the function "office.get_role_id_by_role_name".</param>
        public GetRoleIdByRoleNameProcedure(string roleName)
        {
            this.RoleName = roleName;
        }
        /// <summary>
        /// Prepares and executes the function "office.get_role_id_by_role_name".
        /// </summary>
        public int Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetRoleIdByRoleNameProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM office.get_role_id_by_role_name(@0::text);";
            return Factory.Scalar<int>(this._Catalog, query, this.RoleName);
        }
    }
}