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

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Web.Script.Services;
using System.Web.Services;
using MixERP.Net.ApplicationState;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.Messaging.Email;
using Serilog;

namespace MixERP.Net.Core.Modules.Finance.Services.DayOperation
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class EOD : WebService
    {
        [WebMethod]
        public bool InitializeEODOperation()
        {
            try
            {
                if (!AppUsers.GetCurrent().View.IsAdmin.ToBool())
                {
                    return false;
                }


                int userId = AppUsers.GetCurrent().View.UserId.ToInt();
                int officeId = AppUsers.GetCurrent().View.OfficeId.ToInt();

                Data.EODOperation.Initialize(AppUsers.GetCurrentUserDB(), userId, officeId);
                this.ProcessEmailQueue();
                ForceLogOff(officeId);

                return true;
            }
            catch (Exception ex)
            {
                Log.Warning("Could not initialize eod operation. {Exception}", ex);
                throw;
            }
        }

        private void ProcessEmailQueue()
        {
            MailQueueManager manager = new MailQueueManager();
            manager.Catalog = AppUsers.GetCurrentUserDB();

            ThreadPool.QueueUserWorkItem(async callback => { await manager.ProcessMailQueueAsync(); });
        }

        [WebMethod]
        public void StartNewDay()
        {
            try
            {
                SuggestDateReload();
            }
            catch (Exception ex)
            {
                Log.Warning("Could not start a new day. {Exception}", ex);
                throw;
            }
        }

        private static void ForceLogOff(int officeId)
        {
            Collection<FrequencyDates> applicationDates = Dates.GetFrequencyDates(AppUsers.GetCurrentUserDB());
            DateTime forcedLogOffOn = DateTime.Now.AddMinutes(2);

            if (applicationDates != null)
            {
                FrequencyDates model = applicationDates.FirstOrDefault(c => c.OfficeId.Equals(officeId));

                if (model != null)
                {
                    FrequencyDates item = model.Clone() as FrequencyDates;
                    if (item != null)
                    {
                        item.ForcedLogOffTimestamp = forcedLogOffOn;
                        item.NewDayStarted = false;

                        applicationDates.Add(item);
                        applicationDates.Remove(model);
                    }


                    Dates.SetApplicationDates(AppUsers.GetCurrentUserDB(), applicationDates);
                }
            }
        }

        private static void SuggestDateReload()
        {
            int officeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            Collection<FrequencyDates> applicationDates = Dates.GetFrequencyDates(AppUsers.GetCurrentUserDB());

            if (applicationDates != null)
            {
                FrequencyDates model = applicationDates.FirstOrDefault(c => c.OfficeId.Equals(officeId));
                if (model != null)
                {
                    FrequencyDates item = model.Clone() as FrequencyDates;
                    if (item != null)
                    {
                        item.NewDayStarted = true;

                        applicationDates.Add(item);
                        applicationDates.Remove(model);
                    }


                    Dates.SetApplicationDates(AppUsers.GetCurrentUserDB(), applicationDates);
                }
            }
        }
    }
}