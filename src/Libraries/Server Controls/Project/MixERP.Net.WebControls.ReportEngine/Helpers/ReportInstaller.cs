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

using MixERP.Net.WebControls.ReportEngine.Data;

namespace MixERP.Net.WebControls.ReportEngine.Helpers
{
    public static class ReportInstaller
    {
        public static void InstallReport(string catalog, string menuCode, string parentMenuCode, int level, string menuText, string path)
        {
            Installer.InstallReport(catalog, menuCode, parentMenuCode, level, menuText, path);
        }
    }
}