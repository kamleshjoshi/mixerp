<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EntityAccess.ascx.cs" Inherits="MixERP.Net.Core.Modules.BackOffice.Policy.EntityAccess" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = "Entity Access Policy";
    scrudFactory.description = "Create entity access policy for individual users. By default, users have right to access an entity if a menu acesss policy is granted. If a <a href='{0}'>default entity access policy</a> was created to restrict access to a group of users, you can still override that policy and provide access permission to a particular user.";
    scrudFactory.description = stringFormat(scrudFactory.description, "EntityAccess.mix");
    scrudFactory.viewPocoName = "EntityAccessScrudView";
    scrudFactory.formPocoName = "EntityAccess";
    scrudFactory.formTableName = "policy.entity_access";

    scrudFactory.allowDelete = true;
    scrudFactory.allowEdit = true;
    scrudFactory.excludedColumns = ["audit_user_id", "audit_ts"];

    scrudFactory.keys = [
        {
            property: "EntityName",
            url: '/Services/Modules/PocoService.asmx/GetPocos',
            data: null,
            isArray:true,
            valueField: "",
            textField: ""
        },
        {
            property: "AccessTypeId",
            url: '/Modules/BackOffice/Services/Policy/EntityAccess.asmx/GetAccessTypes',
            data: null,
            valueField: "AccessTypeId",
            textField: "AccessTypeName"
        },
        {
            property: "UserId",
            url: '/api/office/user-selector-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>

<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
