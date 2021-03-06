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
using MixERP.Net.Framework;
using MixERP.Net.Entities.Transactions;
using MixERP.Net.Schemas.Transactions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;
namespace MixERP.Net.Api.Transactions
{
    /// <summary>
    /// Provides a direct HTTP access to execute the function GetJournalView.
    /// </summary>
    [RoutePrefix("api/v1.5/transactions/procedures/get-journal-view")]
    public class GetJournalViewController : ApiController
    {
        /// <summary>
        /// Login id of application user accessing this API.
        /// </summary>
        public long _LoginId { get; set; }

        /// <summary>
        /// User id of application user accessing this API.
        /// </summary>
        public int _UserId { get; set; }

        /// <summary>
        /// Currently logged in office id of application user accessing this API.
        /// </summary>
        public int _OfficeId { get; set; }

        /// <summary>
        /// The name of the database where queries are being executed on.
        /// </summary>
        public string _Catalog { get; set; }

        private GetJournalViewProcedure procedure;
        public class Annotation
        {
            public int UserId { get; set; }
            public int OfficeId { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public long TranId { get; set; }
            public string TranCode { get; set; }
            public string Book { get; set; }
            public string ReferenceNumber { get; set; }
            public string StatementReference { get; set; }
            public string PostedBy { get; set; }
            public string Office { get; set; }
            public string Status { get; set; }
            public string VerifiedBy { get; set; }
            public string Reason { get; set; }
        }

        public GetJournalViewController()
        {
            this._LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this._UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this._OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this._Catalog = AppUsers.GetCurrentUserDB();
            this.procedure = new GetJournalViewProcedure
            {
                _Catalog = this._Catalog,
                _LoginId = this._LoginId,
                _UserId = this._UserId
            };
        }

        [AcceptVerbs("POST")]
        [Route("execute")]
        [Route("~/api/transactions/procedures/get-journal-view/execute")]
        public IEnumerable<DbGetJournalViewResult> Execute([FromBody] Annotation annotation)
        {
            try
            {
                this.procedure.UserId = annotation.UserId;
                this.procedure.OfficeId = annotation.OfficeId;
                this.procedure.From = annotation.From;
                this.procedure.To = annotation.To;
                this.procedure.TranId = annotation.TranId;
                this.procedure.TranCode = annotation.TranCode;
                this.procedure.Book = annotation.Book;
                this.procedure.ReferenceNumber = annotation.ReferenceNumber;
                this.procedure.StatementReference = annotation.StatementReference;
                this.procedure.PostedBy = annotation.PostedBy;
                this.procedure.Office = annotation.Office;
                this.procedure.Status = annotation.Status;
                this.procedure.VerifiedBy = annotation.VerifiedBy;
                this.procedure.Reason = annotation.Reason;

                return this.procedure.Execute();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch (MixERPException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}