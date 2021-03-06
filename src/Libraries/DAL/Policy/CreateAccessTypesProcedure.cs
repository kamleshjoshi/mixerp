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
using MixERP.Net.Entities.Policy;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Policy.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "policy.create_access_types(_access_type_id integer, _access_type_name character varying)" on the database.
    /// </summary>
    public class CreateAccessTypesProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "policy";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "create_access_types";
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
        /// Maps to "_access_type_id" argument of the function "policy.create_access_types".
        /// </summary>
        public int AccessTypeId { get; set; }
        /// <summary>
        /// Maps to "_access_type_name" argument of the function "policy.create_access_types".
        /// </summary>
        public string AccessTypeName { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "policy.create_access_types(_access_type_id integer, _access_type_name character varying)" on the database.
        /// </summary>
        public CreateAccessTypesProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "policy.create_access_types(_access_type_id integer, _access_type_name character varying)" on the database.
        /// </summary>
        /// <param name="accessTypeId">Enter argument value for "_access_type_id" parameter of the function "policy.create_access_types".</param>
        /// <param name="accessTypeName">Enter argument value for "_access_type_name" parameter of the function "policy.create_access_types".</param>
        public CreateAccessTypesProcedure(int accessTypeId, string accessTypeName)
        {
            this.AccessTypeId = accessTypeId;
            this.AccessTypeName = accessTypeName;
        }
        /// <summary>
        /// Prepares and executes the function "policy.create_access_types".
        /// </summary>
        public void Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"CreateAccessTypesProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM policy.create_access_types(@0::integer, @1::character varying);";
            Factory.NonQuery(this._Catalog, query, this.AccessTypeId, this.AccessTypeName);
        }
    }
}