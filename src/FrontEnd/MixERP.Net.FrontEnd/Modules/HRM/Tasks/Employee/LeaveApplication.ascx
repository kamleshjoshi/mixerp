<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveApplication.ascx.cs" Inherits="MixERP.Net.Core.Modules.HRM.Tasks.Employee.LeaveApplication"
    OverridePath="/Modules/HRM/Tasks/Employees.mix" %>
<script>
    var scrudFactory = new Object();

    scrudFactory.title = "Leave Applications";

    scrudFactory.viewAPI = "/api/hrm/leave-application-scrud-view";
    scrudFactory.viewTableName = "hrm.leave_application_scrud_view";

    scrudFactory.formAPI = "/api/hrm/leave-application";
    scrudFactory.formTableName = "hrm.leave_applications";

    scrudFactory.excludedColumns = ["AuditUserId", "AuditTs"];
    scrudFactory.hiddenColumns = ["EnteredBy", "AppliedOn", "EmployeeId"];

    scrudFactory.live = "EmployeeId";

    scrudFactory.back = {
        Title: "Employee",
        Url: "/Modules/HRM/Tasks/EmployeeInfo.mix?EmployeeId=" + getQueryStringByName("EmployeeId")
    };

    scrudFactory.layout = [
        ["LeaveApplicationId", "LeaveTypeId", "", ""],
        ["StartDate", "EndDate", "", ""],
        ["Reason", ""]
    ];

    scrudFactory.keys = [
        {
            property: "LeaveTypeId",
            url: '/api/hrm/leave-type/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        },
        {
            property: "EmployeeId",
            url: '/api/hrm/employee-view/display-fields',
            data: null,
            valueField: "Key",
            textField: "Value"
        }
    ];
</script>


<div data-ng-include="'/Views/Modules/ViewFactory.html'"></div>
<div data-ng-include="'/Views/Modules/FormFactory.html'"></div>
<script>
    $(document).on("formready", function () {
        $("#applied_on").val(window.now);
        $("#entered_by").val(window.userId);
    });
</script>
