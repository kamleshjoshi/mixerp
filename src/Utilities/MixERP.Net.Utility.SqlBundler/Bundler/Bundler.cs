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

using MixERP.Net.Utility.SqlBundler.Helpers;
using MixERP.Net.Utility.SqlBundler.Models;
using System.Collections.ObjectModel;

namespace MixERP.Net.Utility.SqlBundler
{
    public static class Bundler
    {
        public static void Bundle(string root, Collection<string> files, bool includeOptionalFiles, bool includeSample)
        {
            foreach (string file in files)
            {
                BundlerModel model = Parser.Parse(root, file, includeOptionalFiles, includeSample);
                if (model == null)
                {
                    return;
                }

                Collection<SQLBundle> bundles = Processor.Process(root, model);

                if (bundles == null)
                {
                    return;
                }

                IOHelper.WriteBundles(root, bundles);
            }
        }
    }
}