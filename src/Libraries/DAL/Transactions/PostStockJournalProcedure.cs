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
    /// Prepares, validates, and executes the function "transactions.post_stock_journal(_office_id integer, _user_id integer, _login_id bigint, _value_date date, _reference_number character varying, _statement_reference text, _details transactions.stock_adjustment_type[])" on the database.
    /// </summary>
    public class PostStockJournalProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "post_stock_journal";
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
        /// Maps to "_office_id" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// Maps to "_user_id" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Maps to "_login_id" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public long LoginId { get; set; }
        /// <summary>
        /// Maps to "_value_date" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public DateTime ValueDate { get; set; }
        /// <summary>
        /// Maps to "_reference_number" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public string ReferenceNumber { get; set; }
        /// <summary>
        /// Maps to "_statement_reference" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public string StatementReference { get; set; }
        /// <summary>
        /// Maps to "_details" argument of the function "transactions.post_stock_journal".
        /// </summary>
        public MixERP.Net.Entities.Transactions.StockAdjustmentType[][] Details { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.post_stock_journal(_office_id integer, _user_id integer, _login_id bigint, _value_date date, _reference_number character varying, _statement_reference text, _details transactions.stock_adjustment_type[])" on the database.
        /// </summary>
        public PostStockJournalProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.post_stock_journal(_office_id integer, _user_id integer, _login_id bigint, _value_date date, _reference_number character varying, _statement_reference text, _details transactions.stock_adjustment_type[])" on the database.
        /// </summary>
        /// <param name="officeId">Enter argument value for "_office_id" parameter of the function "transactions.post_stock_journal".</param>
        /// <param name="userId">Enter argument value for "_user_id" parameter of the function "transactions.post_stock_journal".</param>
        /// <param name="loginId">Enter argument value for "_login_id" parameter of the function "transactions.post_stock_journal".</param>
        /// <param name="valueDate">Enter argument value for "_value_date" parameter of the function "transactions.post_stock_journal".</param>
        /// <param name="referenceNumber">Enter argument value for "_reference_number" parameter of the function "transactions.post_stock_journal".</param>
        /// <param name="statementReference">Enter argument value for "_statement_reference" parameter of the function "transactions.post_stock_journal".</param>
        /// <param name="details">Enter argument value for "_details" parameter of the function "transactions.post_stock_journal".</param>
        public PostStockJournalProcedure(int officeId, int userId, long loginId, DateTime valueDate, string referenceNumber, string statementReference, MixERP.Net.Entities.Transactions.StockAdjustmentType[][] details)
        {
            this.OfficeId = officeId;
            this.UserId = userId;
            this.LoginId = loginId;
            this.ValueDate = valueDate;
            this.ReferenceNumber = referenceNumber;
            this.StatementReference = statementReference;
            this.Details = details;
        }
        /// <summary>
        /// Prepares and executes the function "transactions.post_stock_journal".
        /// </summary>
        public long Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"PostStockJournalProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            const string query = "SELECT * FROM transactions.post_stock_journal(@0::integer, @1::integer, @2::bigint, @3::date, @4::character varying, @5::text, @6::transactions.stock_adjustment_type[]);";
            return Factory.Scalar<long>(this._Catalog, query, this.OfficeId, this.UserId, this.LoginId, this.ValueDate, this.ReferenceNumber, this.StatementReference, this.Details);
        }
    }
}