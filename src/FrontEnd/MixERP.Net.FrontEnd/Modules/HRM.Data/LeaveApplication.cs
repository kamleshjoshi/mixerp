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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MixERP.Net.DbFactory;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using Npgsql;
using PetaPoco;
using Serilog;

namespace MixERP.Net.Core.Modules.HRM.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "hrm.leave_applications".
    /// </summary>
    public class LeaveApplication : DbAccess
    {
        /// <summary>
        /// The schema of this table. Returns literal "hrm".
        /// </summary>
        public override string _ObjectNamespace => "hrm";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "leave_applications".
        /// </summary>
        public override string _ObjectName => "leave_applications";

        /// <summary>
        /// Login id of application user accessing this table.
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
        /// Performs SQL count on the table "hrm.leave_applications".
        /// </summary>
        /// <returns>Returns the number of rows of the table "hrm.leave_applications".</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long Count()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM hrm.leave_applications;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "hrm.leave_applications" to return a all instances of the "LeaveApplication" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "LeaveApplication" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.LeaveApplication> Get()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM hrm.leave_applications ORDER BY leave_application_id;";
            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "hrm.leave_applications" with a where filter on the column "leave_application_id" to return a single instance of the "LeaveApplication" class. 
        /// </summary>
        /// <param name="leaveApplicationId">The column "leave_application_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "LeaveApplication" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public MixERP.Net.Entities.HRM.LeaveApplication Get(long leaveApplicationId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"LeaveApplication\" filtered by \"LeaveApplicationId\" with value {LeaveApplicationId} was denied to the user with Login ID {_LoginId}", leaveApplicationId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM hrm.leave_applications WHERE leave_application_id=@0;";
            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql, leaveApplicationId).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "hrm.leave_applications" with a where filter on the column "leave_application_id" to return a multiple instances of the "LeaveApplication" class. 
        /// </summary>
        /// <param name="leaveApplicationIds">Array of column "leave_application_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "LeaveApplication" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.LeaveApplication> Get(long[] leaveApplicationIds)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. leaveApplicationIds: {leaveApplicationIds}.", this._LoginId, leaveApplicationIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM hrm.leave_applications WHERE leave_application_id IN (@0);";

            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql, leaveApplicationIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for hrm.leave_applications.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table hrm.leave_applications</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get custom fields for entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM core.custom_field_definition_view WHERE table_name='hrm.leave_applications' ORDER BY field_order;";
                return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from core.get_custom_field_definition('hrm.leave_applications'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of hrm.leave_applications.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table hrm.leave_applications</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            List<DisplayField> displayFields = new List<DisplayField>();

            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return displayFields;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT leave_application_id AS key, leave_application_id as value FROM hrm.leave_applications;";
            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                using (DataTable table = DbOperation.GetDataTable(this._Catalog, command))
                {
                    if (table?.Rows == null || table.Rows.Count == 0)
                    {
                        return displayFields;
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        if (row != null)
                        {
                            DisplayField displayField = new DisplayField
                            {
                                Key = row["key"].ToString(),
                                Value = row["value"].ToString()
                            };

                            displayFields.Add(displayField);
                        }
                    }
                }
            }

            return displayFields;
        }

        /// <summary>
        /// Inserts or updates the instance of LeaveApplication class on the database table "hrm.leave_applications".
        /// </summary>
        /// <param name="leaveApplication">The instance of "LeaveApplication" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(MixERP.Net.Entities.HRM.LeaveApplication leaveApplication, List<EntityParser.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            object primaryKeyValue;

            leaveApplication.AuditUserId = this._UserId;
            leaveApplication.EnteredBy = this._UserId;
            leaveApplication.AuditTs = System.DateTime.UtcNow;

            if (leaveApplication.LeaveApplicationId > 0)
            {
                primaryKeyValue = leaveApplication.LeaveApplicationId;
                this.Update(leaveApplication, leaveApplication.LeaveApplicationId);
            }
            else
            {
                primaryKeyValue = this.Add(leaveApplication);
            }

            string sql = "DELETE FROM core.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM core.custom_field_setup " +
                         "WHERE form_name=core.get_custom_field_form_name('hrm.leave_applications')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO core.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT core.get_custom_field_setup_id_by_table_name('hrm.leave_applications', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of LeaveApplication class on the database table "hrm.leave_applications".
        /// </summary>
        /// <param name="leaveApplication">The instance of "LeaveApplication" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(MixERP.Net.Entities.HRM.LeaveApplication leaveApplication)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. {LeaveApplication}", this._LoginId, leaveApplication);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, leaveApplication);
        }

        /// <summary>
        /// Inserts or updates multiple instances of LeaveApplication class on the database table "hrm.leave_applications";
        /// </summary>
        /// <param name="leaveApplications">List of "LeaveApplication" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<MixERP.Net.Entities.HRM.LeaveApplication> leaveApplications)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. {leaveApplications}", this._LoginId, leaveApplications);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            var result = new List<object>();
            int line = 0;
            try
            {
                using (Database db = new Database(Factory.GetConnectionString(this._Catalog), Factory.ProviderName))
                {
                    using (Transaction transaction = db.GetTransaction())
                    {
                        foreach (var leaveApplication in leaveApplications)
                        {
                            line++;

                            leaveApplication.AuditUserId = this._UserId;
                            leaveApplication.EnteredBy = this._UserId;
                            leaveApplication.AuditTs = System.DateTime.UtcNow;

                            if (leaveApplication.LeaveApplicationId > 0)
                            {
                                result.Add(leaveApplication.LeaveApplicationId);
                                db.Update(leaveApplication, leaveApplication.LeaveApplicationId);
                            }
                            else
                            {
                                result.Add(db.Insert(leaveApplication));
                            }
                        }

                        transaction.Complete();
                    }

                    return result;
                }
            }
            catch (NpgsqlException ex)
            {
                string errorMessage = $"Error on line {line} ";

                if (ex.Code.StartsWith("P"))
                {
                    errorMessage += Factory.GetDBErrorResource(ex);

                    throw new MixERPException(errorMessage, ex);
                }

                errorMessage += ex.Message;
                throw new MixERPException(errorMessage, ex);
            }
            catch (System.Exception ex)
            {
                string errorMessage = $"Error on line {line} ";
                throw new MixERPException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Updates the row of the table "hrm.leave_applications" with an instance of "LeaveApplication" class against the primary key value.
        /// </summary>
        /// <param name="leaveApplication">The instance of "LeaveApplication" class to update.</param>
        /// <param name="leaveApplicationId">The value of the column "leave_application_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(MixERP.Net.Entities.HRM.LeaveApplication leaveApplication, long leaveApplicationId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"LeaveApplication\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {LeaveApplication}", leaveApplicationId, this._LoginId, leaveApplication);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, leaveApplication, leaveApplicationId);
        }

        /// <summary>
        /// Deletes the row of the table "hrm.leave_applications" against the primary key value.
        /// </summary>
        /// <param name="leaveApplicationId">The value of the column "leave_application_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(long leaveApplicationId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"LeaveApplication\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", leaveApplicationId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM hrm.leave_applications WHERE leave_application_id=@0;";
            Factory.NonQuery(this._Catalog, sql, leaveApplicationId);
        }

        /// <summary>
        /// Performs a select statement on table "hrm.leave_applications" producing a paged result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "LeaveApplication" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.LeaveApplication> GetPagedResult()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM hrm.leave_applications ORDER BY leave_application_id LIMIT 10 OFFSET 0;";
            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "hrm.leave_applications" producing a paged result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paged result.</param>
        /// <returns>Returns collection of "LeaveApplication" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.LeaveApplication> GetPagedResult(long pageNumber)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM hrm.leave_applications ORDER BY leave_application_id LIMIT 10 OFFSET @0;";

            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql, offset);
        }

        private List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM core.filters WHERE object_name='hrm.leave_applications' AND lower(filter_name)=lower(@0);";
            return Factory.Get<EntityParser.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "hrm.leave_applications".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "LeaveApplication" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountWhere(List<EntityParser.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM hrm.leave_applications WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.HRM.LeaveApplication(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "hrm.leave_applications" producing a paged result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paged result.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "LeaveApplication" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.LeaveApplication> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM hrm.leave_applications WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.HRM.LeaveApplication(), filters);

            sql.OrderBy("leave_application_id");
            sql.Append("LIMIT @0", 10);
            sql.Append("OFFSET @0", offset);

            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "hrm.leave_applications".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "LeaveApplication" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountFiltered(string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM hrm.leave_applications WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.HRM.LeaveApplication(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "hrm.leave_applications" producing a paged result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paged result.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "LeaveApplication" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.LeaveApplication> GetFiltered(long pageNumber, string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"LeaveApplication\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM hrm.leave_applications WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.HRM.LeaveApplication(), filters);

            sql.OrderBy("leave_application_id");
            sql.Append("LIMIT @0", 10);
            sql.Append("OFFSET @0", offset);

            return Factory.Get<MixERP.Net.Entities.HRM.LeaveApplication>(this._Catalog, sql);
        }


    }
}