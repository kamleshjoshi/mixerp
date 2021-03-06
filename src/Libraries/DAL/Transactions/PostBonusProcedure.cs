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
using MixERP.Net.Entities.Transactions;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Transactions.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "transactions.post_bonus(_user_id integer, _login_id bigint, _office_id integer, _value_date date)" on the database.
    /// </summary>
    public class PostBonusProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "post_bonus";
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
        /// Maps to "_user_id" argument of the function "transactions.post_bonus".
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Maps to "_login_id" argument of the function "transactions.post_bonus".
        /// </summary>
        public long LoginId { get; set; }
        /// <summary>
        /// Maps to "_office_id" argument of the function "transactions.post_bonus".
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// Maps to "_value_date" argument of the function "transactions.post_bonus".
        /// </summary>
        public DateTime ValueDate { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.post_bonus(_user_id integer, _login_id bigint, _office_id integer, _value_date date)" on the database.
        /// </summary>
        public PostBonusProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.post_bonus(_user_id integer, _login_id bigint, _office_id integer, _value_date date)" on the database.
        /// </summary>
        /// <param name="userId">Enter argument value for "_user_id" parameter of the function "transactions.post_bonus".</param>
        /// <param name="loginId">Enter argument value for "_login_id" parameter of the function "transactions.post_bonus".</param>
        /// <param name="officeId">Enter argument value for "_office_id" parameter of the function "transactions.post_bonus".</param>
        /// <param name="valueDate">Enter argument value for "_value_date" parameter of the function "transactions.post_bonus".</param>
        public PostBonusProcedure(int userId, long loginId, int officeId, DateTime valueDate)
        {
            this.UserId = userId;
            this.LoginId = loginId;
            this.OfficeId = officeId;
            this.ValueDate = valueDate;
        }
        /// <summary>
        /// Prepares and executes the function "transactions.post_bonus".
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
                    Log.Information("Access to the function \"PostBonusProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM transactions.post_bonus(@0::integer, @1::bigint, @2::integer, @3::date);";
            Factory.NonQuery(this._Catalog, query, this.UserId, this.LoginId, this.OfficeId, this.ValueDate);
        }
    }
}