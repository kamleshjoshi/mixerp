/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using System.Web;
using System.Web.SessionState;

namespace MixERP.Net.Common.Helpers
{
    public static class SessionHelper
    {
        public static void RemoveSessionKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            HttpSessionState session = HttpContext.Current.Session;

            if (session != null && session[key] != null)
            {
                session.Remove(key);
            }
        }

        public static void AddSessionKey(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            HttpSessionState session = HttpContext.Current.Session;
            if (session != null)
            {
                if (session[key] == null)
                {
                    session[key] = value;
                }
                else
                {
                    session.Add(key, value);
                }
            }
        }

        public static object GetSessionKey(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                HttpSessionState session = HttpContext.Current.Session;
                if (session != null && session[key] != null)
                {
                    return session[key];
                }
            }

            return null;
        }
    }
}