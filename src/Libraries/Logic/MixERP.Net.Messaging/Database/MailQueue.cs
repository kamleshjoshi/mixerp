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
using MixERP.Net.Entities.Core;
using PetaPoco;

namespace MixERP.Net.Messaging.Email.Database
{
    internal static class MailQueue
    {
        public static void AddToQueue(string catalog, EmailQueue queue)
        {
            Factory.Insert(catalog, queue);
        }

        public static IEnumerable<EmailQueue> GetMailInQueue(string catlog)
        {
            const string sql = "SELECT * FROM core.email_queue WHERE NOT delivered AND NOT canceled;";
            return Factory.Get<EmailQueue>(catlog, sql);
        }
    }
}