function LoadDataTable() {
    $.ajax({
        type: 'POST',
        url: '/Postlog/LoadPostlogList',
        datatype: 'json',
        success: function (data) {

            $('#dataTableId').DataTable({
                data: data.data,
                columns: [
                    {

                        data: "schedId"

                    },
                    {

                        data: "postLogId"

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

                        data: "weekNbr"

                    },
                ],
                columnDefs: [
                    {
                        targets: 0,
                        data: "schedId",
                    },
                    {

                        data: "postLogId"

                    },
                    {
                        targets: 1,
                        data: "scheduleName",
                    },
                    {
                        targets: 2,
                        data: "createDt",
                    },
                    {

                        data: "weekDate"

                    },
                    {

                        data: "weekNbr"

                    },
                ],
                paging: false,
                searching: true,
                info: false,
                ordering: false,
                autoWidth: false,
                dom: 'lrtip',
                scrollX: true,
                scrollCollapse: true,
            });
        }
    });
}

$(document).ready(function () {

    LoadDataTable();

});
