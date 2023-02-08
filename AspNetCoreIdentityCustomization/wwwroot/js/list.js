
$(document).ready(function () {
    alert("here");
    debugger
    var oTable = $('#dataTableId').dataTable({
        "bFilter": true,
        "language":
        {
            "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
        },
        "bProcessing": true,
        "serverSide": true,
        "sAjaxSource": ReportListurl,
        "aLengthMenu": [[2, 5, 10, -1], ["Two", "Five", "Ten", "All"]],
        "aoColumns": [
            { "mData": "PostLogId" },
            { "mData": "SchedId" },
            { "mData": "ScheduleName" },
            { "mData": "UpdateDt" },
            { "mData": "WeekNbr" },
            { "mData": "WeekDate" },
            { "mData": "CreateDt" }


        ]


    });
});

