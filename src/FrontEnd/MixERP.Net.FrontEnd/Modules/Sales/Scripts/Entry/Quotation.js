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
/*global getAjax, getAjaxErrorMessage, logError, saveButton, url:true, validateProductControl, errorLabelBottom, appendParameter, getData, valueDate, storeId, partyCode, priceTypeId, referenceNumber, data, statementReference, agentId, shipperId, shippingAddressCode, shippingCharge, cashRepositoryId, costCenterId, transactionIds, attachments*/

if (typeof (saveButton) === "undefined") {
    saveButton = $("#SaveButton");
};



saveButton.click(function() {
    if (validateProductControl()) {
        save();
    };
});

var save = function() {
    saveButton.addClass("loading");
    var ajaxSaveQuotation = saveQuotation(valueDate, storeId, partyCode, priceTypeId, referenceNumber, data, shippingAddressCode, shipperId, shippingCharge, costCenterId, salespersonId, statementReference, transactionIds, attachments, nonTaxable);

    ajaxSaveQuotation.done(function(response) {
        var id = response.d;
        window.location = "/Modules/Sales/Confirmation/Quotation.mix?TranId=" + id;
    });

    ajaxSaveQuotation.fail(function(jqXHR) {
        saveButton.removeClass("loading");
        var errorMessage = getAjaxErrorMessage(jqXHR);
        errorLabelBottom.html(errorMessage);
        logError(errorMessage);
    });
};

var saveQuotation = function(valueDate, storeId, partyCode, priceTypeId, referenceNumber, data, shippingAddressCode, shipperId, shippingCharge, costCenterId, salePersonId, statementReference, transactionIds, attachments, nonTaxable) {
    var d = "";
    d = appendParameter(d, "valueDate", valueDate);
    d = appendParameter(d, "storeId", storeId);
    d = appendParameter(d, "partyCode", partyCode);
    d = appendParameter(d, "priceTypeId", priceTypeId);
    d = appendParameter(d, "referenceNumber", referenceNumber);
    d = appendParameter(d, "data", data);
    d = appendParameter(d, "statementReference", statementReference);
    d = appendParameter(d, "transactionIds", transactionIds);
    d = appendParameter(d, "attachmentsJSON", attachments);
    d = appendParameter(d, "nonTaxable", nonTaxable);
    d = appendParameter(d, "salespersonId", salespersonId);
    d = appendParameter(d, "shipperId", shipperId);
    d = appendParameter(d, "shippingAddressCode", shippingAddressCode);

    d = getData(d);

    url = "/Modules/Sales/Services/Entry/Quotation.asmx/Save";
    return getAjax(url, d);
};
