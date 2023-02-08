


    $(document).ready(function () {
        $("#example").DataTable({
            "processing": true, // for show progress bar    
            "serverSide": true, // for process server side    
            "filter": true, // this is for disable filter (search box)    
            "orderMulti": false, // for disable multiple column at once    
            "ajax": {
                "url": "/Postlog/LoadPostlogList",
                "type": "POST",
                "datatype": "json"
            },
            "columnDefs": [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
            "columns": [
                { "data": "PostLogID", "name": "PostLogID", "autoWidth": true },
                { "data": "SchedId  ", "name": "SchedId  ", "autoWidth": true },
                { "data": "ScheduleName", "name": "ScheduleName", "autoWidth": true },
                { "data": "WeekNbr", "name": "WeekNbr", "autoWidth": true },
                { "data": "WeekDate", "name": "WeekDate", "autoWidth": true },
                { "data": "CreateDt", "name": "CreateDt", "autoWidth": true },
                { "data": "UpdateDt", "name": "UpdateDt", "autoWidth": true }
                
            ]

        });
    });



HandleMappingLoad = function (sourceData) {
    alert("HandleMappingLoad");
    usersTable = $('#postLogDataTable').DataTable({
        data: sourceData,
        destroy: true,
        "pgeLength": 20,
        "columns": [

            { "data": "PostLogId", "sClass": "dtTableCellNowrap" },
            { "data": "PostLogId", "sClass": "dtTableCellNowrap" },




            { "data": "SchedId", "sClass": "dtTableCellNowrap" },
            { "data": "ScheduleName", "sClass": "dtTableCellNowrap" },
            { "data": "WeekNbr", "sClass": "dtTableCellNowrap" },
            { "data": "WeekDate", "sClass": "dtTableCellNowrap" },
            { "data": "CreateDt", "sClass": "dtTableCellNowrap" },
            { "data": "UpdateDt", "sClass": "dtTableCellNowrap" }
        ]
    });
               
               
        //usersTable = $('#postLogDataTable').DataTable({
        //    data: sourceData,
        //    destroy: true,
        //    "pgeLength": 20,
        //    //"bLengthChange": false, //thought this line could hide the LengthMenu
        //    //"bInfo": false,
        //    "order": [], //Initial no order.
        //    "columns": [
        //        {
        //            //  Checkbox for editing multiple records
        //            "mRender": function (data, type, row) {
        //                return '<input type="checkbox" class="clsedit" id="chkSelect_' + row.PostLogId + '"></a>';
        //            }, orderable: false
        //        },

        //        {   // Edit button for editing single recor
        //            "mRender": function (data, type, row) {
        //                return '<a class="fa fa-edit fa-2x" title="Edit" onclick="PopupMappingDetails(' + row.PostLogId + ')" href="javascript:void(0);" id="Edit" ></a>';
        //            }, orderable: false
        //        },
        //        //{
        //        //    "mRender": function (data, type, row) {
        //        //        var html = "";
        //        //        // checkbox is checked if the report is included
        //        //        if (row.include_In_Reporting === true) {
        //        //            html = '<input type="checkbox" id="chkExclude_' + row.PostLogId + '" checked  disabled></a>';
        //        //        }
        //        //        else {
        //        //            html = '<input type="checkbox" id="chkExclude_' + row.PostLogId + '" disabled></a>';
        //        //        }
        //        //        return html;
        //        //    }, orderable: false
        //        //},
        //        { "data": "SchedId", "sClass": "dtTableCellNowrap" },
        //        { "data": "ScheduleName", "sClass": "dtTableCellNowrap" },
        //        { "data": "WeekNbr", "sClass": "dtTableCellNowrap" },

        //        {
        //            "data": "WeekDate", "mRender": function (data, type, row) {
        //                return moment(data).format("YYYY-MM-DD");
        //            }, "sClass": "dtTableCellNowrap"
        //        }
        //        ,
        //        {
        //            "data": "CreateDt", "mRender": function (data, type, row) {
        //                if (data !== null && data !== undefined && data !== "") {
        //                    return moment(data).format("YYYY-MM-DD");
        //                }
        //                else {
        //                    return "";
        //                }
        //            }, "sClass": "dtTableCellNowrap"
        //        },

        //        {
        //            "data": "UpdateDt", "mRender": function (data, type, row) {
        //                if (data !== null && data !== undefined && data !== "") {
        //                    return moment(data).format("YYYY-MM-DD");
        //                }
        //                else {
        //                    return "";
        //                }
        //            }, "sClass": "dtTableCellNowrap"
        //        }


        //    ],
        //    columnDefs: [
        //        { "orderable": false, "targets": 0 } //, render: $.fn.dataTable.render.ellipsis(13)
        //    ],
        //    //"lengthMenu": ["All",20, 40, 60, 100, 500],
        //    "lengthMenu": [[-1, 10, 25, 50, 100, 500], ["All", 10, 25, 50, 100, 500]],
        //    //"bPaginate": false,
        //    //"bLengthChange": false,
        //    language: {
        //        emptyTable: "No Records to Display",
        //        processing: '<i class="fa fa-spinner fa-spin fa-2x" style="z-index:999;backgroundColor:transparent;color: #24b6e0;border:0px solid rgb(170, 170, 170)"></i> '
        //    },
        //    "fnCreatedRow": function (tr, trData, iDataIndex) {
        //        //alert(trData.claritas_SBMS_Id);
        //        if (trData.include_In_Reporting === true) {
        //            $("#chkExclude_" + trData.claritas_SBMS_Id + "").prop("checked", true);
        //        }
        //        $(tr).attr('id', "tr_" + trData.claritas_SBMS_Id);
        //    },
        //    "autoWidth": false,
        //    searching: true,
        //    processing: true,
        //    serverSide: false,
        //    "scrollY": 500,
        //    "scrollX": true,
        //    scrollCollapse: true,
        //    "fnInitComplete": function (oSettings, json) {
        //        var btn = $('#btnSearch');
        //        btn.html(btn.data('original-text'));
        //    },
        //    "bInfo": false,
        //    "drawCallback": function (settings) {
        //    },
        //    initComplete: function (settings, json) {
        //        // Setting up the table body minimum heigth
        //        $(".dataTables_scrollBody").css("min-height", "500px");
        //    }

        //});
}


