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

namespace MixERP.Net.Entities.Transactions.Models
{
    public sealed class ProductDetail
    {
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public string TaxCode { get; set; }
        public decimal Total { get; set; }
        public string Unit { get; set; }
    }
}