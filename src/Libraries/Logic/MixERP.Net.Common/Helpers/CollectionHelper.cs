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
using System.Collections.ObjectModel;

namespace MixERP.Net.Common.Helpers
{
    public static class CollectionHelper
    {
        public static Collection<T> ToCollection<T>(this List<T> items)
        {
            if (items == null)
            {
                return null;
            }


            Collection<T> collection = new Collection<T>();

            foreach (T t in items)
            {
                collection.Add(t);
            }

            return collection;
        }
    }
}