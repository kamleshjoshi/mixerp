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

namespace MixERP.Net.Messaging.Email
{
    public sealed class EmailMessage : IMessage
    {
        public string Subject { get; set; }
        public Type Type { get; set; }
        public DateTime EventDateUTC { get; set; }
        public Status Status { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string SentTo { get; set; }
        public string Message { get; set; }
    }
}