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
    /// Prepares, validates, and executes the function "transactions.is_valid_party_by_stock_master_id(_stock_master_id bigint, _party_id bigint)" on the database.
    /// </summary>
    public class IsValidPartyByStockMasterIdProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "is_valid_party_by_stock_master_id";
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
        /// Maps to "_stock_master_id" argument of the function "transactions.is_valid_party_by_stock_master_id".
        /// </summary>
        public long StockMasterId { get; set; }
        /// <summary>
        /// Maps to "_party_id" argument of the function "transactions.is_valid_party_by_stock_master_id".
        /// </summary>
        public long PartyId { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.is_valid_party_by_stock_master_id(_stock_master_id bigint, _party_id bigint)" on the database.
        /// </summary>
        public IsValidPartyByStockMasterIdProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.is_valid_party_by_stock_master_id(_stock_master_id bigint, _party_id bigint)" on the database.
        /// </summary>
        /// <param name="stockMasterId">Enter argument value for "_stock_master_id" parameter of the function "transactions.is_valid_party_by_stock_master_id".</param>
        /// <param name="partyId">Enter argument value for "_party_id" parameter of the function "transactions.is_valid_party_by_stock_master_id".</param>
        public IsValidPartyByStockMasterIdProcedure(long stockMasterId, long partyId)
        {
            this.StockMasterId = stockMasterId;
            this.PartyId = partyId;
        }
        /// <summary>
        /// Prepares and executes the function "transactions.is_valid_party_by_stock_master_id".
        /// </summary>
        public bool Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"IsValidPartyByStockMasterIdProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM transactions.is_valid_party_by_stock_master_id(@0::bigint, @1::bigint);";
            return Factory.Scalar<bool>(this._Catalog, query, this.StockMasterId, this.PartyId);
        }
    }
}