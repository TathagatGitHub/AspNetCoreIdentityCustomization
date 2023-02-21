$(document).ready(function () {
    
   /* function LoadPostlogList() {*/
    alert("ok");
    loadPostlogList();
    //OnSuccess();
    //$.ajax({
    //    url: "/Postlog/LoadPostlogList",
    //    type: "GET",
    //    dataType: "json",
    //    success: function (result) { debugger }
    //});
        //$.ajax({
        //    url: "/Postlog/LoadPostlogList", dataType: "json", success: function (result) {
        //        debugger
        //    }
        //});
            //$.ajax({
            //    type: "GET",
            //    URL: "/Postlog/LoadPostlogList",
            //    dataType: "json",
            //    success: function (response) { debugger }
            //});



       /* })*/
 /*   }*/

   
});
function loadPostlogList() {
    alert("inside loadPostlogList");
    $.ajax({
        url: "/Postlog/LoadPostlogList",
        type: "GET",
        dataType: "json",
        //success: OnSuccess//function (data) {            OnSuccess(data.data);             debugger         }
        success: function (data) {
            debugger


            usersTable = $("#dataTableId").dataTable({
               
                
                data: data.data,
        columns: [
                    
                    {

                        data: "postLogId"

                    },
                    {

                        data: "schedId"

                    },
                    {

                        data: "scheduleName"

                    },
                    {

                        data: "createDt"

                    },
                    {

                        data: "weekDate"

            },
            {

                data: "UpdateDt"

            },
                    {

                        data: "weekNbr"

                    },
                ],
                columnDefs: [
                    
                    {
                        targets: 0,
                        data: "postLogId"

                    },
                    {
                        targets: 1,
                        data: "schedId",
                    },
                    {
                        targets: 2,
                        data: "scheduleName",
                    },
                    {
                        targets: 3,
                        data: "createDt",
                    },
                    {
                        targets: 4,
                        data: "weekDate"

                    },
                    {
                        targets: 5,
                        data: "UpdateDt"

                    },
                    {
                        targets: 6,
                        data: "weekNbr"

                    },



                ],
                paging: false,
                searching: true,
                info: false,
                ordering: false,
                autoWidth: false,
                dom: 'lrtip',




            });



        }
    });
}
var OnSuccess = function (response) {
    /* do something here */
  
   
//function OnSuccess(response) {
    alert("inside OnSuccess");
    ///start
   usersTable= $("#dataTableId").dataTable({
        bProcessing: true,
        bLengthChange: false,
        lengthMenu: [[2, 5, 10, -1], ["Two", "Five", "Ten", "All"]],
        bfilter: true,
        bsort: true,
        bPaginate: true,
        datatype: 'json',
        data: response,
        columns: [
            {
                
                data: 'CreateDt',
                

            },
            {
                target: 1,
                data: 'PostLogId',
                render: function (data, type, row, meta) {
                    if (type === 'display') {

                        return row.PostLogId
                    }
                }

            },
            {
                target: 2,
                data: 'SchedId',
                render: function (data, type, row, meta) {
                    if (type === 'display') {
                        return row.SchedId
                    }
                    
                }

            },
            {
                target: 3,
                data: 'ScheduleName',
                render: function (data, type, row, meta) {
                    return row.ScheduleName
                }

            },
            {
                target: 4,
                data: 'UpdateDt',
                render: function (data, type, row, meta) {
                    return row.UpdateDt
                }

            },
            {
                target: 5,
                data: 'WeekNbr',
                render: function (data, type, row, meta) {
                    return row.WeekNbr
                }

            },
            {
                target: 6,
                data: 'WeekDate',
                render: function (data, type, row, meta) {
                    return row.WeekDate
                }

            }
            
            

       ],
       columnsDefs: [
           {
               target: 0,
               data: 'CreateDt',
               

           },
           {
               target: 1,
               data: 'PostLogId',
               render: function (data, type, row, meta) {
                   if (type === 'display') {

                       return row.PostLogId
                   }
               }

           },
           {
               target: 2,
               data: 'SchedId',
               render: function (data, type, row, meta) {
                   if (type === 'display') {
                       return row.SchedId
                   }

               }

           },
           {
               target: 3,
               data: 'ScheduleName',
               render: function (data, type, row, meta) {
                   return row.ScheduleName
               }

           },
           {
               target: 4,
               data: 'UpdateDt',
               render: function (data, type, row, meta) {
                   return row.UpdateDt
               }

           },
           {
               target: 5,
               data: 'WeekNbr',
               render: function (data, type, row, meta) {
                   return row.WeekNbr
               }

           },
           {
               target: 6,
               data: 'WeekDate',
               render: function (data, type, row, meta) {
                   return row.WeekDate
               }

           }



       ]

        


    });
    //end
}

//$("#dataTableId").DataTable({
//});



