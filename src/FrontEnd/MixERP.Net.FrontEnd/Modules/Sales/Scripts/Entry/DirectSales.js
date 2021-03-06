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

/*jshint -W032*/
/*global getAjax, getAjaxErrorMessage, logError, saveButton, url:true, validateProductControl, errorLabelBottom, appendParameter, getData, valueDate, storeId, partyCode, priceTypeId, referenceNumber, data, statementReference, transactionType, agentId, shipperId, shippingAddressCode, shippingCharge, cashRepositoryId, costCenterId, transactionIds, attachments*/

if (typeof (saveButton) === "undefined") {
    saveButton = $("#SaveButton");
};

var save = function () {
    saveButton.addClass("loading");
    var ajaxsaveDirectSales = saveDirectSales(valueDate, storeId, partyCode, priceTypeId, referenceNumber, data, statementReference, transactionType, paymentTermId, salespersonId, shipperId, shippingAddressCode, shippingCharge, costCenterId, transactionIds, attachments, nonTaxable);

    ajaxsaveDirectSales.done(function (response) {
        var id = response.d;
        window.location = "/Modules/Sales/Confirmation/DirectSales.mix?TranId=" + id;
    });

    ajaxsaveDirectSales.fail(function (jqXHR) {
        saveButton.removeClass("loading");
        var errorMessage = getAjaxErrorMessage(jqXHR);
        errorLabelBottom.html(errorMessage);
        logError(errorMessage);
    });
};

var saveDirectSales = function (valueDate, storeId, partyCode, priceTypeId, referenceNumber, data, statementReference, transactionType, paymentTermId, salespersonId, shipperId, shippingAddressCode, shippingCharge, costCenterId, transactionIds, attachments, nonTaxable) {
    var d = "";
    d = appendParameter(d, "valueDate", valueDate);
    d = appendParameter(d, "storeId", storeId);
    d = appendParameter(d, "partyCode", partyCode);
    d = appendParameter(d, "priceTypeId", priceTypeId);
    d = appendParameter(d, "referenceNumber", referenceNumber);
    d = appendParameter(d, "data", data);
    d = appendParameter(d, "statementReference", statementReference);
    d = appendParameter(d, "transactionType", transactionType);
    d = appendParameter(d, "paymentTermId", paymentTermId);
    d = appendParameter(d, "salespersonId", salespersonId);
    d = appendParameter(d, "shipperId", shipperId);
    d = appendParameter(d, "shippingAddressCode", shippingAddressCode);
    d = appendParameter(d, "shippingCharge", shippingCharge);
    d = appendParameter(d, "costCenterId", costCenterId);
    d = appendParameter(d, "transactionIds", transactionIds);
    d = appendParameter(d, "attachmentsJSON", attachments);
    d = appendParameter(d, "nonTaxable", nonTaxable);

    d = getData(d);

    url = "/Modules/Sales/Services/Entry/DirectSales.asmx/Save";
    return getAjax(url, d);
};

saveButton.click(function () {
    if (validateProductControl()) {
        save();
    };
});

